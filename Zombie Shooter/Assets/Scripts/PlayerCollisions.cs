using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealthScript;

    private float invincibilityDuration = 0.5f;
    private float invincibilityTimer = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Grenade"))
        {
            this.gameObject.GetComponent<PlayerInventory>().AddGrenades(1);
            Destroy(collision.gameObject, .4f);

            collision.GetComponent<Animator>().SetBool("isPicked", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie") && invincibilityTimer >= invincibilityDuration)
        {
            playerHealthScript.DamagePlayer(collision.gameObject.GetComponent<Zombie>().damage);
            invincibilityTimer = 0f;
        }
    }

    private void FixedUpdate()
    {
        invincibilityTimer += Time.deltaTime;
    }
}
