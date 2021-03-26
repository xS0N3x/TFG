using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelGenerator levelGenerator = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
        levelGenerator.rooms.Add(gameObject);
    }

}
