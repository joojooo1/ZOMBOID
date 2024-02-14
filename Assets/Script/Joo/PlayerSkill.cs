using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public static PlayerSkill playerSkill;

    // 신체 능력
    public PlayerPassiveSkill_Level Fitness_Level;  // 체력
    public PlayerPassiveSkill_Level Strength_Level;  // 근력

    // 생존 능력
    // float Fishing = 0f;  // 낚시
    // float Trapping = 0f;  // 함정
    // float Foraging = 0f;  // 채집

    // 운동 능력
    public PlayerGeneralSkill_Level Sprinting_Level;  // 능숙한 달리기
    public PlayerGeneralSkill_Level Lightfooted_Level;  // 조용한 발걸음 (플레이어의 발소리가 얼마나 멀리서 들리는지)
    public PlayerGeneralSkill_Level Nimble_Level;  // 전투시 발걸음
    public PlayerGeneralSkill_Level Sneaking_Level;  // 은밀함 (은밀히 걸을때 발소리 크기&좀비가 발견할 확률)

    // 전투 능력
    public PlayerGeneralSkill_Level Axe_Level;  // 도끼
    public PlayerGeneralSkill_Level LongBlunt_Level;  // 긴 둔기
    public PlayerGeneralSkill_Level ShortBlunt_Level;  // 짧은 둔기
    public PlayerGeneralSkill_Level LongBlade_Level;  // 장검
    public PlayerGeneralSkill_Level ShortBlade_Level;  // 단검
    public PlayerGeneralSkill_Level Spear_Level;  // 창
    public PlayerGeneralSkill_Level Maintenance_Level;  // 물건관리 ( 근접무기의 내구도 소모율에 영향을 끼침 )

    // 제작 능력
    public PlayerGeneralSkill_Level Carpentry_Level;  // 목공
    public PlayerGeneralSkill_Level Cooking_Level;  // 요리
    public PlayerGeneralSkill_Level Farming_Level;  // 농사
    public PlayerGeneralSkill_Level FirstAid_Level;  // 의료
    public PlayerGeneralSkill_Level Electrical_Level;  // 전기공학
    // float Metalworking = 0f;  // 금속용접
    // float Mechanics = 0f;  // 차량정비
    // float Tailoring = 0f;  // 재단술

    // 총기
    public PlayerGeneralSkill_Level Aiming_Level;  // 조준
    public PlayerGeneralSkill_Level Reloading_Level;  // 재장전

    private void Awake()
    {
        Fitness_Level = new PlayerPassiveSkill_Level(5.0f, "Fitness");
        Strength_Level = new PlayerPassiveSkill_Level(5.0f, "Strength");

        Sprinting_Level = new PlayerGeneralSkill_Level(0f, "Sprinting");
        Lightfooted_Level = new PlayerGeneralSkill_Level(0f, "Lightfooted");
        Nimble_Level = new PlayerGeneralSkill_Level(0f, "Nimble");
        Sneaking_Level = new PlayerGeneralSkill_Level(0f, "Sneaking");

        Axe_Level = new PlayerGeneralSkill_Level(0f, "Axe");
        LongBlunt_Level = new PlayerGeneralSkill_Level(0f, "LongBlunt");
        ShortBlunt_Level = new PlayerGeneralSkill_Level(0f, "ShortBlunt");
        LongBlade_Level = new PlayerGeneralSkill_Level(0f, "LongBlade");
        ShortBlade_Level = new PlayerGeneralSkill_Level(0f, "ShortBlade");
        Spear_Level = new PlayerGeneralSkill_Level(0f, "Spear");
        Maintenance_Level = new PlayerGeneralSkill_Level(0f, "Maintenance");

        Carpentry_Level = new PlayerGeneralSkill_Level(0f, "Carpentry");
        Cooking_Level = new PlayerGeneralSkill_Level(0f, "Cooking");
        Farming_Level = new PlayerGeneralSkill_Level(0f, "Farming");
        FirstAid_Level = new PlayerGeneralSkill_Level(0f, "FirstAid");
        Electrical_Level = new PlayerGeneralSkill_Level(0f, "Electrical");

        Aiming_Level = new PlayerGeneralSkill_Level(0f, "Aiming");
        Reloading_Level = new PlayerGeneralSkill_Level(0f, "Reloading");
    }

}
