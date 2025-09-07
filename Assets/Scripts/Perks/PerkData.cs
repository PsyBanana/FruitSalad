using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PerkType
{
    Multiplier, // x2 , x3 score.
    ExtraScore, // combo extra score
    OnlySize, // depending on size bonus score
    SpawnRate // increase spawn rate of an object.
}

[CreateAssetMenu(fileName = "NewPerk", menuName = "Perks/PerkData")]
public class PerkData : ScriptableObject
{
    public string perkName;             // numele perk-ului
    public string description;          // descriere

    [Header("Perk Configuration")]
    public float value = 1f;            // multiplicator sau scor extra
    public List<FoodData> targetIngredients = new List<FoodData>(); // fructele/ingredientele vizate
    public int requiredIngredientCount = 1;   // cate ingrediente trebuie pentru multiplier
    public int onlySizeOccupied = 0;    // dacă OnlySize, ce dimensiune trebuie să aibă ingredientele

    public string spawnTargetIngredient; // object that increases probability of apparition

    [Header("Perk Metadata")]
    public int cost;
    public PerkRarity rarity;

    public enum PerkRarity { Uncommon, Rare, Legendary }

  //  [Header("Unlock Condition")]
 //   public PerkUnlockCondition unlockCondition;  // referință la ScriptableObject-ul cu condiția de unlock           -- Must finish later --



    public PerkType category;       // tipul de perk
    [System.NonSerialized] public bool hasApplied = false;
    // Metoda care aplică efectul perk-ului pe scor
    public int Apply(BowlManager bowl, int baseScore)
    {
        int score = baseScore;

        switch (category)
        {
            case PerkType.Multiplier:
                if (hasApplied) break;
                int count = 0;
                foreach (var food in bowl.currentBowl)
                    if (targetIngredients.Exists(f => f.name == food.name))
                        count++;
                if (count >= requiredIngredientCount)
                {
                    score = Mathf.CeilToInt(score * value);
                    hasApplied = true;
                }
                break;

            case PerkType.ExtraScore:
                bool hasAll = true;
                foreach (var ingredient in targetIngredients)
                {
                    bool found = false;
                    foreach (var food in bowl.currentBowl)
                        if (food == ingredient)
                            found = true;
                    if (!found)
                        hasAll = false;
                }
                if (hasAll)
                    score += Mathf.CeilToInt(value);
                break;

            case PerkType.OnlySize:
                bool onlySizeMatch = true;
                foreach (var food in bowl.currentBowl)
                    if (food.sizeOccupied != onlySizeOccupied)
                        onlySizeMatch = false;
                if (onlySizeMatch)
                    score = Mathf.CeilToInt(score * value);
                break;
        }

        return score;
    }
}