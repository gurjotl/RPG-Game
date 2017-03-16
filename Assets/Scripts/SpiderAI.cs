using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    public Transform[] points;
    public GameObject spiderLootPrefab;
    private int destPoint = 0;
    NavMeshAgent agent;
	public Transform toChase;
	public Transform player1;
	public Transform player2;
    bool chasing;

	private bool isQuitting = false;
	public bool isLoading = false;
	public bool isRestarting = false;


    // Use this for initialization
    void Start()
    {
        chasing = false;
        agent = GetComponent<NavMeshAgent>();
        //agent.autoBraking = false;
        GotoNextPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
		if (!chasing) {
			var heading = player1.position - transform.position;
			var distance = heading.magnitude;
			var direction = heading / distance;
			RaycastHit hit;
			Ray ray = new Ray (transform.position, direction);
			if (Physics.Raycast (ray, out hit)) {

				if (hit.collider.tag == "Player" && distance < 17 && !chasing) {
					toChase = hit.collider.gameObject.transform;
					transform.LookAt(toChase.position);
					agent.SetDestination(toChase.position);

					agent.speed += 2f;
					chasing = true;
				}
			}
			if (!chasing)
			{
				heading = player2.position - transform.position;
				distance = heading.magnitude;
				direction = heading / distance;
				ray = new Ray(transform.position, direction);
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.tag == "Player" && distance < 17 && !chasing)
					{
						toChase = hit.collider.gameObject.transform;
						transform.LookAt(toChase.position);
						agent.SetDestination(toChase.position);

						agent.speed += 2f;
						chasing = true;
					}
				}
			}
		}
        if (agent.remainingDistance < 1f  && !chasing)
        {
            GotoNextPatrolPoint();
        }
		if(chasing)
		{
			transform.LookAt(toChase.position);
			agent.SetDestination(toChase.position);
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
				if (!isRestarting) 
				{
					var loot = (GameObject)Instantiate (spiderLootPrefab, transform.position, transform.rotation);
					loot.SetActive (true);
				}
			}
		}
    }
		
	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<Health> ().Hit (25);
		}
	}
}

