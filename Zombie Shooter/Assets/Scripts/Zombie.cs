using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameObject player;

    private float speed = 2f;
    private float walkSpeed = 2f;
    private Vector3 distance;

    private Rigidbody2D rb;

    private float sprintSpeed = 4f;
    private float sprintDuration = 1f;
    private float sprintCooldown = 5f;
    private float sprintTimer = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

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
            rb.velocity = distance.normalized * speed;
        }
    }
}
