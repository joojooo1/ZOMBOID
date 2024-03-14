using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medical_Ins : MonoBehaviour
{
    [SerializeField]
    private List<Item_Medical> medical_Ins;
    [SerializeField]
    private GameObject Medical_Prefab;

    // 비어있는 오브젝트(약국의 선반 등)와 플레이어가 충돌 시 랜덤으로 생성되도록 호출
    // bool로 기존에 생성된 적 있는 오브젝트인지 체크
    public void Set_Generating_item(Location_Type location_Type)
    {
        List<Item_Medical> medical_List = new List<Item_Medical>();
        for (int i = 0; i < medical_Ins.Count; i++)
        {
            if (medical_Ins[i].Is_Ins)  // 제작해야하는 아이템 제외
                medical_List.Add(medical_Ins[i]);
        }

        System.Random rand_Count = new System.Random();
        int Count = rand_Count.Next(0, 8);  // 0~6개 생성

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
