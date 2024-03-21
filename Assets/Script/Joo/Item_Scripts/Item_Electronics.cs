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
    public int Nesting_Depth;  // 최대로 중첩되는 갯수

    public string ElectronicsName;
    public string ElectronicsName_Kr;
    public float ElectronicsWeight;
    public Sprite Electronics_Image;

    public bool On;
    public GameObject PowerSources_Item;

    public int Capacity;  // PowerSources 타입에만 적용
                          // 전력 사용시 연결된 PowerSources의 용량이 줄어듦

    public float Range;  // 발전기의 전력 범위 20

    public float Condition;  // 수리해도 내구도는 10%씩 down



}
