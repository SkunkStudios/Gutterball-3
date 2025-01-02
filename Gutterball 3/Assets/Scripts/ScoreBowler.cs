using System;

[Serializable]
public class ScoreBowler
{
    public string playerName;
    public int playerScore;
    public int playerStrikes;
    public int playerSpares;
    public int playerGutters;

    public ScoreBowler(string name, int score, int strikes, int spares, int gutters)
    {
        playerName = name;
        playerScore = score;
        playerStrikes = strikes;
        playerSpares = spares;
        playerGutters = gutters;
    }
}
