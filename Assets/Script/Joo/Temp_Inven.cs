using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemConfig : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
    public int ItemID; // 고유번호 i

    public int ItemPrice; // 가격 i

    public bool ItemEquipable; // 장비가능 b
    public int ItemEquipPosition; // 장비위치 i

    //1 무기 2 방패 
    //3 장갑, 6신발, 5갑주, 4투구

    //4   1
    //5   2
    //6   3
    public bool ItemConsumAble; // 소비품 b

    public float ItemAtdStat; //물리데미지 f
    public float ItemDefStat; //물리방어 f

    public float ItemMgdStat; //마법데미지 f
    public float ItemMgResisStat; // 마법방어 f

    
}
