using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;

    public void AddScore(FoodData food)
    {
        currentScore += food.baseScore;
        Debug.Log("Score: " + currentScore);
    }
}
