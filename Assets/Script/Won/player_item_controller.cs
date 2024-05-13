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
    public GameObject[] Hat;//0: ��� 1: ������� 2:���뷹���� 3:����Ȱ���� 4:���̽���Ű��� 0
    public GameObject[] Glasses; // 0: ��۶� 0
    public GameObject[] Mask; //0: �ݴٳ� 1: ���̽���Ű����ũ 2: �浶�� 0
    public GameObject[] jacket; //0: û���� 1:�������� 2: ����������(���) 3: ����������(�縷) //
    public GameObject[] T_shirt; //0: �������Ƽ 1: ��ũž(���) 2: ��ũž(�縷) //
    public GameObject[] shirt;//0:����Ƽ����(����) 1:����Ƽ����(��ȫ) 2:����Ƽ����(�縷) 3:���̼���//
    public GameObject[] Vest;//0: �����ź���� 1: ������ź���� //
    public GameObject Watch;//�ո�ð�
    public GameObject[] Gloves;//0: �����尩(����) 1:�����尩(����)
    public GameObject[] Shoes;//0: ��ȭ 1:����Ź�(�縷) 2:����Ź�(����)
    public GameObject[] Bottoms;//0: ����������(���) 1: ����������(�縷) 2:û���� 3: ��Ű����1 4: ��Ű�������� 5: ��Ű����2
    public GameObject[] protectiveGear;//0: �簢������ȣ��(��) 1: �簢������ȣ��(��) 2:����������ȣ��(��) 3:����������ȣ��(��)
    public GameObject Cargo_pocket;//��������
    public GameObject MiniBag_forward;//�㸮���� ��
    public GameObject MiniBag_back;//�㸮���� ��
    public GameObject[] Back_Pack;//0: ����밡�� 1:���ù� 2:����賶 3: å����
    public GameObject[] Handheld_Pack_R;//0: �������� 1: ��������� 2:�����ڷ�
    public GameObject[] Handheld_Pack_L;//0: �������� 1: ��������� 2:�����ڷ�
    public GameObject[] Backpack_weapon; // �賶o ��������
    public GameObject[] Back_weapon; // �賶x ��������
    public GameObject[] current_weapon; // ���� ���빫�� 0: ���� 1:���񵵳� 2:�յ��� 3:m14 4:������ 5:js��ź 6:���� 7:������ 8:īŸ�� 9:��ü�� 10: �߱������ 11: ���߱������ 12: �������� 13:���� 14:�� 15:������ġ 16:���ô� 17:���� 18: ��ɿ�Į 19: �ճ� 20: �߽ĵ� 21: ��ũ������̹� 22:������ 23:��Į 24:���к� 25:���̺귻ġ 26: ��ġ 27: �ձٸӸ���ġ 28: �ݼ������� 29: �Ķ����� 30:��ü��â 31:�轺�� 32:����â 33:���۵�â
    public GameObject[] bandage;//0: �Ӹ� 1 : �� 2: ��� 3: ���� 4: �� �� �� 5:���ȾƷ� 6: �� �� �� 7: ���� �Ʒ� 8: ��Ÿ���� 9:�� ����� 10: �� ���Ƹ� 11: �� ����� 12: �� ���Ƹ� 13:�޼� 14:������ 15 :�޹� 16:������   
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
        // ī�װ��� ���� ������ �迭 ����
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
                // Watch�� ���� GameObject�̹Ƿ� �迭�� ���� �ʿ䰡 �����ϴ�.
                // �׳� Watch GameObject�� ���� setActive�� ȣ���մϴ�.
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
                targetArray = protectiveGear;//0�϶� 0,1�� �θ��� 1�϶� 2,3 ȣ���ϰ� ���� 
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
                Debug.LogError("�߸��� ī�װ��Դϴ�.");
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
        // �ش� �迭�� ��Ұ� �����ϴ��� Ȯ�� �� setActive ����
        if (index >= 0 && index < targetArray.Length)
        {
            if(targetArray[index] != null)
            {
                targetArray[index].SetActive(setActive);
            }
        }
        else
        {
            Debug.LogError("�ε����� ������ ������ϴ�.");
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