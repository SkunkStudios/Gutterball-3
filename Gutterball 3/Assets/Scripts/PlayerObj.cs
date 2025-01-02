using System;

[Serializable]
public class PlayerObj
{
    public string playerName;
    public int playerMoney;
    public int playerWin;
    public int playerLoss;
    public int playerStrikes;
    public int playerSpares;
    public int playerGutters;

    public PlayerObj(string name, int money, int win, int loss, int strikes, int spares, int gutters)
    {
        playerName = name;
        playerMoney = money;
        playerWin = win;
        playerLoss = loss;
        playerStrikes = strikes;
        playerSpares = spares;
        playerGutters = gutters;
    }
}
