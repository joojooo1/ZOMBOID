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
                name_kr = "���ò�";
                Explanation_for_Characteristic = "Knows the basics of fishing.";
                Explanation_for_Characteristic_kr = "������ �⺻�� �ȴ�.";
                Characteristic_number = 52;
                Points = -4;
                // ���� ���� +1, �̱��� ���ò۵� Vol.1 ���� ����[2]
                break;
            case 1:
                name = "Burglar";
                name_kr = "������";
                Explanation_for_Characteristic = "Can hotwire vehicles, less chance of breaking the lock of a window.";
                Explanation_for_Characteristic_kr = "������ ������ ������ �� �־� â�� ��� ��ġ�� �ļյ� ���ɼ��� �پ��ϴ�.";
                Characteristic_number = 53;
                Points = -6;
                // ��ų ���Ѿ��� ���� �輱 ���� ����
                // ��� â���� �� �� �ɼ谡 �ɸ� Ȯ�� 10% ����
                break;
            case 2:
                name = "veteran";
                name_kr = "�� ����";
                Explanation_for_Characteristic = "War... War never changes.";
                Explanation_for_Characteristic_kr = "����... ������ ���� ������ �ʴ´�.";
                Characteristic_number = 54;
                Points = +0;
                // ���� ���鿡 �鿪
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
