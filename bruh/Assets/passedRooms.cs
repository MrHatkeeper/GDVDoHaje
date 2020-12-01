using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passedRooms : MonoBehaviour
{

    public float passRooms;
    public float finalPassRooms;

    void Start()
    {
        passRooms = 4;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Door"))
        {   
            finalPassRooms = Mathf.FloorToInt(passRooms + (passRooms * 0.3333f));
            passRooms = finalPassRooms;
        }
    }

}
