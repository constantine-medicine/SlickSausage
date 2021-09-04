using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Sausage : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private float powerImpulse;
    [SerializeField][Range(10f, 80f)] private float pullingForce;
    [SerializeField] private BlankEvent onShotEvent;
    [SerializeField] private BlankEvent gameOverEvent;

    [SerializeField] private bool isGround;
    public bool IsGround { get => isGround; }

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        isGround = true;
    }

    private void Update()
    {
        onShotEvent.Listeners += Shot;
    }

    private void Shot()
    {
        Vector3 directionXZ = inputHandler.StartTouchPosition - inputHandler.EndTouchPosition;
        var magnitude = directionXZ.magnitude;
        if (magnitude > 40f)
        {
            var direction = new Vector3(directionXZ.x, 120f, directionXZ.z);
            rigidbody.AddForce(direction * powerImpulse, ForceMode.Impulse);
        }
        if(magnitude > 0 && magnitude < 40f)
        {
            var direction = new Vector3(directionXZ.x, magnitude + pullingForce, directionXZ.z);
            rigidbody.AddForce(direction * powerImpulse, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) isGround = true;
        else isGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundDead"))
            gameOverEvent.Raise();
    }
}
