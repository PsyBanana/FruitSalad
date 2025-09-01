using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFood", menuName = "Food/FoodData")]
public class FoodData : ScriptableObject

{
    public string foodName;     // numele fructului/ingredientului
    public int baseScore;       // scorul de bază al ingredientului
   
    public int sizeOccupied;
    public GameObject prefab;

    public Sprite icon;         // imaginea pentru UI

}
