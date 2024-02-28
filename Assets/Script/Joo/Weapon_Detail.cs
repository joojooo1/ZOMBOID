using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Detail : MonoBehaviour
{
    public GameObject This_Weapon;
    public bool Is_Equipping = false;

    public int WeaponType;
    public int WeaponID; // �� ���⿡ ���� ������ �ĺ���

    public string WeaponName;
    public float WeaponWeight;
    public float W_Minimum_damage;
    public float W_Maximum_damage;
    public float W_Damage_done_to_doors;  // �� �ı�
    public float W_Damage_done_to_trees;  // ����
    public float W_Minimum_Range;
    public float W_Maximum_Range;
    public float W_Attack_speed;
    public float W_Critical_chance;  // ġ��Ÿ Ȯ��
    public float W_Knockback;
    public float W_Knockdown;
    public float W_Max_Condition;  // ������
    public float W_Condition_lower_chance;  // �������� ������ Ȯ��
    public int W_Multi_Hit;  // ���� Ÿ��

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
