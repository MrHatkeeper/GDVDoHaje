using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public GameObject[] enemies;
    private GameObject[] spawnPoints;
    private GameObject[] missedCoins;




    private float aktValue;
    private float passedRoomsPlayer;
    private float enemy;
    private int point;


    private passedRooms passedRooms;

    // Start is called before the first frame update
    public void SpawnEnemy()
    {
        missedCoins = GameObject.FindGameObjectsWithTag("Coin");

        for(int i = 0; i < missedCoins.Length; i++)
        {
            Destroy(missedCoins[i].gameObject);
        }

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");


        passedRooms = GameObject.FindGameObjectWithTag("Player").GetComponent<passedRooms>();

        passedRoomsPlayer = passedRooms.finalPassRooms;
        aktValue = passedRooms.finalPassRooms;


        while (0 <= aktValue)
        {

            enemy = Mathf.FloorToInt(Random.Range(0, (aktValue))); 
            point = Random.Range(0, spawnPoints.Length);


            if (enemy <= 4)
            {
                Instantiate(enemies[0], spawnPoints[point].transform.position, spawnPoints[point].transform.rotation);
                aktValue -= 1;
            }
            else if (enemy <= 8 && enemy >= 5)
            {
                Instantiate(enemies[1], spawnPoints[point].transform.position, spawnPoints[point].transform.rotation);
                aktValue -= 5;
            }
            else if (enemy >= 9)
            {
                Instantiate(enemies[1], spawnPoints[point].transform.position, spawnPoints[point].transform.rotation);//přepsat na enemies[2]
                aktValue -= 1;//přepsat na -10
            }
        }


        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Destroy(spawnPoints[i].gameObject);
        }
    }
}
