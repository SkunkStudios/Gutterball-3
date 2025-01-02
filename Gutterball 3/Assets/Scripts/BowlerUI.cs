using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlerUI : MonoBehaviour
{
    public Text playerNameText;
    public Text playerMoneyText;
    public Text playerWinText;
    public Text playerLossText;
    public Text playerStrikesText;
    public Text playerSparesText;
    public Text playerGuttersText;

    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void BowlerUpdate(string name, int money, int win, int loss, int strikes, int spares, int gutters)
    {
        playerNameText.text = name;
        playerMoneyText.text = money.ToString();
        playerWinText.text = win.ToString();
        playerLossText.text = loss.ToString();
        playerStrikesText.text = strikes.ToString();
        playerSparesText.text = spares.ToString();
        playerGuttersText.text = gutters.ToString();
    }
}
