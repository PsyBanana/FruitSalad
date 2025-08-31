using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkManager : MonoBehaviour
{
    public List<PerkData> activePerks = new List<PerkData>();

    // Aplică modificările perks la un ingredient ales
    public float ApplyPerks(string ingredientName, float baseScore)
    {
        float finalScore = baseScore;

        foreach (var perk in activePerks)
        {
            switch (perk.perkType)
            {
                case PerkType.ScoreMultiplier:
                    finalScore *= perk.value; // ex: 1.2x
                    break;

                case PerkType.ExtraIngredientChance:
                    // gestionat în FoodManager, nu aici
                    break;

                case PerkType.RareIngredientOnly:
                    // gestionat în FoodManager, dacă ingredientName se potrivește
                    if (ingredientName == perk.targetIngredient)
                        finalScore *= perk.value;
                    break;
            }
        }

        return finalScore;
    }

    public List<PerkData> GetActivePerks()
    {
        return activePerks; // returnează lista actuală de perks
    }
}