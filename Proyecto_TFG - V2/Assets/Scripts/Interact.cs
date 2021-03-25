using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    Color[] colors = {Color.red, Color.blue, Color.white, Color.black, Color.green, Color.yellow};

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Interact")) 
            {
                //Destroy(gameObject);
                gameObject.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
            }
        }
    }
}
