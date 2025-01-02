using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
	public GameObject splashScreen;
	public GameObject activisionScreen;
	public GameObject warningScreen;
	public GameObject loadScreen;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(StartSplash());
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	IEnumerator StartSplash()
	{
		yield return new WaitForSeconds(0.5f);
        splashScreen.SetActive(true);
        yield return new WaitForSeconds(10f);
        splashScreen.SetActive(false);
        activisionScreen.SetActive(true);
        yield return new WaitForSeconds(6f);
        activisionScreen.SetActive(false);
        warningScreen.SetActive(true);
        yield return new WaitForSeconds(6f);
        warningScreen.SetActive(false);
        loadScreen.SetActive(true);
		SceneManager.LoadScene(1);
    }
}
