using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticGameClass
{

    public static int score;
    public static int health;

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

}
