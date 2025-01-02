using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBG : MonoBehaviour
{
	public Transform cam;

	void Update ()
	{
		transform.position = cam.transform.position;
	}
}
