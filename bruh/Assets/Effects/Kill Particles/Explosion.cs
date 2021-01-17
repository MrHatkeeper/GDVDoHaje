using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public Transform sparkle;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Projectile"))
        {
            Instantiate(sparkle, transform.position, sparkle.transform.rotation, transform.parent);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Projectile"))
        {
            Instantiate(sparkle, transform.position, sparkle.transform.rotation, transform.parent);
        }
    }

}
