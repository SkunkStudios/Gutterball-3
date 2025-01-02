using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour
{
    public Game game;
    public static int pinCount = 10;

    private Ball ball;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private int standing;
    private int pinFall;
    private int pinDown;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ball.isGutter)
        {
            game.pinsCounter = lastSettledCount - standing;
        }
        if (GameManager.pinMode == GameManager.PinMode.Spare)
        {
            pinCount = lastStandingCount;
        }
    }

    public void Reset()
    {
        if (GameManager.pinMode != GameManager.PinMode.Spare)
        {
            lastSettledCount = 10;
        }
        else
        {
            pinCount = lastStandingCount;
        }
        pinCount = lastSettledCount;
    }

    public void UpdateStandingCountAndSettle()
    {
        // Update the lastStandingCount
        // Call PinsHaveSettled() when they have
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastStandingCount = currentStanding;
            return;
        }
    }

    public void PinsHaveSettled()
    {
        standing = CountStanding();
        pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        if (!ball.isGutter)
        {
            pinCount = lastSettledCount;
        }
        game.Bowl(pinFall);

        lastStandingCount = -1; // Indicates pins have settled, and ball not back in box
    }

    int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }

        return standing;
    }
}
