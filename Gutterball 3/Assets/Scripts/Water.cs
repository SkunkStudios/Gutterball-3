using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
	public GameObject splash;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("Pin"))
        {
            Vector3 splashPosition = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
			Instantiate(splash, splashPosition, Quaternion.identity);
        }
    }
}
