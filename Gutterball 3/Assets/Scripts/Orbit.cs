using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
	public Transform target;
	public float speed;
	public Vector3 axis;

	// Use this for initialization
	void Start ()
	{
        transform.Rotate(new Vector3 (Random.Range(-axis.x * 3600, axis.x * 3600), Random.Range(-axis.y * 3600, axis.y * 3600), Random.Range(-axis.z * 3600, axis.z * 3600)));
        if (target != null)
        {
            transform.RotateAround(target.transform.position, target.transform.up, speed * Random.Range(-3600, 3600));
        }

    }

    // Update is called once per frame
    void Update ()
	{
		transform.Rotate(axis * Time.deltaTime);
		if (target != null)
		{
            transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
        }
    }
}
