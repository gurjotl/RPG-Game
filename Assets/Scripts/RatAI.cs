using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RatAI : MonoBehaviour
{
    public Transform[] points;
    public GameObject ratLootPrefab;
    private int destPoint = 0;
    NavMeshAgent agent;
	private bool isQuitting;
	public bool isLoading;
	public bool isRestarting;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GotoNextPatrolPoint();
		isLoading = false;
		isRestarting = false;
		isQuitting = false;


    }

    // Update is called once per frame
    void Update()
    {
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
        Transform temp = agent.gameObject.transform.GetChild(1);
        agent.gameObject.transform.GetChild(1).transform.position = agent.gameObject.transform.GetChild(0).transform.position;
        agent.gameObject.transform.GetChild(0).transform.position = temp.position;
        agent.gameObject.transform.Rotate(0, 180, 0);
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
					var loot = (GameObject)Instantiate (ratLootPrefab, transform.position, transform.rotation);
					loot.SetActive (true);
				}
			}
		}
    }

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<Health> ().Hit (10);
		}
	}
}

