using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceText : MonoBehaviour
{
    public Text voice1Text;
    public Text voice2Text;
    public Commentator commentator;

    // Update is called once per frame
    void Update ()
	{
        voice1Text.text = commentator.commentators1[(int)GameManager.voices1].commentators;
        voice2Text.text = commentator.commentators2[(int)GameManager.voices2].commentators;
    }
}
