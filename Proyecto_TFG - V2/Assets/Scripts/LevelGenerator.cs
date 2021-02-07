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

    private void Start()
    {
        Instantiate(startRoom, transform.position, Quaternion.identity);
    }


}
