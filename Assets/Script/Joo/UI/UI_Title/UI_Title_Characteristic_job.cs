using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Title_Characteristic_job : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int index;

    string Job_name;
    string Job_name_kr;
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
                Job_name = "Angler";
                Job_name_kr = "���ò�";
                Explanation_for_Characteristic = "Knows the basics of fishing.";
                Explanation_for_Characteristic_kr = "������ �⺻�� �ȴ�.";
                Characteristic_number = 52;
                Points = +4;
                // ���� ���� +1, �̱��� ���ò۵� Vol.1 ���� ����[2]
                // ��� ��� : ���� +3, ä�� +1
                // ��ų ����ġ ���ʽ� : ���� 125%, ä�� 75%
                break;
            case 1:
                Job_name = "Burglar";
                Job_name_kr = "������";
                Explanation_for_Characteristic = "Can hotwire vehicles, less chance of breaking the lock of a window.";
                Explanation_for_Characteristic_kr = "������ ������ ������ �� �־� â�� ��� ��ġ�� �ļյ� ���ɼ��� �پ��ϴ�.";
                Characteristic_number = 53;
                Points = +6;
                // ��ų ���Ѿ��� ���� �輱 ���� ����
                // ��� â���� �� �� �ɼ谡 �ɸ� Ȯ�� 10% ����
                // ��� ��� : ������ ������ +2, ������ �߰��� +2, ���ؽ� �߰��� +2
                // ��ų ����ġ ���ʽ� : ������ �߰��� +100%, ���ؽ� �߰��� +100%, ������ ������ +100%
                break;
            case 2:
                Job_name = "veteran";
                Job_name_kr = "�� ����";
                Explanation_for_Characteristic = "War... War never changes.";
                Explanation_for_Characteristic_kr = "����... ������ ���� ������ �ʴ´�.";
                Characteristic_number = 54;
                Points = +8;
                // ���� ���鿡 �鿪
                // ��� ��� : ���� +2, ������ +2
                // ��ų ����ġ ���ʽ� : ���� +100%, ������ +100%
                break;
            default: break;
        }


        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            UI_Title_Characteristic_text.Characteristic_text.Open_text(Job_name_kr, Explanation_for_Characteristic_kr, Points);
        }
        else
        {
            UI_Title_Characteristic_text.Characteristic_text.Open_text(Job_name, Explanation_for_Characteristic, Points);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Title_Characteristic_text.Characteristic_text.Close_text();
    }





}
