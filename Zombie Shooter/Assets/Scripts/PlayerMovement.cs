using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 3f;
    [SerializeField] private float sprintingSpeed = 5f;
    private float speed = 3f;
    private Vector2 direction;

    private bool isDashing = false;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        ManageSprint();
        ManageDash();
    }

    private void FixedUpdate()
    {
        if(!isDashing)
            rigidBody.MovePosition(rigidBody.position + direction.normalized * Time.deltaTime * speed);
        else
        {
            rigidBody.MovePosition(rigidBody.position + direction.normalized * Time.deltaTime * walkingSpeed * 10);
            isDashing = false;
        }
    }

    private void ManageSprint()
    {
        if (!isDashing)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                speed = sprintingSpeed;
            else
                speed = walkingSpeed;
        }
    }

    private void ManageDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashing = true;
        }
    }
}