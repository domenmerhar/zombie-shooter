using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealthScript;
    [SerializeField] private PlayerInventory playerInventoryScript;

    private float invincibilityDuration = 0.25f;
    private float invincibilityTimer = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Grenade"))
        {
            playerInventoryScript.AddGrenades(1);
            Destroy(collision.gameObject, .4f);

            collision.GetComponent<Animator>().SetBool("isPicked", true);
        }
        else if (collision.CompareTag("Health"))
        {
            playerHealthScript.ChangeHealth(10f);
            Destroy(collision.gameObject, .4f);

            collision.GetComponent<Animator>().SetBool("isPicked", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie") && invincibilityTimer >= invincibilityDuration)
        {
            playerHealthScript.ChangeHealth(-(collision.gameObject.GetComponent<Zombie>().damage));
            invincibilityTimer = 0f;
        }
    }

    private void FixedUpdate()
    {
        invincibilityTimer += Time.deltaTime;
    }
}
