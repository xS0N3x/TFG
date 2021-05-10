using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBuilder : MonoBehaviour
{
    public NavMeshSurface surface;
    public GameObject map;
    public bool canBuild;

    // Start is called before the first frame update
    void Start()
    {
        canBuild = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuild) 
        {
            map = GameObject.Find("Map");
            surface = map.GetComponent<NavMeshSurface>();
            surface.BuildNavMesh();
            canBuild = false;
        }
    }

}
