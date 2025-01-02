using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public float time;
    public ObjectAnimation[] objects;

	void Start ()
	{
        if (objects.Length == 0)
        {
            objects = GetComponentsInChildren<ObjectAnimation>();
        }
    }

    public void IdleAnimation()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].PlayIdle();
        }
    }

    public void PlayAnimation()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].PlayObject();
        }
    }

    public void SkipAnimation()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SkipObject();
        }
    }

    public void StopAnimation()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].StopObject();
        }
    }
}
