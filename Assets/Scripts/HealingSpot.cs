using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSpot : MonoBehaviour {

    void Update()
    {
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
    }
	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().HP = 100;
        }
    }
}
