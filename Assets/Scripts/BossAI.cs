using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public GameObject round1Player1Trigger;
    public GameObject round1Player2Trigger;
    public GameObject round2Player1Trigger;
    public GameObject round2Player2Trigger;
    public GameObject round3Player1Trigger;
    public GameObject round3Player2Trigger;

    public GameObject player1;
    public GameObject player2;
    public GameObject revertedWizard;
    public GameObject cauldron;
    public GameObject cage;

    public float attackInterval;
    public GameObject bossProjectilePrefab;
    public Transform bossProjectileSpawn;
    public float bossProjectileSpeed;

    bool shooting;
    float lastShot;
    int round;

    // Use this for initialization
    void Start()
    {
        round = 1;
        lastShot = 0;
        shooting = true;
        revertedWizard.SetActive(false);
        cauldron.SetActive(false);
        cage.SetActive(false);
        round1Player1Trigger.SetActive(true);
        round1Player2Trigger.SetActive(true);
        round2Player1Trigger.SetActive(false);
        round2Player2Trigger.SetActive(false);
        round3Player1Trigger.SetActive(false);
        round3Player2Trigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var heading = player1.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                transform.LookAt(player1.transform.position);
                Fire(player1);
                shooting = true;
            }
            else
            {
                shooting = false;
            }
        }
        if (!shooting)
        {
            heading = player2.transform.position - transform.position;
            distance = heading.magnitude;
            direction = heading / distance;
            ray = new Ray(transform.position, direction);
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Player")
                {
                    transform.LookAt(player2.transform.position);
                    Fire(player2);
                    shooting = true;
                }
                else
                {
                    shooting = false;

                }
            }
        }
        if (!shooting)
        {
            heading = player2.transform.position - transform.position;
            distance = heading.magnitude;
            direction = heading / distance;
            ray = new Ray(transform.position, direction);
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Player")
                {
                    transform.LookAt(player2.transform.position);
                    Fire(player2);
                    shooting = true;
                }
                else
                {
                    shooting = false;
                }
            }
        }

        if(round == 1)
        {
            if(round1Player1Trigger.GetComponent<Renderer>().material.color == Color.white && round1Player2Trigger.GetComponent<Renderer>().material.color == Color.white)
            {
                round += 1;
                round1Player1Trigger.SetActive(false);
                round1Player2Trigger.SetActive(false);
                round2Player1Trigger.SetActive(true);
                round2Player2Trigger.SetActive(true);
            }
        }
        else if(round == 2)
        {
            if (round2Player1Trigger.GetComponent<Renderer>().material.color == Color.white && round2Player2Trigger.GetComponent<Renderer>().material.color == Color.white)
            {
                round += 1;
                round2Player1Trigger.SetActive(false);
                round2Player2Trigger.SetActive(false);
                round3Player1Trigger.SetActive(true);
                round3Player2Trigger.SetActive(true);
            }
        }
        else
        {
            if (round3Player1Trigger.GetComponent<Renderer>().material.color == Color.white && round3Player2Trigger.GetComponent<Renderer>().material.color == Color.white)
            {
                round3Player1Trigger.SetActive(false);
                round3Player2Trigger.SetActive(false);
                revertedWizard.SetActive(true);
                cauldron.SetActive(true);
                cage.SetActive(true);
                player1.SetActive(false);
                player2.SetActive(false);

                gameObject.SetActive(false);


                //wizard falls in cauldron, escape and you win
            }
        }
    }

    void Fire(GameObject target)
    {
        if (Time.time > attackInterval + lastShot)
        {
            bossProjectileSpawn.LookAt(target.transform.position);
            var bossProjectile = (GameObject)Instantiate(bossProjectilePrefab, bossProjectileSpawn.position, bossProjectileSpawn.rotation);

            bossProjectile.GetComponent<Rigidbody>().velocity = bossProjectile.transform.forward * bossProjectileSpeed;

            Destroy(bossProjectile, 3.5f);

            lastShot = Time.time;
        }


    }
}

