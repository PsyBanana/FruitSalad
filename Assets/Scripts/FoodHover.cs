using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHover : MonoBehaviour
{
    public FoodData foodData; // setat când spawnează FoodManager

    void OnMouseEnter()
    {
     
        if (FoodDetailsTool.Instance != null)
            FoodDetailsTool.Instance.ShowFoodDetails(foodData);
    }

    void OnMouseExit()
    {
        if (FoodDetailsTool.Instance != null)
            FoodDetailsTool.Instance.HideFoodDetails();
    }

    void OnMouseDown() // click pe obiect
    {
        // trimit către RoundManager
        RoundManager roundManager = FindObjectOfType<RoundManager>();  // ar putea fi imbunatatit fara sa fie nevoie sa il caut de fiecare data.
        if (roundManager != null)
        {
            roundManager.TryAddIngredient(foodData);
        }
        else
        {
            Debug.LogWarning("No RoundManager found in scene!");
        }
    }
}
