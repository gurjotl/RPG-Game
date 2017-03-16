using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatProjectile : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {     
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<Health>().Hit (20);
		}
    }
}
