using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditDrop : MonoBehaviour
{

    public GameObject coin;

    public int coinCount ;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for(int i = 0; i < coinCount; i++)
        {
            if (collision.collider.CompareTag("Projectile"))
            {
                Instantiate(coin, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < coinCount; i++)
        {
            if (collision.CompareTag("Projectile"))
            {
                Instantiate(coin, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

}
