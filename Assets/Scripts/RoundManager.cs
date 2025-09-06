using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    [Header("Panels/Text")]
    public Text bowlSizeText;
    public Text scoreText;
    public Text roundDetails;

    [Header("Managers")]
    public FoodManager foodManager;
    public PerkManager perkManager;
    public BowlManager bowlManager;

    public List<PerkData> activePerksThisRound;

    [Header("Strings")]

    
  

    [Header("GameInfo")]
    // Variabile pentru rundă
    public int currentRound = 1;
    public int currentScore = 0;
    public int roundScore = 0;    // ar trebui sa fac asta sa contina scorul rundei si sa il adun cu current score;
    public int quota = 50;
    public int attemptsLeft = 3;

    // Exemplu de selected bowl
    public string selectedBowl;

    // Metoda de start al rundei
    public void StartRound()
    {
        Debug.Log("StartRound() called\n" + System.Environment.StackTrace);
        Debug.Log("Round " + currentRound + " started!");
        //currentScore = 0;
        // attemptsLeft = 3;     - creaza un bug, unde de fiecare data cand interactionez cu NPC seteaza attempts = 3;
        // aici vei adăuga logica pentru alegerea bolului și ingredientelor

        //activePerksThisRound = perkManager.GetActivePerks();

        List<FoodData> currentOptions = foodManager.GetRandomFoods(3, activePerksThisRound);

        // aici poți afișa ingredientele în UI
    }


    public void TryAddIngredient(FoodData food)
    {
        string message;
        if (bowlManager.AddIngredient(food, activePerksThisRound, out message))
        {
            //currentScore = bowlManager.currentScore;

            bowlManager.filledSlots += food.sizeOccupied;// actualizează Size 
            bowlSizeText.text = bowlManager.filledSlots + "/" + bowlManager.maxSlots; // actualizeaza Size UI

            currentScore = bowlManager.CalculateCurrentScore(activePerksThisRound); // Update Score
            scoreText.text = "Score : " + currentScore;//update scor UI

            
        }
        else
        {
            Debug.LogWarning("BowlIsFull");
            // arată mesaj că bolul e plin
        }
    }

    public void UpdateQuota()
    {
        if(roundDetails != null)
        {
            roundScore += currentScore;
            roundDetails.text = "Quota: " + roundScore + "/" + quota +"\n" + "Attempts:" + attemptsLeft;
            Debug.Log("quota updated");
            currentScore = 0;
            scoreText.text = "Score : " + currentScore;//update scor UI
            bowlManager.ResetBowl();
            //roundScore.text == 0;
            //add some animation

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
