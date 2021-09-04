using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRigidbody : MonoBehaviour
{
    [SerializeField] private SpringJoint connecter;

    private void OnCollisionEnter(Collision collision)
    {
        connecter.connectedBody = null;
    }
}
