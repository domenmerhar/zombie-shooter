using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, this.transform.position.z);
    }
}
