using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Weapons : ScriptableObject
{
    public Type type;
    public Using_Type[] Usingtype;
    public PowerSources_Type Power_type;
    public Weapon_type WeaponType;
    public bool created;
    public int Weapon_ID; // �� ���⿡ ���� ����ID

    public string WeaponName;
    public string WeaponName_Kr;
    public Sprite ItemImage;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public bool Is_Equipping;  // ��� ����
    public bool Is_TwoHand;
    public body_point[] Equipping_Position;  // ��� ��ġ

    public float WeaponWeight;
    public float W_Minimum_damage;
    public float W_Maximum_damage;
    public float W_Damage_done_to_doors;  // �� �ı�
    public float W_Damage_done_to_trees;  // ����
    public float W_Minimum_Range;
    public float W_Maximum_Range;
    public float W_Attack_speed;
    public float W_Critical_chance;  // ġ��Ÿ Ȯ��
    public float W_Critical_multiplier;  // ġ��Ÿ ���� ( ġ��Ÿ �߻��� ������ )
    public float W_Knockback;
    public float W_Knockdown;
    public float W_Max_Condition;  // ������
    public float W_Condition_lower_chance;  // �������� ������ Ȯ��
    public int W_Multi_Hit;  // ���� Ÿ��
    //public AMMO_Type Gun_Ammunition;
    //public Magazine_Type Gun_Magazine;
    public bool equip_Magagine;  // �ѱ���� źâ�� �����ؾ� ��� ����
    public float Gun_Accuracy;  // ��Ȯ��
    public float Gun_Additional_Accuracy_point;
    public float Gun_Additional_Critical_chance;
    public float Gun_Noise_radius;
    public float Gun_Max_Capacity;
    public float Gun_Aiming_time;
    public float Gun_Reload_time;
   // public animType animType;
    public AudioClip audioClip;
    public float audioClip_range;
}



/*  
    Axe[0] = Axe  ����
    Axe[1] = WoodAxe  ���񵵳�
    Axe[2] = AxeHand  �յ���

    LongBlunt[0] = BaseballBat  �߱������
    LongBlunt[1] = BaseballBatNails  ������ �߱������
    LongBlunt[2] = Crowbar  ��������
    LongBlunt[3] = Hoe  ����
    LongBlunt[4] = Shovel  ��
    LongBlunt[5] = Sledgehamer  ������ġ

    ShortBlunt[0] = NightStick  ���к�
    ShortBlunt[1] = PipeWrench  ��������ġ
    ShortBlunt[2] = Hammer  ��ġ
    ShortBlunt[3] = BallPeenHammer  �ձٸӸ���ġ

    LongBlade[0] = Katana  īŸ��
    LongBlade[1] = Machete  ��ü��

    ShortBlade[0] = HuntingKnife  ��ɿ� Į
    ShortBlade[1] = HandScythe  �ճ�
    ShortBlade[2] = Cleaver  �߽ĵ�
    ShortBlade[3] = Screwdriver  ��ũ������̹�
    ShortBlade[4] = HandShovel  ������

    Spear[0] = SpearMachete  â(��ü��)
    Spear[1] = Pitchfork  �轺��
    Spear[2] = StickSharpened  ����â
    Spear[3] = SpearStick  ���۵� â

    Gun[0] = M14 Rifle  M14 �ܹ� �ڵ�����
    Gun[1] = ShotgunDoublebarrel  ���� �跲 ��ź��
    Gun[2] = Shotgun  JS-2000 ��ź��
    Gun[3] = M9_Pistol  M9 ����
    Gun[4] = M36_Revolver  M36 ������
 
 */