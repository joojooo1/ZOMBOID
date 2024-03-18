using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Literature_Ins : MonoBehaviour
{
    [SerializeField]
    private List<Item_Literature> literature_Ins;
    [SerializeField]
    private GameObject literature_Prefab;


    // ����ִ� å��� �÷��̾ �浹 �� �������� �����ǵ��� ȣ��
    // bool�� ������ ������ �� �ִ� ������Ʈ���� üũ
    public void Set_Generating_Book(Location_Type location_Type)
    {
        System.Random rand_Count = new System.Random();
        int Count = rand_Count.Next(0, 8);  // 0~10�� ����

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
