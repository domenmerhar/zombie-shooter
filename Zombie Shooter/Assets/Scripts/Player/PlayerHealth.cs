using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private float health = 100;

    public void ChangeHealth(float changeAmount)
    {
        health += changeAmount;
        if (health > 100) health = 100;
    }
    private void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, health / 100,  2 * Time.deltaTime);
    }
}