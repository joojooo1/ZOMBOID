using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using static UnityEngine.Rendering.DebugUI;

public class Food : MonoBehaviour
{
    public Item_Food FoodData;
    public Item_Food foodData { set {  FoodData = value; } }
}
