﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
	public Color[] colorFireworks;

    // Use this for initialization
    void Start ()
	{
        GameObject.FindObjectOfType<Game>().PlayClip("FireworksPop");
    }
}
