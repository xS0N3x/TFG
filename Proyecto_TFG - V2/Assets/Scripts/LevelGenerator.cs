using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject emptyRoom;
    public GameObject startRoom;

    public List<GameObject> rooms;

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

    private bool spawnedPlayer = false;

    private bool finished;

    private void Start()
    {
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
            player = Instantiate(player, rooms[0].transform.position, Quaternion.identity);
            player.name = "Player";
            virtualCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = player.transform;
        }
        //player.SetActive(true);
        
    }

    private void Update()
    {
        if (finished) 
        {   
            SpawnPlayer();
            Destroy(gameObject);
        }
    }
}
