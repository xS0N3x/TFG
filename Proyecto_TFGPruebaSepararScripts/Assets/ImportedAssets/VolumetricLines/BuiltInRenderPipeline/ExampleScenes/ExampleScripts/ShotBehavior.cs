﻿using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	private GameObject player;
	private Vector3 direction;
	public float damage;
	public float shootSpeed;
	public PlayerController playerController;
	public GameObject particlesPrefab;
	

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerController = player.GetComponent<PlayerController>();
		damage = playerController.playerData.shotDamage;
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
			HealthController hc = other.gameObject.transform.parent.GetComponent<HealthController>();
			if (!hc.dodging)
			{
				hc.TakeDamage(damage);
				Instantiate(particlesPrefab, transform.position, transform.rotation);
				Destroy(gameObject);
			}
			
		}

		if (other.tag == "Boss")
		{
			HealthController hc = other.gameObject.transform.parent.GetComponent<HealthController>();
			if (!hc.dodging)
			{
				hc.BossTakeDamage(damage);
				Instantiate(particlesPrefab, transform.position, transform.rotation);
				Destroy(gameObject);
			}

		}
	}

    private void OnCollisionEnter(Collision collision)
    {

		if (collision.transform.tag == "Obstacle" || collision.transform.tag == "Shield")
		{
			Instantiate(particlesPrefab, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}


}
