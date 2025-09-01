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
}
