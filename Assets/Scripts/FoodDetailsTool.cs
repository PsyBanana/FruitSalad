using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodDetailsTool : MonoBehaviour
{
    public static FoodDetailsTool Instance; // singleton

    public GameObject foodDetails; // panel-ul UI
    private Text[] texts; // toate text-urile din panel

    void Awake()
    {
        // singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // optional dacă vrei să rămână între scene
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // găsește panel-ul dacă nu e setat manual
        if (foodDetails == null)
            foodDetails = GameObject.Find("DetailsPanelFood");

        if (foodDetails != null)
            texts = foodDetails.GetComponentsInChildren<Text>();
        else
            Debug.LogError("DetailsPanelFood nu a fost găsit în scenă!");
    }

    public void ShowFoodDetails(FoodData foodData)
    {
        if (foodDetails != null && foodData != null)
        {
            foodDetails.SetActive(true);
            foreach (Text t in texts)
            {
                if (t.name.Contains("Name")) t.text = "Name: " + foodData.foodName;
                if (t.name.Contains("Score")) t.text = "Score: " + foodData.baseScore;
                if (t.name.Contains("Size")) t.text = "Size: " + foodData.sizeOccupied;
            }
        }
    }

    public void HideFoodDetails()
    {
        if (foodDetails != null)
            foodDetails.SetActive(false);
    }
}