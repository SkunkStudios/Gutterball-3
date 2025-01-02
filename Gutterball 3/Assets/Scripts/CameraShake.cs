using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cam;
    private GameManager gameManager;
    private float shakeHit;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeHit > 0)
        {
            shakeHit -= Time.deltaTime * 15;
        }
        else if (shakeHit < 0)
        {
            shakeHit = 0;
        }
        transform.position = new Vector3(cam.position.x + Random.Range(-shakeHit, shakeHit), cam.position.y + Random.Range(-shakeHit, shakeHit), cam.position.z + Random.Range(-shakeHit, shakeHit));
    }

    public void Shake(float setShake)
    {
        if (GameManager.isShake)
        {
            shakeHit += setShake * 0.5f;
        }
    }
}
