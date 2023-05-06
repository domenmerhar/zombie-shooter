using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private int health = 100;

    public void DamagePlayer(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100;
    }

    public void HealPlayer(int heal)
    {
        health += heal;
        healthBar.fillAmount = health / 100;
    }
}
