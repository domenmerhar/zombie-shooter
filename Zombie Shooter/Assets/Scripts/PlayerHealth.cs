using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private float health = 100;

    public void DamagePlayer(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100;
    }

    public void HealPlayer(float heal)
    {
        health += heal;
        healthBar.fillAmount = health / 100;
    }

    private void Update()
    {
        Debug.Log(health / 100);
    }
}
