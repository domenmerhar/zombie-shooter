using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform ShootingPoint;

    private float bulletForce = 20f;

    private float shootCooldown = 0.1f;
    private float shootTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && shootTimer >= shootCooldown)
        {
            Shoot(bulletForce);
            shootTimer = 0;
        }
        else
        {
            shootTimer += Time.deltaTime;
        }
    }

    private void Shoot(float force)
    {
        GameObject bullet = Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(ShootingPoint.right * force, ForceMode2D.Impulse);
        Destroy(bullet, .25f);
    }
}
