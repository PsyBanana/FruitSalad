using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour

{

    public List<FoodData> allFoods; // toate ingredientele

    public List<FoodData> GetRandomFoods(int count, List<PerkData> perks)
    {
        List<FoodData> pool = new List<FoodData>(allFoods);

        foreach (PerkData perk in perks)
        {
            foreach (FoodData food in pool.ToArray())
            {
                if (!string.IsNullOrEmpty(perk.targetIngredient) && perk.targetIngredient == food.foodName)
                {
                    int bonusCopies = Mathf.CeilToInt(perk.value);
                    for (int b = 0; b < bonusCopies; b++)
                        pool.Add(food); // crește șansa să apară ingredientul favorit
                }
            }
        }

        List<FoodData> selected = new List<FoodData>();
        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            selected.Add(pool[index]);
            pool.RemoveAt(index); // să nu fie duplicate
        }

        return selected;
    }
}