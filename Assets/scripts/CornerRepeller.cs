using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerRepeller : MonoBehaviour
{
    public float pushForce = 7f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.attachedRigidbody;
            if (rb != null)
            {
                Vector3 pushDir = (other.transform.position - transform.position).normalized;
                pushDir.y = 0f; // не толкать вверх

                rb.AddForce(pushDir * pushForce, ForceMode.VelocityChange);
            }
        }
    }
}
