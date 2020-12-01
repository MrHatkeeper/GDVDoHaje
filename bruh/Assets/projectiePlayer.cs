using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class projectiePlayer : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
