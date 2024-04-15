using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Title_Characteristic_job : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int index;

    string name;
    string name_kr;
    string Explanation_for_Characteristic;
    string Explanation_for_Characteristic_kr;
    int Characteristic_number;
    Sprite Sprite;
    int Points;
    Characteristic_type type = Characteristic_type.Occupation;

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (index)
        {
            case 0:
                name = "Angler";
                name_kr = "낚시꾼";
                Explanation_for_Characteristic = "Knows the basics of fishing.";
                Explanation_for_Characteristic_kr = "낚시의 기본을 안다.";
                Characteristic_number = 52;
                Points = -4;
                // 낚시 레벨 +1, 미국의 낚시꾼들 Vol.1 내용 습득[2]
                break;
            case 1:
                name = "Burglar";
                name_kr = "좀도둑";
                Explanation_for_Characteristic = "Can hotwire vehicles, less chance of breaking the lock of a window.";
                Explanation_for_Characteristic_kr = "차량에 열선을 연결할 수 있어 창문 잠금 장치가 파손될 가능성이 줄어듭니다.";
                Characteristic_number = 53;
                Points = -6;
                // 스킬 제한없이 차량 배선 따기 가능
                // 잠긴 창문을 열 때 걸쇠가 걸릴 확률 10% 감소
                break;
            case 2:
                name = "veteran";
                name_kr = "퇴역 군인";
                Explanation_for_Characteristic = "War... War never changes.";
                Explanation_for_Characteristic_kr = "전쟁... 전쟁은 결코 변하지 않는다.";
                Characteristic_number = 54;
                Points = +0;
                // 긴장 무들에 면역
                break;
            default: break;
        }


        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            UI_Title_Characteristic_text.Characteristic_text.Open_text(name_kr, Explanation_for_Characteristic_kr, Points);
        }
        else
        {
            UI_Title_Characteristic_text.Characteristic_text.Open_text(name, Explanation_for_Characteristic, Points);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Title_Characteristic_text.Characteristic_text.Close_text();
    }





}
