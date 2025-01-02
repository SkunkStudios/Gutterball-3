using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMasterOldBall3
{
    public enum Action { Tidy, Reset, EndTurn, EndGame };

    private int[] bowls = new int[30];
    private int bowl = 1;

    public static Action NextAction(List<int> pinfFalls)
    {
        ActionMasterOldBall3 am = new ActionMasterOldBall3();
        Action currentAction = new Action();

        foreach (int pinFall in pinfFalls)
        {
            currentAction = am.Bowl(pinFall);
        }

        return currentAction;
    }

    private Action Bowl(int pins)
    { // TODO make private
        if (pins < 0 || pins > 10) { throw new UnityException("Invalid pins"); }

        bowls[bowl - 1] = pins;

        if (bowl == 30)
        {
            return Action.EndGame;
        }

        // Handle last-frame special cases
        if (bowl >= 28 && pins == 10)
        {
            bowl++;
            return Action.Reset;
        }
        else if (bowl == 30)
        {
            bowl++;
            if (bowls[28 - 1] == 10 && bowls[29 - 1] == 0)
            {
                return Action.Tidy;
            }
            else if (bowls[28 - 1] + bowls[29 - 1] == 10)
            {
                return Action.Reset;
            }
            return Action.EndGame;
        }

        if (bowl % 3 != 0)
        { // First bowl of frame
            if (pins == 10)
            {
                bowl += 3;
                return Action.EndTurn;
            }
            else
            {
                bowl += 1;
                return Action.Tidy;
            }
        }
        else if (bowl % 3 == 0)
        { // Third bowl of frame
            bowl += 1;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }
}