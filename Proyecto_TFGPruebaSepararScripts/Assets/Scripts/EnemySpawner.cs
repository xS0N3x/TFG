using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> rooms;
    public List<bool> waveRooms;
    public bool canSpawn;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            for (int i = 0; i < rooms.Count; i++) 
            {
                if (waveRooms[i]) 
                {
                    Instantiate(enemyPrefab, rooms[i].transform);
                }
            }
            canSpawn = false;
        }
    }

}
