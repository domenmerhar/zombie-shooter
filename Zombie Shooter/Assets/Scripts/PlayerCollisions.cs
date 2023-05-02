using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Grenade"))
        {
            this.gameObject.GetComponent<PlayerInventory>().AddGrenades(1);
            Destroy(collision.gameObject);
        }
    }
}
