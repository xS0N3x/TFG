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

    public LevelGenerator levelGenerator;

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "SpawnPoint")
        {
            SpawnPoint point = other.GetComponent<SpawnPoint>();

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

            Destroy(other.gameObject);

        }

        /*if (other.transform.tag == "Room") 
        {
            Destroy(other.gameObject);
        }*/

    }

    private void Update()
    {
        if (!spawned)
        {
            Invoke("SpawnRoom", 1);
        }
        
        /*if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SpawnRoom();
        }*/
    }

    private void SpawnRoom() {
        int rand;

        if (hasDoorUp)
        {
            if (hasDoorLeft)
            {
                if (hasDoorRight) //Has door Up & Left & Right
                {
                    //Caso 1
                    Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                else if (hasDoorDown)//Has door Up & Left & Down
                {
                    //Caso 2
                    Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                else //Has door Up & Left 
                {

                    if (hasWallDown)
                    {
                        if (hasWallLeft)
                        {
                            //Caso 5.3   
                            Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                            Destroy(gameObject);
                        }
                        else
                        {
                            //Caso 5.1
                            rand = Random.Range(0, 2);
                            if (rand < 1) 
                            {
                                Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                            else
                            {
                                Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                        }
                    }
                    else
                    {
                        if (hasWallLeft)
                        {
                            //Caso 5.2 
                            rand = Random.Range(0, 2);
                            if (rand < 1)
                            {
                                Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                            else
                            {
                                Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                        }
                        else 
                        {
                            //Caso 5
                            rand = Random.Range(0, levelGenerator.upLeftRooms.Length);
                            Instantiate(levelGenerator.upLeftRooms[rand], transform.position, Quaternion.identity);
                            Destroy(gameObject);
                        }
                    }
                }
            }
            else
            {
                if (hasDoorRight)
                {
                    if (hasDoorDown)//Has door Up & Right & Down
                    {
                        //Caso 4
                        Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else //Has door Up & Right 
                    {
                        if (hasWallLeft)
                        {
                            if (hasWallDown)
                            {
                                //Caso 7.3
                                Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                            else
                            {
                                //Caso 7.2
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                        }
                        else {
                            if (hasWallDown)
                            {
                                //Caso 7.1
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.upLeftRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                            else
                            {
                                //Caso 7
                                rand = Random.Range(0, levelGenerator.upRightRooms.Length);
                                Instantiate(levelGenerator.upRightRooms[rand], transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                        }

                        
                    }

                }
                else
                {
                    if (hasDoorDown) //Has door Up & Down
                    {
                        if (hasWallLeft)
                        {
                            if (hasWallRight)
                            {
                                //Caso 6.3
                                Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                            else 
                            {
                                //Caso 6.2
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                        }
                        else
                        {
                            if (hasWallRight)
                            {
                                //Caso 6.1
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                            else
                            {
                                //Caso 6
                                rand = Random.Range(0, levelGenerator.upDownRooms.Length);
                                Instantiate(levelGenerator.upDownRooms[rand], transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                        }
                    }
                    else //Has door Up
                    {
                        if (hasWallLeft) 
                        {
                            if (hasWallRight)
                            {
                                if (hasWallDown) 
                                {
                                    //Caso 11.1
                                    Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    //Caso 11.2
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    { 
                                        Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                            else
                            {
                                if (hasWallDown)
                                {
                                    //Caso 11.3
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                                else
                                {
                                    //Caso 11.6
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (hasWallRight)
                            {
                                if (hasWallDown)
                                {
                                    //Caso 11.4
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.upRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                                else
                                {
                                    //Caso 11.7
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                            else
                            {
                                if (hasWallDown)
                                {
                                    //Caso 11.5
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                                else
                                {
                                    //Caso 11
                                    rand = Random.Range(0, levelGenerator.upRooms.Length);
                                    Instantiate(levelGenerator.upRooms[rand], transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (hasDoorLeft)
            {
                if (hasDoorRight)
                {
                    if (hasDoorDown) //Has door Left & Right & Down
                    {
                        //Caso 3
                        Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    else //Has door Left & Right
                    {
                        if (hasWallUp)
                        {
                            if (hasWallDown)
                            {
                                //Caso 8.3
                                Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                            else
                            {
                                //Caso 8.2
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                        }
                        else 
                        {
                            if (hasWallDown)
                            {
                                //Caso 8.1
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                            else
                            {
                                //Caso 8
                                rand = Random.Range(0, levelGenerator.leftRightRooms.Length);
                                Instantiate(levelGenerator.leftRightRooms[rand], transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                        }
                    }
                }
                else
                {
                    if (hasDoorDown) //Has door Down & Left
                    {
                        if (hasWallUp)
                        {
                            if (hasWallRight)
                            {
                                //Caso 10.3
                                Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                            else
                            {
                                //Caso 10.1
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                        }
                        else 
                        {
                            if (hasWallRight)
                            {
                                //Caso 10.2
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.upLeftDownRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                            else
                            {
                                //Caso 10
                                rand = Random.Range(0, levelGenerator.downLeftRooms.Length);
                                Instantiate(levelGenerator.downLeftRooms[rand], transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                        }
                    }
                    else //Has door Left 
                    {
                        if (hasWallUp)
                        {
                            if (hasWallRight)
                            {
                                if (hasWallDown)
                                {
                                    //Caso 12.1
                                    Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    //Caso 12.2
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                            else
                            {
                                if (hasWallDown)
                                {
                                    //Caso 12.3
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                                else
                                {
                                    //Caso 12.6
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (hasWallRight)
                            {
                                if (hasWallDown)
                                {
                                    //Caso 12.4
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.leftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                                else
                                {
                                    //Caso 12.7
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                            else
                            {
                                if (hasWallDown)
                                {
                                    //Caso 12.5
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.upLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                                else
                                {
                                    //Caso 12
                                    rand = Random.Range(0, levelGenerator.leftRooms.Length);
                                    Instantiate(levelGenerator.leftRooms[rand], transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (hasDoorRight)
                {
                    if (hasDoorDown) //Has door Right & Down
                    {
                        if (hasWallUp) 
                        {
                            if (hasWallLeft)
                            {
                                //Caso 9.3
                                Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                            else
                            {
                                //Caso9.1
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.downLeftRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                        }
                        else
                        {
                            if (hasWallLeft)
                            {
                                //Caso 9.2
                                rand = Random.Range(0, 2);
                                if (rand < 1)
                                {
                                    Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    Instantiate(levelGenerator.upDownRightRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                            else
                            {
                                //Caso 9
                                rand = Random.Range(0, levelGenerator.downRightRooms.Length);
                                Instantiate(levelGenerator.downRightRooms[rand], transform.position, Quaternion.identity);
                                Destroy(gameObject);
                            }
                        }
                    }
                    else // Has door Right
                    {
                        if (hasDoorDown) //Has door Down
                        {
                            if (hasWallUp)
                            {
                                if (hasWallLeft)
                                {
                                    if (hasWallDown)
                                    {
                                        //Caso 14.1
                                        Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        //Caso 14.2
                                        rand = Random.Range(0, 2);
                                        if (rand < 1)
                                        {
                                            Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                        else
                                        {
                                            Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                    }
                                }
                                else
                                {
                                    if (hasWallDown)
                                    {
                                        //Caso 14.4
                                        rand = Random.Range(0, 2);
                                        if (rand < 1)
                                        {
                                            Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                        else
                                        {
                                            Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                    }
                                    else
                                    {
                                        //Caso 14.5
                                        rand = Random.Range(0, 2);
                                        if (rand < 1)
                                        {
                                            Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                        else
                                        {
                                            Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (hasWallLeft)
                                {
                                    if (hasWallDown)
                                    {
                                        //Caso 14.3
                                        rand = Random.Range(0, 2);
                                        if (rand < 1)
                                        {
                                            Instantiate(levelGenerator.rightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                        else
                                        {
                                            Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                    }
                                    else
                                    {
                                        //Caso 14.6
                                        rand = Random.Range(0, 2);
                                        if (rand < 1)
                                        {
                                            Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                        else
                                        {
                                            Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                    }
                                }
                                else
                                {
                                    if (hasWallDown)
                                    {
                                        //Caso 14.7
                                        rand = Random.Range(0, 2);
                                        if (rand < 1)
                                        {
                                            Instantiate(levelGenerator.upRightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                        else
                                        {
                                            Instantiate(levelGenerator.leftRightRoom, transform.position, Quaternion.identity);
                                            Destroy(gameObject);
                                        }
                                    }
                                    else
                                    {
                                        //Caso 14
                                        rand = Random.Range(0, levelGenerator.rightRooms.Length);
                                        Instantiate(levelGenerator.rightRooms[rand], transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (hasDoorDown) //Has door Down
                    {
                        if (hasWallUp)
                        {
                            if (hasWallRight)
                            {
                                if (hasWallLeft)
                                {
                                    //Caso 13.1
                                    Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    //Caso 13.4
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                            else
                            {
                                if (hasWallLeft)
                                {
                                    //Caso 13.3
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                                else
                                {
                                    //Caso 13.6
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.downRightRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (hasWallRight)
                            {
                                if (hasWallLeft)
                                {
                                    //Caso 13.2
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.downRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                                else
                                {
                                    //Caso 13.7
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.downLeftRooms[rand], transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                            }
                            else
                            {
                                if (hasWallLeft)
                                {
                                    //Caso 13.5
                                    rand = Random.Range(0, 2);
                                    if (rand < 1)
                                    {
                                        Instantiate(levelGenerator.upDownRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                    else
                                    {
                                        Instantiate(levelGenerator.downLeftRoom, transform.position, Quaternion.identity);
                                        Destroy(gameObject);
                                    }
                                }
                                else
                                {
                                    //Caso 13
                                    rand = Random.Range(0, levelGenerator.downRooms.Length);
                                    Instantiate(levelGenerator.downRooms[rand], transform.position, Quaternion.identity);
                                    Destroy(gameObject);
                                }
                            }
                        }
                    }
                    else
                    {
                        //No hay nada
                        //Destroy(gameObject);
                    }
                }
            }
        }
    }
}
