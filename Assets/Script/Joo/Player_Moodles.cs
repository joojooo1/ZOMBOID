using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Moodle_Hungry = new Moodles_state("Hungry", 0f, 0.15f, 0.25f, 0.45f, 0.7f);
        /*
         15% 이상: -
         25% 이상: 운반능력 -1, 체온발생량 약간감소, 치유속도 -35%
         45% 이상: 운반능력 -2, 체온발생량 감소, 치유속도 -60%
         70% 이상: 운반능력 -2, 체온발생량 더욱감소
         */
        Moodle_Stuffed = new Moodles_state("Stuffed", 0f, 0.15f, 0.25f, 0.45f, 0.7f);
        /*
         15% 이상: 치유속도 약간상승, 힘 증가
         25% 이상: 치유속도 상승, 힘 증가
         45% 이상: 치유속도 상승, 힘 증가, 식사 불가능
         70% 이상: 치유속도 상승, 힘 증가, 식사 불가능
         */
        Moodle_Thirsty = new Moodles_state("Thirsty", 0f, 0.13f, 0.25f, 0.7f, 0.85f);
        /*
         13% 이상: -
         25% 이상: 운반능력 -1, 체온발생량 약간증가
         70% 이상: 운반능력 -2, 체온발생량 증가
         85% 이상: 운반능력 -2, 체온발생량 증가, 체력 지속적 감소 (죽거나 갈증해소할때까지)
         */
        Moodle_Panic = new Moodles_state("Panic", 0f, 0.3f, 0.5f, 0.8f, 0.9f);  // 임의로 설정
        /*
          30% 이상(약간의 패닉): 크리티컬 확률 -1.3%
          50% 이상(공황): 크리티컬 확률 -2.6%, 근접무기데미지 -0.1,  앉은 자세에서 더 빨리 일어섬
          80% 이상(강한 패닉): 크리티컬 확률 -3.9%, 근접무기데미지 -0.2, 총 데미지 -0.4(Aiming_Level이 6부터 제외),  앉은 자세에서 더 빨리 일어섬
          90% 이상(익스트림 패닉): 크리티컬 확률 -5.2%, 근접무기데미지 -0.3, 총 데미지 -0.6(Aiming_Level이 6부터 제외),  앉은 자세에서 더 빨리 일어섬, 시야 좁아짐

          * 무기 데미지는 0.1 미만으로 낮아지지않음
         */
        Moodle_Bored = new Moodles_state("Bored", 0f, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% 이상: -
         50% 이상: 불행 느린속도로 증가
         75% 이상: 불행 적당한 속도로 증가
         90% 이상: 불행 빠른 속도로 증가
         */
        Moodle_Stressed = new Moodles_state("Stressed", 0f, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% 이상: -
         50% 이상: 근접 & 원거리 피해 -0.1, 불행 느린속도로 증가
         75% 이상: 근접 & 원거리 피해 -0.2, 불행 적당한 속도로 증가
         90% 이상: 근접 & 원거리 피해 -0.3, 불행 빠른 속도로 증가
         */
        Moodle_Unhappy = new Moodles_state("Unhappy", 0f, 0.2f, 0.45f, 0.6f, 0.8f);
        /*
         20% 이상: 시간 제한이 있는 행동속도 -7.4%
         45% 이상: 시간 제한이 있는 행동속도 -13.7%
         60% 이상: 시간 제한이 있는 행동속도 -19.6%
         80% 이상: 시간 제한이 있는 행동속도 -26.5%
         */
        Moodle_Drunk = new Moodles_state("Drunk", 0f, 0.1f, 0.3f, 0.5f, 0.7f);
        /*
         10% 이상: 피로도 약간증가, 체온발생량 약간감소
         30% 이상: 피로도 약간증가, 체온발생량 약간감소
         50% 이상: 피로도 증가, 체온발생량 감소
         70% 이상: 피로도 증가, 체온발생량 감소
         */
        Moodle_Heavy_Load = new Moodles_state("Heavy_Load", 0f, 1f, 1.25f, 1.5f, 1.75f);
        /*
         총 부담 > 100% Weight: 낮은 울타리 넘을때 넘어질 확률 +13%, 달리기/파워워크 때 넘어질 확률 +13%, 
                                크리티컬 확률 -5%, 공격 속도 -7%, 높은 울타리를 오를 확률 -8%, 
                                걷기/달리기/파워워크 속도 -19%, 지구력 회복량 감소, 좀비의 정면공격을 막아낼 확률 -2%
         총 부담 > 125% Weight: 낮은 울타리 넘을때 넘어질 확률 +26%, 달리기/파워워크 때 넘어질 확률 +26%, 
                                크리티컬 확률 -10%, 공격 속도 -14%, 높은 울타리를 오를 확률 -16%, 
                                걷기/달리기/파워워크 속도 -37%, 지구력 회복량 심각히 감소, 좀비의 정면공격을 막아낼 확률 -4%
         총 부담 > 150% Weight: 낮은 울타리 넘을때 넘어질 확률 +39%, 달리기/파워워크 때 넘어질 확률 +39%, 
                                크리티컬 확률 -15%, 공격 속도 -21%, 높은 울타리를 오를 확률 -24%, 
                                걷기/달리기/파워워크 속도 -56%, 달리기 비활성화(파워워크 가능),
                                지구력 회복 중지 및 천천히 감소, 체력 75% 될 떄까지 감소, 
                                좀비의 정면공격을 막아낼 확률 -6%
         총 부담 > 175% Weight: 낮은 울타리 넘을때 넘어질 확률 +52%, 달리기/파워워크 때 넘어질 확률 +52%, 
                                크리티컬 확률 -20%, 공격 속도 -28%, 높은 울타리를 오를 확률 -32%, 
                                걷기/달리기/파워워크 속도 -75%, 달리기 비활성화(파워워크 가능),
                                지구력 회복 중지 및 적당한 비율로 감소, 체력 75% 될 떄까지 감소, 
                                좀비의 정면공격을 막아낼 확률 -8%
         */
        Moodle_Endurance = new Moodles_state("Endurance", 0f, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% 이상: 근접데미지 -50%, 공격속도 -7%, 낮은 울타리 넘을때 넘어질 확률 +10%,
                   달리기/파워워크 때 넘어질 확률 +10%, 높은 울타리를 오를 확률 -5%, 걷기/달리기/파워워크 속도 -19%,
                   좀비의 정면공격을 막아낼 확률 -2%
         50% 이상: 근접데미지 -80%, 공격속도 -14%, 낮은 울타리 넘을때 넘어질 확률 +20%,
                   달리기/파워워크 때 넘어질 확률 +20%, 높은 울타리를 오를 확률 -10%, 걷기/파워워크 속도 -37%,
                   달리기 비활성화, 좀비의 정면공격을 막아낼 확률 -4%
         75% 이상: 근접데미지 -90%, 공격속도 -21%, 낮은 울타리 넘을때 넘어질 확률 +30%,
                   달리기/파워워크 때 넘어질 확률 +30%, 높은 울타리를 오를 확률 -15%, 걷기 속도 -56%,
                   달리기/파워워크 비활성화, 좀비의 정면공격을 막아낼 확률 -6%, 운동 비활성화
         90% 이상: 근접데미지 -95%, 공격속도 -28%, 낮은 울타리 넘을때 넘어질 확률 +40%,
                   달리기/파워워크 때 넘어질 확률 +40%, 높은 울타리를 오를 확률 -20%, 걷기 속도 -75%, 큰 망치 사용불가
                   달리기/파워워크 비활성화, 좀비의 정면공격을 막아낼 확률 -8%, 운동 비활성화
         */
        Moodle_Tired = new Moodles_state("Tired", 0f, 0.6f, 0.7f, 0.8f, 0.9f);
        /*
         60% 이상: 근접데미지 -50%, 시야 좁아짐, 지구력 회복량 크게 감소
         70% 이상: 근접데미지 -80%, 시야 좁아짐, 인식 반경 좁아짐, 지구력 회복량 심각하게 감소
         80% 이상: 근접데미지 -90%, 시야 좁아짐, 인식 반경 좁아짐, 지구력 회복량 비현실적으로 감소
         90% 이상: 근접데미지 -95%, 시야 좁아짐, 인식 반경 손상됨, 지구력 회복량 중단
         */
        Moodle_Hyperthermia_Hot = new Moodles_state("Hyperthermia_Hot", 36f, 37.5f, 39f, 40f, 41f);
        /*
         37.5도 이상: 갈증 약간빨리 증가
         39도 이상: 갈증 빨리 증가, 피로 빨리 증가, 공격속도 -34%, 이동속도 약간 감소
         40도 이상: 갈증 더빨리 증가, 피로 더빨리 증가, 공격속도 -67%, 이동속도 적당히 감소
         41도 이상: 갈증 현저히 증가, 피로 현저히 증가, 인지도 약간 감소, 공격속도 -90%, 이동속도 크게 감소, 체력 천천히 감소
         */
        Moodle_Hyperthermia_Cold = new Moodles_state("Hyperthermia_Cold", 36f, 36.5f, 35f, 30f, 25f);
        /*
         36.5도 이하: -
         35도 이하: 공격속도 -34%, 걷기/달리기 속도 적당히 감소
         30도 이하: 공격속도 -67%, 걷기/달리기 속도 크게 감소
         25도 이하: 공격속도 -90%, 걷기/달리기 속도 심하게 감소, 체력이 1%가 될때까지 천천히 감소
        */
        Moodle_Windchill = new Moodles_state("Windchill", 0f, 2f, 5f, 7f, 9f);  // 임의로 설정
        /*
         2 이상: 실제보다 5~10도 낮게 느낌
         5 이상: 실제보다 10~15도 낮게 느낌
         7 이상: 실제보다 15~20도 낮게 느낌
         9 이상: 실제보다 20도 이상 낮게 느낌
        */
        Moodle_Wet = new Moodles_state("Wet", 0f, 0.15f, 0.4f, 0.7f, 0.9f);
        /*
         15% 이상: 약간 젖어있음
         40% 이상: 다소 젖어있음
         70% 이상: 아플 수 있음
         90% 이상: 병에 걸릴 가능성이 높음
        */
        Moodle_Injured = new Moodles_state("Injured", 0f, 0.8f, 0.6f, 0.4f, 0.25f);
        /*
         체력 80% 미만: -
         체력 60% 미만: 운반능력 -1
         체력 40% 미만: 운반능력 -2
         체력 25% 미만: 운반능력 -3
        */
        Moodle_Pain = new Moodles_state("Pain", 0f, 0.8f, 0.6f, 0.4f, 0.25f);  // 임의로 설정 (부상과 동일)
        /*
         체력 80% 미만: 낮은 울타리를 넘을때 넘어질 확률 +5%, 달리기/파워워크 때 넘어질 확률 +5%
         체력 60% 미만: 낮은 울타리를 넘을때 넘어질 확률 +10%, 달리기/파워워크 때 넘어질 확률 +10%,
                       수면 비활성화, 부상부위에 따라 이동, 근접데미지, 공격속도 소폭 감소
         체력 40% 미만: 낮은 울타리를 넘을때 넘어질 확률 +15%, 달리기/파워워크 때 넘어질 확률 +15%,
                       수면 비활성화, 부상부위에 따라 이동, 근접데미지, 공격속도 적당히 감소
         체력 25% 미만: 낮은 울타리를 넘을때 넘어질 확률 +20%, 달리기/파워워크 때 넘어질 확률 +20%,
                       수면 비활성화, 부상부위에 따라 이동, 근접데미지, 공격속도 크게 감소, 운동 비활성화
        */
        Moodle_Bleeding = new Moodles_state("Bleeding", 0f, 1f, 2f, 3f, 4f);
        /*
         출혈 상처 1개 이상: 시간이 지남에 따라 체력 천천히 손실
         출혈 상처 2개 이상: 시간이 지남에 따라 체력 어느정도 손실, 운반능력 -1
         출혈 상처 3개 이상: 시간이 지남에 따라 체력 심각하게 손실, 운반능력 -1
         출혈 상처 4개 이상: 즉시 치료하지않으면 사망에 이를 수 있음, 운반능력 -1
        */
        Moodle_Has_a_Cold = new Moodles_state("Has_a_Cold", 0f, 0.2f, 0.4f, 0.6f, 0.8f);
        /*
         20% 이상: 재채기나 기침을 할 가능성 적음
         40% 이상: 재채기나 기침을 할 가능성 있음
         60% 이상: 재채기나 기침을 할 가능성 높아서 좀비를 피하기 어려움
         60% 이상: 재채기나 기침을 계속 해서 외딴 지역or실내가 아니면 계속 좀비를 끌어들임
        */
        Moodle_Sick = new Moodles_state("Sick", 0f, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% 이상: 체온발생량 약간 증가, 
                   좀비화or중독이면 체력 천천히 감소
         50% 이상: 체온발생량 적당히 증가, 운반 능력 -1, 나쁜 음식or시체로 인한 경우 치유속도 느려짐,
                   좀비화or중독이면 체력 서서히 감소
         75% 이상: 체온발생량 더욱 증가, 운반 능력 -2, 나쁜 음식or시체로 인한 경우 치유속도 훨씬 느려짐,
                   좀비화or중독이면 체력 심각하게 감소
         90% 이상: 체온발생량 크게 증가, 운반 능력 -3, 나쁜 음식or시체로 인한 경우 체력이 천천히 감소,
                   좀비화or중독이면 체력 치명적으로 감소
        */
        Moodle_Dead = new Moodles_state("Dead", 100f, 0f, 0f, 0f, 0f);  // 체력이 0이되면 바로 실행
        /*
         플레이어가 감염되지 않고 사망한 경우
         */
        Moodle_Zombie = new Moodles_state("Zombie", 100f, 0f, 0f, 0f, 0f);  // 임의로 설정 (기준: 체력 0 && Dead가 아닌 경우)
        /*
         플레이어가 감염되고 사망한 경우.
         불타 재가 되지 않고나 땅에 시체를 남기는 경우 좀비로 부활
         */
        Moodle_Restricted_Movement = new Moodles_state("Restricted_Movement", 0f, 0f, 0f, 0f, 0f); // 임의로 설정 (기준: 신발 착용 x || 다리에 부목댄 경우 || 총 부담 > 175% Weight 경우)
        /*
         맨발, 다리부상, 과부하, 무거운 옷 착용, 속도에 영향을 미침
         달리기/파워워킹 할 수 없음
         */
    }



    float Timer = 0.0f;
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 3.0f)
        {
            // 3초마다 피로도 +3.0f * 피로도 생성 비율 (임의로 설정)
            Moodle_Tired.Set_Moodles_state();
            Timer = 0.0f;
        }
    }


}

public class Moodles_state
{
    string _Moodle_Name = "";
    state _Moodle_Number = 0;
    float _Moodle_current_state = 0f;
    float _First_state = 0f;
    float _Second_state = 0f;
    float _Third_state = 0f;
    float _Fourth_state = 0f;

    public Moodles_state(string Moodle_Name, float Moodle_current_state, float First_state, float Second_state, float Third_state, float Fourth_state)
    {
        _Moodle_Name = Moodle_Name;
        _Moodle_current_state = Moodle_current_state;
        _First_state = First_state;
        _Second_state = Second_state;
        _Third_state = Third_state;
        _Fourth_state = Fourth_state;
    }
    enum state
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
    public void Set_Moodles_state()
    {
        switch(_Moodle_Number)
        {
            case state.Hungry:
                break;
            case state.Stuffed:
                break;
            case state.Thirsty:
                break;
            case state.Panic:
                break;
            case state.Bored:
                break;
            case state.Stressed:
                break;
            case state.Unhappy:
                break;
            case state.Drunk:
                break;
            case state.Heavy_Load:
                break;
            case state.Endurance:
                break;
            case state.Tired:
                _Moodle_current_state += 3.0f * Player_main.player_main.playerSkill_ActivationProbability.Get_Fatigue_Generation_Rate();  // * 피로도 생성 비율
                //if()
                break;
            case state.Hyperthermia_Hot:
                break;
            case state.Hyperthermia_Cold:
                break;
            case state.Windchill:
                break;
            case state.Wet:
                break;
            case state.Injured:
                break;
            case state.Pain:
                break;
            case state.Bleeding:
                break;
            case state.Has_a_Cold:
                break;
            case state.Sick:
                break;
            case state.Dead:
                break;
            case state.Zombie:
                break;
            case state.Restricted_Movement:
                break;
            default:
                break;

        }
    }

    public float Get_Moodles_state()
    {
        return _Moodle_current_state;
    }


}

