using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.transform.root.gameObject.CompareTag("Player"))
        {
            other.transform.root.gameObject.GetComponent<Health>().Hit(50);
        }
    }
}