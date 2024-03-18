using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Literature_Ins : MonoBehaviour
{
    [SerializeField]
    private List<Item_Literature> literature_Ins;
    [SerializeField]
    private GameObject literature_Prefab;


    // 비어있는 책장과 플레이어가 충돌 시 랜덤으로 생성되도록 호출
    // bool로 기존에 생성된 적 있는 오브젝트인지 체크
    public void Set_Generating_Book(Location_Type location_Type)
    {
        System.Random rand_Count = new System.Random();
        int Count = rand_Count.Next(0, 8);  // 0~10개 생성

        for (int i = 0; i < Count; i++)
        {
            System.Random rand_book = new System.Random();
            int item = rand_book.Next(0, literature_Ins.Count);

            Instan(literature_Ins[item]);
        }

    }

    public Item_Literature Instan(Item_Literature literature)
    {
        Item_Literature newliterature = Instantiate(literature_Prefab).GetComponent<Item_Literature>();
        newliterature = literature;
        return newliterature;
    }






}
