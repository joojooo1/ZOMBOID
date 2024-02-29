using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Weapons : ScriptableObject
{
    public int WeaponType;
    public int Weapon_ID; // �� ���⿡ ���� ����ID

    public string WeaponName;
    public Sprite ItemImage;

    public bool Is_Equipping;  // ��� ����
    public body_point Equipping_Position;  // ��� ��ġ

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
}
