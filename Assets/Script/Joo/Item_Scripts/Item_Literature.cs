using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Literature : ScriptableObject
{
    public Type type;
    public Book_Type LiteratureType;
    public Skill_Type LiteratureSkillType;
    public PowerSources_Type PowerSources_Type;
    public bool created;
    public int Literature_ID;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public string LiteratureName;
    public string LiteratureName_Kr;
    public float LiteratureWeight;
    public Sprite Literature_Image;

    public int Literature_Level;

    public float L_Unhappiness;
    public float L_Stress;
    public float L_Boredom;

}


/*  Magazine
   
  - Fishing
    1. Angler USA Magazine Vol. 1 : ���ô�
    2. Angler USA Magazine Vol. 2 : ���, ������

   - Electrical
    1. Electronics Magazine Vol. 1 : �����������
    2. Electronics Magazine Vol. 2 : Ÿ�̸�
    3. Electronics Magazine Vol. 3 : ���۰�������
    4. Electronics Magazine Vol. 4 : ��������Ʈ����
    5. Engineer Magazine Vol. 1 : �����߻���
    6. Engineer Magazine Vol. 2 : ����ź
    7. Guerilla Radio Vol. 1 : ����
    8. Guerilla Radio Vol. 2 : ������
    9. Guerilla Radio Vol. 3 : �� ����
    10. How to Use Generators : ������
    11. Laines Auto Manual - Standard Models : �Ϲ� ������ ������ �� �ְ� ��
    12. Laines Auto Manual - Commercial Models : ����/����� ������ ������ �� �ְ� ��
    13. Laines Auto Manual - Performance Models : ������ī�� ������ �� �ְ� ��
    14. The Metalwork Magazine Vol. 1 : �ݼ� ��, �ݼ� ����
    15. The Metalwork Magazine Vol. 2 : �ݼ� �����̳�
    16. The Metalwork Magazine Vol. 3 : �ݼ� �潺
    17. The Metalwork Magazine Vol. 4 : �ݼ� ��, ���� �ݼ� ��

   - Cooking
    1. Good Cooking Magazine Vol. 1 : ����ũ, ���� ����
    2. Good Cooking Magazine Vol. 2 : ������

   - Farming
    1. The Farming Magazine : ������ ������, �ĸ� ������

   - Foraging
    1. The Herbalist : ���, ����, ������ ������ �� �ְ� �� ( ���� �� ������ ������ �����Ǿ� ���� )

 */