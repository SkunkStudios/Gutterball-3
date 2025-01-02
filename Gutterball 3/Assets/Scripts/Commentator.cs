using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commentator : MonoBehaviour
{
    public CommentatorClip[] commentators1 = new CommentatorClip[5];
    public CommentatorClip[] commentators2 = new CommentatorClip[5];
    private AudioClip commentatorWait;

    // Use this for initialization
    void Start ()
	{
        commentators1[(int)GameManager.voices1].Strike.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Strike.voices.Length);
        commentators1[(int)GameManager.voices1].Spare.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Spare.voices.Length);
        commentators1[(int)GameManager.voices1].Gutterball.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Gutterball.voices.Length);
        commentators1[(int)GameManager.voices1].Double.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Double.voices.Length);
        commentators1[(int)GameManager.voices1].Turkey.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Turkey.voices.Length);
        commentators1[(int)GameManager.voices1].Split.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Split.voices.Length);
        commentators1[(int)GameManager.voices1].Split710.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Split710.voices.Length);
        commentators1[(int)GameManager.voices1].SplitPick.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].SplitPick.voices.Length);
        commentators1[(int)GameManager.voices1].Most.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Most.voices.Length);
        commentators1[(int)GameManager.voices1].Few.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Few.voices.Length);
        commentators1[(int)GameManager.voices1].One.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].One.voices.Length);
        commentators1[(int)GameManager.voices1].Miss.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Miss.voices.Length);
        commentators1[(int)GameManager.voices1].EndBad.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].EndBad.voices.Length);
        commentators1[(int)GameManager.voices1].EndOk.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].EndOk.voices.Length);
        commentators1[(int)GameManager.voices1].EndGood.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].EndGood.voices.Length);
        commentators1[(int)GameManager.voices1].EndGreat.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].EndGreat.voices.Length);
        commentators2[(int)GameManager.voices2].Strike.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Strike.voices.Length);
        commentators2[(int)GameManager.voices2].Spare.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Spare.voices.Length);
        commentators2[(int)GameManager.voices2].Gutterball.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Gutterball.voices.Length);
        commentators2[(int)GameManager.voices2].Double.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Double.voices.Length);
        commentators2[(int)GameManager.voices2].Turkey.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Turkey.voices.Length);
        commentators2[(int)GameManager.voices2].Split.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Split.voices.Length);
        commentators2[(int)GameManager.voices2].Split710.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Split710.voices.Length);
        commentators2[(int)GameManager.voices2].SplitPick.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].SplitPick.voices.Length);
        commentators2[(int)GameManager.voices2].Most.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Most.voices.Length);
        commentators2[(int)GameManager.voices2].Few.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Few.voices.Length);
        commentators2[(int)GameManager.voices2].One.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].One.voices.Length);
        commentators2[(int)GameManager.voices2].Miss.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Miss.voices.Length);
        commentators2[(int)GameManager.voices2].EndBad.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].EndBad.voices.Length);
        commentators2[(int)GameManager.voices2].EndOk.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].EndOk.voices.Length);
        commentators2[(int)GameManager.voices2].EndGood.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].EndGood.voices.Length);
        commentators2[(int)GameManager.voices2].EndGreat.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].EndGreat.voices.Length);
        commentators1[(int)GameManager.voices1].Strike.voiceRandom = commentators1[(int)GameManager.voices1].Strike.voices.Length;
        commentators1[(int)GameManager.voices1].Spare.voiceRandom = commentators1[(int)GameManager.voices1].Spare.voices.Length;
        commentators1[(int)GameManager.voices1].Gutterball.voiceRandom = commentators1[(int)GameManager.voices1].Gutterball.voices.Length;
        commentators1[(int)GameManager.voices1].Double.voiceRandom = commentators1[(int)GameManager.voices1].Double.voices.Length;
        commentators1[(int)GameManager.voices1].Turkey.voiceRandom = commentators1[(int)GameManager.voices1].Turkey.voices.Length;
        commentators1[(int)GameManager.voices1].Split.voiceRandom = commentators1[(int)GameManager.voices1].Split.voices.Length;
        commentators1[(int)GameManager.voices1].Split710.voiceRandom = commentators1[(int)GameManager.voices1].Split710.voices.Length;
        commentators1[(int)GameManager.voices1].SplitPick.voiceRandom = commentators1[(int)GameManager.voices1].SplitPick.voices.Length;
        commentators1[(int)GameManager.voices1].Most.voiceRandom = commentators1[(int)GameManager.voices1].Most.voices.Length;
        commentators1[(int)GameManager.voices1].Few.voiceRandom = commentators1[(int)GameManager.voices1].Few.voices.Length;
        commentators1[(int)GameManager.voices1].One.voiceRandom = commentators1[(int)GameManager.voices1].One.voices.Length;
        commentators1[(int)GameManager.voices1].Miss.voiceRandom = commentators1[(int)GameManager.voices1].Miss.voices.Length;
        commentators2[(int)GameManager.voices2].Strike.voiceRandom = commentators2[(int)GameManager.voices2].Strike.voices.Length;
        commentators2[(int)GameManager.voices2].Spare.voiceRandom = commentators2[(int)GameManager.voices2].Spare.voices.Length;
        commentators2[(int)GameManager.voices2].Gutterball.voiceRandom = commentators2[(int)GameManager.voices2].Gutterball.voices.Length;
        commentators2[(int)GameManager.voices2].Double.voiceRandom = commentators2[(int)GameManager.voices2].Double.voices.Length;
        commentators2[(int)GameManager.voices2].Turkey.voiceRandom = commentators2[(int)GameManager.voices2].Turkey.voices.Length;
        commentators2[(int)GameManager.voices2].Split.voiceRandom = commentators2[(int)GameManager.voices2].Split.voices.Length;
        commentators2[(int)GameManager.voices2].Split710.voiceRandom = commentators2[(int)GameManager.voices2].Split710.voices.Length;
        commentators2[(int)GameManager.voices2].SplitPick.voiceRandom = commentators2[(int)GameManager.voices2].SplitPick.voices.Length;
        commentators2[(int)GameManager.voices2].Most.voiceRandom = commentators2[(int)GameManager.voices2].Most.voices.Length;
        commentators2[(int)GameManager.voices2].Few.voiceRandom = commentators2[(int)GameManager.voices2].Few.voices.Length;
        commentators2[(int)GameManager.voices2].One.voiceRandom = commentators2[(int)GameManager.voices2].One.voices.Length;
        commentators2[(int)GameManager.voices2].Miss.voiceRandom = commentators2[(int)GameManager.voices2].Miss.voices.Length;
    }

    // Update is called once per frame
    void Update ()
	{
        if (commentators1[(int)GameManager.voices1].Strike.nextVoice >= commentators1[(int)GameManager.voices1].Strike.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Strike.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Strike.voiceCount[i] = commentators1[(int)GameManager.voices1].Strike.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Strike.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Spare.nextVoice >= commentators1[(int)GameManager.voices1].Spare.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Spare.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Spare.voiceCount[i] = commentators1[(int)GameManager.voices1].Spare.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Spare.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Gutterball.nextVoice >= commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Gutterball.voiceCount[i] = commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Gutterball.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Double.nextVoice >= commentators1[(int)GameManager.voices1].Double.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Double.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Double.voiceCount[i] = commentators1[(int)GameManager.voices1].Double.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Double.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Turkey.nextVoice >= commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Turkey.voiceCount[i] = commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Turkey.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Split.nextVoice >= commentators1[(int)GameManager.voices1].Split.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Split.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Split.voiceCount[i] = commentators1[(int)GameManager.voices1].Split.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Split.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Split710.nextVoice >= commentators1[(int)GameManager.voices1].Split710.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Split710.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Split710.voiceCount[i] = commentators1[(int)GameManager.voices1].Split710.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Split710.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].SplitPick.nextVoice >= commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].SplitPick.voiceCount[i] = commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].SplitPick.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Most.nextVoice >= commentators1[(int)GameManager.voices1].Most.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Most.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Most.voiceCount[i] = commentators1[(int)GameManager.voices1].Most.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Most.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Few.nextVoice >= commentators1[(int)GameManager.voices1].Few.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Few.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Few.voiceCount[i] = commentators1[(int)GameManager.voices1].Few.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Few.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].One.nextVoice >= commentators1[(int)GameManager.voices1].One.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].One.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].One.voiceCount[i] = commentators1[(int)GameManager.voices1].One.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].One.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Miss.nextVoice >= commentators1[(int)GameManager.voices1].Miss.voiceCount.Length)
        {
            for (int i = 0; i < commentators1[(int)GameManager.voices1].Miss.voiceCount.Length; i++)
            {
                commentators1[(int)GameManager.voices1].Miss.voiceCount[i] = commentators1[(int)GameManager.voices1].Miss.voiceCount.Length;
            }
            commentators1[(int)GameManager.voices1].Miss.nextVoice = 0;
        }
        if (commentators1[(int)GameManager.voices1].Strike.voiceIndex >= commentators1[(int)GameManager.voices1].Strike.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Strike.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].Spare.voiceIndex >= commentators1[(int)GameManager.voices1].Spare.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Spare.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].Gutterball.voiceIndex >= commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Gutterball.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].Double.voiceIndex >= commentators1[(int)GameManager.voices1].Double.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Double.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].Turkey.voiceIndex >= commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Turkey.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].Split.voiceIndex >= commentators1[(int)GameManager.voices1].Split.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Split.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].Split710.voiceIndex >= commentators1[(int)GameManager.voices1].Split710.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Split710.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].SplitPick.voiceIndex >= commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].SplitPick.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].Most.voiceIndex >= commentators1[(int)GameManager.voices1].Most.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Most.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].Few.voiceIndex >= commentators1[(int)GameManager.voices1].Few.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Few.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].One.voiceIndex >= commentators1[(int)GameManager.voices1].One.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].One.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].Miss.voiceIndex >= commentators1[(int)GameManager.voices1].Miss.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].Miss.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].EndBad.voiceIndex >= commentators1[(int)GameManager.voices1].EndBad.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].EndBad.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].EndOk.voiceIndex >= commentators1[(int)GameManager.voices1].EndOk.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].EndOk.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].EndGood.voiceIndex >= commentators1[(int)GameManager.voices1].EndGood.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].EndGood.voiceIndex = 0;
        }
        if (commentators1[(int)GameManager.voices1].EndGreat.voiceIndex >= commentators1[(int)GameManager.voices1].EndGreat.voiceCount.Length)
        {
            commentators1[(int)GameManager.voices1].EndGreat.voiceIndex = 0;
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Strike.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Strike.voiceCount[i] == commentators1[(int)GameManager.voices1].Strike.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Strike.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Strike.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Spare.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Spare.voiceCount[i] == commentators1[(int)GameManager.voices1].Spare.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Spare.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Spare.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Gutterball.voiceCount[i] == commentators1[(int)GameManager.voices1].Gutterball.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Gutterball.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Gutterball.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Double.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Double.voiceCount[i] == commentators1[(int)GameManager.voices1].Double.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Double.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Double.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Turkey.voiceCount[i] == commentators1[(int)GameManager.voices1].Turkey.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Turkey.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Turkey.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Split.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Split.voiceCount[i] == commentators1[(int)GameManager.voices1].Split.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Split.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Split.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Split710.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Split710.voiceCount[i] == commentators1[(int)GameManager.voices1].Split710.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Split710.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Split710.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].SplitPick.voiceCount[i] == commentators1[(int)GameManager.voices1].SplitPick.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].SplitPick.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].SplitPick.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Most.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Most.voiceCount[i] == commentators1[(int)GameManager.voices1].Most.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Most.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Most.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Few.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Few.voiceCount[i] == commentators1[(int)GameManager.voices1].Few.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Few.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Few.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].One.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].One.voiceCount[i] == commentators1[(int)GameManager.voices1].One.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].One.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].One.voices.Length);
            }
        }
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Miss.voiceCount.Length; i++)
        {
            if (commentators1[(int)GameManager.voices1].Miss.voiceCount[i] == commentators1[(int)GameManager.voices1].Miss.voiceIndex)
            {
                commentators1[(int)GameManager.voices1].Miss.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Miss.voices.Length);
            }
        }
        if (commentators2[(int)GameManager.voices2].Strike.nextVoice >= commentators2[(int)GameManager.voices2].Strike.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Strike.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Strike.voiceCount[i] = commentators2[(int)GameManager.voices2].Strike.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Strike.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Spare.nextVoice >= commentators2[(int)GameManager.voices2].Spare.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Spare.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Spare.voiceCount[i] = commentators2[(int)GameManager.voices2].Spare.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Spare.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Gutterball.nextVoice >= commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Gutterball.voiceCount[i] = commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Gutterball.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Double.nextVoice >= commentators2[(int)GameManager.voices2].Double.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Double.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Double.voiceCount[i] = commentators2[(int)GameManager.voices2].Double.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Double.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Turkey.nextVoice >= commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Turkey.voiceCount[i] = commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Turkey.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Split.nextVoice >= commentators2[(int)GameManager.voices2].Split.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Split.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Split.voiceCount[i] = commentators2[(int)GameManager.voices2].Split.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Split.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Split710.nextVoice >= commentators2[(int)GameManager.voices2].Split710.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Split710.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Split710.voiceCount[i] = commentators2[(int)GameManager.voices2].Split710.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Split710.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].SplitPick.nextVoice >= commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].SplitPick.voiceCount[i] = commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].SplitPick.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Most.nextVoice >= commentators2[(int)GameManager.voices2].Most.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Most.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Most.voiceCount[i] = commentators2[(int)GameManager.voices2].Most.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Most.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Few.nextVoice >= commentators2[(int)GameManager.voices2].Few.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Few.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Few.voiceCount[i] = commentators2[(int)GameManager.voices2].Few.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Few.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].One.nextVoice >= commentators2[(int)GameManager.voices2].One.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].One.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].One.voiceCount[i] = commentators2[(int)GameManager.voices2].One.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].One.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Miss.nextVoice >= commentators2[(int)GameManager.voices2].Miss.voiceCount.Length)
        {
            for (int i = 0; i < commentators2[(int)GameManager.voices2].Miss.voiceCount.Length; i++)
            {
                commentators2[(int)GameManager.voices2].Miss.voiceCount[i] = commentators2[(int)GameManager.voices2].Miss.voiceCount.Length;
            }
            commentators2[(int)GameManager.voices2].Miss.nextVoice = 0;
        }
        if (commentators2[(int)GameManager.voices2].Strike.voiceIndex >= commentators2[(int)GameManager.voices2].Strike.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Strike.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].Spare.voiceIndex >= commentators2[(int)GameManager.voices2].Spare.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Spare.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].Gutterball.voiceIndex >= commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Gutterball.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].Double.voiceIndex >= commentators2[(int)GameManager.voices2].Double.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Double.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].Turkey.voiceIndex >= commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Turkey.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].Split.voiceIndex >= commentators2[(int)GameManager.voices2].Split.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Split.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].Split710.voiceIndex >= commentators2[(int)GameManager.voices2].Split710.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Split710.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].SplitPick.voiceIndex >= commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].SplitPick.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].Most.voiceIndex >= commentators2[(int)GameManager.voices2].Most.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Most.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].Few.voiceIndex >= commentators2[(int)GameManager.voices2].Few.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Few.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].One.voiceIndex >= commentators2[(int)GameManager.voices2].One.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].One.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].Miss.voiceIndex >= commentators2[(int)GameManager.voices2].Miss.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].Miss.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].EndBad.voiceIndex >= commentators2[(int)GameManager.voices2].EndBad.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].EndBad.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].EndOk.voiceIndex >= commentators2[(int)GameManager.voices2].EndOk.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].EndOk.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].EndGood.voiceIndex >= commentators2[(int)GameManager.voices2].EndGood.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].EndGood.voiceIndex = 0;
        }
        if (commentators2[(int)GameManager.voices2].EndGreat.voiceIndex >= commentators2[(int)GameManager.voices2].EndGreat.voiceCount.Length)
        {
            commentators2[(int)GameManager.voices2].EndGreat.voiceIndex = 0;
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Strike.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Strike.voiceCount[i] == commentators2[(int)GameManager.voices2].Strike.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Strike.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Strike.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Spare.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Spare.voiceCount[i] == commentators2[(int)GameManager.voices2].Spare.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Spare.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Spare.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Gutterball.voiceCount[i] == commentators2[(int)GameManager.voices2].Gutterball.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Gutterball.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Gutterball.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Double.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Double.voiceCount[i] == commentators2[(int)GameManager.voices2].Double.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Double.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Double.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Turkey.voiceCount[i] == commentators2[(int)GameManager.voices2].Turkey.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Turkey.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Turkey.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Split.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Split.voiceCount[i] == commentators2[(int)GameManager.voices2].Split.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Split.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Split.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Split710.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Split710.voiceCount[i] == commentators2[(int)GameManager.voices2].Split710.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Split710.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Split710.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].SplitPick.voiceCount[i] == commentators2[(int)GameManager.voices2].SplitPick.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].SplitPick.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].SplitPick.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Most.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Most.voiceCount[i] == commentators2[(int)GameManager.voices2].Most.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Most.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Most.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Few.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Few.voiceCount[i] == commentators2[(int)GameManager.voices2].Few.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Few.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Few.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].One.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].One.voiceCount[i] == commentators2[(int)GameManager.voices2].One.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].One.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].One.voices.Length);
            }
        }
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Miss.voiceCount.Length; i++)
        {
            if (commentators2[(int)GameManager.voices2].Miss.voiceCount[i] == commentators2[(int)GameManager.voices2].Miss.voiceIndex)
            {
                commentators2[(int)GameManager.voices2].Miss.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Miss.voices.Length);
            }
        }
        if (commentators1[(int)GameManager.voices1].Strike.voiceRandom == commentators1[(int)GameManager.voices1].Strike.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Strike.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Strike.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].Spare.voiceRandom == commentators1[(int)GameManager.voices1].Spare.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Spare.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Spare.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].Gutterball.voiceRandom == commentators1[(int)GameManager.voices1].Gutterball.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Gutterball.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Gutterball.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].Double.voiceRandom == commentators1[(int)GameManager.voices1].Double.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Double.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Double.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].Turkey.voiceRandom == commentators1[(int)GameManager.voices1].Turkey.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Turkey.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Turkey.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].Split.voiceRandom == commentators1[(int)GameManager.voices1].Split.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Split.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Split.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].Split710.voiceRandom == commentators1[(int)GameManager.voices1].Split710.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Split710.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Split710.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].SplitPick.voiceRandom == commentators1[(int)GameManager.voices1].SplitPick.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].SplitPick.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].SplitPick.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].Most.voiceRandom == commentators1[(int)GameManager.voices1].Most.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Most.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Most.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].Few.voiceRandom == commentators1[(int)GameManager.voices1].Few.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Few.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Few.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].One.voiceRandom == commentators1[(int)GameManager.voices1].One.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].One.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].One.voices.Length);
        }
        if (commentators1[(int)GameManager.voices1].Miss.voiceRandom == commentators1[(int)GameManager.voices1].Miss.voiceIndex)
        {
            commentators1[(int)GameManager.voices1].Miss.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Miss.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Strike.voiceRandom == commentators2[(int)GameManager.voices2].Strike.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Strike.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Strike.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Spare.voiceRandom == commentators2[(int)GameManager.voices2].Spare.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Spare.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Spare.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Gutterball.voiceRandom == commentators2[(int)GameManager.voices2].Gutterball.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Gutterball.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Gutterball.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Double.voiceRandom == commentators2[(int)GameManager.voices2].Double.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Double.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Double.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Turkey.voiceRandom == commentators2[(int)GameManager.voices2].Turkey.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Turkey.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Turkey.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Split.voiceRandom == commentators2[(int)GameManager.voices2].Split.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Split.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Split.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Split710.voiceRandom == commentators2[(int)GameManager.voices2].Split710.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Split710.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Split710.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].SplitPick.voiceRandom == commentators2[(int)GameManager.voices2].SplitPick.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].SplitPick.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].SplitPick.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Most.voiceRandom == commentators2[(int)GameManager.voices2].Most.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Most.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Most.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Few.voiceRandom == commentators2[(int)GameManager.voices2].Few.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Few.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Few.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].One.voiceRandom == commentators2[(int)GameManager.voices2].One.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].One.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].One.voices.Length);
        }
        if (commentators2[(int)GameManager.voices2].Miss.voiceRandom == commentators2[(int)GameManager.voices2].Miss.voiceIndex)
        {
            commentators2[(int)GameManager.voices2].Miss.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Miss.voices.Length);
        }
    }

    public void Strike(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Strike.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Strike.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Strike.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Strike.voices[commentators1[(int)GameManager.voices1].Strike.voiceIndex]);
            commentators1[(int)GameManager.voices1].Strike.voiceRandom = commentators1[(int)GameManager.voices1].Strike.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Strike.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Strike.voices[commentators1[(int)GameManager.voices1].Strike.voiceIndex]);
            commentators1[(int)GameManager.voices1].Strike.voiceRandom = commentators1[(int)GameManager.voices1].Strike.voiceIndex;
            commentators1[(int)GameManager.voices1].Strike.voiceCount[commentators1[(int)GameManager.voices1].Strike.voiceIndex] = commentators1[(int)GameManager.voices1].Strike.voiceIndex;
            commentators1[(int)GameManager.voices1].Strike.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Strike.voices.Length);
            commentators1[(int)GameManager.voices1].Strike.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Strike.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Strike.voices[commentators2[(int)GameManager.voices2].Strike.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Strike.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Strike.voices[commentators2[(int)GameManager.voices2].Strike.voiceIndex]);
            commentators2[(int)GameManager.voices2].Strike.voiceRandom = commentators2[(int)GameManager.voices2].Strike.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Strike.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Strike.voices[commentators2[(int)GameManager.voices2].Strike.voiceIndex]);
            commentators2[(int)GameManager.voices2].Strike.voiceCount[commentators2[(int)GameManager.voices2].Strike.voiceIndex] = commentators2[(int)GameManager.voices2].Strike.voiceIndex;
            commentators2[(int)GameManager.voices2].Strike.voiceRandom = commentators2[(int)GameManager.voices2].Strike.voiceIndex;
            commentators2[(int)GameManager.voices2].Strike.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Strike.voices.Length);
            commentators2[(int)GameManager.voices2].Strike.nextVoice++;
        }
    }

    public void Spare(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Spare.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Spare.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Spare.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Spare.voices[commentators1[(int)GameManager.voices1].Spare.voiceIndex]);
            commentators1[(int)GameManager.voices1].Spare.voiceRandom = commentators1[(int)GameManager.voices1].Spare.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Spare.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Spare.voices[commentators1[(int)GameManager.voices1].Spare.voiceIndex]);
            commentators1[(int)GameManager.voices1].Spare.voiceRandom = commentators1[(int)GameManager.voices1].Spare.voiceIndex;
            commentators1[(int)GameManager.voices1].Spare.voiceCount[commentators1[(int)GameManager.voices1].Spare.voiceIndex] = commentators1[(int)GameManager.voices1].Spare.voiceIndex;
            commentators1[(int)GameManager.voices1].Spare.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Spare.voices.Length);
            commentators1[(int)GameManager.voices1].Spare.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Spare.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Spare.voices[commentators2[(int)GameManager.voices2].Spare.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Spare.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Spare.voices[commentators2[(int)GameManager.voices2].Spare.voiceIndex]);
            commentators2[(int)GameManager.voices2].Spare.voiceRandom = commentators2[(int)GameManager.voices2].Spare.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Spare.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Spare.voices[commentators2[(int)GameManager.voices2].Spare.voiceIndex]);
            commentators2[(int)GameManager.voices2].Spare.voiceCount[commentators2[(int)GameManager.voices2].Spare.voiceIndex] = commentators2[(int)GameManager.voices2].Spare.voiceIndex;
            commentators2[(int)GameManager.voices2].Spare.voiceRandom = commentators2[(int)GameManager.voices2].Spare.voiceIndex;
            commentators2[(int)GameManager.voices2].Spare.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Spare.voices.Length);
            commentators2[(int)GameManager.voices2].Spare.nextVoice++;
        }
    }

    public void Gutterball(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Gutterball.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Gutterball.voices[commentators1[(int)GameManager.voices1].Gutterball.voiceIndex]);
            commentators1[(int)GameManager.voices1].Gutterball.voiceRandom = commentators1[(int)GameManager.voices1].Gutterball.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Gutterball.voices[commentators1[(int)GameManager.voices1].Gutterball.voiceIndex]);
            commentators1[(int)GameManager.voices1].Gutterball.voiceRandom = commentators1[(int)GameManager.voices1].Gutterball.voiceIndex;
            commentators1[(int)GameManager.voices1].Gutterball.voiceCount[commentators1[(int)GameManager.voices1].Gutterball.voiceIndex] = commentators1[(int)GameManager.voices1].Gutterball.voiceIndex;
            commentators1[(int)GameManager.voices1].Gutterball.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Gutterball.voices.Length);
            commentators1[(int)GameManager.voices1].Gutterball.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Gutterball.voices[commentators2[(int)GameManager.voices2].Gutterball.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Gutterball.voices[commentators2[(int)GameManager.voices2].Gutterball.voiceIndex]);
            commentators2[(int)GameManager.voices2].Gutterball.voiceRandom = commentators2[(int)GameManager.voices2].Gutterball.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Gutterball.voices[commentators2[(int)GameManager.voices2].Gutterball.voiceIndex]);
            commentators2[(int)GameManager.voices2].Gutterball.voiceCount[commentators2[(int)GameManager.voices2].Gutterball.voiceIndex] = commentators2[(int)GameManager.voices2].Gutterball.voiceIndex;
            commentators2[(int)GameManager.voices2].Gutterball.voiceRandom = commentators2[(int)GameManager.voices2].Gutterball.voiceIndex;
            commentators2[(int)GameManager.voices2].Gutterball.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Gutterball.voices.Length);
            commentators2[(int)GameManager.voices2].Gutterball.nextVoice++;
        }
    }

    public void Double(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Double.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Double.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Double.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Double.voices[commentators1[(int)GameManager.voices1].Double.voiceIndex]);
            commentators1[(int)GameManager.voices1].Double.voiceRandom = commentators1[(int)GameManager.voices1].Double.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Double.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Double.voices[commentators1[(int)GameManager.voices1].Double.voiceIndex]);
            commentators1[(int)GameManager.voices1].Double.voiceRandom = commentators1[(int)GameManager.voices1].Double.voiceIndex;
            commentators1[(int)GameManager.voices1].Double.voiceCount[commentators1[(int)GameManager.voices1].Double.voiceIndex] = commentators1[(int)GameManager.voices1].Double.voiceIndex;
            commentators1[(int)GameManager.voices1].Double.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Double.voices.Length);
            commentators1[(int)GameManager.voices1].Double.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Double.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Double.voices[commentators2[(int)GameManager.voices2].Double.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Double.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Double.voices[commentators2[(int)GameManager.voices2].Double.voiceIndex]);
            commentators2[(int)GameManager.voices2].Double.voiceRandom = commentators2[(int)GameManager.voices2].Double.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Double.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Double.voices[commentators2[(int)GameManager.voices2].Double.voiceIndex]);
            commentators2[(int)GameManager.voices2].Double.voiceCount[commentators2[(int)GameManager.voices2].Double.voiceIndex] = commentators2[(int)GameManager.voices2].Double.voiceIndex;
            commentators2[(int)GameManager.voices2].Double.voiceRandom = commentators2[(int)GameManager.voices2].Double.voiceIndex;
            commentators2[(int)GameManager.voices2].Double.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Double.voices.Length);
            commentators2[(int)GameManager.voices2].Double.nextVoice++;
        }
    }

    public void Turkey(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Turkey.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Turkey.voices[commentators1[(int)GameManager.voices1].Turkey.voiceIndex]);
            commentators1[(int)GameManager.voices1].Turkey.voiceRandom = commentators1[(int)GameManager.voices1].Turkey.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Turkey.voices[commentators1[(int)GameManager.voices1].Turkey.voiceIndex]);
            commentators1[(int)GameManager.voices1].Turkey.voiceRandom = commentators1[(int)GameManager.voices1].Turkey.voiceIndex;
            commentators1[(int)GameManager.voices1].Turkey.voiceCount[commentators1[(int)GameManager.voices1].Turkey.voiceIndex] = commentators1[(int)GameManager.voices1].Turkey.voiceIndex;
            commentators1[(int)GameManager.voices1].Turkey.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Turkey.voices.Length);
            commentators1[(int)GameManager.voices1].Turkey.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Turkey.voices[commentators2[(int)GameManager.voices2].Turkey.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Turkey.voices[commentators2[(int)GameManager.voices2].Turkey.voiceIndex]);
            commentators2[(int)GameManager.voices2].Turkey.voiceRandom = commentators2[(int)GameManager.voices2].Turkey.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Turkey.voices[commentators2[(int)GameManager.voices2].Turkey.voiceIndex]);
            commentators2[(int)GameManager.voices2].Turkey.voiceCount[commentators2[(int)GameManager.voices2].Turkey.voiceIndex] = commentators2[(int)GameManager.voices2].Turkey.voiceIndex;
            commentators2[(int)GameManager.voices2].Turkey.voiceRandom = commentators2[(int)GameManager.voices2].Turkey.voiceIndex;
            commentators2[(int)GameManager.voices2].Turkey.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Turkey.voices.Length);
            commentators2[(int)GameManager.voices2].Turkey.nextVoice++;
        }
    }

    public void Split(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Split.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Split.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Split.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Split.voices[commentators1[(int)GameManager.voices1].Split.voiceIndex]);
            commentators1[(int)GameManager.voices1].Split.voiceRandom = commentators1[(int)GameManager.voices1].Split.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Split.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Split.voices[commentators1[(int)GameManager.voices1].Split.voiceIndex]);
            commentators1[(int)GameManager.voices1].Split.voiceRandom = commentators1[(int)GameManager.voices1].Split.voiceIndex;
            commentators1[(int)GameManager.voices1].Split.voiceCount[commentators1[(int)GameManager.voices1].Split.voiceIndex] = commentators1[(int)GameManager.voices1].Split.voiceIndex;
            commentators1[(int)GameManager.voices1].Split.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Split.voices.Length);
            commentators1[(int)GameManager.voices1].Split.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Split.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Split.voices[commentators2[(int)GameManager.voices2].Split.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Split.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Split.voices[commentators2[(int)GameManager.voices2].Split.voiceIndex]);
            commentators2[(int)GameManager.voices2].Split.voiceRandom = commentators2[(int)GameManager.voices2].Split.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Split.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Split.voices[commentators2[(int)GameManager.voices2].Split.voiceIndex]);
            commentators2[(int)GameManager.voices2].Split.voiceCount[commentators2[(int)GameManager.voices2].Split.voiceIndex] = commentators2[(int)GameManager.voices2].Split.voiceIndex;
            commentators2[(int)GameManager.voices2].Split.voiceRandom = commentators2[(int)GameManager.voices2].Split.voiceIndex;
            commentators2[(int)GameManager.voices2].Split.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Split.voices.Length);
            commentators2[(int)GameManager.voices2].Split.nextVoice++;
        }
    }

    public void Split710(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Split710.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Split710.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Split710.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Split710.voices[commentators1[(int)GameManager.voices1].Split710.voiceIndex]);
            commentators1[(int)GameManager.voices1].Split710.voiceRandom = commentators1[(int)GameManager.voices1].Split710.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Split710.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Split710.voices[commentators1[(int)GameManager.voices1].Split710.voiceIndex]);
            commentators1[(int)GameManager.voices1].Split710.voiceRandom = commentators1[(int)GameManager.voices1].Split710.voiceIndex;
            commentators1[(int)GameManager.voices1].Split710.voiceCount[commentators1[(int)GameManager.voices1].Split710.voiceIndex] = commentators1[(int)GameManager.voices1].Split710.voiceIndex;
            commentators1[(int)GameManager.voices1].Split710.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Split710.voices.Length);
            commentators1[(int)GameManager.voices1].Split710.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Split710.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Split710.voices[commentators2[(int)GameManager.voices2].Split710.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Split710.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Split710.voices[commentators2[(int)GameManager.voices2].Split710.voiceIndex]);
            commentators2[(int)GameManager.voices2].Split710.voiceRandom = commentators2[(int)GameManager.voices2].Split710.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Split710.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Split710.voices[commentators2[(int)GameManager.voices2].Split710.voiceIndex]);
            commentators2[(int)GameManager.voices2].Split710.voiceCount[commentators2[(int)GameManager.voices2].Split710.voiceIndex] = commentators2[(int)GameManager.voices2].Split710.voiceIndex;
            commentators2[(int)GameManager.voices2].Split710.voiceRandom = commentators2[(int)GameManager.voices2].Split710.voiceIndex;
            commentators2[(int)GameManager.voices2].Split710.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Split710.voices.Length);
            commentators2[(int)GameManager.voices2].Split710.nextVoice++;
        }
    }

    public void SplitPick(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].SplitPick.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].SplitPick.voices[commentators1[(int)GameManager.voices1].SplitPick.voiceIndex]);
            commentators1[(int)GameManager.voices1].SplitPick.voiceRandom = commentators1[(int)GameManager.voices1].SplitPick.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].SplitPick.voices[commentators1[(int)GameManager.voices1].SplitPick.voiceIndex]);
            commentators1[(int)GameManager.voices1].SplitPick.voiceRandom = commentators1[(int)GameManager.voices1].SplitPick.voiceIndex;
            commentators1[(int)GameManager.voices1].SplitPick.voiceCount[commentators1[(int)GameManager.voices1].SplitPick.voiceIndex] = commentators1[(int)GameManager.voices1].SplitPick.voiceIndex;
            commentators1[(int)GameManager.voices1].SplitPick.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].SplitPick.voices.Length);
            commentators1[(int)GameManager.voices1].SplitPick.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].SplitPick.voices[commentators2[(int)GameManager.voices2].SplitPick.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].SplitPick.voices[commentators2[(int)GameManager.voices2].SplitPick.voiceIndex]);
            commentators2[(int)GameManager.voices2].SplitPick.voiceRandom = commentators2[(int)GameManager.voices2].SplitPick.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].SplitPick.voices[commentators2[(int)GameManager.voices2].SplitPick.voiceIndex]);
            commentators2[(int)GameManager.voices2].SplitPick.voiceCount[commentators2[(int)GameManager.voices2].SplitPick.voiceIndex] = commentators2[(int)GameManager.voices2].SplitPick.voiceIndex;
            commentators2[(int)GameManager.voices2].SplitPick.voiceRandom = commentators2[(int)GameManager.voices2].SplitPick.voiceIndex;
            commentators2[(int)GameManager.voices2].SplitPick.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].SplitPick.voices.Length);
            commentators2[(int)GameManager.voices2].SplitPick.nextVoice++;
        }
    }

    public void Most(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Most.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Most.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Most.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Most.voices[commentators1[(int)GameManager.voices1].Most.voiceIndex]);
            commentators1[(int)GameManager.voices1].Most.voiceRandom = commentators1[(int)GameManager.voices1].Most.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Most.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Most.voices[commentators1[(int)GameManager.voices1].Most.voiceIndex]);
            commentators1[(int)GameManager.voices1].Most.voiceRandom = commentators1[(int)GameManager.voices1].Most.voiceIndex;
            commentators1[(int)GameManager.voices1].Most.voiceCount[commentators1[(int)GameManager.voices1].Most.voiceIndex] = commentators1[(int)GameManager.voices1].Most.voiceIndex;
            commentators1[(int)GameManager.voices1].Most.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Most.voices.Length);
            commentators1[(int)GameManager.voices1].Most.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Most.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Most.voices[commentators2[(int)GameManager.voices2].Most.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Most.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Most.voices[commentators2[(int)GameManager.voices2].Most.voiceIndex]);
            commentators2[(int)GameManager.voices2].Most.voiceRandom = commentators2[(int)GameManager.voices2].Most.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Most.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Most.voices[commentators2[(int)GameManager.voices2].Most.voiceIndex]);
            commentators2[(int)GameManager.voices2].Most.voiceCount[commentators2[(int)GameManager.voices2].Most.voiceIndex] = commentators2[(int)GameManager.voices2].Most.voiceIndex;
            commentators2[(int)GameManager.voices2].Most.voiceRandom = commentators2[(int)GameManager.voices2].Most.voiceIndex;
            commentators2[(int)GameManager.voices2].Most.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Most.voices.Length);
            commentators2[(int)GameManager.voices2].Most.nextVoice++;
        }
    }

    public void Few(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Few.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Few.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Few.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Few.voices[commentators1[(int)GameManager.voices1].Few.voiceIndex]);
            commentators1[(int)GameManager.voices1].Few.voiceRandom = commentators1[(int)GameManager.voices1].Few.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Few.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Few.voices[commentators1[(int)GameManager.voices1].Few.voiceIndex]);
            commentators1[(int)GameManager.voices1].Few.voiceRandom = commentators1[(int)GameManager.voices1].Few.voiceIndex;
            commentators1[(int)GameManager.voices1].Few.voiceCount[commentators1[(int)GameManager.voices1].Few.voiceIndex] = commentators1[(int)GameManager.voices1].Few.voiceIndex;
            commentators1[(int)GameManager.voices1].Few.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Few.voices.Length);
            commentators1[(int)GameManager.voices1].Few.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Few.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Few.voices[commentators2[(int)GameManager.voices2].Few.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Few.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Few.voices[commentators2[(int)GameManager.voices2].Few.voiceIndex]);
            commentators2[(int)GameManager.voices2].Few.voiceRandom = commentators2[(int)GameManager.voices2].Few.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Few.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Few.voices[commentators2[(int)GameManager.voices2].Few.voiceIndex]);
            commentators2[(int)GameManager.voices2].Few.voiceCount[commentators2[(int)GameManager.voices2].Few.voiceIndex] = commentators2[(int)GameManager.voices2].Few.voiceIndex;
            commentators2[(int)GameManager.voices2].Few.voiceRandom = commentators2[(int)GameManager.voices2].Few.voiceIndex;
            commentators2[(int)GameManager.voices2].Few.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Few.voices.Length);
            commentators2[(int)GameManager.voices2].Few.nextVoice++;
        }
    }

    public void One(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].One.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].One.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].One.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].One.voices[commentators1[(int)GameManager.voices1].One.voiceIndex]);
            commentators1[(int)GameManager.voices1].One.voiceRandom = commentators1[(int)GameManager.voices1].One.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].One.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].One.voices[commentators1[(int)GameManager.voices1].One.voiceIndex]);
            commentators1[(int)GameManager.voices1].One.voiceRandom = commentators1[(int)GameManager.voices1].One.voiceIndex;
            commentators1[(int)GameManager.voices1].One.voiceCount[commentators1[(int)GameManager.voices1].One.voiceIndex] = commentators1[(int)GameManager.voices1].One.voiceIndex;
            commentators1[(int)GameManager.voices1].One.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].One.voices.Length);
            commentators1[(int)GameManager.voices1].One.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].One.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].One.voices[commentators2[(int)GameManager.voices2].One.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].One.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].One.voices[commentators2[(int)GameManager.voices2].One.voiceIndex]);
            commentators2[(int)GameManager.voices2].One.voiceRandom = commentators2[(int)GameManager.voices2].One.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].One.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].One.voices[commentators2[(int)GameManager.voices2].One.voiceIndex]);
            commentators2[(int)GameManager.voices2].One.voiceCount[commentators2[(int)GameManager.voices2].One.voiceIndex] = commentators2[(int)GameManager.voices2].One.voiceIndex;
            commentators2[(int)GameManager.voices2].One.voiceRandom = commentators2[(int)GameManager.voices2].One.voiceIndex;
            commentators2[(int)GameManager.voices2].One.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].One.voices.Length);
            commentators2[(int)GameManager.voices2].One.nextVoice++;
        }
    }

    public void Miss(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].Miss.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Miss.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].Miss.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Miss.voices[commentators1[(int)GameManager.voices1].Miss.voiceIndex]);
            commentators1[(int)GameManager.voices1].Miss.voiceRandom = commentators1[(int)GameManager.voices1].Miss.voiceIndex;
        }
        if (commentators1[(int)GameManager.voices1].Miss.voiceCount.Length >= 3)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Miss.voices[commentators1[(int)GameManager.voices1].Miss.voiceIndex]);
            commentators1[(int)GameManager.voices1].Miss.voiceRandom = commentators1[(int)GameManager.voices1].Miss.voiceIndex;
            commentators1[(int)GameManager.voices1].Miss.voiceCount[commentators1[(int)GameManager.voices1].Miss.voiceIndex] = commentators1[(int)GameManager.voices1].Miss.voiceIndex;
            commentators1[(int)GameManager.voices1].Miss.voiceIndex = Random.Range(0, commentators1[(int)GameManager.voices1].Miss.voices.Length);
            commentators1[(int)GameManager.voices1].Miss.nextVoice++;
        }
        if (commentators2[(int)GameManager.voices2].Miss.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Miss.voices[commentators2[(int)GameManager.voices2].Miss.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].Miss.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Miss.voices[commentators2[(int)GameManager.voices2].Miss.voiceIndex]);
            commentators2[(int)GameManager.voices2].Miss.voiceRandom = commentators2[(int)GameManager.voices2].Miss.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].Miss.voiceCount.Length >= 3)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Miss.voices[commentators2[(int)GameManager.voices2].Miss.voiceIndex]);
            commentators2[(int)GameManager.voices2].Miss.voiceCount[commentators2[(int)GameManager.voices2].Miss.voiceIndex] = commentators2[(int)GameManager.voices2].Miss.voiceIndex;
            commentators2[(int)GameManager.voices2].Miss.voiceRandom = commentators2[(int)GameManager.voices2].Miss.voiceIndex;
            commentators2[(int)GameManager.voices2].Miss.voiceIndex = Random.Range(0, commentators2[(int)GameManager.voices2].Miss.voices.Length);
            commentators2[(int)GameManager.voices2].Miss.nextVoice++;
        }
    }

    public void EndBad(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].EndBad.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].EndBad.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].EndBad.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].EndBad.voices[commentators1[(int)GameManager.voices1].EndBad.voiceIndex]);
            commentators1[(int)GameManager.voices1].EndBad.voiceRandom = commentators1[(int)GameManager.voices1].EndBad.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].EndBad.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].EndBad.voices[commentators2[(int)GameManager.voices2].EndBad.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].EndBad.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].EndBad.voices[commentators2[(int)GameManager.voices2].EndBad.voiceIndex]);
            commentators2[(int)GameManager.voices2].EndBad.voiceRandom = commentators2[(int)GameManager.voices2].EndBad.voiceIndex;
        }
    }

    public void EndOk(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].EndOk.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].EndOk.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].EndOk.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].EndOk.voices[commentators1[(int)GameManager.voices1].EndOk.voiceIndex]);
            commentators1[(int)GameManager.voices1].EndOk.voiceRandom = commentators1[(int)GameManager.voices1].EndOk.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].EndOk.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].EndOk.voices[commentators2[(int)GameManager.voices2].EndOk.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].EndOk.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].EndOk.voices[commentators2[(int)GameManager.voices2].EndOk.voiceIndex]);
            commentators2[(int)GameManager.voices2].EndOk.voiceRandom = commentators2[(int)GameManager.voices2].EndOk.voiceIndex;
        }
    }

    public void EndGood(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].EndGood.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].EndGood.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].EndGood.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].EndGood.voices[commentators1[(int)GameManager.voices1].EndGood.voiceIndex]);
            commentators1[(int)GameManager.voices1].EndGood.voiceRandom = commentators1[(int)GameManager.voices1].EndGood.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].EndGood.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].EndGood.voices[commentators2[(int)GameManager.voices2].EndGood.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].EndGood.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].EndGood.voices[commentators2[(int)GameManager.voices2].EndGood.voiceIndex]);
            commentators2[(int)GameManager.voices2].EndGood.voiceRandom = commentators2[(int)GameManager.voices2].EndGood.voiceIndex;
        }
    }

    public void EndGreat(AudioSource voice)
    {
        if (commentators1[(int)GameManager.voices1].EndGreat.voiceCount.Length == 1)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].EndGreat.voices[0]);
        }
        if (commentators1[(int)GameManager.voices1].EndGreat.voiceCount.Length == 2)
        {
            voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].EndGreat.voices[commentators1[(int)GameManager.voices1].EndGreat.voiceIndex]);
            commentators1[(int)GameManager.voices1].EndGreat.voiceRandom = commentators1[(int)GameManager.voices1].EndGreat.voiceIndex;
        }
        if (commentators2[(int)GameManager.voices2].EndGreat.voiceCount.Length == 1)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].EndGreat.voices[commentators2[(int)GameManager.voices2].EndGreat.voiceIndex]);
        }
        if (commentators2[(int)GameManager.voices2].EndGreat.voiceCount.Length == 2)
        {
            commentatorWait = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].EndGreat.voices[commentators2[(int)GameManager.voices2].EndGreat.voiceIndex]);
            commentators2[(int)GameManager.voices2].EndGreat.voiceRandom = commentators2[(int)GameManager.voices2].EndGreat.voiceIndex;
        }
    }

    public void SecondVoice(AudioSource voice)
    {
        voice.clip = commentatorWait;
    }

    public void Intro(AudioSource voice)
    {
        voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].intro);
    }

    public void PlayGutterball1(AudioSource voice)
    {
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Strike.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Strike.voiceCount[i] = commentators1[(int)GameManager.voices1].Strike.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Strike.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Spare.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Spare.voiceCount[i] = commentators1[(int)GameManager.voices1].Spare.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Spare.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Gutterball.voiceCount[i] = commentators1[(int)GameManager.voices1].Gutterball.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Gutterball.nextVoice = 1;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Double.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Double.voiceCount[i] = commentators1[(int)GameManager.voices1].Double.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Double.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Turkey.voiceCount[i] = commentators1[(int)GameManager.voices1].Turkey.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Turkey.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Split.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Split.voiceCount[i] = commentators1[(int)GameManager.voices1].Split.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Split.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Split710.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Split710.voiceCount[i] = commentators1[(int)GameManager.voices1].Split710.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Split710.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].SplitPick.voiceCount[i] = commentators1[(int)GameManager.voices1].SplitPick.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].SplitPick.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Most.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Most.voiceCount[i] = commentators1[(int)GameManager.voices1].Most.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Most.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Few.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Few.voiceCount[i] = commentators1[(int)GameManager.voices1].Few.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Few.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].One.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].One.voiceCount[i] = commentators1[(int)GameManager.voices1].One.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].One.nextVoice = 0;
        for (int i = 0; i < commentators1[(int)GameManager.voices1].Miss.voiceCount.Length; i++)
        {
            commentators1[(int)GameManager.voices1].Miss.voiceCount[i] = commentators1[(int)GameManager.voices1].Miss.voiceCount.Length;
        }
        commentators1[(int)GameManager.voices1].Miss.nextVoice = 0;
        voice.clip = Resources.Load<AudioClip>(commentators1[(int)GameManager.voices1].commentators + "/" + commentators1[(int)GameManager.voices1].Gutterball.voices[0]);
        commentators1[(int)GameManager.voices1].Gutterball.voiceCount[0] = 0;
    }

    public void PlayGutterball2(AudioSource voice)
    {
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Strike.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Strike.voiceCount[i] = commentators2[(int)GameManager.voices2].Strike.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Strike.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Spare.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Spare.voiceCount[i] = commentators2[(int)GameManager.voices2].Spare.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Spare.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Gutterball.voiceCount[i] = commentators2[(int)GameManager.voices2].Gutterball.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Gutterball.nextVoice = 1;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Double.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Double.voiceCount[i] = commentators2[(int)GameManager.voices2].Double.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Double.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Turkey.voiceCount[i] = commentators2[(int)GameManager.voices2].Turkey.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Turkey.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Split.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Split.voiceCount[i] = commentators2[(int)GameManager.voices2].Split.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Split.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Split710.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Split710.voiceCount[i] = commentators2[(int)GameManager.voices2].Split710.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Split710.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].SplitPick.voiceCount[i] = commentators2[(int)GameManager.voices2].SplitPick.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].SplitPick.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Most.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Most.voiceCount[i] = commentators2[(int)GameManager.voices2].Most.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Most.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Few.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Few.voiceCount[i] = commentators2[(int)GameManager.voices2].Few.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Few.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].One.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].One.voiceCount[i] = commentators2[(int)GameManager.voices2].One.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].One.nextVoice = 0;
        for (int i = 0; i < commentators2[(int)GameManager.voices2].Miss.voiceCount.Length; i++)
        {
            commentators2[(int)GameManager.voices2].Miss.voiceCount[i] = commentators2[(int)GameManager.voices2].Miss.voiceCount.Length;
        }
        commentators2[(int)GameManager.voices2].Miss.nextVoice = 0;
        voice.clip = Resources.Load<AudioClip>(commentators2[(int)GameManager.voices2].commentators + "/" + commentators2[(int)GameManager.voices2].Gutterball.voices[0]);
        commentators2[(int)GameManager.voices2].Gutterball.voiceCount[0] = 0;
    }
}
