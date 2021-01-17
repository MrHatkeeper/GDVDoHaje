using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class projectiePlayer : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player") || !collision.collider.CompareTag("sword"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || !collision.CompareTag("sword"))
        {
            Destroy(gameObject);
        }
    }

}
