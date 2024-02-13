using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    // 신체 능력
    protected float Min_Fitness = 0f;  // 최소 체력
    protected float Max_Fitness = 10f;  // 최대 체력
    protected float Min_Strength = 0f;  // 최소 근력
    protected float Max_Strength = 10f;  // 최대 근력

    // 생존 능력
    // float Fishing = 0f;  // 낚시
    // float Trapping = 0f;  // 함정
    // float Foraging = 0f;  // 채집

    // 운동 능력
    protected float Min_Sprinting = 0f;  // 달리기
    protected float Max_Sprinting = 10f;  
    protected float Min_Lightfooted = 0f;  // 민첩함
    protected float Max_Lightfooted = 10f;  
    protected float Min_Nimble = 0f;  // 날렵함
    protected float Max_Nimble = 10f; 
    protected float Min_Sneaking = 0f;  // 은밀함
    protected float Max_Sneaking = 10f;  

    // 전투 능력
    protected float Min_Axe = 0f;  // 도끼
    protected float Max_Axe = 10f;
    protected float Min_LongBlunt = 0f;  // 긴 둔기
    protected float Max_LongBlunt = 10f;
    protected float Min_ShortBlunt = 0f;  // 짧은 둔기
    protected float Max_ShortBlunt = 10f;
    protected float Min_LongBlade = 0f;  // 장검
    protected float Max_LongBlade = 10f;
    protected float Min_ShortBlade = 0f;  // 단검
    protected float Max_ShortBlade = 10f;
    protected float Min_Spear = 0f;  // 창
    protected float Max_Spear = 10f;
    protected float Min_Maintenance = 0f;  // 물건관리
    protected float Max_Maintenance = 10f;

    // 제작 능력
    protected float Min_Carpentry = 0f;  // 목공
    protected float Max_Carpentry = 10f;
    protected float Min_Cooking = 0f;  // 요리
    protected float Max_Cooking = 10f;
    protected float Min_Farming = 0f;  // 농사
    protected float Max_Farming = 10f;
    protected float Min_FirstAid = 0f;  // 의료
    protected float Max_FirstAid = 10f;
    protected float Min_Electrical = 0f;  // 전기공학
    protected float Max_Electrical = 10f;
    // float Metalworking = 0f;  // 금속용접
    // float Mechanics = 0f;  // 차량정비
    // float Tailoring = 0f;  // 재단술

    // 총기
    protected float Min_Aiming = 0f;  // 조준
    protected float Max_Aiming = 10f;
    protected float Min_Reloading = 0f;  // 재장전
    protected float Max_Reloading = 10f;

}
