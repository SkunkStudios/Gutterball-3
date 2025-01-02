using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text playerRankText;
    public Text playerNameText;
    public Text playerScoreText;
    public Text playerStrikesText;
    public Text playerSparesText;
    public Text playerGuttersText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BowlerUpdate(int rank, string name, int score, int strikes, int spares, int gutters)
    {
        playerRankText.text = "#" + rank + ".";
        playerNameText.text = name;
        playerScoreText.text = score.ToString();
        playerStrikesText.text = strikes.ToString();
        playerSparesText.text = spares.ToString();
        playerGuttersText.text = gutters.ToString();
    }
}
