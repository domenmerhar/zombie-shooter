using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 3f;
    [SerializeField] private float sprintingSpeed = 5f;
    private float speed = 3f;
    private Vector2 direction;

    private bool isDashing = false;
    private float dashCooldown = 3f;
    private float dashTimer = 1.5f;

    private Rigidbody2D rigidBody;
    [SerializeField] private new Camera camera;

    [SerializeField] PlayerStamina playerStaminaScript;

    Vector2 mousePosition;

    [Header("Stamina Options")]
    [SerializeField] private float staminaRecovery;
    [SerializeField] private float staminaDrain;
    [SerializeField] private float dashStaminaDrain = 20;

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

        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rigidBody.MovePosition(rigidBody.position + direction.normalized * Time.deltaTime * speed);

            StaminaRegen();
        }
        else //When dashing
        {
            if (playerStaminaScript.stamina > dashStaminaDrain)
            {
                rigidBody.MovePosition(rigidBody.position + direction.normalized * Time.deltaTime * walkingSpeed * 10);
                playerStaminaScript.ChangeStamina(dashStaminaDrain);
            }
            isDashing = false;
        }
        RotatePlayer();
    }
    
    private void StaminaRegen()
    {
        if (speed < sprintingSpeed) //Triggers when walking
        {
            playerStaminaScript.ChangeStamina(staminaRecovery);
        }
        else if (speed >= sprintingSpeed)//Triggers when sprinting
        {
            playerStaminaScript.ChangeStamina(staminaDrain);
        }
    }

    private void ManageSprint()
    {
        if (!isDashing)
        {
            if (Input.GetKey(KeyCode.LeftShift) && playerStaminaScript.stamina > 0)
                speed = sprintingSpeed;
            else
                speed = walkingSpeed;
        }
    }

    private void ManageDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashTimer >= dashCooldown && playerStaminaScript.stamina >= dashStaminaDrain)
        {
            isDashing = true;
            dashTimer = 0;
        }
        else
        {
            dashTimer += Time.deltaTime;
        }
    }

    private void RotatePlayer()
    {
        Vector2 lookDirection = mousePosition - rigidBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rigidBody.rotation = angle;
    }
}
