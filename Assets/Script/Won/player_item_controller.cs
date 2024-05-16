using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_item_controller : MonoBehaviour
{
    public GameObject Hat_off;
    public GameObject Hat_on;
    public GameObject top_body;
    public GameObject bottom_body;
    public GameObject foot;
    public GameObject Hand_L;
    public GameObject Hand_R;
    public GameObject[] Hat;//0: 비니 1: 전투헬멧 2:군용레베모 3:군용활동모 4:아이스하키헬멧 0
    public GameObject[] Glasses; // 0: 썬글라스 0
    public GameObject[] Mask; //0: 반다나 1: 아이스하키마스크 2: 방독면 0
    public GameObject[] jacket; //0: 청자켓 1:가죽자켓 2: 전투복상의(녹색) 3: 전투복상의(사막) //
    public GameObject[] T_shirt; //0: 군용반팔티 1: 탱크탑(녹색) 2: 탱크탑(사막) //
    public GameObject[] shirt;//0:긴팔티셔츠(검정) 1:긴팔티셔츠(분홍) 2:긴팔티셔츠(사막) 3:와이셔츠//
    public GameObject[] Vest;//0: 군용방탄조끼 1: 경찰방탄조끼 //
    public GameObject Watch;//손목시계
    public GameObject[] Gloves;//0: 가죽장갑(검정) 1:가죽장갑(갈색)
    public GameObject[] Shoes;//0: 군화 1:군용신발(사막) 2:군용신발(검정)
    public GameObject[] Bottoms;//0: 전투복바지(녹색) 1: 전투복바지(사막) 2:청바지 3: 스키니진1 4: 스키니전투복 5: 스키니진2
    public GameObject[] protectiveGear;//0: 사각무릎보호대(오) 1: 사각무릎보호대(왼) 2:원형무릎보호대(오) 3:원형무릎보호대(왼)
    public GameObject Cargo_pocket;//보조가방
    public GameObject MiniBag_forward;//허리가방 앞
    public GameObject MiniBag_back;//허리가방 뒤
    public GameObject[] Back_Pack;//0: 여행용가방 1:더플백 2:군용배낭 3: 책가방
    public GameObject[] Handheld_Pack_R;//0: 서류가방 1: 쓰레기봉투 2:포대자루
    public GameObject[] Handheld_Pack_L;//0: 서류가방 1: 쓰레기봉투 2:포대자루
    public GameObject[] Backpack_weapon; // 배낭o 보조무기
    public GameObject[] Back_weapon; // 배낭x 보조무기
    public GameObject[] current_weapon; // 현재 착용무기 0: 도끼 1:벌목도끼 2:손도끼 3:m14 4:더블베럴 5:js산탄 6:권총 7:리볼버 8:카타나 9:마체테 10: 야구방망이 11: 못야구방망이 12: 쇠지렛대 13:괭이 14:삽 15:대형망치 16:낚시대 17:판자 18: 사냥용칼 19: 손낫 20: 중식도 21: 스크류드라이버 22:모종삽 23:빵칼 24:진압봉 25:파이브렌치 26: 망치 27: 둥근머리망치 28: 금속파이프 29: 후라이팬 30:마체테창 31:쇠스랑 32:나무창 33:제작된창
    public GameObject[] bandage;//0: 머리 1 : 목 2: 어깨 3: 복부 4: 왼 팔 위 5:왼팔아래 6: 오 팔 위 7: 오팔 아래 8: 사타구니 9:왼 허벅지 10: 왼 종아리 11: 오 허벅지 12: 오 종아리 13:왼손 14:오른손 15 :왼발 16:오른발   
    // Start is called before the first frame update
    void Start()
    {
        start_item();
    }

    // Update is called once per frame
    void Update()
    {

    }
    bool Back_Pack_on = false;
    bool Hand = false;
    bool hat = false;
    bool bot = false;
    bool shooes = false;
    bool TOP = false;
    public void current_Back_Pack(string category, int index, bool setActive)
    {
        GameObject[] targetArray = null;
        if (category == "Weapon")
        {
            if (Back_Pack_on)
            {
                category = "Backpack_weapon";
            }
            else
            {
                category = "Back_weapon";
            }
        }
        // 카테고리에 따라 적절한 배열 선택
        switch (category)
        {
            case "Handheld_back_R":
                targetArray = Handheld_Pack_R;
                break;
            case "Handheld_back_L":
                targetArray = Handheld_Pack_L;
                break;
            case "Hat":
                targetArray = Hat;
                Hair(setActive);
                break;
            case "Glasses":
                targetArray = Glasses;
                break;
            case "Mask":
                targetArray = Mask;
                break;
            case "jacket":
                targetArray = jacket;
                jacket_set = setActive;
                top_body_set(setActive);
                break;
            case "T_shirt":
                targetArray = T_shirt;
                TOP_SET(category, setActive, index);
                top_body_set(setActive);
                break;
            case "shirt":
                targetArray = shirt;
                TOP_SET(category, setActive, index);
                top_body_set(setActive);
                break;
            case "Vest":
                targetArray = Vest;
                break;
            case "Watch":
                // Watch는 단일 GameObject이므로 배열에 넣을 필요가 없습니다.
                // 그냥 Watch GameObject에 직접 setActive를 호출합니다.
                Watch.SetActive(setActive);
                return;
            case "Gloves":
                targetArray = Gloves;
                hand(setActive);
                break;
            case "Shoes":
                targetArray = Shoes;
                foots(setActive);
                break;
            case "Bottoms":
                targetArray = Bottoms;
                bot_body(setActive);
                break;
            case "protectiveGear":
                targetArray = protectiveGear;//0일때 0,1도 부르고 1일때 2,3 호출하게 변경 
                break;
            case "Cargo_pocket":
                Cargo_pocket.SetActive(setActive);
                return;
            case "MiniBag_forward":
                MiniBag_forward.SetActive(setActive);
                return;
            case "MiniBag_back":
                MiniBag_back.SetActive(setActive);
                return;
            case "Back_back":
                targetArray = Back_Pack;
                Back_Pack_on = setActive;
                break;
            case "Backpack_weapon":
                targetArray = Backpack_weapon;
                break;
            case "Back_weapon":
                bandage_set(setActive,index);
                return;
            case "current_weapon":
                targetArray = current_weapon;
                break;
            case "bandage":
                targetArray = bandage;
                break;
            default:
                Debug.LogError("잘못된 카테고리입니다.");
                return;
        }
        if (targetArray == shirt)
        {
            if (jacket_set)
            {
                return;
            }
        }
        if (targetArray == T_shirt)
        {
            if (jacket_set || shit_set)
            {
                return;
            }
        }
        // 해당 배열의 요소가 존재하는지 확인 후 setActive 적용
        if (index >= 0 && index < targetArray.Length)
        {
            if(targetArray[index] != null)
            {
                targetArray[index].SetActive(setActive);
            }
        }
        else
        {
            Debug.LogError("인덱스가 범위를 벗어났습니다.");
        }
    }
    bool jacket_set = false;
    bool shit_set = false;
    int shit_set_index;
    bool t_shit_set = false;
    int t_shit_set_index;
    void TOP_SET(string item_type, bool set, int index)
    {
        if (set)
        {
            if (item_type == "shirt")
            {
                shit_set = true;
                shit_set_index = index;
            }
            else
            {
                t_shit_set = true;
                t_shit_set_index = index;
            }
        }
        else
        {
            if (item_type == "shirt")
            {
                shit_set = false;
            }
            else
            {
                t_shit_set = false;
            }
        }
    }
    void top_body_set(bool setActive)
    {
        if (!jacket_set || !shit_set || !t_shit_set)
        {

            top_body.SetActive(!setActive);
        }
        else
        {
            top_body.SetActive(false);
            
        }
        if (!jacket_set && t_shit_set)
        {
            if (shit_set)
            {
                shirt[shit_set_index].SetActive(true);
            }
            else
            {
                T_shirt[t_shit_set_index].SetActive(true);
            }
        }
        TOP = setActive;
        bandage_seve_on(0);
    }
    void Hair(bool setActive)
    {
        Hat_on.SetActive(setActive);
        Hat_off.SetActive(!setActive);
        hat = setActive;
        bandage_seve_on(4);
    }
    void hand(bool setActive)
    {
        Hand_L.SetActive(!setActive);
        Hand_R.SetActive(!setActive);
        Hand = setActive;
        bandage_seve_on(2);
    }
    void foots(bool setActive)
    {
        foot.SetActive(!setActive);
        shooes = setActive;
        bandage_seve_on(3);
    }
    void bot_body(bool setActive)
    {
        bottom_body.SetActive(!setActive);
        bot = setActive;
        bandage_seve_on(1);
    }
    List<int> bandage_seve = new List<int>();
    void bandage_set(bool setActive,int index)
    {
        if(index >= 2 && index <= 7)
        {
            if (!TOP)
            {
                bandage[index].SetActive(setActive);
            }
        }
        else if (index >=8 && index <= 12)
        {
            if (!bot)
            {
                bandage[index].SetActive(setActive);
            }
        }
        else if(index >= 13 && index <= 14)
        {
            if (!Hand)
            {
                bandage[index].SetActive(setActive);
            }
        }
        else if(index >= 15 && index <= 16)
        {
            if (!shooes)
            {
                bandage[index].SetActive(setActive);
            }
        }
        else if (index >= 0)
        {
            if (!hat)
            {
                bandage[index].SetActive(setActive);
            }
        }
        else
            bandage[index].SetActive(setActive);
        if(setActive)
        {
            bandage_seve.Add(index);
        }
        else
        {
            bandage_seve.Remove(index);
        }
    }
    void bandage_seve_on(int pos)
    {
        foreach(int index in bandage_seve)
        {
            if (index >= 2 && index <= 7 && pos == 0)
            {
                if (!TOP)
                {
                    bandage[index].SetActive(true);
                }
            }
            else if (index >= 8 && index <= 12 && pos == 1)
            {
                if (!bot)
                {
                    bandage[index].SetActive(true);
                }
            }
            else if (index >= 13 && index <= 14 && pos == 2)
            {
                if (!Hand)
                {
                    bandage[index].SetActive(true);
                }
            }
            else if (index >= 15 && index <= 16 && pos == 3)
            {
                if (!shooes)
                {
                    bandage[index].SetActive(true);
                }
            }
            else if (index >= 0 && pos == 4)
            {
                if (!hat)
                {
                    bandage[index].SetActive(true);
                }
            }
        }
    }

    void start_item()
    {
        int a = 0;
        foreach (var item in Hat)
        {
            if (item.activeSelf)
            {
                Hair(item.activeSelf);
                break;
            }
            else
                Hair(item.activeSelf);
        }
        foreach (var item in Gloves)
        {
            if (item.activeSelf)
            {
                hand(item.activeSelf);
                break;
            }
            else
                hand(item.activeSelf);
        }
        foreach (var item in jacket)
        {
            
            if (item.activeSelf)
            {
                jacket_set = item.activeSelf;
                TOP_SET("jacket", item.activeSelf, a);
                top_body_set(item.activeSelf);
                break;
            }
            else
            {
                jacket_set = item.activeSelf;
                top_body_set(item.activeSelf);
            }
            a++;
        }
        a = 0;
        foreach (var item in shirt)
        {
            if (item.activeSelf)
            {
                shit_set = item.activeSelf;
                TOP_SET("shirt", item.activeSelf, a);
                top_body_set(item.activeSelf);
                break;
            }
            else
            {
                shit_set = item.activeSelf;
                top_body_set(item.activeSelf);
            }
            a++;
        }
        a = 0;
        foreach (var item in T_shirt)
        {
            if (item.activeSelf)
            {
                t_shit_set = item.activeSelf;
                TOP_SET("T_shirt", item.activeSelf, a);
                top_body_set(item.activeSelf);
                break;
            }
            else
            {
                t_shit_set = item.activeSelf;
                top_body_set(item.activeSelf);
            }
            a++;
        }
        foreach (var item in Bottoms)
        {
            if (item.activeSelf)
            {
                bot_body(item.activeSelf);
                break;
            }
            else
            {
                bot_body(item.activeSelf);
            }
        }
        foreach (var item in Shoes)
        {
            if (item.activeSelf)
            {
                foots(item.activeSelf);
                break;
            }
            else
            {
                foots(item.activeSelf);
            }
        }
        foreach (var item in Back_Pack)
        {
            if (item.activeSelf)
            {
                Back_Pack_on = item.activeSelf;
                break;
            }
            
        }
        a = 0;
    }
}