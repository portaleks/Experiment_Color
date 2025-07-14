using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPush : MonoBehaviour
{

    public float pushForce = 5f;
    // Start is called before the first frame update
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.rigidbody;
            if (rb != null)
            {

                // ��������� ����������� �� ����� � ������
                Vector3 pushDir = collision.transform.position - transform.position;
                pushDir.y = 0f; // �� ������ �����
                pushDir.Normalize();
                // ��������� ������������
                rb.AddForce(pushDir * pushForce, ForceMode.VelocityChange);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
