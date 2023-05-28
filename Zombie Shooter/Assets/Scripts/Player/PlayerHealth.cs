using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private float health = 100;

    [SerializeField] private Transform playerTransform;

    public void ChangeHealth(float changeAmount)
    {
        health += changeAmount;
        if (health > 100) health = 100;
    }
    private void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, health / 100,  2 * Time.deltaTime);
        
        if(health <= 0)
        {
            OnDeath();
            health = 100;
        }
    }

    private void OnDeath()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");

        foreach(GameObject zombie in zombies) 
        { 
            Destroy(zombie);
        }

        TeleportPlayer(new Vector3(0, 0, 0));
    }

    private void TeleportPlayer(Vector3 position)
    {
        playerTransform.position = position;
    }
}
