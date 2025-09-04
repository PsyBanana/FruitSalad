using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlManager : MonoBehaviour
{

    public int currentScore = 0; // Bowl Score
    
    public int maxSlots = 5;
    public int filledSlots = 0;
    public List<FoodData> currentBowl = new List<FoodData>();

    public Text bowlSizeText;

    public bool AddIngredient(FoodData food, List<PerkData> perks, out string message)
    {
        if(GetUsedSlots() + food.sizeOccupied <= maxSlots)
        {
            currentBowl.Add(food);
            // calculează scorul ingredientului inclusiv bonus perk
            int foodScore = food.baseScore;
            foreach (var perk in perks)
            {
                if (perk.perkType == PerkType.ScoreBonus)
                    foodScore += Mathf.CeilToInt(perk.value); // daca perk.value e int
            }

            currentScore += foodScore; // adaugă la scorul curent
            message = "Ingredient added!";
            return true;
        }
        message = "No space left in the bowl!";
        return false;
    }
    public int CalculateCurrentScore(List<PerkData> perks)
    {
        int score = 0;
        foreach (var food in currentBowl)
            score += food.baseScore;

        // aplic perks care cresc scorul
        foreach (var perk in perks)
        {
            if (perk.perkType == PerkType.ScoreBonus)
            {
                score += Mathf.CeilToInt(perk.value);
            }
        }

        return score;
    }

    public void UpdateStats()  //update visuals and more
    {
        
        bowlSizeText.text = filledSlots + "/" + maxSlots;


      
    }

    public int GetUsedSlots() // increase size in bowl
    {
        int used = 0;
        foreach (var food in currentBowl)
            used += food.sizeOccupied;
        return used;
    }

    public void ResetBowl()
    {
        currentBowl.Clear();
        currentScore = 0;
    }


}
