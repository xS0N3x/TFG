using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool hasDoorUp;
    public bool hasDoorLeft;
    public bool hasDoorDown;
    public bool hasDoorRight;

    public bool hasWallUp;
    public bool hasWallLeft;
    public bool hasWallDown;
    public bool hasWallRight;

    public bool spawned = false;
    private float caso;

    public LevelGenerator levelGenerator;


    private void Start()
    {
        levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "SpawnPoint")
        {

            SpawnPoint point = other.GetComponent<SpawnPoint>();

            if (point.spawned)
            {
                Destroy(other.gameObject);
            }
            else {
                spawned = true;
            }

            if (point.hasDoorDown)
            {
                hasDoorDown = true;
            }
            if (point.hasDoorUp)
            {
                hasDoorUp = true;
            }
            if (point.hasDoorRight)
            {
                hasDoorRight = true;
            }
            if (point.hasDoorLeft)
            {
                hasDoorLeft = true;
            }
            if (point.hasWallUp)
            {
                hasWallUp = true;
            }
            if (point.hasWallDown)
            {
                hasWallDown = true;
            }
            if (point.hasWallRight)
            {
                hasWallRight = true;
            }
            if (point.hasWallLeft)
            {
                hasWallLeft = true;
            }     
        }
    }

    private void Update()
    {
        if (!spawned)
        {
            Invoke("SelectCase", 1);
        }

        /*if (!spawned && Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("SelectCase", 1);
        }*/
    }

    private void SpawnRoom() 
    {

        int rand;      

        switch (caso) 
        {
            case 1:
                rand = Random.Range(0, levelGenerator.upRooms.Length);
                Instantiate(levelGenerator.upRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 1.1f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 1.2f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 1.3f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 1.4f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 1.5f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 1.6f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 1.7f:
                Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //---------------------------------------------------------------------------------------------------//
            case 2:
                rand = Random.Range(0, levelGenerator.rightRooms.Length);
                Instantiate(levelGenerator.leftRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 2.1f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 2.2f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 2.3f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 2.4f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 2.5f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 2.6f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 2.7f:
                Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //----------------------------------------------------------------------------------------------//
            case 3:
                rand = Random.Range(0, levelGenerator.downRooms.Length);
                Instantiate(levelGenerator.downRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 3.1f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 3.2f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 3.3f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 3.4f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 3.5f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 3.6f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 3.7f:
                Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //-----------------------------------------------------------------------------------------------------//
            case 4:
                rand = Random.Range(0, levelGenerator.rightRooms.Length);
                Instantiate(levelGenerator.rightRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 4.1f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 4.2f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 4.3f:
                rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 2)
                {
                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 3)
                {
                    Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 4.4f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 4.5f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 4.6f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 4.7f:
                Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //----------------------------------------------------------------------------------------------------//
            case 5:
                rand = Random.Range(0, levelGenerator.upLeftRooms.Length);
                Instantiate(levelGenerator.upLeftRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 5.1f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 5.2f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 5.3f:
                Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //-----------------------------------------------------------------------------------------------//
            case 6:
                rand = Random.Range(0, levelGenerator.downLeftRooms.Length);
                Instantiate(levelGenerator.downLeftRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 6.1f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 6.2f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 6.3f:
                Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //----------------------------------------------------------------------------------------------------//
            case 7:
                rand = Random.Range(0, levelGenerator.downRightRooms.Length);
                Instantiate(levelGenerator.downRightRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 7.1f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 7.2f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 7.3f:
                Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //------------------------------------------------------------------------------------------------------------//
            case 8:
                rand = Random.Range(0, levelGenerator.upRightRooms.Length);
                Instantiate(levelGenerator.upRightRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 8.1f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 8.2f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 8.3f:
                Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //------------------------------------------------------------------------------------------------------//
            case 9:
                rand = Random.Range(0, levelGenerator.upDownRooms.Length);
                Instantiate(levelGenerator.upDownRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 9.1f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 9.2f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 9.3f:
                Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //-------------------------------------------------------------------------------------------------//
            case 10:
                rand = Random.Range(0, levelGenerator.leftRightRooms.Length);
                Instantiate(levelGenerator.leftRightRooms[rand], transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 10.1f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 10.2f:
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                else if (rand == 1)
                {
                    Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                    spawned = true; //Destroy(gameObject); 
                }
                break;
            case 10.3f:
                Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
                //-------------------------------------------------------------------------------------------------------//
            case 11:
                Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 12:
                Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 13:
                Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 14:
                Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;

        }
    }

    private void SpawnRoom2()
    {
        switch (caso)
        {
            case 1:
                Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 1.1f:
                Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 1.2f:
                Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 1.3f:
                Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 1.4f:
                Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 1.5f:
                Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 1.6f:
                Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 1.7f:
                Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //---------------------------------------------------------------------------------------------------//
            case 2:
                Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 2.1f:
                Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 2.2f:
                Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 2.3f:
                Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 2.4f:
                Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 2.5f:
                Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 2.6f:
                Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 2.7f:
                Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //----------------------------------------------------------------------------------------------//
            case 3:
                Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 3.1f:
                Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 3.2f:
                Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 3.3f:
                Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 3.4f:
                Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 3.5f:
                Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 3.6f:
                Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 3.7f:
                Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //-----------------------------------------------------------------------------------------------------//
            case 4:
                Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 4.1f:
                Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 4.2f:
                Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 4.3f:
                Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 4.4f:
                Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 4.5f:
                Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 4.6f:
                Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);
                break;
            case 4.7f:
                Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //----------------------------------------------------------------------------------------------------//
            case 5:
                Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 5.1f:
                Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 5.2f:
                Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 5.3f:
                Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //-----------------------------------------------------------------------------------------------//
            case 6:
                Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 6.1f:
                Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 6.2f:
                Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 6.3f:
                Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //----------------------------------------------------------------------------------------------------//
            case 7:
                Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 7.1f:
                Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 7.2f:
                Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 7.3f:
                Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //------------------------------------------------------------------------------------------------------------//
            case 8:
                Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 8.1f:
                Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 8.2f:
                Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 8.3f:
                Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //------------------------------------------------------------------------------------------------------//
            case 9:
                Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject);  
                break;
            case 9.1f:
                Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 9.2f:
                Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 9.3f:
                Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //-------------------------------------------------------------------------------------------------//
            case 10:
                Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 10.1f:
                Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 10.2f:
                Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 10.3f:
                Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            //-------------------------------------------------------------------------------------------------------//
            case 11:
                Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 12:
                Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 13:
                Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
            case 14:
                Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                spawned = true; //Destroy(gameObject); 
                break;
        }
    }

    private void SelectCase() 
    {
        if (hasDoorUp && !hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 1
        {
            caso = 1;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && !hasWallRight) //Caso 1.1
        {
            caso = 1.1f;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 1.2
        {
            caso = 1.2f;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && hasWallRight) //Caso 1.3
        {
            caso = 1.3f;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && hasWallLeft && hasWallDown && !hasWallRight) //Caso 1.4
        {
            caso = 1.4f;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && hasWallRight) //Caso 1.5
        {
            caso = 1.5f;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && hasWallRight) //Caso 1.6
        {
            caso = 1.6f;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && hasWallLeft && hasWallDown && hasWallRight) //Caso 1.7
        {
            caso = 1.7f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 2
        {
            caso = 2;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 2.1
        {
            caso = 2.1f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 2.2
        {
            caso = 2.2f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && hasWallRight) //Caso 2.3
        {
            caso = 2.3f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && hasWallRight) //Caso 2.4
        {
            caso = 2.4f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && hasWallUp && !hasWallLeft && !hasWallDown && hasWallRight) //Caso 2.5
        {
            caso = 2.5f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 2.6
        {
            caso = 2.6f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && hasWallUp && !hasWallLeft && hasWallDown && hasWallRight) //Caso 2.7
        {
            caso = 2.7f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 3
        {
            caso = 3;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 3.1
        {
            caso = 3.1f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && !hasWallRight) //Caso 3.2
        {
            caso = 3.2f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && hasWallRight) //Caso 3.3
        {
            caso = 3.3f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && hasWallUp && hasWallLeft && !hasWallDown && !hasWallRight) //Caso 3.4
        {
            caso = 3.4f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && hasWallUp && !hasWallLeft && !hasWallDown && hasWallRight) //Caso 3.5
        {
            caso = 3.5f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && hasWallRight) //Caso 3.6
        {
            caso = 3.6f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 3.7
        {
            caso = 3.7f;
        }
        else if (!hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 4
        {
            caso = 4;
        }
        else if (!hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 4.1
        {
            caso = 4.1f;
        }
        else if (!hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && !hasWallRight) //Caso 4.2
        {
            caso = 4.2f;
        }
        else if (!hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 4.3
        {
            caso = 4.3f;
        }
        else if (!hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && hasWallUp && hasWallLeft && !hasWallDown && !hasWallRight) //Caso 4.4
        {
            caso = 4.4f;
        }
        else if (!hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && hasWallLeft && hasWallDown && !hasWallRight) //Caso 4.5
        {
            caso = 4.5f;
        }
        else if (!hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 4.6
        {
            caso = 4.6f;
        }
        else if (!hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && hasWallUp && hasWallLeft && hasWallDown && !hasWallRight) //Caso 4.7
        {
            caso = 4.7f;
        }
        else if (hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 5
        {
            caso = 5;
        }
        else if (hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 5.1
        {
            caso = 5.1f;
        }
        else if (hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && hasWallRight) //Caso 5.2
        {
            caso = 5.2f;
        }
        else if (hasDoorUp && hasDoorLeft && !hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && hasWallRight) //Caso 5.3
        {
            caso = 5.3f;
        }
        else if (!hasDoorUp && hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 6
        {
            caso = 6;
        }
        else if (!hasDoorUp && hasDoorLeft && hasDoorDown && !hasDoorRight && hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 6.1
        {
            caso = 6.1f;
        }
        else if (!hasDoorUp && hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && hasWallRight) //Caso 6.2
        {
            caso = 6.2f;
        }
        else if (!hasDoorUp && hasDoorLeft && hasDoorDown && !hasDoorRight && hasWallUp && !hasWallLeft && !hasWallDown && hasWallRight) //Caso 6.3
        {
            caso = 6.3f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 7
        {
            caso = 7;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && hasDoorRight && hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 7.1
        {
            caso = 7.1f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && !hasWallRight) //Caso 7.2
        {
            caso = 7.2f;
        }
        else if (!hasDoorUp && !hasDoorLeft && hasDoorDown && hasDoorRight && hasWallUp && hasWallLeft && !hasWallDown && !hasWallRight) //Caso 7.3
        {
            caso = 7.3f;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 8
        {
            caso = 8;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && !hasWallRight) //Caso 8.1
        {
            caso = 8.1f;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 8.2
        {
            caso = 8.2f;
        }
        else if (hasDoorUp && !hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && hasWallRight) //Caso 8.3
        {
            caso = 8.3f;
        }
        else if (hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 9
        {
            caso = 9;
        }
        else if (hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && !hasWallRight) //Caso 9.1
        {
            caso = 9.1f;
        }
        else if (hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && hasWallRight) //Caso 9.2
        {
            caso = 9.2f;
        }
        else if (hasDoorUp && !hasDoorLeft && hasDoorDown && !hasDoorRight && !hasWallUp && hasWallLeft && !hasWallDown && hasWallRight) //Caso 9.3
        {
            caso = 9.3f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 10
        {
            caso = 10;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && hasDoorRight && hasWallUp && !hasWallLeft && !hasWallDown && !hasWallRight) //Caso 10.1
        {
            caso = 10.1f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && hasDoorRight && !hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 10.2
        {
            caso = 10.2f;
        }
        else if (!hasDoorUp && hasDoorLeft && !hasDoorDown && hasDoorRight && hasWallUp && !hasWallLeft && hasWallDown && !hasWallRight) //Caso 10.3
        {
            caso = 10.3f;
        }
        else if (hasDoorUp && hasDoorLeft && hasDoorDown && !hasDoorRight) //Caso 11
        {
            caso = 11;
        }
        else if (!hasDoorUp && hasDoorLeft && hasDoorDown && hasDoorRight) //Caso 12
        {
            caso = 12;
        }
        else if (hasDoorUp && !hasDoorLeft && hasDoorDown && hasDoorRight) //Caso 13
        {
            caso = 13;
        }
        else if (hasDoorUp && hasDoorLeft && !hasDoorDown && hasDoorRight) //Caso 14
        {
            caso = 14;
        }
        else  //Caso 0
        {
            caso = 0;
        }

        if (levelGenerator.rooms.Count <= 15)
        {
            SpawnRoom();
        }
        else {
            SpawnRoom2();
        }
        
    }
}
