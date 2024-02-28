using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Detail : MonoBehaviour
{
    public GameObject This_Weapon;
    public bool Is_Equipping = false;

    public int WeaponType;
    public int WeaponID; // 각 무기에 대한 고유한 식별자

    public string WeaponName;
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

    float W_Current_Condition;

    private void Start()
    {
        W_Current_Condition = W_Max_Condition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_main.player_main.Inven_main.Add_Weapon_Item(This_Weapon);
        }
    }

}
