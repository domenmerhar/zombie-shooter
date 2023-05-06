using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Zombie"))
        {
            DamageZombie(collision);
        }
    }

    private void DamageZombie(Collider2D collision)
    {
        Zombie zombieScript = collision.GetComponent<Zombie>();
        zombieScript.health -= damage;

        if (zombieScript.health <= 0)
        {
            Destroy(collision.gameObject);
        }
    }
}
