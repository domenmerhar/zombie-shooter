using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform ShootingPoint;

    private float bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Shoot(bulletForce);
        }
    }

    private void Shoot(float force)
    {
        GameObject bullet = Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(ShootingPoint.right * force, ForceMode2D.Impulse);
        
    }
}
