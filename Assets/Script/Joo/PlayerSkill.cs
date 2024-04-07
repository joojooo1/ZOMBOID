using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public static PlayerSkill playerSkill;

    // 신체 능력
    public PlayerPassiveSkill_Level Fitness_Level;  // 체력       /* 24.02.16 test */
    public PlayerPassiveSkill_Level Strength_Level;  // 근력       /* 24.02.16 test */

    // 생존 능력
    public PlayerSurvivalSkill_Level Hunting_Level;  // 사냥  // 함정포함
    public PlayerSurvivalSkill_Level Fishing_Level;  // 낚시
    public PlayerSurvivalSkill_Level Foraging_Level;  // 채집
    public PlayerSurvivalSkill_Level Riding_Level;  // 승마

    // 운동 능력
    public PlayerGeneralSkill_Level Sprinting_Level;  // 능숙한 달리기                                                    /* 24.02.16 test */
    public PlayerGeneralSkill_Level Lightfooted_Level;  // 조용한 발걸음 (플레이어의 발소리가 얼마나 멀리서 들리는지)        /* 24.02.16 test */
    public PlayerGeneralSkill_Level Nimble_Level;  // 조준시 발걸음                                                       /* 24.02.16 test */
    public PlayerGeneralSkill_Level Sneaking_Level;  // 은밀한 움직임 (은밀히 걸을때 발소리 크기&좀비가 발견할 확률)                /* 24.02.16 test */

    // 전투 능력
    public PlayerWeaponSkill_Level Axe_Level;  // 도끼
    public PlayerWeaponSkill_Level LongBlunt_Level;  // 긴 둔기
    public PlayerWeaponSkill_Level ShortBlunt_Level;  // 짧은 둔기
    public PlayerWeaponSkill_Level LongBlade_Level;  // 장검
    public PlayerWeaponSkill_Level ShortBlade_Level;  // 단검
    public PlayerWeaponSkill_Level Spear_Level;  // 창

    public PlayerMaintenanceSkill_Level Maintenance_Level;  // 물건관리 ( 근접무기의 내구도 소모율에 영향을 끼침 )

    // 총기
    public PlayerGunSkill_Level Aiming_Level;  // 조준
    public PlayerGunSkill_Level Reloading_Level;  // 재장전

    // 제작 능력
    public PlayerCraftingSkill_Level Carpentry_Level;  // 목공
    public PlayerCraftingSkill_Level Cooking_Level;  // 요리
    public PlayerCraftingSkill_Level Farming_Level;  // 농사
    public PlayerCraftingSkill_Level FirstAid_Level;  // 의료
    public PlayerCraftingSkill_Level Electrical_Level;  // 전기공학
    // public PlayerCraftingSkill_Level Tailoring_Level;  // 재단술
    // float Metalworking = 0f;  // 금속용접
    // float Mechanics = 0f;  // 차량정비

    private void Awake()
    {
        playerSkill = this;

        Fitness_Level = new PlayerPassiveSkill_Level(5.0f, "Fitness", "체력");
        Strength_Level = new PlayerPassiveSkill_Level(5.0f, "Strength", "근력");

        Hunting_Level = new PlayerSurvivalSkill_Level(0f, "Hunting", "사냥");
        Fishing_Level = new PlayerSurvivalSkill_Level(0f, "Fishing", "낚시");
        Foraging_Level = new PlayerSurvivalSkill_Level(0f, "Foraging", "채집");
        Riding_Level = new PlayerSurvivalSkill_Level(0f, "Riding", "승마");

        Sprinting_Level = new PlayerGeneralSkill_Level(0f, "Sprinting", "능숙한 달리기");
        Lightfooted_Level = new PlayerGeneralSkill_Level(0f, "Lightfooted", "조용한 발걸음");
        Nimble_Level = new PlayerGeneralSkill_Level(0f, "Nimble", "조준시 발걸음");
        Sneaking_Level = new PlayerGeneralSkill_Level(0f, "Sneaking", "은밀한 움직임");

        Axe_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.Axe, "Axe", "도끼");
        LongBlunt_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.LongBlunt, "LongBlunt", "긴 둔기");
        ShortBlunt_Level = new  (0f, Weapon_type.ShortBlunt, "ShortBlunt", "짧은 둔기");
        LongBlade_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.LongBlade, "LongBlade", "장검");
        ShortBlade_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.ShortBlade, "ShortBlade", "단검");
        Spear_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.Spear, "Spear", "창");

        Maintenance_Level = new PlayerMaintenanceSkill_Level(0f, "Maintenance", "물건관리");

        Aiming_Level = new PlayerGunSkill_Level(0f, Weapon_type.Gun, "Aiming", "조준");
        Reloading_Level = new PlayerGunSkill_Level(0f, Weapon_type.Gun, "Reloading", "재장전");

        Carpentry_Level = new PlayerCraftingSkill_Level(0f, "Carpentry", "목공");
        Cooking_Level = new PlayerCraftingSkill_Level(0f, "Cooking", "요리");
        Farming_Level = new PlayerCraftingSkill_Level(0f, "Farming", "농사");
        FirstAid_Level = new PlayerCraftingSkill_Level(0f, "FirstAid", "의료");
        Electrical_Level = new PlayerCraftingSkill_Level(0f, "Electrical", "전기공학");
       

    }

}
