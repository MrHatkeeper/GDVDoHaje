using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class projectiePlayer : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
