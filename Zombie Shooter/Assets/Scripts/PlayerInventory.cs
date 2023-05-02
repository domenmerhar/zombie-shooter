using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int grenades = 3;

    public void AddGrenades(int toAdd)
    {
        grenades += toAdd;
    }
}
