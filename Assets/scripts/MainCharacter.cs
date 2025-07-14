using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    // перемение для ходьбы
    [SerializeField] float movementSpeed = 5f;
    float currentSpeed;
    // сила прыжка
    [SerializeField] float jumpForce = 7f;
    bool isGrounded = true;
    Rigidbody rb;
    Vector3 direction;

    void Start()
    {
        // получение и подключение компонента Rigidbody
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // управление ходьбой
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
        // расчёты для ходьбы
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }
}