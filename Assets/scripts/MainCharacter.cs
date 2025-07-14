using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    // ��������� ��� ������
    [SerializeField] float movementSpeed = 5f;
    float currentSpeed;
    // ���� ������
    [SerializeField] float jumpForce = 7f;
    bool isGrounded = true;
    Rigidbody rb;
    Vector3 direction;

    void Start()
    {
        // ��������� � ����������� ���������� Rigidbody
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // ���������� �������
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    void FixedUpdate()
    {
        // ������� ��� ������
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }
}