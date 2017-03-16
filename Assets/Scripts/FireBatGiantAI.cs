using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FireBatGiantAI : MonoBehaviour {
	//https://docs.unity3d.com/Manual/nav-AgentPatrol.html 7-8 63-71
	public Transform[] points;
	private int destPoint = 0;
	NavMeshAgent agent;
	public Transform player1;
	public Transform player2;
	public float attackInterval;
	public GameObject batProjectilePrefab;
	public Transform batProjectileSpawn;
	public float batProjectileSpeed;
	public Transform originalTransform;
	bool shooting;

	float lastShot = 0;
	private bool isQuitting = false;
	public bool isLoading = false;
	public bool isRestarting = false;
	public GameObject loot;

	// Use this for initialization
	void Start () {
		shooting = true;
		originalTransform = gameObject.transform;
		agent = GetComponent<NavMeshAgent>();
		GotoNextPatrolPoint();
	}

	// Update is called once per frame
	void Update() {
		var heading = player1.position - transform.position;
		var distance = heading.magnitude;
		var direction = heading / distance;
		RaycastHit hit;
		Ray ray = new Ray(transform.position, direction);
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.tag == "Player" && distance < 15)
			{
				agent.Stop();
				transform.LookAt(player1.position);
				Fire();
				shooting = true;
			}
			else
			{
				shooting = false;
				transform.transform.rotation = new Quaternion(0.0f, -1.0f, 0.0f, 0.0f);
				agent.Resume();
			}
		}
		if(!shooting)
		{
			heading = player2.position - transform.position;
			distance = heading.magnitude;
			direction = heading / distance;
			ray = new Ray(transform.position, direction);
			if (Physics.Raycast(ray, out hit))
			{

				if (hit.collider.tag == "Player" && distance < 15)
				{

					agent.Stop();
					transform.LookAt(player2.position);
					Fire();
					shooting = true;
				}
				else
				{
					shooting = false;
					transform.transform.rotation = new Quaternion(0.0f, -1.0f, 0.0f, 0.0f);
					agent.Resume();

				}
			}
		}
		if(!shooting)
		{
			heading = player2.position - transform.position;
			distance = heading.magnitude;
			direction = heading / distance;
			ray = new Ray(transform.position, direction);
			if (Physics.Raycast(ray, out hit))
			{

				if (hit.collider.tag == "Player" && distance < 15)
				{

					agent.Stop();
					transform.LookAt(player2.position);
					Fire();
					shooting = true;
				}
				else
				{
					shooting = false;
					transform.transform.rotation = new Quaternion(0.0f, -1.0f, 0.0f, 0.0f);
					agent.Resume();

				}
			}
		}
		if (agent.remainingDistance < 0.5f)
		{
			GotoNextPatrolPoint();
		}
	}

	void GotoNextPatrolPoint()
	{
		if (points.Length == 0)
		{
			return;
		}

		agent.destination = points[destPoint].position;
		destPoint = (destPoint + 1) % points.Length;
	}

	void Fire()
	{
		if (Time.time > attackInterval + lastShot)
		{
			var batProjectile = (GameObject)Instantiate(batProjectilePrefab, batProjectileSpawn.position, batProjectileSpawn.rotation);

			batProjectile.GetComponent<Rigidbody>().velocity = batProjectile.transform.forward * batProjectileSpeed;

			Destroy(batProjectile, 3.5f);

			lastShot = Time.time;
		}


	}

	void OnApplicationQuit()
	{
		isQuitting = true;
	}

	void OnDisable()
	{
		if (!isQuitting) 
		{
			if (!isLoading) 
			{
				if (!isRestarting) {
					loot.SetActive (true);
				}
			}
		}
	}
}

