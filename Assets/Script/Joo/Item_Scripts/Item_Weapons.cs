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
    public int Weapon_ID; // 각 무기에 대한 고유ID

    public string WeaponName;
    public string WeaponName_Kr;
    public Sprite ItemImage;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // 최대로 중첩되는 갯수

    public bool Is_Equipping;  // 장비 여부
    public bool Is_TwoHand;
    public body_point[] Equipping_Position;  // 장비 위치

    public float WeaponWeight;
    public float W_Minimum_damage;
    public float W_Maximum_damage;
    public float W_Damage_done_to_doors;  // 문 파괴
    public float W_Damage_done_to_trees;  // 벌목
    public float W_Minimum_Range;
    public float W_Maximum_Range;
    public float W_Attack_speed;
    public float W_Critical_chance;  // 치명타 확률
    public float W_Critical_multiplier;  // 치명타 배율 ( 치명타 발생시 데미지 )
    public float W_Knockback;
    public float W_Knockdown;
    public float W_Max_Condition;  // 내구도
    public float W_Condition_lower_chance;  // 내구도가 내려갈 확률
    public int W_Multi_Hit;  // 다중 타격
    //public AMMO_Type Gun_Ammunition;
    //public Magazine_Type Gun_Magazine;
    public bool equip_Magagine;  // 총기류는 탄창을 장착해야 사용 가능
    public float Gun_Accuracy;  // 정확도
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
    Axe[0] = Axe  도끼
    Axe[1] = WoodAxe  벌목도끼
    Axe[2] = AxeHand  손도끼

    LongBlunt[0] = BaseballBat  야구방망이
    LongBlunt[1] = BaseballBatNails  못박은 야구방망이
    LongBlunt[2] = Crowbar  쇠지렛대
    LongBlunt[3] = Hoe  괭이
    LongBlunt[4] = Shovel  삽
    LongBlunt[5] = Sledgehamer  대형망치

    ShortBlunt[0] = NightStick  진압봉
    ShortBlunt[1] = PipeWrench  파이프렌치
    ShortBlunt[2] = Hammer  망치
    ShortBlunt[3] = BallPeenHammer  둥근머리망치

    LongBlade[0] = Katana  카타나
    LongBlade[1] = Machete  마체테

    ShortBlade[0] = HuntingKnife  사냥용 칼
    ShortBlade[1] = HandScythe  손낫
    ShortBlade[2] = Cleaver  중식도
    ShortBlade[3] = Screwdriver  스크류드라이버
    ShortBlade[4] = HandShovel  모종삽

    Spear[0] = SpearMachete  창(마체테)
    Spear[1] = Pitchfork  쇠스랑
    Spear[2] = StickSharpened  나무창
    Spear[3] = SpearStick  제작된 창

    Gun[0] = M14 Rifle  M14 단발 자동소총
    Gun[1] = ShotgunDoublebarrel  더블 배럴 산탄총
    Gun[2] = Shotgun  JS-2000 산탄총
    Gun[3] = M9_Pistol  M9 권총
    Gun[4] = M36_Revolver  M36 리볼버
 
 */