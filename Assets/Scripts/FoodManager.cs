using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour

{
    public Transform[] foodSpawnPoints;


    public List<FoodData> allFoods; // toate ingredientele

    private List<GameObject> spawnedFoods = new List<GameObject>(); // evidenta pentru fructele spawnate.

    public List<FoodData> GetRandomFoods(int count, List<PerkData> perks)
    {
        List<FoodData> pool = new List<FoodData>(allFoods);

        foreach (PerkData perk in perks)
        {
            foreach (FoodData food in pool.ToArray())
            {
                if (!string.IsNullOrEmpty(perk.spawnTargetIngredient) && perk.spawnTargetIngredient == food.foodName)
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

        spawnedFoods.Clear();

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
                Debug.Log($"Spawning food: {foodData.foodName} at point {i}");
                // Setăm datele în FoodDetailsTool
                spawnedFoods.Add(spawned);

                FoodDetailsTool details = spawned.GetComponent<FoodDetailsTool>();

            }
            else
            {
                Debug.LogWarning($"Food {foodData.foodName} nu are prefab setat!");
            }
        }
    }

    public void ClearFoods()
    {
        foreach (var food in spawnedFoods)
        {
            if (food != null)
                Destroy(food); // distruge fiecare aliment spawn-uit
        }
        spawnedFoods.Clear();
    }

    public void RespawnFoods(int count, List<PerkData> perks)
    {
        ClearFoods();
        SpawnFoods(count, perks);
    }
}