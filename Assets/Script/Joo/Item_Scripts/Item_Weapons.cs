using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Weapons : ScriptableObject
{
    public int WeaponType;
    public int Weapon_ID; // 각 무기에 대한 고유ID

    public string WeaponName;
    public Sprite ItemImage;

    public bool Is_Equipping;  // 장비 여부
    public body_point Equipping_Position;  // 장비 위치

    public float WeaponWeight;
    public float W_Minimum_damage;
    public float W_Maximum_damage;
    public float W_Damage_done_to_doors;  // 문 파괴
    public float W_Damage_done_to_trees;  // 벌목
    public float W_Minimum_Range;
    public float W_Maximum_Range;
    public float W_Attack_speed;
    public float W_Critical_chance;  // 치명타 확률
    public float W_Knockback;
    public float W_Knockdown;
    public float W_Max_Condition;  // 내구도
    public float W_Condition_lower_chance;  // 내구도가 내려갈 확률
    public int W_Multi_Hit;  // 다중 타격
}
