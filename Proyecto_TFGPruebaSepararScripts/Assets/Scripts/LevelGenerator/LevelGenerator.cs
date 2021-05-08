using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{

    public GameObject emptyRoom;
    public GameObject startRoom;

    public List<GameObject> rooms;

    [HideInInspector] public EnemySpawner enemySpawner;
    [HideInInspector] public NavMeshBuilder navMeshBuilder;

    public GameObject[] upRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] downRooms;

    public GameObject[] upLeftRooms;
    public GameObject[] upRightRooms;
    public GameObject[] downLeftRooms;
    public GameObject[] downRightRooms;
    public GameObject[] upDownRooms;
    public GameObject[] leftRightRooms;

    public GameObject upLeftDownRoom;
    public GameObject upLeftRightRoom;
    public GameObject upDownRightRoom;
    public GameObject downLeftRightRoom;

    public GameObject upLeftRoom;
    public GameObject upRightRoom;
    public GameObject downLeftRoom;
    public GameObject downRightRoom;
    public GameObject upDownRoom;
    public GameObject leftRightRoom;

    public GameObject upRoom;
    public GameObject leftRoom;
    public GameObject downRoom;
    public GameObject rightRoom;

    public GameObject bossShape;
    public GameObject smallShape;
    public GameObject bigShape;
    public GameObject midShape;
    public GameObject midShape2;

    private GameObject map;

    public GameObject player;
    public GameObject virtualCamera;

    public GameObject canvas;

    private bool spawnedPlayer = false;

    private bool finished;

    private void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        navMeshBuilder = GameObject.Find("NavMeshBuilder").GetComponent<NavMeshBuilder>();
        map = GameObject.Find("Map");
        //Instantiate(startRoom, transform.position, Quaternion.identity);
        Invoke("SpawnShapes", 9f);
        Invoke("ConstructMap", 10f);
    }

    private void SpawnShapes() 
    {
        GameObject shape;

        for (int i = 1; i < rooms.Count; i++) 
        {
            if (i != rooms.Count - 1)
            {

                int rand = Random.Range(0, 100);

                if (rand < 5)
                {
                    shape = Instantiate(bigShape, rooms[i].transform.position, Quaternion.identity);
                    shape.transform.SetParent(map.transform);
                }
                else if (rand < 15) 
                {
                    shape = Instantiate(midShape, rooms[i].transform.position, Quaternion.identity);
                    shape.transform.SetParent(map.transform);
                }
                else if (rand < 25)
                {
                    shape = Instantiate(midShape2, rooms[i].transform.position, Quaternion.identity);
                    shape.transform.SetParent(map.transform);
                }
                else if (rand < 30)
                {
                    shape = Instantiate(smallShape, rooms[i].transform.position, Quaternion.identity);
                    shape.transform.SetParent(map.transform);
                }

            }
            else 
            {
                shape = Instantiate(bossShape, rooms[i].transform.position, Quaternion.identity);
                shape.transform.SetParent(map.transform);
            }
        }
    }

    private void ConstructMap() 
    {
        foreach (GameObject room in rooms)
        {
            room.transform.SetParent(map.transform);
            room.transform.Find("Destroyer").gameObject.SetActive(false);
        }

        finished = true;
    }

    private void SpawnPlayer() 
    {
        if (!spawnedPlayer) 
        {
            spawnedPlayer = true;
            player = Instantiate(player, rooms[0].transform.position + (Vector3.up/10), Quaternion.identity);
            player.name = "Player";
            virtualCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = player.transform;
        }
        //player.SetActive(true);
        
    }

    private void Update()
    {
        if (finished) 
        {
            enemySpawner.rooms = rooms;
            
            for (int i = 0; i < enemySpawner.rooms.Count; i++) 
            {
                int dice = Random.Range(0, 100);

                if (i == 0) 
                {
                    enemySpawner.waveRooms.Add(false);
                }
                else if (i == enemySpawner.rooms.Count - 1)
                {
                    enemySpawner.waveRooms.Add(true);
                }
                else if (dice < 50)
                {
                    enemySpawner.waveRooms.Add(true);
                }
                else
                {
                    enemySpawner.waveRooms.Add(false);
                }
            }

            enemySpawner.canSpawn = true;
            navMeshBuilder.canBuild = true;
            SpawnPlayer();
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
