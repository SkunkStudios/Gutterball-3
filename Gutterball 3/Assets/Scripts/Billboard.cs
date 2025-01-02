using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public string findName;
    public bool isFind;

    private Transform cam;

    void Start ()
	{
        if (isFind)
        {
            cam = GameObject.Find(findName).transform;
        }
        else
        {
            cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
