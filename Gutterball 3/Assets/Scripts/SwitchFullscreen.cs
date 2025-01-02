using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFullscreen : MonoBehaviour
{
    public GameObject switchON;
    public GameObject switchOFF;

	// Update is called once per frame
	void Update ()
	{
        if (Screen.fullScreen)
        {
            switchON.SetActive(true);
            switchOFF.SetActive(false);
        }
        else
        {
            switchON.SetActive(false);
            switchOFF.SetActive(true);
        }
    }
}
