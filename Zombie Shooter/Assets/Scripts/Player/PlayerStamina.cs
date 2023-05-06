using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private Image staminaBar;
    public float stamina = 100;

    public void ChangeStamina(float changeAmount)
    {
        stamina += changeAmount;
        if (stamina > 100) stamina = 100;
    }

    private void Update()
    {
        staminaBar.fillAmount = Mathf.MoveTowards(staminaBar.fillAmount, stamina / 100,  2 * Time.deltaTime);
    }
}
