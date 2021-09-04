using UnityEngine;

public class FollowToObject : MonoBehaviour
{
    [SerializeField] private Transform followObject;

    private Vector3 deltaPossition;

    private void Start()
    {
        deltaPossition = followObject.position - transform.position;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = followObject.position - deltaPossition;
    }
}
