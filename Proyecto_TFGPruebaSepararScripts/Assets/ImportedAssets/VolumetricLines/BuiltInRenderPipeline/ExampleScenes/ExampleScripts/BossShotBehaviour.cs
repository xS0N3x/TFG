using UnityEngine;
using System.Collections;

public class BossShotBehaviour : MonoBehaviour
{

	private GameObject player;
	private Vector3 direction;
	private Quaternion rotation;
	public float damage;
	public float shootSpeed;
	public EnemyController enemyController;
	public GameObject particlesPrefab;


	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
		enemyController = GameObject.Find("Boss").GetComponent<EnemyController>();
		damage = enemyController.enemyData.shotDamage;
		direction = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
		rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
		Destroy(gameObject, 2f);
	}

	// Update is called once per frame
	void Update()
	{
		transform.position += direction.normalized * shootSpeed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.transform.parent.GetComponent<PlayerHealth>().TakeDamage(damage);
			Instantiate(particlesPrefab, transform.position, rotation);
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.transform.tag == "Obstacle")
		{
			Instantiate(particlesPrefab, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}


}
