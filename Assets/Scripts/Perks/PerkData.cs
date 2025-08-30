using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PerkType
{
    ScoreMultiplier,
    ExtraIngredientChance,
    RareIngredientOnly
}

[CreateAssetMenu(fileName = "NewPerk", menuName = "Perks/PerkData")]
public class PerkData : ScriptableObject
{
    public string perkName;
    public PerkType perkType;
    public float value; // multiplicator sau procentaj
    public string targetIngredient; // optional, pentru perks care afectează un ingredient specific
}