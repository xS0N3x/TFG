using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	private GameObject player;
	private Vector3 direction;
	public float damage;
	public float shootSpeed;
	public PlayerController playerController;
	

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerController = player.GetComponent<PlayerController>();
		damage = playerController.damage;
		direction = player.transform.forward;
		Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction.normalized * shootSpeed * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Enemy") 
		{
			other.gameObject.transform.parent.GetComponent<HealthController>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
