using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_item_controller : MonoBehaviour
{
    public GameObject[] Hat;//0: ��� 1: ������� 2:���뷹���� 3:����Ȱ���� 4:���̽���Ű���
    public GameObject[] Glasses; // 0: ��۶�
    public GameObject[] Mask; //0: �ݴٳ� 1: ���̽���Ű����ũ 2: �浶��
    public GameObject[] jacket; //0: û���� 1:��������
    public GameObject[] T_shirt; //0: �������Ƽ 1:����Ƽ����(����) 2:����Ƽ����(��ȫ) 3:����Ƽ����(�縷)
    public GameObject[] shirt;//0: ����������(���) 1: ����������(�縷) 2:���̼���
    public GameObject[] underwear;
    public GameObject[] Vest;//0: ��ũž(���) 1: ��ũž(�縷)
    public GameObject Watch;//�ո�ð�
    public GameObject[] Gloves;//0: �����尩(����) 1:�����尩(����)
    public GameObject[] Shoes;//0: ��ȭ 1:����Ź�(�縷) 2:����Ź�(����)
    public GameObject[] Bottoms;//0: ����������(���) 1: ����������(�縷) 2:û���� 3: û�ݹ��� 4: ��Ű�������� 5: ��Ű����
    public GameObject[] protectiveGear;//0: ����������ȣ�� 1: �簢������ȣ��
    public GameObject Cargo_pocket;//��������
    public GameObject MiniBag_forward;//�㸮���� ��
    public GameObject MiniBag_back;//�㸮���� ��
    public GameObject[] Back_back;//0: ����밡�� 1:���ù� 2:����賶 3: å����
    public GameObject[] Handheld_back_R;//0: �������� 1: ��������� 2:�����ڷ�
    public GameObject[] Handheld_back_L;//0: �������� 1: ��������� 2:�����ڷ�
    public GameObject[] Backpack_weapon; // �賶o ��������
    public GameObject[] Back_weapon; // �賶x ��������
    public GameObject[] current_weapon; // ���� ���빫��
    public GameObject current_Hand_R_pos;//���� ������ ��ġ ���� ������Ʈ
    public GameObject current_Hand_L_pos;//���� �޼� ��ġ ���� ������Ʈ
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
        // ī�װ��� ���� ������ �迭 ����
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
                // Watch�� ���� GameObject�̹Ƿ� �迭�� ���� �ʿ䰡 �����ϴ�.
                // �׳� Watch GameObject�� ���� setActive�� ȣ���մϴ�.
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
                Debug.LogError("�߸��� ī�װ��Դϴ�.");
                return;
        }

        // �ش� �迭�� ��Ұ� �����ϴ��� Ȯ�� �� setActive ����
        if (index >= 0 && index < targetArray.Length)
        {
            targetArray[index].SetActive(setActive);
        }
        else
        {
            Debug.LogError("�ε����� ������ ������ϴ�.");
        }
    }
}
