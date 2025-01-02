using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleText : MonoBehaviour
{
	public string key;
	public Text switchText;

	// Use this for initialization
	void Start ()
	{
        GetComponent<Toggle>().isOn = (PlayerPrefs.GetInt(key) == 0);
    }

    // Update is called once per frame
    void Update ()
	{
        if (GetComponent<Toggle>().isOn)
		{
			switchText.text = "on";
			switchText.color = Color.green;
        }
		else
		{
            switchText.text = "off";
            switchText.color = Color.red;
        }
    }
}
