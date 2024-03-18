using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Clothing : ScriptableObject
{
    public int Clothing_ID; // �� ���⿡ ���� ����ID

    public string Clothing_Name;
    public Sprite ClothingImage;

    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public bool Is_Equipping;
    public int Equipping_Position;  // ��� ��ġ

    public float ClothingWeight;




}
