using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Clothing : ScriptableObject
{
    public Type type;
    public Clothing_Type ClothingType;
    public int Clothing_ID; // �� ���⿡ ���� ����ID

    public string Clothing_Name;
    public string Clothing_Name_kr;
    public Sprite ClothingImage;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public bool Is_Equipping;
    public body_point Equipping_Position;  // ��� ��ġ

    public float ClothingWeight;




}
