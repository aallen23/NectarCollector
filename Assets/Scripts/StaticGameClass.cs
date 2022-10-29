using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticGameClass
{

    public static int score = 0;
    public static int health = 3;

    public static bool playing = false;

    public static void PlayingTrue()
    {
        playing = true;
    }

    public static void PlayingFalse()
    {
        playing = false;
    }

    public static int GetScore()
    {
        return score;
    }

    public static int GetHealth()
    {
        return health;
    }

    public static void IncreaseScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public static void TakeDamage()
    {
        health--;
    }

    public static void ResetHealth()
    {
        health = 3;
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
