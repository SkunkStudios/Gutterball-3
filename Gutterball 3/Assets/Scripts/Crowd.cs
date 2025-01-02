using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd : MonoBehaviour
{
	public string[] cheerBig, cheerMed, crowdOk, crowdHohum, crowdCrap, laugh, roll, oooh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheerBig(AudioSource audio)
    {
        if (cheerBig.Length == 1)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + cheerBig[0]);
            audio.Play();
        }
        if (cheerBig.Length >= 2)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + cheerBig[Random.Range(0, cheerBig.Length)]);
            audio.Play();
        }
    }

    public void CheerMed(AudioSource audio)
    {
        if (cheerMed.Length == 1)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + cheerMed[0]);
            audio.Play();
        }
        if (cheerMed.Length >= 2)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + cheerMed[Random.Range(0, cheerMed.Length)]);
            audio.Play();
        }
    }

    public void CrowdOk(AudioSource audio)
    {
        if (crowdOk.Length == 1)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + crowdOk[0]);
            audio.Play();
        }
        if (crowdOk.Length >= 2)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + crowdOk[Random.Range(0, crowdOk.Length)]);
            audio.Play();
        }
    }

    public void CrowdHohum(AudioSource audio)
    {
        if (crowdHohum.Length == 1)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + crowdHohum[0]);
            audio.Play();
        }
        if (crowdHohum.Length >= 2)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + crowdHohum[Random.Range(0, crowdHohum.Length)]);
            audio.Play();
        }
    }

    public void CrowdCrap(AudioSource audio)
    {
        if (crowdCrap.Length == 1)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + crowdCrap[0]);
            audio.Play();
        }
        if (crowdCrap.Length >= 2)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + crowdCrap[Random.Range(0, crowdCrap.Length)]);
            audio.Play();
        }
    }

    public void Laugh(AudioSource audio)
    {
        if (laugh.Length == 1)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + laugh[0]);
            audio.Play();
        }
        if (laugh.Length >= 2)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + laugh[Random.Range(0, laugh.Length)]);
            audio.Play();
        }
    }

    public void Roll(AudioSource audio)
    {
        if (roll.Length == 1)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + roll[0]);
            audio.Play();
        }
        if (roll.Length >= 2)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + roll[Random.Range(0, roll.Length)]);
            audio.Play();
        }
    }

    public void Oooh(AudioSource audio)
    {
        if (oooh.Length == 1)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + oooh[0]);
            audio.Play();
        }
        if (oooh.Length >= 2)
        {
            audio.clip = Resources.Load<AudioClip>("Sound/" + oooh[Random.Range(0, oooh.Length)]);
            audio.Play();
        }
    }
}
