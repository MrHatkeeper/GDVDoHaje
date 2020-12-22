using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoots : MonoBehaviour
{

    public Transform firePoint;
    public GameObject projectile;

    public float bulletSpeed;


    private float timeBtwShots;
    public float startTimeBtwShots;

    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
