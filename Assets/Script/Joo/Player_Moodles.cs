using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Moodles_private_code
{
    Hungry = 0,
    Stuffed = 1,
    Thirsty = 2,
    Panic = 3,
    Bored = 4,
    Stressed = 5,
    Unhappy = 6,
    Drunk = 7,
    Heavy_Load = 8,
    Endurance = 9,
    Tired = 10,
    Hyperthermia_Hot = 11,
    Hyperthermia_Cold = 12,
    Windchill = 13,
    Wet = 14,
    Injured = 15,
    Pain = 16,
    Bleeding = 17,
    Has_a_Cold = 18,
    Sick = 19,
    Dead = 20,
    Zombie = 21,
    Restricted_Movement = 22
}

public class Player_Moodles : MonoBehaviour
{
    public static Player_Moodles playerMoodles;

    public Moodles_state Moodle_Hungry; // 배고픔
    public Moodles_state Moodle_Stuffed; // 배부름
    public Moodles_state Moodle_Thirsty; // 목마름
    public Moodles_state Moodle_Panic; // 긴장 
    public Moodles_state Moodle_Bored; // 지루함
    public Moodles_state Moodle_Stressed; // 스트레스
    public Moodles_state Moodle_Unhappy; // 불행함
    public Moodles_state Moodle_Drunk; // 취함
    public Moodles_state Moodle_Heavy_Load; // 무거움
    public Moodles_state Moodle_Endurance; // 지침
    public Moodles_state Moodle_Tired; // 피곤함
    public Moodles_state Moodle_Hyperthermia_Hot; // 더움
    public Moodles_state Moodle_Hyperthermia_Cold;  // 추움
    public Moodles_state Moodle_Windchill; // 찬 바람
    public Moodles_state Moodle_Wet; // 젖음
    public Moodles_state Moodle_Injured; // 부상
    public Moodles_state Moodle_Pain; // 고통
    public Moodles_state Moodle_Bleeding; // 출혈
    public Moodles_state Moodle_Has_a_Cold; // 감기
    public Moodles_state Moodle_Sick; // 질병
    public Moodles_state Moodle_Dead;  // 사망
    public Moodles_state Moodle_Zombie; // 좀비화
    public Moodles_state Moodle_Restricted_Movement; // 전력질주 할 수 없음

    private void Awake()
    {
        playerMoodles = this;

        Moodle_Hungry = new Moodles_state(Moodles_private_code.Hungry, 0.15f, 0.25f, 0.45f, 0.7f);
        /*
         15% 이상: -
         25% 이상: 운반능력 -1, 체온발생량 약간감소, 치유속도 -35%
         45% 이상: 운반능력 -2, 체온발생량 감소, 치유속도 -60%
         70% 이상: 운반능력 -2, 체온발생량 더욱감소, 치유속도 -60%
         */
        Moodle_Stuffed = new Moodles_state(Moodles_private_code.Stuffed, 0.15f, 0.25f, 0.45f, 0.7f);
        /*
         15% 이상: 치유속도 약간상승, 운반능력 +2
         25% 이상: 치유속도 상승, 운반능력 +2
         45% 이상: 치유속도 상승, 운반능력 +2, 식사 불가능(칼로리 수치 1000 이상일 경우)
         70% 이상: 치유속도 상승, 운반능력 +2, 식사 불가능(칼로리 수치 1000 이상일 경우)
         */
        Moodle_Thirsty = new Moodles_state(Moodles_private_code.Thirsty, 0.13f, 0.25f, 0.7f, 0.85f);
        /*
         13% 이상: -
         25% 이상: 운반능력 -1, 체온발생량 약간증가
         70% 이상: 운반능력 -2, 체온발생량 증가
         85% 이상: 운반능력 -2, 체온발생량 증가, 체력 지속적 감소 (죽거나 갈증해소할때까지)
         */
        Moodle_Panic = new Moodles_state(Moodles_private_code.Panic, 0.3f, 0.5f, 0.8f, 0.9f);  // 임의로 설정
        /*
          30% 이상(약간의 패닉): 크리티컬 확률 -1.3%
          50% 이상(공황): 크리티컬 확률 -2.6%, 근접무기데미지 -0.1,  앉은 자세에서 더 빨리 일어섬
          80% 이상(강한 패닉): 크리티컬 확률 -3.9%, 근접무기데미지 -0.2, 총 데미지 -0.4(Aiming_Level이 6부터 제외),  앉은 자세에서 더 빨리 일어섬
          90% 이상(익스트림 패닉): 크리티컬 확률 -5.2%, 근접무기데미지 -0.3, 총 데미지 -0.6(Aiming_Level이 6부터 제외),  앉은 자세에서 더 빨리 일어섬, 시야 좁아짐

          * 무기 데미지는 0.1 미만으로 낮아지지않음
         */
        Moodle_Bored = new Moodles_state(Moodles_private_code.Bored, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% 이상: -
         50% 이상: 불행 느린속도로 증가
         75% 이상: 불행 적당한 속도로 증가
         90% 이상: 불행 빠른 속도로 증가
         */
        Moodle_Stressed = new Moodles_state(Moodles_private_code.Stressed, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% 이상: -
         50% 이상: 근접 & 원거리 피해 -0.1, 불행 느린속도로 증가
         75% 이상: 근접 & 원거리 피해 -0.2, 불행 적당한 속도로 증가
         90% 이상: 근접 & 원거리 피해 -0.3, 불행 빠른 속도로 증가
         */
        Moodle_Unhappy = new Moodles_state(Moodles_private_code.Unhappy, 0.2f, 0.45f, 0.6f, 0.8f);
        /*
         20% 이상: 시간 제한이 있는 행동속도 -7.4%
         45% 이상: 시간 제한이 있는 행동속도 -13.7%
         60% 이상: 시간 제한이 있는 행동속도 -19.6%
         80% 이상: 시간 제한이 있는 행동속도 -26.5%
         */
        Moodle_Drunk = new Moodles_state(Moodles_private_code.Drunk, 0.1f, 0.3f, 0.5f, 0.7f);
        /*
         10% 이상: 피로도 약간증가, 긴장 감소 속도 증가, 고통 무들 상쇄, 불행 감소, 운전 제어력 감소
         30% 이상: 피로도 약간증가, 긴장 감소 속도 증가, 고통 무들 상쇄, 불행 감소, 운전 제어력 감소
         50% 이상: 피로도 증가, 긴장 감소 속도 증가, 고통 무들 상쇄, 불행 감소, 운전 제어력 감소
         70% 이상: 피로도 증가, 긴장 감소 속도 증가, 고통 무들 상쇄, 불행 감소, 운전 제어력 감소
         */
        Moodle_Heavy_Load = new Moodles_state(Moodles_private_code.Heavy_Load, 1f, 1.25f, 1.5f, 1.75f);
        /*
         총 부담 > 100% Weight: 낮은 울타리 넘을때/달리기/파워워크 때 넘어질 확률 +13%, 
                                크리티컬 확률 -5%, 공격 속도 -7%, 높은 울타리를 오를 확률 -8%, 
                                이동속도 -19%, 지구력 회복량 감소, 좀비의 정면공격을 막아낼 확률 -2%
         총 부담 > 125% Weight: 낮은 울타리 넘을때/달리기/파워워크 때 넘어질 확률 +26%, 
                                크리티컬 확률 -10%, 공격 속도 -14%, 높은 울타리를 오를 확률 -16%, 전력질주 불가,
                                이동속도 -37%, 지구력 회복량 심각히 감소, 좀비의 정면공격을 막아낼 확률 -4%
         총 부담 > 150% Weight: 낮은 울타리 넘을때/달리기/파워워크 때 넘어질 확률 +39%, 
                                크리티컬 확률 -15%, 공격 속도 -21%, 높은 울타리를 오를 확률 -24%, 
                                이동속도 -56%, 달리기 비활성화(파워워크 가능),
                                지구력 회복 중지 및 천천히 감소, 체력 75% 될 떄까지 서서히 감소, 
                                좀비의 정면공격을 막아낼 확률 -6%
         총 부담 > 175% Weight: 낮은 울타리 넘을때/달리기/파워워크 때 넘어질 확률 +52%, 
                                크리티컬 확률 -20%, 공격 속도 -28%, 높은 울타리를 오를 확률 -32%, 
                                이동속도 -75%, 달리기 비활성화(파워워크 가능),
                                지구력 회복 중지 및 적당한 비율로 감소, 체력 75% 될 떄까지 감소, 걷는 상태에서 지구력 감소
                                좀비의 정면공격을 막아낼 확률 -8%
         */
        Moodle_Endurance = new Moodles_state(Moodles_private_code.Endurance, 25f, 50f, 75f, 91f);
        /*
         75% 이하: 근접데미지 -50%, 공격속도 -7%, 낮은 울타리 넘을때/달리기/파워워크 때 넘어질 확률 +10%,
                   높은 울타리를 오를 확률 -5%, 걷기/달리기/파워워크 속도 -19%,
                   좀비의 정면공격을 막아낼 확률 -2%
         50% 이하: 근접데미지 -80%, 공격속도 -14%, 낮은 울타리 넘을때/달리기/파워워크 때 넘어질 확률 +20%,
                   높은 울타리를 오를 확률 -10%, 걷기/파워워크 속도 -37%,
                   달리기 비활성화, 좀비의 정면공격을 막아낼 확률 -4%
         25% 이하: 근접데미지 -90%, 공격속도 -21%, 낮은 울타리 넘을때/달리기/파워워크 때 넘어질 확률 +30%,
                   높은 울타리를 오를 확률 -15%, 걷기 속도 -56%,
                   달리기/파워워크 비활성화, 좀비의 정면공격을 막아낼 확률 -6%, 운동 비활성화
         9% 이하: 근접데미지 -95%, 공격속도 -28%, 낮은 울타리 넘을때/달리기/파워워크 때 넘어질 확률 +40%,
                   높은 울타리를 오를 확률 -20%, 걷기 속도 -75%, 큰 망치 사용불가
                   달리기/파워워크 비활성화, 좀비의 정면공격을 막아낼 확률 -8%, 운동 비활성화
         */
        Moodle_Tired = new Moodles_state(Moodles_private_code.Tired, 0.6f, 0.7f, 0.8f, 0.9f);
        /*
         60% 이상: 근접데미지 -50%, 시야 좁아짐, 지구력 회복량 크게 감소
         70% 이상: 근접데미지 -80%, 시야 좁아짐, 인식 반경 좁아짐, 지구력 회복량 심각하게 감소
         80% 이상: 근접데미지 -90%, 시야 좁아짐, 인식 반경 좁아짐, 지구력 회복량 비현실적으로 감소
         90% 이상: 근접데미지 -95%, 시야 좁아짐, 인식 반경 손상됨, 지구력 회복량 중단
         */
        Moodle_Hyperthermia_Hot = new Moodles_state(Moodles_private_code.Hyperthermia_Hot, 37.5f, 39f, 40f, 41f);  // 정상(36f)
        /*
         37.5도 이상: 갈증 약간빨리 증가
         39도 이상: 갈증 빨리 증가, 피로 빨리 증가, 공격속도 -34%, 이동속도 약간 감소
         40도 이상: 갈증 더빨리 증가, 피로 더빨리 증가, 공격속도 -67%, 이동속도 적당히 감소
         41도 이상: 갈증 현저히 증가, 피로 현저히 증가, 인지도 약간 감소, 공격속도 -90%, 이동속도 크게 감소, 체력 천천히 감소
         */
        Moodle_Hyperthermia_Cold = new Moodles_state(Moodles_private_code.Hyperthermia_Cold, 36.5f, 35f, 30f, 25f);  // 정상(36f)
        /*
         36.5도 이하: -
         35도 이하: 공격속도 -34%, 걷기/달리기 속도 적당히 감소
         30도 이하: 공격속도 -67%, 걷기/달리기 속도 크게 감소
         25도 이하: 공격속도 -90%, 걷기/달리기 속도 심하게 감소, 체력이 1%가 될때까지 천천히 감소
        */
        Moodle_Windchill = new Moodles_state(Moodles_private_code.Windchill, 2f, 5f, 7f, 9f);  // 임의로 설정
        /*
         2 이상: 실제보다 5~10도 낮게 느낌
         5 이상: 실제보다 10~15도 낮게 느낌
         7 이상: 실제보다 15~20도 낮게 느낌
         9 이상: 실제보다 20도 이상 낮게 느낌
        */
        Moodle_Wet = new Moodles_state(Moodles_private_code.Wet, 0.15f, 0.4f, 0.7f, 0.9f);
        /*
         15% 이상: 약간 젖어있음
         40% 이상: 다소 젖어있음
         70% 이상: 아플 수 있음
         90% 이상: 병에 걸릴 가능성이 높음
        */
        Moodle_Injured = new Moodles_state(Moodles_private_code.Injured, 0.8f, 0.6f, 0.4f, 0.25f);
        /*
         체력 80% 미만: -
         체력 60% 미만: 운반능력 -1
         체력 40% 미만: 운반능력 -2
         체력 25% 미만: 운반능력 -3
        */
        Moodle_Pain = new Moodles_state(Moodles_private_code.Pain, 0.8f, 0.6f, 0.4f, 0.25f);  // 임의로 설정 (부상과 동일)
        /*
         체력 80% 미만: 낮은 울타리를 넘을때/달리기/파워워크 때 넘어질 확률 +5%
         체력 60% 미만: 낮은 울타리를 넘을때/달리기/파워워크 때 넘어질 확률 +10%,
                       수면 비활성화, 부상부위에 따라 이동, 근접데미지, 공격속도 소폭 감소
         체력 40% 미만: 낮은 울타리를 넘을때/달리기/파워워크 때 넘어질 확률 +15%,
                       수면 비활성화, 부상부위에 따라 이동, 근접데미지, 공격속도 적당히 감소
         체력 25% 미만: 낮은 울타리를 넘을때/달리기/파워워크 때 넘어질 확률 +20%,
                       수면 비활성화, 부상부위에 따라 이동, 근접데미지, 공격속도 크게 감소, 운동 비활성화
        */
        Moodle_Bleeding = new Moodles_state(Moodles_private_code.Bleeding, 1f, 2f, 3f, 4f);
        /*
         출혈 상처 1개 이상: 시간이 지남에 따라 체력 천천히 손실
         출혈 상처 2개 이상: 시간이 지남에 따라 체력 어느정도 손실, 운반능력 -1
         출혈 상처 3개 이상: 시간이 지남에 따라 체력 심각하게 손실, 운반능력 -1
         출혈 상처 4개 이상: 즉시 치료하지않으면 사망에 이를 수 있음, 운반능력 -1
        */
        Moodle_Has_a_Cold = new Moodles_state(Moodles_private_code.Has_a_Cold, 0.2f, 0.4f, 0.6f, 0.8f);
        /*
         20% 이상: 재채기나 기침을 할 가능성 적음
         40% 이상: 재채기나 기침을 할 가능성 있음
         60% 이상: 재채기나 기침을 할 가능성 높아서 좀비를 피하기 어려움
         60% 이상: 재채기나 기침을 계속 해서 외딴 지역or실내가 아니면 계속 좀비를 끌어들임
        */
        Moodle_Sick = new Moodles_state(Moodles_private_code.Sick, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% 이상: 체온발생량 약간 증가, 
                   좀비화or중독이면 체력 천천히 감소
         50% 이상: 체온발생량 적당히 증가, 운반 능력 -1, 나쁜 음식or시체더미(20구이상)로 인한 경우 치유속도 느려짐,
                   좀비화or중독이면 체력 서서히 감소 & 스트레스 무들
         75% 이상: 체온발생량 더욱 증가, 운반 능력 -1, 나쁜 음식or시체더미(20구이상)로 인한 경우 치유속도 훨씬 느려짐,
                   좀비화or중독이면 체력 심각하게 감소 & 스트레스 무들
         90% 이상: 체온발생량 크게 증가, 운반 능력 -2, 나쁜 음식or시체더미(20구이상)로 인한 경우 체력이 천천히 감소,
                   좀비화or중독이면 체력 치명적으로 감소 & 스트레스 무들
        */
        Moodle_Dead = new Moodles_state(Moodles_private_code.Dead, 0f, 0f, 0f, 0f);  // 체력이 0이되면 바로 실행
        /*
         플레이어가 감염되지 않고 사망한 경우
         */
        Moodle_Zombie = new Moodles_state(Moodles_private_code.Zombie, 0f, 0f, 0f, 0f);  // 임의로 설정 (기준: 체력 0 && Dead가 아닌 경우)
        /*
         플레이어가 감염되고 사망한 경우.
         불타 재가 되지 않고나 땅에 시체를 남기는 경우 좀비로 부활
         */
        Moodle_Restricted_Movement = new Moodles_state(Moodles_private_code.Restricted_Movement, 0f, 0f, 0f, 0f); // 임의로 설정 (기준: 신발 착용 x || 다리에 부목댄 경우 || 총 부담 > 175% Weight 경우)
        /*
         맨발, 다리부상, 과부하, 무거운 옷 착용, 속도에 영향을 미침
         달리기/파워워킹 할 수 없음
         */
    }

    bool _Player_Setting_Language_to_Korean;
    public void Set_Player_Language(bool Language_type)
    {
        _Player_Setting_Language_to_Korean = Language_type;
    }

    public bool Get_Player_Language_Is_Korean()
    {
        return _Player_Setting_Language_to_Korean;
    }

}

public class Moodles_state
{
    public Moodles_private_code _Moodle_Code = new Moodles_private_code();
    string _Moodle_Name = "";
    float _Moodle_current_value = 0;  // 이 무들의 현재 상태
    int _Moodle_current_step = 0;

    // 설정된 수치를 넘기면 그 상태로 바뀜
    float _First_state = 0;
    float _Second_state = 0;
    float _Third_state = 0;
    float _Fourth_state = 0;
    string _current_state_to_string = "";
    string _current_detail_state_to_string = "";

    public Moodles_state(Moodles_private_code Moodle_Code, float First_state, float Second_state, float Third_state, float Fourth_state)
    {
        _Moodle_Code = Moodle_Code;
        _Moodle_Name = _Moodle_Code.ToString();
        _First_state = First_state;
        _Second_state = Second_state;
        _Third_state = Third_state;
        _Fourth_state = Fourth_state;
    }

    public void Set_Moodles_state(float current_value)
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Hungry:  //  0.15f, 0.25f, 0.45f, 0.7f  // Player_main_Update
                _Moodle_current_value = current_value / 300;  // 최소최대값 Player_main 에서 관리
                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if(Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "출출함";
                        _current_detail_state_to_string = "먹을 게 있으면 좋겠음.";
                    }
                    else
                    {
                        _current_state_to_string = "Peckish";
                        _current_detail_state_to_string = "Could do with a bite to eat.";
                    }
                    
                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "배고픔";
                        _current_detail_state_to_string = "말이라도 있으면 먹고 싶음.";
                    }
                    else
                    {
                        _current_state_to_string = "Hungry";
                        _current_detail_state_to_string = "Could eat a horse right now.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.35f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "매우 배고픔";
                        _current_detail_state_to_string = "근력과 치유능력이 크게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Very Hungry";
                        _current_detail_state_to_string = "Reduced strength and healing.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.6f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "굶주림";
                        _current_detail_state_to_string = "체력이 지속적으로 깎임.";
                    }
                    else
                    {
                        _current_state_to_string = "Starving";
                        _current_detail_state_to_string = "Health now just falling away...";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.6f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.26 */
            case Moodles_private_code.Stuffed:  //  0.15f, 0.25f, 0.45f, 0.7f  // Player_main_Update
                _Moodle_current_value = (current_value / 300);  // 최소최대값 Player_main 에서 관리
                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.ability_Eat = true;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "요기는 때움";
                        _current_detail_state_to_string = "신경 쓰이는 배고픔이 사라졌다.";
                    }
                    else
                    {
                        _current_state_to_string = "Satiated";
                        _current_detail_state_to_string = "Gnawing hunger entirely absent.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.ability_Eat = true;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "적당한 포만감";
                        _current_detail_state_to_string = "배가 꽉찼다. 당신의 몸을 이롭게 할 겁니다.";
                    }
                    else
                    {
                        _current_state_to_string = "Well Fed";
                        _current_detail_state_to_string = "Tummy full. Goodness is making its way through your system.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.ability_Eat = true;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "배가 든든함";
                        _current_detail_state_to_string = "위장이 만족했다. 잠깐 체력과 근력이 증가한다.";
                    }
                    else
                    {
                        _current_state_to_string = "Stuffed";
                        _current_detail_state_to_string = "Stomach contented. Health and strength aided.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.ability_Eat = false;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "어머니의 밥상";
                        _current_detail_state_to_string = "한 입 더 먹는 걸 멈추지 못했어... 근력과 치유능력이 장시간 유지됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Full to Bursting";
                        _current_detail_state_to_string = "Couldn't take another single, solitary bite.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.ability_Eat = false;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.26 */
            case Moodles_private_code.Thirsty:  //  0.13f, 0.25f, 0.7f, 0.85f  // PlayerState_Update, Player_HP_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "살짝 목마름";
                        _current_detail_state_to_string = "입이 마름.";
                    }
                    else
                    {
                        _current_state_to_string = "Slightly Thirsty";
                        _current_detail_state_to_string = "Dry Mouth.";
                    }

                    _Moodle_current_step = 1;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "많이 목마름";
                        _current_detail_state_to_string = "수분 부족.";
                    }
                    else
                    {
                        _current_state_to_string = "Thirsty";
                        _current_detail_state_to_string = "Dehydrated.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Thirsty, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "심한 갈증";
                        _current_detail_state_to_string = "정신이 혼미하고 어지러움.";
                    }
                    else
                    {
                        _current_state_to_string = "Parched";
                        _current_detail_state_to_string = "Feeling faint and dizzy.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Thirsty, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "말라죽기 직전";
                        _current_detail_state_to_string = "물을 찾아 눈이 돌아감.";
                    }
                    else
                    {
                        _current_state_to_string = "Dying of Thirst";
                        _current_detail_state_to_string = "Desperate for water.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Thirsty, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.05 */
            case Moodles_private_code.Panic:  //  0.3f, 0.5f, 0.8f, 0.9f  // Player_main_Update  // Player_main_Calculate_HitForce
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _First_state && current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "살짝 긴장됨";
                        _current_detail_state_to_string = "숨어서 심호흡을 하십시오.";
                    }
                    else
                    {
                        _current_state_to_string = "Slight Panic";
                        _current_detail_state_to_string = "Do your best to remain calm.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.013f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Second_state && current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "긴장됨";
                        _current_detail_state_to_string = "명중률이 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Panic";
                        _current_detail_state_to_string = "Accuracy reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.026f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Third_state && current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "심하게 긴장됨";
                        _current_detail_state_to_string = "명중률이 크게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Strong Panic";
                        _current_detail_state_to_string = "Accuracy severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.039f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.2f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "공황상태";
                        _current_detail_state_to_string = "명중률과 시야가 심각하게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Extreme Panic";
                        _current_detail_state_to_string = "Accuracy and vision severely reduced.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.052f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.3f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.06 */
            case Moodles_private_code.Bored:  //  0.25f, 0.5f, 0.75f, 0.9f  // 질나쁜 음식 먹을때만 반영하도록 구현 예정
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if(_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "심심함";
                        _current_detail_state_to_string = "할 일이나 즐거운 일을 만들어 보십시오.";
                    }
                    else
                    {
                        _current_state_to_string = "Getting Bored";
                        _current_detail_state_to_string = "Occupy yourself, or seek entertainment.";
                    }

                    _Moodle_current_step = 1;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "지루함";
                        _current_detail_state_to_string = "우울증에 걸릴 수 있음.";
                    }
                    else
                    {
                        _current_state_to_string = "Bored";
                        _current_detail_state_to_string = "In danger of becoming unhappy.";
                    }

                    _Moodle_current_step = 2;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "매우 지루함";
                        _current_detail_state_to_string = "우울증에 걸릴 확률이 높음.";
                    }
                    else
                    {
                        _current_state_to_string = "Very Bored";
                        _current_detail_state_to_string = "High chance of becoming unhappy.";
                    }

                    _Moodle_current_step = 3;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "극심한 지루함";
                        _current_detail_state_to_string = "우울증으로 가는 길.";
                    }
                    else
                    {
                        _current_state_to_string = "Extremely Bored";
                        _current_detail_state_to_string = "Very high chance of becoming unhappy.";
                    }

                    _Moodle_current_step = 4;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.06 */  // 질나쁜 음식 먹을때만 반영하도록 구현 예정
            case Moodles_private_code.Stressed:  //  0.25f, 0.5f, 0.75f, 0.9f  // 
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 근접무기 데미지 0 감소
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "불안함";
                        _current_detail_state_to_string = "굉장히 예민함.";
                    }
                    else
                    {
                        _current_state_to_string = "Anxious";
                        _current_detail_state_to_string = "On edge.";
                    }

                    _Moodle_current_step = 1;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 근접무기 데미지 0 감소
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "동요함";
                        _current_detail_state_to_string = "신경과민.";
                    }
                    else
                    {
                        _current_state_to_string = "Agitated";
                        _current_detail_state_to_string = "Nervous and jumpy.";
                    }

                    _Moodle_current_step = 2;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 근접무기 데미지 0.1 감소
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "심한 스트레스";
                        _current_detail_state_to_string = "식은땀이 나고 불안감이 엄습.";
                    }
                    else
                    {
                        _current_state_to_string = "Stressed";
                        _current_detail_state_to_string = "Sweaty palms. Gnawing fear.";
                    }

                    _Moodle_current_step = 3;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 근접무기 데미지 0.2 감소
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "신경과민";
                        _current_detail_state_to_string = "정신분열이 일어남.";
                    }
                    else
                    {
                        _current_state_to_string = "Nervous Wreck";
                        _current_detail_state_to_string = "Terrified.";
                    }

                    _Moodle_current_step = 4;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 근접무기 데미지 0.3 감소
                }
                break;     /* 24.03.07 */  // 좀비에게 둘러싸임, 좀비 상처 치료 안함, 자다가 타의로 강제 기상, 좀비 감염  일때 호출   // 근접무기 착용시 데미지 반영
            case Moodles_private_code.Unhappy:  //  0.2f, 0.45f, 0.6f, 0.8f  // 
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 행동속도 0.0% 감소
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "슬퍼짐";
                        _current_detail_state_to_string = "기분 전환을 할만한 것을 찾으십시오.";
                    }
                    else
                    {
                        _current_state_to_string = "Feeling a little sad";
                        _current_detail_state_to_string = "Find a way to raise your mood.";
                    }

                    _Moodle_current_step = 1;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 행동속도 7.4% 감소
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "울고 싶음";
                        _current_detail_state_to_string = "흥분될만한 행동이나 사람들을 찾으십시오.";
                    }
                    else
                    {
                        _current_state_to_string = "Getting a tad weepy";
                        _current_detail_state_to_string = "Seek some excitement or human contact.";
                    }

                    _Moodle_current_step = 2;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 행동속도 13.7% 감소
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "우울함";
                        _current_detail_state_to_string = "쓸쓸함과 슬픔에 휩싸이고 있음.";
                    }
                    else
                    {
                        _current_state_to_string = "Depressed";
                        _current_detail_state_to_string = "Ravaged by mourning and desperation.";
                    }

                    _Moodle_current_step = 3;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 행동속도 19.6% 감소
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "극심한 우울함";
                        _current_detail_state_to_string = "현실도피를 할 방법을 찾으십시오.";
                    }
                    else
                    {
                        _current_state_to_string = "Severely Depressed";
                        _current_detail_state_to_string = "Find a way to forget reality.";
                    }

                    _Moodle_current_step = 4;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // 행동속도 26.5% 감소
                }
                break;           // 전체 행동속도 감소하도록 구현 예정
            case Moodles_private_code.Drunk:  //  0.1f, 0.3f, 0.5f, 0.7f  // PlayerState_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Set_Driving_control(1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "약한 술기운";
                        _current_detail_state_to_string = "술기운이 돌기 시작.";
                    }
                    else
                    {
                        _current_state_to_string = "A Bit Tipsy";
                        _current_detail_state_to_string = "Downed some booze.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Set_Driving_control(0.95f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "조금 취함";
                        _current_detail_state_to_string = "몸이 마음대로 잘 안 움직임.";
                    }
                    else
                    {
                        _current_state_to_string = "Inebriated";
                        _current_detail_state_to_string = "Co-ordination slightly impaired.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Set_Driving_control(0.85f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "많이 취함";
                        _current_detail_state_to_string = "몸을 가누기가 힘듦.";
                    }
                    else
                    {
                        _current_state_to_string = "Plastered";
                        _current_detail_state_to_string = "Co-ordination impaired.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Set_Driving_control(0.7f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "꽐라";
                        _current_detail_state_to_string = "느어랑 나밖에 업쓰어~ 이 세상은 쓰렉기야! 사랑해~사랑해...";
                    }
                    else
                    {
                        _current_state_to_string = "Utterly Shit-Faced";
                        _current_detail_state_to_string = "Iss you an' me 'gainst the wurld. I love you. I LOVE YOU.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Set_Driving_control(0.5f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.08 */
            case Moodles_private_code.Heavy_Load:  //  1f, 1.25f, 1.5f, 1.75f  // playerInventory_Weight_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "약간 무거움";
                        _current_detail_state_to_string = "짐이 버거움.";
                    }
                    else
                    {
                        _current_state_to_string = "Fairly Heavy Load";
                        _current_detail_state_to_string = "Carrying a little too much.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.07f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.19f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.13f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.08f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.02f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "많이 무거움";
                        _current_detail_state_to_string = "이동속도가 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Heavy Load";
                        _current_detail_state_to_string = "Movement speed reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.14f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.10f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.37f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.26f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.16f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.04f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "매우 무거움";
                        _current_detail_state_to_string = "이동속도가 크게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Very Heavy Load";
                        _current_detail_state_to_string = "Movement speed highly reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.21f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.56f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.39f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.24f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.06f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "용량초과";
                        _current_detail_state_to_string = "등을 다칠 위험이 있음. 움직임이 제한됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Extremely Heavy Load";
                        _current_detail_state_to_string = "Can't take much more! Movement compromised.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.28f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.75f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.52f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.32f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.08f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    /*걷는 상태에서 지구력 감소 ( 미구현 사항 )*/
                }
                break;     /* 24.02.26 */
            case Moodles_private_code.Endurance:  //  25f, 50f, 75f, 91f  // PlayerState_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 100) { _Moodle_current_value = 100; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "약간 지침";
                        _current_detail_state_to_string = "조금만 쉬십시오.";
                    }
                    else
                    {
                        _current_state_to_string = "Moderate Exertion";
                        _current_detail_state_to_string = "Take a break.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0.5f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.07f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.19f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.1f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.02f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "많이 지침";
                        _current_detail_state_to_string = "달리기도 힘듦.";
                    }
                    else
                    {
                        _current_state_to_string = "High Exertion";
                        _current_detail_state_to_string = "Can barely jog.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0.8f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.14f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.37f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.1f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.04f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "매우 지침";
                        _current_detail_state_to_string = "걷는 것도 힘듦.";
                    }
                    else
                    {
                        _current_state_to_string = "Excessive Exertion";
                        _current_detail_state_to_string = "Can barely walk.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0.9f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.21f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.56f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.3f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.06f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "기진맥진";
                        _current_detail_state_to_string = "움직이기도 힘듦.";
                    }
                    else
                    {
                        _current_state_to_string = "Exhausted";
                        _current_detail_state_to_string = "Can barely move.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0.95f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.28f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.75f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.4f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.08f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.23 */
            case Moodles_private_code.Tired:  //  0.6f, 0.7f, 0.8f, 0.9f  // PlayerState_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "피곤함";
                        _current_detail_state_to_string = "누울 데가 있으면 좋겠음.";
                    }
                    else
                    {
                        _current_state_to_string = "Drowsy";
                        _current_detail_state_to_string = "Could do with a lie-down.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.5f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "졸림";
                        _current_detail_state_to_string = "집중력이 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Tired";
                        _current_detail_state_to_string = "Awareness reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.8f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "심한 졸림";
                        _current_detail_state_to_string = "집중력이 크게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Very Tired";
                        _current_detail_state_to_string = "Awareness severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.9f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "비몽사몽";
                        _current_detail_state_to_string = "너무 피곤하고. 힘이 안 난다. 무시무시하게 피곤하다.";
                    }
                    else
                    {
                        _current_state_to_string = "Ridiculously Tired";
                        _current_detail_state_to_string = "So tired. So desperately, inhumanly tired.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.95f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    /*
                     미구현 사항: 바닥에서 잠자기 가능, 수면 방지 무들 무시하고 잠자기 가능
                     */
                }
                break;     /* 24.03.07 */
            case Moodles_private_code.Hyperthermia_Hot:  //  37.5f, 39f, 40f, 41f  // PlayerState_Update  // Player_HP_Update  // GameManeger_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "약간 더움";
                        _current_detail_state_to_string = "더워지기 시작함. 옷을 벗고 싶음. 갈증이 증가함.";
                    }
                    else
                    {
                        _current_state_to_string = "Unpleasantly Hot";
                        _current_detail_state_to_string = "Consider taking off clothing. Thirst increased.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "지나치게 더움";
                        _current_detail_state_to_string = "목이 마르고 땀이 남. 햇빛에 과다 노출됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Overheated";
                        _current_detail_state_to_string = "Thirsty. Sweaty. Over-exposed.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.34f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.01f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0.01f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "찜통";
                        _current_detail_state_to_string = "메스껍고 집중력이 떨어짐. 수분을 찾아 혈안이 됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Sunstruck";
                        _current_detail_state_to_string = "Nauseous, unable to concentrate and desperate for liquids.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.67f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.03f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0.03f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "열사병";
                        _current_detail_state_to_string = "열사병으로 의식이 혼미함. 심각한 위기상황.";
                    }
                    else
                    {
                        _current_state_to_string = "Hyperthermic";
                        _current_detail_state_to_string = "Delirious from heat stroke and exposure. Severely endangered.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.90f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0.07f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */  // 옷입을때, 질병에 의한 발열, 좀비화, 여름 일때 호출
            case Moodles_private_code.Hyperthermia_Cold:  //  36.5f, 35f, 30f, 25f  // PlayerState_Update  // Player_HP_Update  // GameManeger_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value > _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _First_state && _Moodle_current_value > _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "쌀쌀함";
                        _current_detail_state_to_string = "여긴 좀 추운 것 같은데...";
                    }
                    else
                    {
                        _current_state_to_string = "Chilly";
                        _current_detail_state_to_string = "It feels a bit nippy around here...";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Second_state && _Moodle_current_value > _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "추움";
                        _current_detail_state_to_string = "따뜻하게 있을 방법을 찾으십시오.";
                    }
                    else
                    {
                        _current_state_to_string = "Cold";
                        _current_detail_state_to_string = "You need to find ways to keep warm.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.34f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.01f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.02f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Third_state && _Moodle_current_value > _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "매우 추움";
                        _current_detail_state_to_string = "아직 살아있다. 엄청나게 추워.";
                    }
                    else
                    {
                        _current_state_to_string = "Freezing";
                        _current_detail_state_to_string = "Man alive. It is SO cold.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.67f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.03f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.17f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value < _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "저체온증";
                        _current_detail_state_to_string = "몸과 마음이 추위에 사로잡혔음. 얼어죽는다.";
                    }
                    else
                    {
                        _current_state_to_string = "Hypothermic";
                        _current_detail_state_to_string = "Body and mind obsessed by the cold.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.90f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.47f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */  // 옷벗을때, 찬바람 무들 활성화 일때 호출
            case Moodles_private_code.Windchill:  //  2f, 5f, 7f, 9f  // GameManager
                _Moodle_current_value = current_value;
                if (current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _First_state && current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "가벼운 찬 바람";
                        _current_detail_state_to_string = "실제보다 5-10도 정도 차갑게 느낀다.";
                    }
                    else
                    {
                        _current_state_to_string = "Slight windchill";
                        _current_detail_state_to_string = "It's feeling 5 to 10 degrees colder than it actually is.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(-5.0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Second_state && current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "성가신 찬 바람";
                        _current_detail_state_to_string = "실제보다 10-15도 정도 차갑게 느낀다.";
                    }
                    else
                    {
                        _current_state_to_string = "Uncomfortable windchill";
                        _current_detail_state_to_string = "It's feeling 10 to 15 degrees colder than it actually is.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(-10.0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Third_state && current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "얼음같은 찬 바람";
                        _current_detail_state_to_string = "실제보다 15-20도 정도 차갑게 느낀다.";
                    }
                    else
                    {
                        _current_state_to_string = "Freezing windchill";
                        _current_detail_state_to_string = "It's feeling 15 to 20 degrees colder than it actually is.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(-15.0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "엄청나게 추운 바람";
                        _current_detail_state_to_string = "실제보다 20도 넘게 차갑게 느낀다.";
                    }
                    else
                    {
                        _current_state_to_string = "Horrific windchill";
                        _current_detail_state_to_string = "It's feeling more than 20 degrees colder than it actually is.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(-20.0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */
            case Moodles_private_code.Wet:  //  0.15f, 0.4f, 0.7f, 0.9f  
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "축축함";
                        _current_detail_state_to_string = "약간 축축하다. 비인가? 땀인가?";
                    }
                    else
                    {
                        _current_state_to_string = "Damp";
                        _current_detail_state_to_string = "Slightly damp. Rain, or sweat?";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "젖음";
                        _current_detail_state_to_string = "축축하다. 땀이 많이 나는 건가? 비가 많이 오는 건가?";
                    }
                    else
                    {
                        _current_state_to_string = "Wet";
                        _current_detail_state_to_string = "Sweatier, or even more rained on?";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "많이 젖음";
                        _current_detail_state_to_string = "감기에 걸릴 것 같다.";
                    }
                    else
                    {
                        _current_state_to_string = "Soaking";
                        _current_detail_state_to_string = "Chance of catching a cold.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "흠뻑 젖음";
                        _current_detail_state_to_string = "몹시 감기에 걸릴 것 같다.";
                    }
                    else
                    {
                        _current_state_to_string = "Drenched";
                        _current_detail_state_to_string = "High chance of catching a cold.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.2f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */  // 젖는 상황일때 호출
            case Moodles_private_code.Injured:  //  0.8f, 0.6f, 0.4f, 0.25f  // Player_HP_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value > _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _First_state && _Moodle_current_value > _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "경상";
                        _current_detail_state_to_string = "응급조치가 필요함.";
                    }
                    else
                    {
                        _current_state_to_string = "Discomfort";
                        _current_detail_state_to_string = "Something doesn't feel right...";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Second_state && _Moodle_current_value > _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "부상";
                        _current_detail_state_to_string = "근력과 이동속도가 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Injured";
                        _current_detail_state_to_string = "Strength and speed reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Third_state && _Moodle_current_value > _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "심각한 부상";
                        _current_detail_state_to_string = "근력과 이동속도가 크게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Severe Injuries";
                        _current_detail_state_to_string = "Strength and speed severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "치명적인 부상";
                        _current_detail_state_to_string = "편히 잠들지 못할 것 같다...";
                    }
                    else
                    {
                        _current_state_to_string = "Critical Injuries";
                        _current_detail_state_to_string = "Not going gently into that good night...";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.22 */
            case Moodles_private_code.Pain:  //  0.8f, 0.6f, 0.4f, 0.25f  // Player_HP_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value > _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.ability_Sleeping = true;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _First_state && _Moodle_current_value > _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "약간 아픔";
                        _current_detail_state_to_string = "약간의 고통을 느낌.";
                    }
                    else
                    {
                        _current_state_to_string = "Minor Pain";
                        _current_detail_state_to_string = "Feeling slight pain.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.ability_Sleeping = true;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0.05f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Second_state && _Moodle_current_value > _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "고통";
                        _current_detail_state_to_string = "이동속도와 명중률이 조금 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Pain";
                        _current_detail_state_to_string = "Speed and accuracy slightly reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.ability_Sleeping = false;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.1f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.1f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Third_state && _Moodle_current_value > _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "심한 고통";
                        _current_detail_state_to_string = "이동속도와 명중률이 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Severe Pain";
                        _current_detail_state_to_string = "Speed and accuracy reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.ability_Sleeping = false;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0.15f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "극도의 고통";
                        _current_detail_state_to_string = "이동속도와 명중률이 크게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Agony";
                        _current_detail_state_to_string = "Speed and accuracy severely reduced.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.ability_Sleeping = false;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0.2f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.27 */
            case Moodles_private_code.Bleeding:  //  1f, 2f, 3f, 4f  // Player_HP_Update  // PlayerState_Player_body_Location
                _Moodle_current_value = current_value;
                if (current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _First_state && current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "경미한 출혈";
                        _current_detail_state_to_string = "붕대가 필요합니다.";
                    }
                    else
                    {
                        _current_state_to_string = "Minor Bleeding";
                        _current_detail_state_to_string = "Bandage required.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Second_state && current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "출혈";
                        _current_detail_state_to_string = "근력과 이동속도가 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Bleeding";
                        _current_detail_state_to_string = "Strength and speed reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Third_state && current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "심한 출혈";
                        _current_detail_state_to_string = "근력과 이동속도가 크게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Severe Bleeding";
                        _current_detail_state_to_string = "Strength and speed severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "대규모 혈액 손실";
                        _current_detail_state_to_string = "사망 직전.";
                    }
                    else
                    {
                        _current_state_to_string = "Massive Blood Loss";
                        _current_detail_state_to_string = "Death imminent.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.22 */
            case Moodles_private_code.Has_a_Cold:  //  0.2f, 0.4f, 0.6f, 0.8f  // PlayerState_Update  // Player_main_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Is_Cold = false;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "콧물이 남";
                        _current_detail_state_to_string = "가끔씩 재채기를 함.";
                    }
                    else
                    {
                        _current_state_to_string = "Runny Nose";
                        _current_detail_state_to_string = "Occasional sneezing.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Is_Cold = true;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "두통이 동반된 콧물";
                        _current_detail_state_to_string = "자꾸만 재채기를 함.";
                    }
                    else
                    {
                        _current_state_to_string = "The Sniffles";
                        _current_detail_state_to_string = "Prone to sneezing.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Is_Cold = true;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "감기";
                        _current_detail_state_to_string = "기침을 동반한 재채기. 이동속도와 치유능력이 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "You Have A Cold";
                        _current_detail_state_to_string = "Sneezing and coughing. Speed and healing reduced.";
                    }
                   
                    _Moodle_current_step = 3;
                    Player_main.player_main.Is_Cold = true;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "지독한 감기";
                        _current_detail_state_to_string = "이동속도와 치유능력이 크게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "You Have A Nasty Cold";
                        _current_detail_state_to_string = "Speed and healing now severely reduced.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Is_Cold = true;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.6f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.4f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */
            case Moodles_private_code.Sick:  //  0.25f, 0.5f, 0.75f, 0.9f  //
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "속이 안 좋음";
                        _current_detail_state_to_string = "쉬어가면서 행동하십시오.";
                    }
                    else
                    {
                        _current_state_to_string = "Queasy";
                        _current_detail_state_to_string = "Take things easy.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.05f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "메스꺼움";
                        _current_detail_state_to_string = "근력과 치유능력이 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Nauseous";
                        _current_detail_state_to_string = "Strength and healing reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "아픔";
                        _current_detail_state_to_string = "근력과 치유능력이 크게 저하됨.";
                    }
                    else
                    {
                        _current_state_to_string = "Sick";
                        _current_detail_state_to_string = "Strength and healing severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.3f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4단계
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "고열";
                        _current_detail_state_to_string = "죽음의 위험이 점점 커짐.";
                    }
                    else
                    {
                        _current_state_to_string = "Fever";
                        _current_detail_state_to_string = "Increasing danger of death.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.5f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.08 */  // 상한 음식 or 독이 든 음식 섭취, 좀비 감염 일때 호출
            case Moodles_private_code.Dead:  // 비감염 && 사망  // Player_HP_Update
                if (current_value == _First_state && 
                    Player_main.player_main.playerState.Get_Is_Infection() == false)
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "사망";
                        _current_detail_state_to_string = "쥐 먹이가 될 확률이 높음.";
                    }
                    else
                    {
                        _current_state_to_string = "Deceased";
                        _current_detail_state_to_string = "High chance of becoming rat food.";
                    }

                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    /* 죽는 animation 필요함 */
                }
                break;     /* 24.03.08 */
            case Moodles_private_code.Zombie:  // 감염 && 사망  // Player_HP_Update
                if (current_value == _First_state &&
                    Player_main.player_main.playerState.Get_Is_Infection() == true)
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "좀비화";
                        _current_detail_state_to_string = "사람이 맛있어 보임.";
                    }
                    else
                    {
                        _current_state_to_string = "Zombified";
                        _current_detail_state_to_string = "Sudden desire to eat people.";
                    }

                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    /* 좀비화되는 animation 필요함 */
                }
                break;     /* 24.03.08 */
            default:
                break;

        }

    }

    public string Get_current_state_to_string()
    {
        return _current_state_to_string;
    }

    public string Get_current_detail_state_to_string()
    {
        return _current_detail_state_to_string;
    }

    public float Get_Moodle_current_value()
    {
        return _Moodle_current_value;
    }

    public int Get_Moodle_current_step()
    {
        return _Moodle_current_step;
    }

}

