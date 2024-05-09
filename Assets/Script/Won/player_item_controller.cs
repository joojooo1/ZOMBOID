using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_item_controller : MonoBehaviour
{
    public GameObject[] Hat;//0: 비니 1: 전투헬멧 2:군용레베모 3:군용활동모 4:아이스하키헬멧
    public GameObject[] Glasses; // 0: 썬글라스
    public GameObject[] Mask; //0: 반다나 1: 아이스하키마스크 2: 방독면
    public GameObject[] jacket; //0: 청자켓 1:가죽자켓
    public GameObject[] T_shirt; //0: 군용반팔티 1:긴팔티셔츠(검정) 2:긴팔티셔츠(분홍) 3:긴팔티셔츠(사막)
    public GameObject[] shirt;//0: 전투복상의(녹색) 1: 전투복상의(사막) 2:와이셔츠
    public GameObject[] underwear;
    public GameObject[] Vest;//0: 탱크탑(녹색) 1: 탱크탑(사막)
    public GameObject Watch;//손목시계
    public GameObject[] Gloves;//0: 가죽장갑(검정) 1:가죽장갑(갈색)
    public GameObject[] Shoes;//0: 군화 1:군용신발(사막) 2:군용신발(검정)
    public GameObject[] Bottoms;//0: 전투복바지(녹색) 1: 전투복바지(사막) 2:청바지 3: 청반바지 4: 스키니전투복 5: 스키니진
    public GameObject[] protectiveGear;//0: 원형무릎보호대 1: 사각무릎보호대
    public GameObject Cargo_pocket;//보조가방
    public GameObject MiniBag_forward;//허리가방 앞
    public GameObject MiniBag_back;//허리가방 뒤
    public GameObject[] Back_back;//0: 여행용가방 1:더플백 2:군용배낭 3: 책가방
    public GameObject[] Handheld_back_R;//0: 서류가방 1: 쓰레기봉투 2:포대자루
    public GameObject[] Handheld_back_L;//0: 서류가방 1: 쓰레기봉투 2:포대자루
    public GameObject[] Backpack_weapon; // 배낭o 보조무기
    public GameObject[] Back_weapon; // 배낭x 보조무기
    public GameObject[] current_weapon; // 현재 착용무기
    public GameObject current_Hand_R_pos;//현재 오른손 위치 관리 오브젝트
    public GameObject current_Hand_L_pos;//현재 왼손 위치 관리 오브젝트
    public GameObject[] current_Hand_R_parent; //allgirls : 0 // milltary_all
    public GameObject[] current_Hand_L_parent; //allgirls : 0 // milltary_all
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool Back_Pack_on = false;
    bool Current_weapon_pos = false;
    public void Current_Weapon(int a , bool set)
    {
        if (current_Hand_R_parent[1].activeSelf)
        {
            Current_weapon_pos= true;
        }
        else
        {
            Current_weapon_pos = false;
        }
        if (Current_weapon_pos)
        {
            current_Hand_R_pos.transform.SetParent(current_Hand_R_parent[1].transform);
            current_Hand_L_pos.transform.SetParent(current_Hand_L_parent[1].transform);
        }
        else
        {
            current_Hand_R_pos.transform.SetParent(current_Hand_R_parent[0].transform);
            current_Hand_L_pos.transform.SetParent(current_Hand_L_parent[0].transform);
        }
        return;
    }
    public void current_Back_Pack(string category, int index, bool setActive)
    {
        GameObject[] targetArray = null;
        if(category == "Weapon")
        {
            for (int i = 0; i < Back_back.Length; i++)
            {
                if (Back_back[i].activeSelf)
                {
                    Back_Pack_on = true;
                    break;
                }
            }
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
                targetArray = Handheld_back_R;
                break;
            case "Handheld_back_L":
                targetArray = Handheld_back_L;
                break;
            case "Hat":
                targetArray = Hat;
                break;
            case "Glasses":
                targetArray = Glasses;
                break;
            case "Mask":
                targetArray = Mask;
                break;
            case "jacket":
                targetArray = jacket;
                break;
            case "T_shirt":
                targetArray = T_shirt;
                break;
            case "shirt":
                targetArray = shirt;
                break;
            case "underwear":
                targetArray = underwear;
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
                break;
            case "Shoes":
                targetArray = Shoes;
                break;
            case "Bottoms":
                targetArray = Bottoms;
                break;
            case "protectiveGear":
                targetArray = protectiveGear;
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
                targetArray = Back_back;
                break;
            case "Backpack_weapon":
                targetArray = Backpack_weapon;
                break;
            case "Back_weapon":
                targetArray = Back_weapon;
                break;
            case "current_weapon":
                targetArray = current_weapon;
                Current_Weapon(index, setActive);
                break;
            case "current_weapons_pos":
                current_Hand_R_pos.SetActive(setActive);
                return;
            case "current_weapon_parent":
                targetArray = current_Hand_R_parent;
                break;
            default:
                Debug.LogError("잘못된 카테고리입니다.");
                return;
        }

        // 해당 배열의 요소가 존재하는지 확인 후 setActive 적용
        if (index >= 0 && index < targetArray.Length)
        {
            targetArray[index].SetActive(setActive);
        }
        else
        {
            Debug.LogError("인덱스가 범위를 벗어났습니다.");
        }
    }
}
