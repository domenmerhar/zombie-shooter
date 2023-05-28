using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameObject player;
    private Camera playerCamera;

    public float damage;

    private float speed = 2.5f;
    private float walkSpeed = 2f;
    private Vector3 distance;

    private Rigidbody2D rb;

    private float sprintSpeed = 4f;
    private float sprintDuration = 1f;
    private float sprintCooldown = 5f;
    private float sprintTimer = 6f;

    private Vector2 lookDirection;

    public float health = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        playerCamera = Camera.main;

        damage = UnityEngine.Random.Range(8f, 12f);
        speed = UnityEngine.Random.Range(speed * .80f, speed * 1.20f);
        walkSpeed = UnityEngine.Random.Range(speed * .80f, speed * 1.20f);
    }

    private void FixedUpdate()
    {
        if(player.activeInHierarchy)
        {
            if (sprintTimer >= sprintCooldown)
            {
                speed = sprintSpeed;
                sprintTimer = 0f;
            }
            else
            {
                sprintTimer += Time.deltaTime;
            }
            if (sprintTimer > sprintDuration)
            {
                speed = walkSpeed;
            }

            distance = player.transform.position - rb.transform.position;

            if (IsOnScreen(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0)))
            {
                rb.velocity = distance.normalized * speed;
            }
            else
            {
                rb.velocity = distance.normalized * speed * 1.5f;
            }
            lookDirection = this.gameObject.transform.position - player.transform.position;
            this.rb.rotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
        }
    }
    
    private bool IsOnScreen(Vector3 postion)
    {
        Vector3 screenPosition = playerCamera.WorldToViewportPoint(postion);
        return (screenPosition.x >= 0 && screenPosition.x <= 1 && screenPosition.y >= 0 && screenPosition.y <= 1);
    }
}
