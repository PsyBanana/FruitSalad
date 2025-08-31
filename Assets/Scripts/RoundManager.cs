using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public FoodManager foodManager;
    public PerkManager perkManager;
    public BowlManager bowlManager;

    public List<PerkData> activePerksThisRound;

    // Variabile pentru rundă
    public int currentRound = 1;
    public int currentScore = 0;
    public int quota = 50;
    public int attemptsLeft = 3;

    // Exemplu de selected bowl
    public string selectedBowl;

    // Metoda de start al rundei
    public void StartRound()
    {
        Debug.Log("Round " + currentRound + " started!");
        //currentScore = 0;
        attemptsLeft = 3;
        // aici vei adăuga logica pentru alegerea bolului și ingredientelor

        activePerksThisRound = perkManager.GetActivePerks();

        List<FoodData> currentOptions = foodManager.GetRandomFoods(3, activePerksThisRound);

        // aici poți afișa ingredientele în UI
    }


    public void TryAddIngredient(FoodData food)
    {
        string message;
        if (bowlManager.AddIngredient(food, activePerksThisRound, out message))
        {
            currentScore = bowlManager.currentScore;
            // actualizează scor UI
        }
        else
        {
            // arată mesaj că bolul e plin
        }
    }

    // Metoda de finalizare a rundei
    public void EndRound()
    {
        currentScore = bowlManager.CalculateCurrentScore(activePerksThisRound);
        Debug.Log("Round " + currentRound + " ended! Score: " + currentScore);
        currentRound++;
        // treci la următoarea rundă sau arată ecran de final
    }

}
