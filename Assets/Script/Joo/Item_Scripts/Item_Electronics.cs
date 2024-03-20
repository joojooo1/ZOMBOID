using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Electronics : ScriptableObject
{
    public Electronic_Type type;
    public body_point[] Equipping_Position;
    public int Electronics_ID;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // ÃÖ´ë·Î ÁßÃ¸µÇ´Â °¹¼ö

    public string ElectronicsName;
    public string ElectronicsName_Kr;
    public float ElectronicsWeight;
    public Sprite Electronics_Image;

    public bool On;

    public int Capacity;
    public float Range;
    public float Condition;



}
