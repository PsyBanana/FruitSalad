using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public RoundManager roundController; // referință către RoundController
    public FoodManager foodManager;         // referință către FoodManager

    public int playerCoins = 0; // bani jucător

    private void Start()
    {
        if (roundController != null)
        {
            roundController.StartRound(); // începe prima rundă
        }
        else
        {
            Debug.LogError("RoundController nu este setat în GameManager!");
        }
    }
}