using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour

{
    public Transform[] foodSpawnPoints;


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

    public void SpawnFoods(int count, List<PerkData> perks)
    {
        List<FoodData> foodsToSpawn = GetRandomFoods(count, perks);

        for (int i = 0; i < foodsToSpawn.Count && i < foodSpawnPoints.Length; i++)
        {
            FoodData foodData = foodsToSpawn[i];

            if (foodData.prefab != null)
            {
                // Instanțiem prefab-ul
                GameObject spawned = Instantiate(foodData.prefab,
                                                 foodSpawnPoints[i].position,
                                                 foodSpawnPoints[i].rotation);

                // Setăm datele în FoodDetailsTool
                FoodDetailsTool details = spawned.GetComponent<FoodDetailsTool>();
                if (details != null)
                {
             //       details.foodName = foodData.foodName;
              //      details.score = foodData.baseScore;
               //     details.size = foodData.sizeOccupied;

                    FoodHover hover = spawned.GetComponent<FoodHover>();
                    if (hover != null)
                        hover.foodData = foodsToSpawn[i]; // setează datele ScriptableObject


                    // Dacă folosești și un GameObject UI pentru tooltip
                    if (details.foodDetails != null)
                        details.foodDetails.SetActive(false); // ascundem tooltip la spawn
                }
            }
            else
            {
                Debug.LogWarning($"Food {foodData.foodName} nu are prefab setat!");
            }
        }
    }
}