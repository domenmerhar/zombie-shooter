using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI grenadeCounter;
    private int grenades = 3;

    public void AddGrenades(int toAdd)
    {
        grenades += toAdd;
        grenadeCounter.text = grenades.ToString() + "x";
    }
}
