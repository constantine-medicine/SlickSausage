using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private BlankEvent onShotEvent;
    [SerializeField] private Sausage sausage;

    private Vector3 startTouchPosition;
    private Vector3 endTouchPosition;

    private bool isTouch;

    public Vector3 StartTouchPosition { get => startTouchPosition; }
    public Vector3 EndTouchPosition { get => endTouchPosition; }

    private void Update()
    {
       if (sausage.IsGround)
            Touch();
    }

    private Vector3 SetPosittion()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.collider.CompareTag("Toucher"))
        {
            return hit.point;
        }
        else return new Vector3(0f, 0f, 0f);
    }

    private void Touch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
            startTouchPosition = SetPosittion();
        }
        if (Input.GetMouseButtonUp(0) && isTouch)
        {
            endTouchPosition = SetPosittion();
            var direction = startTouchPosition - endTouchPosition;
            isTouch = false;
            onShotEvent.Raise();
        }
    }
}
