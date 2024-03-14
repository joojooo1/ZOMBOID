using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medical_Ins : MonoBehaviour
{
    [SerializeField]
    private List<Item_Medical> medical_Ins;
    [SerializeField]
    private GameObject Medical_Prefab;

    // ����ִ� ������Ʈ(�౹�� ���� ��)�� �÷��̾ �浹 �� �������� �����ǵ��� ȣ��
    // bool�� ������ ������ �� �ִ� ������Ʈ���� üũ
    public void Set_Generating_item(Location_Type location_Type)
    {
        List<Item_Medical> medical_List = new List<Item_Medical>();
        for (int i = 0; i < medical_Ins.Count; i++)
        {
            if (medical_Ins[i].Is_Ins)  // �����ؾ��ϴ� ������ ����
                medical_List.Add(medical_Ins[i]);
        }

        System.Random rand_Count = new System.Random();
        int Count = rand_Count.Next(0, 8);  // 0~6�� ����

        for (int i = 0; i < Count; i++)
        {
            System.Random rand_item = new System.Random();
            int item = rand_item.Next(0, medical_List.Count);

            Instan(medical_List[item]);
        }

    }

    public Medical Instan(Item_Medical medical)
    {
        Medical newMedical = Instantiate(Medical_Prefab).GetComponent<Medical>();
        newMedical.medicalData = medical;
        return newMedical;
    }

}
