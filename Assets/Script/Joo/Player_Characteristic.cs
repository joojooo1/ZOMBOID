using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements.Experimental;
using UnityEngine.XR;

public enum Characteristic_type
{
    Positives = 0,
    Negatives = 1,
    Occupation = 2
}

public class Characteristic
{
    public string name;
    public string name_kr;
    public string Explanation_for_Characteristic;
    public string Explanation_for_Characteristic_kr;
    public int Characteristic_number;
    public Sprite Sprite;

    public int Points;
    public Characteristic_type type;
    public bool Choice;
}

public class Player_Characteristic : MonoBehaviour
{
    [SerializeField] Transform Characteristic_P_Window;
    [SerializeField] Transform Characteristic_N_Window;
    [SerializeField] Transform Characteristic_S_Window;
    [SerializeField] Sprite[] Characteristic_Image;
    [SerializeField] GameObject Characteristic_Prefab;

    public static Player_Characteristic instance;
    private void Awake()
    {
        instance = this;
        //Set_Weight_Characteristic();
        for (int i = 0; i < Characteristic_Image.Length - 3; i++)
        {
            GameObject tempObj = null;
            Set_Characteristic(i, false, tempObj);
        }
    }

    private void Update()
    {
        //for(int i = 0; i < Weight.Length; i++)
        //{
        //    if (Player_main.player_main.Get_Weight() > Weight[i])
        //    {
        //        Debug.Log(i);
        //    }
        //}

    }

    /* 캐릭터 생성시 선택할 특성 */

    /*  체중
     
     비만: 선택시 초기 몸무게 105kg. 몸무게가 100 이상일 때 활성화.
     과체중: 선택시 초기 몸무게 95kg. 몸무게가 85~99 사이일 때 활성화.
     저체중: 선택시 초기 몸무게 70kg. 몸무게가 66~75 사이일 때 활성화.
     심한 저체중: 선택시 초기 몸무게 60kg. 몸무게가 51~65 사이일 때 활성화.
     수척함: 몸무게가 50 이하일 때 활성화.

     */

    /*   근력/체력

     약함 근력이 0~1 사이일 때 활성화
     연약함: 근력이 2~4 사이일 때 활성화
     통통함: 선택하지 않아도 근력이 6~8 사이일 때 활성화
     튼튼함: 선택하지 않아도 근력이 9 이상일 때 활성화
     비실함: 체력이 0~1 사이일 때 활성화
     건강 이상: 체력이 2~4 사이일 때 활성화
     건강함: 선택하지 않아도 체력이 6~8 사이일 때 활성화
     육상 선수: 선택하지 않아도 체력이 9 이상일 때 활성화

     */

    //public Weight_Characteristic[] Weight = new Weight_Characteristic[5];

    //public class Weight_Characteristic
    //{
    //    public string name;
    //    public string name_kr;
    //    public Sprite Sprites;

    //    public float value;
    //    public int Points;
    //}

    //void Set_Weight_Characteristic()
    //{
    //    Weight[0].name = "수척함";
    //    Weight[0].name_kr = "수척함";
    //}

    public List<UI_Title_Characteristic_prefab> characteristics_list = new List<UI_Title_Characteristic_prefab>();
    public List<UI_Title_Characteristic_prefab> characteristics_Player = new List<UI_Title_Characteristic_prefab>();

    public void Remove_Selected_list(int Characteristic_number, bool selected)
    {
        if (selected)
        {
            for(int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == Characteristic_number)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
            }

        }
        else
        {
            for (int i = 0; i < characteristics_list.Count; i++)
            {
                if (characteristics_list[i].Prefab.Characteristic_number == Characteristic_number)
                {
                    Destroy(characteristics_list[i].gameObject);
                    characteristics_list.RemoveAt(i);
                }

            }

        }
    }

    public void Set_Characteristic(int value, bool Choice, GameObject tempObj)
    {
        //tempObj = Instantiate(Characteristic_Prefab, Characteristic_P_Window);
        Characteristic temp = new Characteristic();
        switch (value)
        {
            case 0:
                temp = Characteristic_Speed_Demon(temp, Choice);
                break;
            case 1:
                temp = Characteristic_Cats_Eyes(temp, Choice);
                break;
            case 2:
                temp = Characteristic_Outdoorsman(temp, Choice);
                break;
            case 3:
                temp = Characteristic_Fast_Reader(temp, Choice);
                break;
            case 4:
                temp = Characteristic_Wakeful(temp, Choice);
                break;
            case 5:
                temp = Characteristic_Iron_Gut(temp, Choice);
                break;
            case 6:
                temp = Characteristic_Resilient(temp, Choice);
                break;
            case 7:
                temp = Characteristic_Light_Eater(temp, Choice);
                break;
            case 8:
                temp = Characteristic_Brave(temp, Choice);
                break;
            case 9:
                temp = Characteristic_Graceful(temp, Choice);
                break;
            case 10:
                temp = Characteristic_Fit(temp, Choice);
                break;
            case 11:
                temp = Characteristic_Low_Thirst(temp, Choice);
                break;
            case 12:
                temp = Characteristic_Eagle_Eyed(temp, Choice);
                break;
            case 13:
                temp = Characteristic_Fast_Healer(temp, Choice);
                break;
            case 14:
                temp = Characteristic_Keen_Hearing(temp, Choice);
                break;
            case 15:
                temp = Characteristic_Stout(temp, Choice);
                break;
            case 16:
                temp = Characteristic_Fast_Learner(temp, Choice);
                break;
            case 17:
                temp = Characteristic_Thick_Skinned(temp, Choice);
                break;
            case 18:
                temp = Characteristic_Adrenaline_Junkie(temp, Choice);
                break;
            case 19:
                temp = Characteristic_Athletic(temp, Choice);
                break;
            case 20:
                temp = Characteristic_Strong(temp, Choice);
                break;
            case 21:
                temp = Characteristic_Sunday_driver(temp, Choice);
                break;
            case 22:
                temp = Characteristic_Cowardly(temp, Choice);
                break;
            case 23:
                temp = Characteristic_Clumsy(temp, Choice);
                break;
            case 24:
                temp = Characteristic_Slow_Reader(temp, Choice);
                break;
            case 25:
                temp = Characteristic_Short_Sighted(temp, Choice);
                break;
            case 26:
                temp = Characteristic_Weak_Stomach(temp, Choice);
                break;
            case 27:
                temp = Characteristic_Smoker(temp, Choice);
                break;
            case 28:
                temp = Characteristic_Agoraphobic(temp, Choice);
                break;
            case 29:
                temp = Characteristic_Hearty_Appetite(temp, Choice);
                break;
            case 30:
                temp = Characteristic_Claustrophobic(temp, Choice);
                break;
            case 31:
                temp = Characteristic_Hard_of_Hearing(temp, Choice);
                break;
            case 32:
                temp = Characteristic_Sleepyhead(temp, Choice);
                break;
            case 33:
                temp = Characteristic_Prone_to_Illness(temp, Choice);
                break;
            case 34:
                temp = Characteristic_Pacifist(temp, Choice);
                break;
            case 35:
                temp = Characteristic_Asthmatic(temp, Choice);
                break;
            case 36:
                temp = Characteristic_Out_of_Shape(temp, Choice);
                break;
            case 37:
                temp = Characteristic_Overweight(temp, Choice);
                break;
            case 38:
                temp = Characteristic_High_Thirst(temp, Choice);
                break;
            case 39:
                temp = Characteristic_Slow_Healer(temp, Choice);
                break;
            case 40:
                temp = Characteristic_Slow_Learner(temp, Choice);
                break;
            case 41:
                temp = Characteristic_Restless_Sleeper(temp, Choice);
                break;
            case 42:
                temp = Characteristic_Feeble(temp, Choice);
                break;
            case 43:
                temp = Characteristic_Underweight(temp, Choice);
                break;
            case 44:
                temp = Characteristic_Illiterate(temp, Choice);
                break;
            case 45:
                temp = Characteristic_Thin_skinned(temp, Choice);
                break;
            case 46:
                temp = Characteristic_Obese(temp, Choice);
                break;
            case 47:
                temp = Characteristic_Unfit(temp, Choice);
                break;
            case 48:
                temp = Characteristic_Very_Underweight(temp, Choice);
                break;
            case 49:
                temp = Characteristic_Emaciated(temp, Choice);
                break;
            case 50:
                temp = Characteristic_Weak(temp, Choice);
                break;
            case 51:
                temp = Characteristic_Deaf(temp, Choice);
                break;
            //case 52:
            //    temp = Characteristic_Burglar(temp, Choice);
            //    break;
            //case 53:
            //    temp = Characteristic_Desensitized(temp, Choice);
            //    break;
            //case 54:
            //    temp = Characteristic_Angler(temp, Choice);
            //    break;
            default: break;
        }

        if (temp.type == Characteristic_type.Negatives && temp.Choice == false)
        {
            tempObj = Instantiate(Characteristic_Prefab, Characteristic_N_Window);
        }
        else if (temp.type == Characteristic_type.Positives && temp.Choice == false)
        {
            tempObj = Instantiate(Characteristic_Prefab, Characteristic_P_Window);
        }
        else if (temp.type == Characteristic_type.Occupation || temp.Choice == true)
        {
            tempObj = Instantiate(Characteristic_Prefab, Characteristic_S_Window);
        }
        tempObj.GetComponent<UI_Title_Characteristic_prefab>().SetCharacteristic(temp);

        if (Choice)
        {
            characteristics_Player.Add(tempObj.GetComponent<UI_Title_Characteristic_prefab>());
        }
        else
        {
            characteristics_list.Add(tempObj.GetComponent<UI_Title_Characteristic_prefab>());
        }

        if(value >= 52)
        {
            UI_Title_Characteristic_text.Characteristic_text.Open_text(temp.name_kr, temp.Explanation_for_Characteristic_kr, temp.Points);
        }
    }

    /*
     긍정적 특성
     : 속도광, 고양이의 눈, 등산애호가, 민첩한, 속독, 잠이 없는, 강철 위장, 강한 회복력, 부족한 존재감, 소식가,
       용감함, 우아함, 행운, 건강함, 낮은 갈증, 매의 눈, 빠른 회복, 예민한 청력, 정리쟁이, 통통함, 
       현자, 두꺼운 피부, 아드레날린 중독, 육상 선수, 튼튼함
    */
    Characteristic Characteristic_Speed_Demon(Characteristic Speed_Demon, bool Choice)
    {
        Speed_Demon.name = "Speed Demon";
        Speed_Demon.name_kr = "속도광";
        Speed_Demon.Explanation_for_Characteristic = "The fast driver.";
        Speed_Demon.Explanation_for_Characteristic_kr = "빠른 운전을 합니다.";
        Speed_Demon.Characteristic_number = 0;
        Speed_Demon.Sprite = Characteristic_Image[0];
        Speed_Demon.Points = -1;
        Speed_Demon.type = Characteristic_type.Positives;
        Speed_Demon.Choice = Choice;
        return Speed_Demon;
        // 모든 차량의 기어 전환 속도 +100%(200%), 최고 속도 +15%(115%), 엔진 RPM 상승, 후진 RPM 최대치로 고정
        // 비활성화되는 특성: 초보 운전
    }

    Characteristic Characteristic_Cats_Eyes(Characteristic Cats_Eyes, bool Choice)
    {
        Cats_Eyes.name = "Cat's Eyes";
        Cats_Eyes.name_kr = "고양이의 눈";
        Cats_Eyes.Explanation_for_Characteristic = "Better vision at night.";
        Cats_Eyes.Explanation_for_Characteristic_kr = "밤에 더 나은 시력을 가집니다.";
        Cats_Eyes.Characteristic_number = 1;
        Cats_Eyes.Sprite = Characteristic_Image[1];
        Cats_Eyes.Points = -2;
        Cats_Eyes.type = Characteristic_type.Positives;
        Cats_Eyes.Choice = Choice;
        return Cats_Eyes;
        // 야간 시야 범위 +20%, 수색 반경 +0.2, 수색 어둠 페널티 - 20 %, 야간 밝기 증가,
        // 손전등, 차량 전조등 등의 광원의 범위 넓혀줌
    }

    Characteristic Characteristic_Outdoorsman(Characteristic Outdoorsman, bool Choice)
    {
        Outdoorsman.name = "Outdoorsman";
        Outdoorsman.name_kr = "등산애호가";
        Outdoorsman.Explanation_for_Characteristic = "Not affected by harsh weather conditions.";
        Outdoorsman.Explanation_for_Characteristic_kr = "혹독한 날씨에도 영향을 받지 않습니다.";
        Outdoorsman.Characteristic_number = 2;
        Outdoorsman.Sprite = Characteristic_Image[2];
        Outdoorsman.Points = -2;
        Outdoorsman.type = Characteristic_type.Positives;
        Outdoorsman.Choice = Choice;
        return Outdoorsman;
        // 감기에 걸릴 확률 -90%, 나무를 지날 때 다칠 확률 - 50 %, 수색 반경 + 0.4
        // 수색 어둠 페널티 - 7 %, 수색 날씨 페널티 -13 %, 구멍난 판자로 불을 더 빨리 피움
    }

    //Characteristic Characteristic_Dextrous(Characteristic Dextrous)
    //{
    //    Dextrous.name = "Dextrous";
    //    Dextrous.name_kr = "민첩한";
    //    Dextrous.Explanation_for_Characteristic = "Transfers inventory items quickly.";
    //    Dextrous.Explanation_for_Characteristic_kr = "소지품창에 물건을 넣고 꺼낼 때 속도가 빨라집니다.";
    //    Dextrous.Sprite = Characteristic_Image[3];
    //    Dextrous.Points = -2;
    //    Dextrous.type = Characteristic_type.Positives;
    //    Dextrous.Choice = false;
    //    return Dextrous;
    //    // 물품을 옮기는 시간 50% (아이템을 장착하는 데는 차이가 없고 오직 줍기와 옮기는 속도에만 영향을 끼침)
    //    // ex. 기본: 옷(1초), 쇠지렛대(2초), 도끼/대형망치(3초)
    //    // 비활성화되는 특성: 서투름
    //}

    Characteristic Characteristic_Fast_Reader(Characteristic Fast_Reader, bool Choice)
    {
        Fast_Reader.name = "Fast Reader";
        Fast_Reader.name_kr = "속독";
        Fast_Reader.Explanation_for_Characteristic = "Increases XP gains.";
        Fast_Reader.Explanation_for_Characteristic_kr = "책을 읽는데 시간이 적게 소요됩니다.";
        Fast_Reader.Characteristic_number = 3;
        Fast_Reader.Sprite = Characteristic_Image[3];
        Fast_Reader.Points = -2;
        Fast_Reader.type = Characteristic_type.Positives;
        Fast_Reader.Choice = Choice;
        return Fast_Reader;
        // 독서 속도 +30%
        // 비활성화되는 특성: 정독, 문맹
    }

    Characteristic Characteristic_Wakeful(Characteristic Wakeful, bool Choice)
    {
        Wakeful.name = "Wakeful";
        Wakeful.name_kr = "잠이 없는";
        Wakeful.Explanation_for_Characteristic = "Needs less sleep.";
        Wakeful.Explanation_for_Characteristic_kr = "잠을 덜 필요로 합니다.";
        Wakeful.Characteristic_number = 4;
        Wakeful.Sprite = Characteristic_Image[4];
        Wakeful.Points = -2;
        Wakeful.type = Characteristic_type.Positives;
        Wakeful.Choice = Choice;
        return Wakeful;
        // 수면 효율 +10%, 피로도 증가량 -30%
        // 비활성화되는 특성: 잠꾸러기
    }

    Characteristic Characteristic_Iron_Gut(Characteristic Iron_Gut, bool Choice)
    {
        Iron_Gut.name = "Iron Gut";
        Iron_Gut.name_kr = "강철 위장";
        Iron_Gut.Explanation_for_Characteristic = "Less chance to have food illness.";
        Iron_Gut.Explanation_for_Characteristic_kr = "음식으로 인한 질병에 걸릴 확률이 감소합니다.";
        Iron_Gut.Characteristic_number = 5;
        Iron_Gut.Sprite = Characteristic_Image[5];
        Iron_Gut.Points = -3;
        Iron_Gut.type = Characteristic_type.Positives;
        Iron_Gut.Choice = Choice;
        return Iron_Gut;
        // 식중독에 걸릴 확률 -50%, 식중독 유지시간 감소
        // 비활성화되는 특성: 소화불량
    }

    Characteristic Characteristic_Resilient(Characteristic Resilient, bool Choice)
    {
        Resilient.name = "Resilient";
        Resilient.name_kr = "강한 회복력";
        Resilient.Explanation_for_Characteristic = "Less prone to disease. Slower rate of zombification.";
        Resilient.Explanation_for_Characteristic_kr = "질병에 걸릴 가능성이 감소합니다.\r\n좀비화 상태가 되었을 때 진행되는 속도를 느리게 합니다.";
        Resilient.Characteristic_number = 6;
        Resilient.Sprite = Characteristic_Image[6];
        Resilient.Points = -4;
        Resilient.type = Characteristic_type.Positives;
        Resilient.Choice = Choice;
        return Resilient;
        // 감기에 걸릴 확률 -55%, 추위 영향 -20%, 추위 진행 속도 -50%, 좀비화 속도 -75%
        // 비활성화되는 특성: 질병에 취약함
    }

    //Characteristic Characteristic_Inconspicuous(Characteristic Inconspicuous)
    //{
    //    Inconspicuous.name = "Inconspicuous";
    //    Inconspicuous.name_kr = "부족한 존재감";
    //    Inconspicuous.Explanation_for_Characteristic = "Less likely to be spotted by zombies.";
    //    Inconspicuous.Explanation_for_Characteristic_kr = "좀비에게 덜 발견됩니다.";
    //    Inconspicuous.Sprite = Characteristic_Image[8];
    //    Inconspicuous.Points = -4;
    //    Inconspicuous.type = Characteristic_type.Positives;
    //    Inconspicuous.Choice = false;
    //    return Inconspicuous;
    //    // 좀비에게 발견될 확률 50%
    //    // 비활성화되는 특성: 넘치는 존재감
    //}

    Characteristic Characteristic_Light_Eater(Characteristic Light_Eater, bool Choice)
    {
        Light_Eater.name = "Light Eater";
        Light_Eater.name_kr = "소식가";
        Light_Eater.Explanation_for_Characteristic = "Needs to eat less regularly.";
        Light_Eater.Explanation_for_Characteristic_kr = "덜 주기적으로 식사를 합니다.";
        Light_Eater.Characteristic_number = 7;
        Light_Eater.Sprite = Characteristic_Image[7];
        Light_Eater.Points = -4;
        Light_Eater.type = Characteristic_type.Positives;
        Light_Eater.Choice = Choice;
        return Light_Eater;
        // 배고픔 진행속도 75%
        // 비활성화되는 특성: 대식가
    }

    Characteristic Characteristic_Brave(Characteristic Brave, bool Choice)
    {
        Brave.name = "Brave";
        Brave.name_kr = "용감함";
        Brave.Explanation_for_Characteristic = "Less prone to becoming panicked.";
        Brave.Explanation_for_Characteristic_kr = "공황상태에 잘 빠지지 않습니다.";
        Brave.Characteristic_number = 8;
        Brave.Sprite = Characteristic_Image[8];
        Brave.Points = -4;
        Brave.type = Characteristic_type.Positives;
        Brave.Choice = Choice;
        return Brave;
        // 긴장 상승량 -70%
        // 비활성화되는 특성: 겁쟁이, 광장공포증, 밀실공포증
    }

    Characteristic Characteristic_Graceful(Characteristic Graceful, bool Choice)
    {
        Graceful.name = "Graceful";
        Graceful.name_kr = "우아함";
        Graceful.Explanation_for_Characteristic = "Makes less noise when moving.";
        Graceful.Explanation_for_Characteristic_kr = "움직일 때 나는 소리가 감소합니다.";
        Graceful.Characteristic_number = 9;
        Graceful.Sprite = Characteristic_Image[9];
        Graceful.Points = -4;
        Graceful.type = Characteristic_type.Positives;
        Graceful.Choice = Choice;
        return Graceful;
        // 움직일 때 발생하는 소음반경 -40%,
        // 달리기/질주로 낮은 울타리를 뛰어 넘거나 좀비를 공격할 때 넘어질 확률 -10%
        // 전투중 발생하는 소음이나 유리를 밟을 때 등 다른 소음에는 영향을 주지 않고, 오직 발소리만 줄여줌
        // 비활성화되는 특성: 덤벙댐
    }
    //Characteristic Characteristic_Lucky(Characteristic Lucky)
    //{
    //    Lucky.name = "Lucky";
    //    Lucky.name_kr = "행운";
    //    Lucky.Explanation_for_Characteristic = "Sometimes things just go your way.";
    //    Lucky.Explanation_for_Characteristic_kr = "때때로 생각지도 않던 물건을 얻을 수 있습니다.";
    //    Lucky.Sprite = Characteristic_Image[12];
    //    Lucky.Points = -4;
    //    Lucky.type = Characteristic_type.Positives;
    //    Lucky.Choice = false;
    //    return Lucky;
    //    // 아이템 발견 확률 +10%, 아이템 수리 실패율 -5%, 수색 반경 +1
    //    // 멀티플레이에서는 사용할 수 없습니다.
    //    // 비활성화되는 특성: 불운
    //}

    Characteristic Characteristic_Fit(Characteristic Fit, bool Choice)
    {
        Fit.name = "Fit";
        Fit.name_kr = "건강함";
        Fit.Explanation_for_Characteristic = "In good physical shape.";
        Fit.Explanation_for_Characteristic_kr = "달리는 속도가 빠릅니다.";
        Fit.Characteristic_number = 10;
        Fit.Sprite = Characteristic_Image[10];
        Fit.Points = -6;
        Fit.type = Characteristic_type.Positives;
        Fit.Choice = Choice;
        return Fit;
        // 체력 +2
    }

    Characteristic Characteristic_Low_Thirst(Characteristic Low_Thirst, bool Choice)
    {
        Low_Thirst.name = "Low Thirst";
        Low_Thirst.name_kr = "낮은 갈증";
        Low_Thirst.Explanation_for_Characteristic = "Needs to drink water less regularly.";
        Low_Thirst.Explanation_for_Characteristic_kr = "생존을 위한 물의 소모량이 감소합니다.";
        Low_Thirst.Characteristic_number = 11;
        Low_Thirst.Sprite = Characteristic_Image[11];
        Low_Thirst.Points = -6;
        Low_Thirst.type = Characteristic_type.Positives;
        Low_Thirst.Choice = Choice;
        return Low_Thirst;
        // 갈증 진행 속도 -50%
        // 비활성화되는 특성: 높은 갈증
    }

    Characteristic Characteristic_Eagle_Eyed(Characteristic Eagle_Eyed, bool Choice)
    {
        Eagle_Eyed.name = "Eagle Eyed";
        Eagle_Eyed.name_kr = "매의 눈";
        Eagle_Eyed.Explanation_for_Characteristic = "Has a faster visibility fade and a higher visibility arc.";
        Eagle_Eyed.Explanation_for_Characteristic_kr = "시야 확보 속도가 빨라집니다. \r\n 볼 수 있는 시야가 넓어집니다.";
        Eagle_Eyed.Characteristic_number = 12;
        Eagle_Eyed.Sprite = Characteristic_Image[12];
        Eagle_Eyed.Points = -6;
        Eagle_Eyed.type = Characteristic_type.Positives;
        Eagle_Eyed.Choice = Choice;
        return Eagle_Eyed;
        // 시야 범위 증가, 시야 확보 속도 증가, 수색 반경 +0.5
        // 비활성화되는 특성: 짧은 시야
    }

    Characteristic Characteristic_Fast_Healer(Characteristic Fast_Healer, bool Choice)
    {
        Fast_Healer.name = "Fast Healer";
        Fast_Healer.name_kr = "빠른 회복";
        Fast_Healer.Explanation_for_Characteristic = "Has a faster visibility fade and a higher visibility arc.";
        Fast_Healer.Explanation_for_Characteristic_kr = "부상과 질병을 빠르게 회복합니다.";
        Fast_Healer.Characteristic_number = 13;
        Fast_Healer.Sprite = Characteristic_Image[13];
        Fast_Healer.Points = -6;
        Fast_Healer.type = Characteristic_type.Positives;
        Fast_Healer.Choice = Choice;
        return Fast_Healer;
        // 긁힘, 찢어짐, 물림, 깊은 상처, 화상 상처 심각도 -20%
        // 비활성화되는 특성: 느린 치유
    }

    Characteristic Characteristic_Keen_Hearing(Characteristic Keen_Hearing, bool Choice)
    {
        Keen_Hearing.name = "Keen Hearing";
        Keen_Hearing.name_kr = "예민한 청력";
        Keen_Hearing.Explanation_for_Characteristic = "Larger perception radius.";
        Keen_Hearing.Explanation_for_Characteristic_kr = "소리를 인지하는 반경이 커집니다.\r\n들리는 범위가 넓어집니다.";
        Keen_Hearing.Characteristic_number = 14;
        Keen_Hearing.Sprite = Characteristic_Image[14];
        Keen_Hearing.Points = -6;
        Keen_Hearing.type = Characteristic_type.Positives;
        Keen_Hearing.Choice = Choice;
        return Keen_Hearing;
        // 소리 인지 반경 +100%(200%), 주변 시야 범위 증가
        // 비활성화되는 특성: 어두운 귀, 청각 장애
    }

    //Characteristic Characteristic_Organized(Characteristic Organized)
    //{
    //    Organized.name = "Organized";
    //    Organized.name_kr = "정리쟁이";
    //    Organized.Explanation_for_Characteristic = "Increased container inventory capacity.";
    //    Organized.Explanation_for_Characteristic_kr = "보관함에 물건을 넣을 수 있는 양이 증가합니다.";
    //    Organized.Sprite = Characteristic_Image[18];
    //    Organized.Points = -6;
    //    Organized.type = Characteristic_type.Positives;
    //    Organized.Choice = false;
    //    return Organized;
    //    // 인벤토리를 제외한 모든 보관함(가방, 냉장고, 상자, 서랍, 차량 트렁크 등)의 용량 +30% (최소 +1)
    //    // 비활성화되는 특성: 비체계적인
    //}

    Characteristic Characteristic_Stout(Characteristic Stout, bool Choice)
    {
        Stout.name = "Stout";
        Stout.name_kr = "통통함";
        Stout.Explanation_for_Characteristic = "Extra knockback from melee weapons and increased carry weight.";
        Stout.Explanation_for_Characteristic_kr = "근접무기 사용 시에 뒤로 밀칠 확률이 증가합니다.\r\n옮길 수 있는 무게량이 증가합니다.";
        Stout.Characteristic_number = 15;
        Stout.Sprite = Characteristic_Image[15];
        Stout.Points = -6;
        Stout.type = Characteristic_type.Positives;
        Stout.Choice = Choice;
        return Stout;
        // 근력 +2, 밀쳐내기 확률 25% 증가
    }

    Characteristic Characteristic_Fast_Learner(Characteristic Fast_Learner, bool Choice)
    {
        Fast_Learner.name = "Fast Learner";
        Fast_Learner.name_kr = "현자";
        Fast_Learner.Explanation_for_Characteristic = "Increases XP gains.";
        Fast_Learner.Explanation_for_Characteristic_kr = "경험치 획득량이 증가합니다.";
        Fast_Learner.Characteristic_number = 16;
        Fast_Learner.Sprite = Characteristic_Image[16];
        Fast_Learner.Points = -6;
        Fast_Learner.type = Characteristic_type.Positives;
        Fast_Learner.Choice = Choice;
        return Fast_Learner;
        // 신체 능력(근력, 체력)을 제외한 모든 스킬의 경험치 획득량 +30%
        // 비활성화되는 특성: 느린 학습
    }

    Characteristic Characteristic_Thick_Skinned(Characteristic Thick_Skinned, bool Choice)
    {
        Thick_Skinned.name = "Thick Skinned";
        Thick_Skinned.name_kr = "두꺼운 피부";
        Thick_Skinned.Explanation_for_Characteristic = "Less chance of scratches or bites breaking the skin.";
        Thick_Skinned.Explanation_for_Characteristic_kr = "긁히거나 물릴 위험이 낮아집니다.";
        Thick_Skinned.Characteristic_number = 17;
        Thick_Skinned.Sprite = Characteristic_Image[17];
        Thick_Skinned.Points = -8;
        Thick_Skinned.type = Characteristic_type.Positives;
        Thick_Skinned.Choice = Choice;
        return Thick_Skinned;
        // 긁힘, 찢어짐, 물림 확률 -30%
        // 회피율 : 15 + (무기 숙련도에 따른 수치 -5% ~ 7%) * {1.3(두꺼운 피부) or 0.77(얇은 피부)}
        // 비활성화되는 특성: 얇은 피부
    }

    Characteristic Characteristic_Adrenaline_Junkie(Characteristic Adrenaline_Junkie, bool Choice)
    {
        Adrenaline_Junkie.name = "Adrenaline Junkie";
        Adrenaline_Junkie.name_kr = "아드레날린 중독";
        Adrenaline_Junkie.Explanation_for_Characteristic = "Moves faster when highly panicked.";
        Adrenaline_Junkie.Explanation_for_Characteristic_kr = "공황상태일 때 더 빨리 움직입니다.";
        Adrenaline_Junkie.Characteristic_number = 18;
        Adrenaline_Junkie.Sprite = Characteristic_Image[18];
        Adrenaline_Junkie.Points = -8;
        Adrenaline_Junkie.type = Characteristic_type.Positives;
        Adrenaline_Junkie.Choice = Choice;
        return Adrenaline_Junkie;
        // 3단계 긴장이면 0.2, 4단계 긴장이면 0.25의 추가 이동속도를 얻는다.
        // 비활성화되는 특성: 겁쟁이, 광장공포증, 밀실공포증
    }

    Characteristic Characteristic_Athletic(Characteristic Athletic, bool Choice)
    {
        Athletic.name = "Athletic";
        Athletic.name_kr = "육상 선수";
        Athletic.Explanation_for_Characteristic = "Can run faster and longer without tiring.";
        Athletic.Explanation_for_Characteristic_kr = "달리기 속도가 빨라집니다.\r\n더 오래 지치지 않고 달릴 수 있습니다.";
        Athletic.Characteristic_number = 19;
        Athletic.Sprite = Characteristic_Image[19];
        Athletic.Points = -10;
        Athletic.type = Characteristic_type.Positives;
        Athletic.Choice = Choice;
        return Athletic;
        // 체력 +4, 달리기 속도 +20%, 이동으로 인한 지구력 소모율 -20%
    }

    Characteristic Characteristic_Strong(Characteristic Strong, bool Choice)
    {
        Strong.name = "Strong";
        Strong.name_kr = "튼튼함";
        Strong.Explanation_for_Characteristic = "Extra knockback from melee weapons and increased carry weight.";
        Strong.Explanation_for_Characteristic_kr = "근접무기 사용 시에 뒤로 밀칠 확률이 증가합니다.\r\n옮길 수 있는 무게량이 증가합니다.";
        Strong.Characteristic_number = 20;
        Strong.Sprite = Characteristic_Image[20];
        Strong.Points = -10;
        Strong.type = Characteristic_type.Positives;
        Strong.Choice = Choice;
        return Strong;
        // 근력 +4, 밀쳐낼 확률 +40%
    }




    /*
     부정적 특성
     : 초보 운전, 겁쟁이, 덤벙댐, 서투름, 정독, 짧은 시야, 소화불량, 골초, 광장공포증, 넘치는 존재감
       대식가, 밀실공포증, 불운, 비체계적인, 어두운 귀, 잠꾸러기, 질병에 취약함, 평화주의자, 천식환자, 피 공포증,
       건강 이상, 과체중, 높은 갈증, 느린 치유, 느린 학습, 수면장애, 연약함, 저체중, 문맹, 얇은 피부,
       비만, 비실함, 심한 저체중, 수척함, 약함, 청각 장애

    */
    Characteristic Characteristic_Sunday_driver(Characteristic Sunday_driver, bool Choice)
    {
        Sunday_driver.name = "Sunday driver";
        Sunday_driver.name_kr = "초보 운전";
        Sunday_driver.Explanation_for_Characteristic = "The very slow driver";
        Sunday_driver.Explanation_for_Characteristic_kr = "느린 운전을 합니다.";
        Sunday_driver.Characteristic_number = 21;
        Sunday_driver.Sprite = Characteristic_Image[21];
        Sunday_driver.Points = +1;
        Sunday_driver.type = Characteristic_type.Negatives;
        Sunday_driver.Choice = Choice;
        return Sunday_driver;
        // 차량 가속력 -40%, 최대 속도가 30mph[= 48km]로 제한, 최대 속도로 주행중 기름이 추가로 소모됨
        // 비활성화되는 특성: 속도광
    }

    Characteristic Characteristic_Cowardly(Characteristic Cowardly, bool Choice)
    {
        Cowardly.name = "Cowardly";
        Cowardly.name_kr = "겁쟁이";
        Cowardly.Explanation_for_Characteristic = "Especially prone to becoming panicked";
        Cowardly.Explanation_for_Characteristic_kr = "공황상태에 빠지기 쉽습니다.";
        Cowardly.Characteristic_number = 22;
        Cowardly.Sprite = Characteristic_Image[22];
        Cowardly.Points = +2;
        Cowardly.type = Characteristic_type.Negatives;
        Cowardly.Choice = Choice;
        return Cowardly;
        // 긴장 상승률 +100%
        // 비활성화되는 특성: 용감함, 아드레날린 중독
    }

    Characteristic Characteristic_Clumsy(Characteristic Clumsy, bool Choice)
    {
        Clumsy.name = "Clumsy";
        Clumsy.name_kr = "덤벙댐";
        Clumsy.Explanation_for_Characteristic = "Makes more noise when moving";
        Clumsy.Explanation_for_Characteristic_kr = "움직일 때 나는 소리가 증가합니다.";
        Clumsy.Characteristic_number = 23;
        Clumsy.Sprite = Characteristic_Image[23];
        Clumsy.Points = +2;
        Clumsy.type = Characteristic_type.Negatives;
        Clumsy.Choice = Choice;
        return Clumsy;
        // 움직일 때 발생하는 소음반경 +20%, 넘어질 확률 +10%
        // 달리거나 전력 질주를 하는 도중 낮은 울타리를 넘거나 좀비와 부딫힐 때 넘어질 확률이 추가로 10% 증가
        // 비활성화되는 특성: 우아함
    }

    //Characteristic Characteristic_All_Thumbs(Characteristic All_Thumbs)
    //{
    //    All_Thumbs.name = "All Thumbs";
    //    All_Thumbs.name_kr = "서투름";
    //    All_Thumbs.Explanation_for_Characteristic = "Transfers inventory items slowly";
    //    All_Thumbs.Explanation_for_Characteristic_kr = "소지품창에 물건을 넣고 뺄때 속도가 느려집니다.";
    //    All_Thumbs.Sprite = Characteristic_Image[3];
    //    All_Thumbs.Points = 2;
    //    All_Thumbs.type = Characteristic_type.Negatives;
    //    All_Thumbs.Choice = false;
    //    return All_Thumbs;
    //    // 물품을 옮기는 시간 400% (줍기와 버리기 속도만)
    //    // 비활성화되는 특성: 민첩한
    //}

    Characteristic Characteristic_Slow_Reader(Characteristic Slow_Reader, bool Choice)
    {
        Slow_Reader.name = "Slow Reader";
        Slow_Reader.name_kr = "정독";
        Slow_Reader.Explanation_for_Characteristic = "Takes longer to read books";
        Slow_Reader.Explanation_for_Characteristic_kr = "책을 읽는데 시간이 많이 소요됩니다.";
        Slow_Reader.Characteristic_number = 24;
        Slow_Reader.Sprite = Characteristic_Image[24];
        Slow_Reader.Points = +2;
        Slow_Reader.type = Characteristic_type.Negatives;
        Slow_Reader.Choice = Choice;
        return Slow_Reader;
        // 독서 속도 -30%
        // 비활성화되는 특성: 속독, 문맹
    }

    Characteristic Characteristic_Short_Sighted(Characteristic Short_Sighted, bool Choice)
    {
        Short_Sighted.name = "Short Sighted";
        Short_Sighted.name_kr = "짧은 시야";
        Short_Sighted.Explanation_for_Characteristic = "Small view distance. Slower visibility fade.";
        Short_Sighted.Explanation_for_Characteristic_kr = "시야 거리가 짧아집니다.\r\n시야 확보 속도가 느려집니다.";
        Short_Sighted.Characteristic_number = 25;
        Short_Sighted.Sprite = Characteristic_Image[25];
        Short_Sighted.Points = +2;
        Short_Sighted.type = Characteristic_type.Negatives;
        Short_Sighted.Choice = Choice;
        return Short_Sighted;
        // 시야 확보 속도 감소, 수색 반경 -2
        // ( 안경이나 독서용 안경을 장비하면 페널티가 아예 무효화됨 )
        // 비활성화되는 특성: 매의 눈
    }

    Characteristic Characteristic_Weak_Stomach(Characteristic Weak_Stomach, bool Choice)
    {
        Weak_Stomach.name = "Weak Stomach";
        Weak_Stomach.name_kr = "소화불량";
        Weak_Stomach.Explanation_for_Characteristic = "Higher chance to have food illness.";
        Weak_Stomach.Explanation_for_Characteristic_kr = "음식으로 인한 질병에 걸릴 확률이 크게 증가합니다.";
        Weak_Stomach.Characteristic_number = 26;
        Weak_Stomach.Sprite = Characteristic_Image[26];
        Weak_Stomach.Points = +3;
        Weak_Stomach.type = Characteristic_type.Negatives;
        Weak_Stomach.Choice = Choice;
        return Weak_Stomach;
        // 식중독에 걸릴 확률 +100%, 식중독 유지 시간 증가
        // 비활성화되는 특성: 강철 위장
    }

    Characteristic Characteristic_Smoker(Characteristic Smoker, bool Choice)
    {
        Smoker.name = "Smoker";
        Smoker.name_kr = "골초";
        Smoker.Explanation_for_Characteristic = "Stress and unhappiness decrease after smoking tobacco. Unhappiness rises when tobacco is not smoked.";
        Smoker.Explanation_for_Characteristic_kr = "담배를 피우면 스트레스와 불행이 감소합니다.\r\n담배를 피우지 않으면 스트레스와 불행이 올라갑니다.";
        Smoker.Characteristic_number = 27;
        Smoker.Sprite = Characteristic_Image[27];
        Smoker.Points = +4;
        Smoker.type = Characteristic_type.Negatives;
        Smoker.Choice = Choice;
        return Smoker;
        // 스트레스 상시 상승, 흡연으로 인한 질병 무들이 발생하지 않음
        // 흡연시 불행 -10, 흡연시 스트레스 0으로 감소
        // 담배를 피우지 않으면 스트레스가 2단계 무들인 '동요함'까지 상승
    }

    Characteristic Characteristic_Agoraphobic(Characteristic Agoraphobic, bool Choice)
    {
        Agoraphobic.name = "Agoraphobic";
        Agoraphobic.name_kr = "광장공포증";
        Agoraphobic.Explanation_for_Characteristic = "Gets panicked when outdoors";
        Agoraphobic.Explanation_for_Characteristic_kr = "문 밖을 나서면 점점 공황상태가 되어 갑니다.";
        Agoraphobic.Characteristic_number = 28;
        Agoraphobic.Sprite = Characteristic_Image[28];
        Agoraphobic.Points = +4;
        Agoraphobic.type = Characteristic_type.Negatives;
        Agoraphobic.Choice = Choice;
        return Agoraphobic;
        // 야외에 있을 때 공황 발생, 수색 반경 -1.5
        // ( 밖으로 나가면 매우 빠르게 긴장이 올라 7초도 안돼서 공황상태에 도달 )
        // 비활성화되는 특성: 용감함, 아드레날린 중독, 밀실공포증
    }

    //Characteristic Characteristic_Conspicuous(Characteristic Conspicuous)
    //{
    //    Conspicuous.name = "Conspicuous";
    //    Conspicuous.name_kr = "넘치는 존재감";
    //    Conspicuous.Explanation_for_Characteristic = "More likely to be spotted by zombies.";
    //    Conspicuous.Explanation_for_Characteristic_kr = "좀비에게 발견될 확률이 높아집니다.";
    //    Conspicuous.Sprite = Characteristic_Image[9];
    //    Conspicuous.Points = 4;
    //    Conspicuous.type = Characteristic_type.Negatives;
    //    Conspicuous.Choice = false;
    //    return Conspicuous;
    //    // 좀비에게 발견될 확률 200%
    //    // 비활성화되는 특성: 부족한 존재감
    //}

    Characteristic Characteristic_Hearty_Appetite(Characteristic Hearty_Appetite, bool Choice)
    {
        Hearty_Appetite.name = "Hearty Appetite";
        Hearty_Appetite.name_kr = "대식가";
        Hearty_Appetite.Explanation_for_Characteristic = "Needs to eat more regularly";
        Hearty_Appetite.Explanation_for_Characteristic_kr = "주기적으로 식사를 더 해야 합니다.";
        Hearty_Appetite.Characteristic_number = 29;
        Hearty_Appetite.Sprite = Characteristic_Image[29];
        Hearty_Appetite.Points = +4;
        Hearty_Appetite.type = Characteristic_type.Negatives;
        Hearty_Appetite.Choice = Choice;
        return Hearty_Appetite;
        // 배고픔 진행 속도 150%, 채집보너스: 동물 / 산딸기 / 버섯 / 포장식품 +3%
        // 비활성화되는 특성: 소식가
    }

    Characteristic Characteristic_Claustrophobic(Characteristic Claustrophobic, bool Choice)
    {
        Claustrophobic.name = "Claustrophobic";
        Claustrophobic.name_kr = "밀실공포증";
        Claustrophobic.Explanation_for_Characteristic = "Gets panicked when indoors";
        Claustrophobic.Explanation_for_Characteristic_kr = "실내에 있을 때 점점 공황상태가 되어 갑니다.";
        Claustrophobic.Characteristic_number = 30;
        Claustrophobic.Sprite = Characteristic_Image[30];
        Claustrophobic.Points = +4;
        Claustrophobic.type = Characteristic_type.Negatives;
        Claustrophobic.Choice = Choice;
        return Claustrophobic;
        // 실내에 있을 때 공황 발생
        // 비활성화되는 특성: 용감함, 아드레날린 중독, 광장공포증
    }

    //Characteristic Characteristic_Unlucky(Characteristic Unlucky)
    //{
    //    Unlucky.name = "Unlucky";
    //    Unlucky.name_kr = "불운";
    //    Unlucky.Explanation_for_Characteristic = "What could go wrong for you, often does.";
    //    Unlucky.Explanation_for_Characteristic_kr = "알 수 없지만 뭔가 자꾸 손해를 보는 것 같습니다.";
    //    Unlucky.Sprite = Characteristic_Image[12];
    //    Unlucky.Points = 4;
    //    Unlucky.type = Characteristic_type.Negatives;
    //    Unlucky.Choice = false;
    //    return Unlucky;
    //    // 희귀한 아이템 발견 확률 -10%, 무기 수리 성공률 -5%, 수색 반경 -1
    //    // 멀티플레이에서는 사용할 수 없습니다.
    //    // 비활성화되는 특성: 행운
    //}

    //Characteristic Characteristic_Disorganized(Characteristic Disorganized)
    //{
    //    Disorganized.name = "Disorganized";
    //    Disorganized.name_kr = "비체계적인";
    //    Disorganized.Explanation_for_Characteristic = "Decreased container inventory capacity";
    //    Disorganized.Explanation_for_Characteristic_kr = "가방류 아이템에 물건을 넣을 수 있는 양이 감소합니다.";
    //    Disorganized.Sprite = Characteristic_Image[13];
    //    Disorganized.Points = 4;
    //    Disorganized.type = Characteristic_type.Negatives;
    //    Disorganized.Choice = false;
    //    return Disorganized;
    //    // 인벤토리를 제외한 모든 보관함의 용량 -30% (소수점 아래 버림, 최소 1)
    //    // 비활성화되는 특성: 정리쟁이
    //}

    Characteristic Characteristic_Hard_of_Hearing(Characteristic Hard_of_Hearing, bool Choice)
    {
        Hard_of_Hearing.name = "Hard of Hearing";
        Hard_of_Hearing.name_kr = "어두운 귀";
        Hard_of_Hearing.Explanation_for_Characteristic = "Smaller perception radius. Smaller hearing range.";
        Hard_of_Hearing.Explanation_for_Characteristic_kr = "소리를 인지하는 반경이 작아집니다.\r\n들리는 범위가 짧아집니다.";
        Hard_of_Hearing.Characteristic_number = 31;
        Hard_of_Hearing.Sprite = Characteristic_Image[31];
        Hard_of_Hearing.Points = +4;
        Hard_of_Hearing.type = Characteristic_type.Negatives;
        Hard_of_Hearing.Choice = Choice;
        return Hard_of_Hearing;
        // 소리 인지 범위 감소, 소리가 먹먹하게 들림, 주변 밝기 감소
        // 비활성화되는 특성: 예민한 청력, 청각 장애
    }

    Characteristic Characteristic_Sleepyhead(Characteristic Sleepyhead, bool Choice)
    {
        Sleepyhead.name = "Sleepyhead";
        Sleepyhead.name_kr = "잠꾸러기";
        Sleepyhead.Explanation_for_Characteristic = "Needs more sleep";
        Sleepyhead.Explanation_for_Characteristic_kr = "더 많은 잠을 필요로 합니다.";
        Sleepyhead.Characteristic_number = 32;
        Sleepyhead.Sprite = Characteristic_Image[32];
        Sleepyhead.Points = +4;
        Sleepyhead.type = Characteristic_type.Negatives;
        Sleepyhead.Choice = Choice;
        return Sleepyhead;
        // 피로도 상승률 +30%, 수면 효율 -10%
        // 비활성화되는 특성: 잠이 없는
    }

    Characteristic Characteristic_Prone_to_Illness(Characteristic Prone_to_Illness, bool Choice)
    {
        Prone_to_Illness.name = "Prone to Illness";
        Prone_to_Illness.name_kr = "질병에 취약함";
        Prone_to_Illness.Explanation_for_Characteristic = "More prone to disease. Faster rate of zombification.";
        Prone_to_Illness.Explanation_for_Characteristic_kr = "질병에 걸릴 가능성이 증가합니다.\r\n좀비화 상태가 되었을 때 진행되는 속도가 빨라집니다.";
        Prone_to_Illness.Characteristic_number = 33;
        Prone_to_Illness.Sprite = Characteristic_Image[33];
        Prone_to_Illness.Points = +4;
        Prone_to_Illness.type = Characteristic_type.Negatives;
        Prone_to_Illness.Choice = Choice;
        return Prone_to_Illness;
        // 감기에 걸릴 확률 +70%, 추위 내성 -20%, 추위 진행 속도 +50%, 좀비화 속도 +25%
        // 비활성화되는 특성: 강한 회복력
    }

    Characteristic Characteristic_Pacifist(Characteristic Pacifist, bool Choice)
    {
        Pacifist.name = "Pacifist";
        Pacifist.name_kr = "평화주의자";
        Pacifist.Explanation_for_Characteristic = "Less effective with weapons";
        Pacifist.Explanation_for_Characteristic_kr = "무기의 효율이 감소합니다.";
        Pacifist.Characteristic_number = 34;
        Pacifist.Sprite = Characteristic_Image[34];
        Pacifist.Points = +4;
        Pacifist.type = Characteristic_type.Negatives;
        Pacifist.Choice = Choice;
        return Pacifist;
        // 모든 무기, 물건관리, 조준 스킬의 경험치 습득률 -25%
    }

    Characteristic Characteristic_Asthmatic(Characteristic Asthmatic, bool Choice)
    {
        Asthmatic.name = "Asthmatic";
        Asthmatic.name_kr = "천식환자";
        Asthmatic.Explanation_for_Characteristic = "Faster endurance loss";
        Asthmatic.Explanation_for_Characteristic_kr = "빠르게 지친 상태가 됩니다.";
        Asthmatic.Characteristic_number = 35;
        Asthmatic.Sprite = Characteristic_Image[35];
        Asthmatic.Points = +5;
        Asthmatic.type = Characteristic_type.Negatives;
        Asthmatic.Choice = Choice;
        return Asthmatic;
        // 달리기와 질주의 지구력 소모량 +40%, 도구와 무기 사용의 지구력 소모량 +30%
    }

    //Characteristic Characteristic_Fear_of_Blood(Characteristic Fear_of_Blood)
    //{
    //    Fear_of_Blood.name = "Fear of Blood";
    //    Fear_of_Blood.name_kr = "피 공포증";
    //    Fear_of_Blood.Explanation_for_Characteristic = "Panic when performing first aid on self, cannot perform first aid on others, gets stressed when bloody";
    //    Fear_of_Blood.Explanation_for_Characteristic_kr = "피범벅이 되거나 자신에게 응급처치 시 공황상태에 빠집니다.";
    //    Fear_of_Blood.Sprite = Characteristic_Image[19];
    //    Fear_of_Blood.Points = 5;
    //    Fear_of_Blood.type = Characteristic_type.Negatives;
    //    Fear_of_Blood.Choice = false;
    //    return Fear_of_Blood;
    //    // 착용 의류의 '피투성이' 수치에 비례하여 스트레스 증가
    //    // 출혈 상태의 상처를 치료하면 공황무들 발생
    //}

    Characteristic Characteristic_Out_of_Shape(Characteristic Out_of_Shape, bool Choice)
    {
        Out_of_Shape.name = "Out of Shape";
        Out_of_Shape.name_kr = "건강 이상";
        Out_of_Shape.Explanation_for_Characteristic = "Low endurance, low endurance regeneration.";
        Out_of_Shape.Explanation_for_Characteristic_kr = "낮은 지구력과 느린 지구력 회복을 가집니다.";
        Out_of_Shape.Characteristic_number = 36;
        Out_of_Shape.Sprite = Characteristic_Image[36];
        Out_of_Shape.Points = +6;
        Out_of_Shape.type = Characteristic_type.Negatives;
        Out_of_Shape.Choice = Choice;
        return Out_of_Shape;
        // 체력 -2
    }

    Characteristic Characteristic_Overweight(Characteristic Overweight, bool Choice)
    {
        Overweight.name = "Overweight";
        Overweight.name_kr = "과체중";
        Overweight.Explanation_for_Characteristic = "Reduced running speed, low endurance and prone to injury.";
        Overweight.Explanation_for_Characteristic_kr = "달리기 속도가 느려집니다.\r\n달리기로 인해 더 빨리 지칩니다.";
        Overweight.Characteristic_number = 37;
        Overweight.Sprite = Characteristic_Image[37];
        Overweight.Points = +6;
        Overweight.type = Characteristic_type.Negatives;
        Overweight.Choice = Choice;
        return Overweight;
        // 시작 몸무게: 95kg
        // 몸무게 기준: 85~99kg
        // 체력 -1
        // 넘어질 확률 +10%
        // 지구력 회복량 - 30%
        // 높은 담장을 넘을 확률 - 15%
        // 낮은 담장을 뛰어넘을 때 넘어지지 않을 확률 +10%
    }

    Characteristic Characteristic_High_Thirst(Characteristic High_Thirst, bool Choice)
    {
        High_Thirst.name = "High Thirst";
        High_Thirst.name_kr = "높은 갈증";
        High_Thirst.Explanation_for_Characteristic = "Needs more water to survive";
        High_Thirst.Explanation_for_Characteristic_kr = "생존을 위한 물의 소모량이 증가합니다.";
        High_Thirst.Characteristic_number = 38;
        High_Thirst.Sprite = Characteristic_Image[38];
        High_Thirst.Points = +6;
        High_Thirst.type = Characteristic_type.Negatives;
        High_Thirst.Choice = Choice;
        return High_Thirst;
        // 갈증 진행 속도 +100%
        // 비활성화되는 특성: 낮은 갈증
    }

    Characteristic Characteristic_Slow_Healer(Characteristic Slow_Healer, bool Choice)
    {
        Slow_Healer.name = "Slow Healer";
        Slow_Healer.name_kr = "느린 치유";
        Slow_Healer.Explanation_for_Characteristic = "Recovers slowly from injuries and illness";
        Slow_Healer.Explanation_for_Characteristic_kr = "부상과 질병을 느리게 회복합니다.";
        Slow_Healer.Characteristic_number = 39;
        Slow_Healer.Sprite = Characteristic_Image[39];
        Slow_Healer.Points = +6;
        Slow_Healer.type = Characteristic_type.Negatives;
        Slow_Healer.Choice = Choice;
        return Slow_Healer;
        // 긁힘, 찢어짐, 물림, 깊은 상처, 화상 상처 심각도 증가
        // 비활성화되는 특성: 빠른 회복
    }
    Characteristic Characteristic_Slow_Learner(Characteristic Slow_Learner, bool Choice)
    {
        Slow_Learner.name = "Slow Learner";
        Slow_Learner.name_kr = "느린 학습";
        Slow_Learner.Explanation_for_Characteristic = "Decreased XP gains";
        Slow_Learner.Explanation_for_Characteristic_kr = "경험치 획득량이 감소합니다.";
        Slow_Learner.Characteristic_number = 40;
        Slow_Learner.Sprite = Characteristic_Image[40];
        Slow_Learner.Points = +6;
        Slow_Learner.type = Characteristic_type.Negatives;
        Slow_Learner.Choice = Choice;
        return Slow_Learner;
        // 모든 스킬의 경험치 획득량 -30%
        // 비활성화되는 특성: 현자
    }

    Characteristic Characteristic_Restless_Sleeper(Characteristic Restless_Sleeper, bool Choice)
    {
        Restless_Sleeper.name = "Restless Sleeper";
        Restless_Sleeper.name_kr = "수면장애";
        Restless_Sleeper.Explanation_for_Characteristic = "Slow loss of tiredness while sleeping";
        Restless_Sleeper.Explanation_for_Characteristic_kr = "잠으로 피곤함을 해소하는 것이 느려집니다.";
        Restless_Sleeper.Characteristic_number = 41;
        Restless_Sleeper.Sprite = Characteristic_Image[41];
        Restless_Sleeper.Points = +6;
        Restless_Sleeper.type = Characteristic_type.Negatives;
        Restless_Sleeper.Choice = Choice;
        return Restless_Sleeper;
        // 최대 수면 시간이 3시간으로 제한됨, 수면으로 경감되는 피로도 감소
    }

    Characteristic Characteristic_Feeble(Characteristic Feeble, bool Choice)
    {
        Feeble.name = "Feeble";
        Feeble.name_kr = "연약함";
        Feeble.Explanation_for_Characteristic = "Less knockback from melee weapons. Decreased carrying weight.";
        Feeble.Explanation_for_Characteristic_kr = "근접무기 사용 시에 뒤로 밀칠 확률이 감소합니다.\r\n옮길 수 있는 무게량이 감소합니다.";
        Feeble.Characteristic_number = 42;
        Feeble.Sprite = Characteristic_Image[42];
        Feeble.Points = +6;
        Feeble.type = Characteristic_type.Negatives;
        Feeble.Choice = Choice;
        return Feeble;
        // 근력 -2
    }

    Characteristic Characteristic_Underweight(Characteristic Underweight, bool Choice)
    {
        Underweight.name = "Underweight";
        Underweight.name_kr = "저체중";
        Underweight.Explanation_for_Characteristic = "Low strength, low endurance and prone to injury.";
        Underweight.Explanation_for_Characteristic_kr = "낮은 힘과 낮은 지구력 그리고 부상 당하기 쉽습니다.";
        Underweight.Characteristic_number = 43;
        Underweight.Sprite = Characteristic_Image[43];
        Underweight.Points = +6;
        Underweight.type = Characteristic_type.Negatives;
        Underweight.Choice = Choice;
        return Underweight;
        // 시작 몸무게: 70kg
        // 몸무게 기준: 65~75kg
        // 체력 -1
        // 근접 대미지 -20%
        // 넘어질 확률 +10%
        // 높은 담장을 넘을 확률 -15%
    }

    Characteristic Characteristic_Illiterate(Characteristic Illiterate, bool Choice)
    {
        Illiterate.name = "Illiterate";
        Illiterate.name_kr = "문맹";
        Illiterate.Explanation_for_Characteristic = "Cannot read books";
        Illiterate.Explanation_for_Characteristic_kr = "책을 읽을 수 없습니다.";
        Illiterate.Characteristic_number = 44;
        Illiterate.Sprite = Characteristic_Image[44];
        Illiterate.Points = +8;
        Illiterate.type = Characteristic_type.Negatives;
        Illiterate.Choice = Choice;
        return Illiterate;
        // 읽기 비활성화
        // 비활성화되는 특성: 속독, 정독
    }

    Characteristic Characteristic_Thin_skinned(Characteristic Thin_skinned, bool Choice)
    {
        Thin_skinned.name = "Thin skinned";
        Thin_skinned.name_kr = "얇은 피부";
        Thin_skinned.Explanation_for_Characteristic = "Increased chance of scratches, lacerations, or bites breaking the skin.";
        Thin_skinned.Explanation_for_Characteristic_kr = "긁히거나 찢어지거나 물릴 위험이 높아집니다.";
        Thin_skinned.Characteristic_number = 45;
        Thin_skinned.Sprite = Characteristic_Image[45];
        Thin_skinned.Points = +8;
        Thin_skinned.type = Characteristic_type.Negatives;
        Thin_skinned.Choice = Choice;
        return Thin_skinned;
        // 모든 긁힘, 찢어짐, 물림 확률 +23%
        // 나무를 지나갈 때 부상이 생길 확률 +30%
        // 회피율 : 15 + (무기 숙련도에 따른 수치 -5% ~ 7%) * {1.3(두꺼운 피부) or 0.77(얇은 피부)}
        // 비활성화되는 특성: 두꺼운 피부
    }

    Characteristic Characteristic_Obese(Characteristic Obese, bool Choice)
    {
        Obese.name = "Obese";
        Obese.name_kr = "비만";
        Obese.Explanation_for_Characteristic = "Reduced running speed, very low endurance and prone to injury.";
        Obese.Explanation_for_Characteristic_kr = "달리는 속도가 느리고 매우 낮은 지구력, 다치기 쉬운 경향이 있습니다.";
        Obese.Characteristic_number = 46;
        Obese.Sprite = Characteristic_Image[46];
        Obese.Points = +10;
        Obese.type = Characteristic_type.Negatives;
        Obese.Choice = Choice;
        return Obese;
        // 체력 -2
        // 달리기 속도 감소
        // 넘어질 확률 +20%, 낙하 대미지 +20%
        // 지구력 회복량 -60%
        // 높은 담장을 넘을 확률 -25%
        // 좀비와 부딪칠 때 넘어질 확률 -10%
    }

    Characteristic Characteristic_Unfit(Characteristic Unfit, bool Choice)
    {
        Unfit.name = "Unfit";
        Unfit.name_kr = "비실함";
        Unfit.Explanation_for_Characteristic = "Very low endurance, very low endurance regeneration.";
        Unfit.Explanation_for_Characteristic_kr = "매우 낮은 지구력과 매우 느린 지구력 회복을 가집니다.";
        Unfit.Characteristic_number = 47;
        Unfit.Sprite = Characteristic_Image[47];
        Unfit.Points = +10;
        Unfit.type = Characteristic_type.Negatives;
        Unfit.Choice = Choice;
        return Unfit;
        // 체력 -4
    }

    Characteristic Characteristic_Very_Underweight(Characteristic Very_Underweight, bool Choice)
    {
        Very_Underweight.name = "Very Underweight";
        Very_Underweight.name_kr = "심한 저체중";
        Very_Underweight.Explanation_for_Characteristic = "Very low strength, very low endurance and prone to injury.";
        Very_Underweight.Explanation_for_Characteristic_kr = "매우 낮은 힘과 매우 낮은 지구력 그리고 부상 당하기 쉽습니다.";
        Very_Underweight.Characteristic_number = 48;
        Very_Underweight.Sprite = Characteristic_Image[48];
        Very_Underweight.Points = +10;
        Very_Underweight.type = Characteristic_type.Negatives;
        Very_Underweight.Choice = Choice;
        return Very_Underweight;
        // 시작 몸무게: 60kg
        // 몸무게 기준: 50~64kg
        // 체력 -2
        // 근접 대미지 -40%
        // 넘어질 확률 +20%
        // 낙하 대미지 +10%
        // 높은 담장을 넘을 확률 -25%
    }

    Characteristic Characteristic_Emaciated(Characteristic Emaciated, bool Choice)
    {
        Emaciated.name = "Emaciated";
        Emaciated.name_kr = "수척함";
        Emaciated.Explanation_for_Characteristic = "Low strength, low endurance and prone to injury";
        Emaciated.Explanation_for_Characteristic_kr = "힘이 약하고 지구력이 약하며 부상을 당하기 쉽습니다";
        Emaciated.Characteristic_number = 49;
        Emaciated.Sprite = Characteristic_Image[49];
        Emaciated.Points = +0;  // 선택불가
        Emaciated.type = Characteristic_type.Negatives;
        Emaciated.Choice = Choice;
        return Emaciated;
        // 몸무게 기준: 49kg 이하
        // 체력 -2
        // 근접 대미지 -60%
        // 넘어질 확률 +25%
        // 낙하 대미지 +20%
        // 높은 담장을 넘을 확률 -25%
        // 지구력 회복량 -70%
        // 체중이 35kg 이하로 내려가면 영양실조로 죽게 됨
    }

    Characteristic Characteristic_Weak(Characteristic Weak, bool Choice)
    {
        Weak.name = "Weak";
        Weak.name_kr = "약함";
        Weak.Explanation_for_Characteristic = "Less knockback from melee weapons. Decreased carrying weight.";
        Weak.Explanation_for_Characteristic_kr = "근접무기 사용 시에 뒤로 밀칠 확률이 감소합니다.\r\n옮길 수 있는 무게량이 감소합니다.";
        Weak.Characteristic_number = 50;
        Weak.Sprite = Characteristic_Image[50];
        Weak.Points = +10;
        Weak.type = Characteristic_type.Negatives;
        Weak.Choice = Choice;
        return Weak;
        // 근력 -5, 무게제한 6으로 감소됨
    }

    Characteristic Characteristic_Deaf(Characteristic Deaf, bool Choice)
    {
        Deaf.name = "Deaf";
        Deaf.name_kr = "청각 장애";
        Deaf.Explanation_for_Characteristic = "Smaller perception radius and hearing range";
        Deaf.Explanation_for_Characteristic_kr = "소리를 들을 수 없습니다.";
        Deaf.Characteristic_number = 51;
        Deaf.Sprite = Characteristic_Image[51];
        Deaf.Points = +12;
        Deaf.type = Characteristic_type.Negatives;
        Deaf.Choice = Choice;
        return Deaf;
        // 소리가 들리지 않는다
        // 비활성화되는 특성: 예민한 청력, 어두운 귀
        // 텔레비전과 비디오는 시청 가능하고 경험치도 받을 수 있음
    }


    /*
     직업 전용 특성
      - 좀도둑
      - 둔감함
     */

    // 좀도둑
    //Characteristic Characteristic_Burglar(Characteristic Burglar, bool Choice)
    //{
    //    Burglar.name = "Burglar";
    //    Burglar.name_kr = "좀도둑";
    //    Burglar.Explanation_for_Characteristic = "Can hotwire vehicles, less chance of breaking the lock of a window.";
    //    Burglar.Explanation_for_Characteristic_kr = "차량에 열선을 연결할 수 있어 창문 잠금 장치가 파손될 가능성이 줄어듭니다.";
    //    Burglar.Characteristic_number = 52;
    //    Burglar.Sprite = Characteristic_Image[52];
    //    Burglar.Points = +0;
    //    Burglar.type = Characteristic_type.Occupation;
    //    Burglar.Choice = Choice;
    //    return Burglar;
    //    // 스킬 제한없이 차량 배선 따기 가능
    //    // 잠긴 창문을 열 때 걸쇠가 걸릴 확률 10% 감소
    //}

    //public void Characteristic_Burglar(bool _Choice)
    //{
    //    string name = "Burglar";
    //    string name_kr = "좀도둑";
    //    string Explanation_for_Characteristic = "Can hotwire vehicles, less chance of breaking the lock of a window.";
    //    string Explanation_for_Characteristic_kr = "차량에 열선을 연결할 수 있어 창문 잠금 장치가 파손될 가능성이 줄어듭니다.";
    //    int Characteristic_number = 52;
    //    Sprite Sprite = Characteristic_Image[52];
    //    int Points = +0;
    //    Characteristic_type type = Characteristic_type.Occupation;
    //    bool Choice = _Choice;
    //    // 스킬 제한없이 차량 배선 따기 가능
    //    // 잠긴 창문을 열 때 걸쇠가 걸릴 확률 10% 감소
    //}

    // 군인
    //Characteristic Characteristic_Desensitized(Characteristic Desensitized, bool Choice)
    //{
    //    Desensitized.name = "Desensitized";
    //    Desensitized.name_kr = "둔감함";
    //    Desensitized.Explanation_for_Characteristic = "War... War never changes.";
    //    Desensitized.Explanation_for_Characteristic_kr = "전쟁... 전쟁은 결코 변하지 않는다.";
    //    Desensitized.Characteristic_number = 53;
    //    Desensitized.Sprite = Characteristic_Image[53];
    //    Desensitized.Points = +0;
    //    Desensitized.type = Characteristic_type.Occupation;
    //    Desensitized.Choice = Choice;
    //    return Desensitized;
    //    // 긴장 무들에 면역
    //}

    //public void Characteristic_Desensitized(bool _Choice)
    //{
    //    string name = "Desensitized";
    //    string name_kr = "둔감함";
    //    string Explanation_for_Characteristic = "War... War never changes.";
    //    string Explanation_for_Characteristic_kr = "전쟁... 전쟁은 결코 변하지 않는다.";
    //    int Characteristic_number = 53;
    //    Sprite Sprite = Characteristic_Image[53];
    //    int Points = +0;
    //    Characteristic_type type = Characteristic_type.Occupation;
    //    bool Choice = _Choice;
    //    // 긴장 무들에 면역
    //}

    // 낚시꾼
    //Characteristic Characteristic_Angler(Characteristic Angler, bool Choice)
    //{
    //    Angler.name = "Angler";
    //    Angler.name_kr = "낚시꾼";
    //    Angler.Explanation_for_Characteristic = "Knows the basics of fishing.";
    //    Angler.Explanation_for_Characteristic_kr = "낚시의 기본을 안다.";
    //    Angler.Characteristic_number = 54;
    //    Angler.Sprite = Characteristic_Image[54];
    //    Angler.Points = -4;
    //    Angler.type = Characteristic_type.Occupation;
    //    Angler.Choice = Choice;
    //    return Angler;
    //    // 낚시 레벨 +1, 미국의 낚시꾼들 Vol.1 내용 습득[2]
    //}

    //public void Characteristic_Angler(bool _Choice)
    //{
    //    string name = "Angler";
    //    string name_kr = "낚시꾼";
    //    string Explanation_for_Characteristic = "Knows the basics of fishing.";
    //    string Explanation_for_Characteristic_kr = "낚시의 기본을 안다.";
    //    int Characteristic_number = 54;
    //    Sprite Sprite = Characteristic_Image[54];
    //    int Points = -4;
    //    Characteristic_type type = Characteristic_type.Occupation;
    //    bool Choice = _Choice;
    //    // 낚시 레벨 +1, 미국의 낚시꾼들 Vol.1 내용 습득[2]
    //}
}
