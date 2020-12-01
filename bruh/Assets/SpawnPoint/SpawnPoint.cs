using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public GameObject[] enemies;
    private GameObject[] spawnPoints;



    private float aktValue;
    private float passedRoomsPlayer;
    private float enemy;
    private int point;


    private passedRooms passedRooms;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        passedRooms = GameObject.FindGameObjectWithTag("Player").GetComponent<passedRooms>();

        passedRoomsPlayer = passedRooms.finalPassRooms;
        aktValue = passedRooms.finalPassRooms;



        while (0 <= aktValue)
        {

            enemy = Mathf.FloorToInt(Random.Range(0, (0))); //později přepsat na aktValue
            point = Random.Range(0, spawnPoints.Length);


            if (enemy <= 4)
            {
                Instantiate(enemies[0], spawnPoints[point].transform.position, spawnPoints[point].transform.rotation, transform.parent);
                aktValue -= 1;
            }
            else if (enemy <= 8 && enemy >= 5)
            {
                Instantiate(enemies[1], spawnPoints[point].transform.position, spawnPoints[point].transform.rotation, transform.parent);
                aktValue -= 5;
            }
            else if (enemy >= 9)
            {
                Instantiate(enemies[2], spawnPoints[point].transform.position, spawnPoints[point].transform.rotation, transform.parent);
                aktValue -= 10;
            }
        }
    }
}
