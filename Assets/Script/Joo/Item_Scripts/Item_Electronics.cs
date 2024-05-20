using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Electronics : ScriptableObject
{
    public Type type;
    public Using_Type usingtype;
    public Electronic_usingType electronic_usingType;
    public PowerSources_Type Power_type;  // 만들어내는 or 보관하는 연료의 타입
    public PowerSources_Type UsingPower_type;  // 사용하는 연료의 타입
    public body_point[] Equipping_Position;
    public int Electronics_ID;
    public animType animType;

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
                         // 광원: 밝혀주는 범위

    public float Condition;  // 수리시 4% + (0.5 * 전기level)%를 복원


}
