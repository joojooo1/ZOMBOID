using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemConfig : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
    public int ItemID; // ������ȣ i

    public int ItemPrice; // ���� i

    public bool ItemEquipable; // ��񰡴� b
    public int ItemEquipPosition; // �����ġ i

    //1 ���� 2 ���� 
    //3 �尩, 6�Ź�, 5����, 4����

    //4   1
    //5   2
    //6   3
    public bool ItemConsumAble; // �Һ�ǰ b

    public float ItemAtdStat; //���������� f
    public float ItemDefStat; //������� f

    public float ItemMgdStat; //���������� f
    public float ItemMgResisStat; // ������� f

    
}
