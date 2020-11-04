using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private LevelTemplates templates;

    void Strart()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<LevelTemplates>();
    }

    void Update()
    {
        if(openingDirection == 1)
        {

        }   
        else if(openingDirection == 2)
        {

        }
        else if (openingDirection == 3)
        {

        }
        else if (openingDirection == 4)
        {

        }
    }
}
