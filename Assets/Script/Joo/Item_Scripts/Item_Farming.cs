using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Farming : ScriptableObject
{
    public Type type;
    public Using_Type Usingtype;
    public int Gardening_ID; // �� ���⿡ ���� ����ID

    public string Gardening_Name;
    public string Gardening_Name_kr;
    public Sprite Gardening_Image;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public float Gardening_Weight;
}
