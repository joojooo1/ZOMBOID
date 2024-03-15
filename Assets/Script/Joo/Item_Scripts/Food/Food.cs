using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Food : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image[] FoodIcon;

    public Item_Food FoodData;

    //public Item_Food foodData { set { FoodData = value; } }

    public void SetFood(Item_Food food)
    {
        FoodData = food;
        FoodIcon[0].sprite = food.Food_Image[0];

    }

}


