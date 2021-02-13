using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	private GameObject player;
	private Vector3 direction;

	public float shootSpeed;
	

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		direction = player.transform.forward;
		Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction.normalized * shootSpeed * Time.deltaTime;
	}


}
