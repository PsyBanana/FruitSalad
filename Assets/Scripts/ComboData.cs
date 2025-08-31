using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCombo", menuName = "ComboData")]
public class ComboData : ScriptableObject
{

    public string comboName;
    public FoodData[] ingredientsRequired;
    public int bonusPoints;
    public int comboPrice;

}
