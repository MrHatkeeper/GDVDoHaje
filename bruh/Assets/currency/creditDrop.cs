using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditDrop : MonoBehaviour
{

    public GameObject coin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            Instantiate(coin, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
