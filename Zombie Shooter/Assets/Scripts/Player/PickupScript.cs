using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public Animator pickupAnimator;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();    
    }
}
