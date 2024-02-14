using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    float MinWeight = 0.0f;
    float MaxWeight = 6.0f;
    // �ٷ� 0�� �� MaxWeight = 6.0f
    // �ٷ� 10�� �� MaxWeight = 20.0f
    // �������� ���� �� ����

    public float Get_MaxWeight()
    {
        return MaxWeight;
    }

    // ���� �ѵ�  // Strength
    public void Set_MaxWeight_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                MaxWeight = 6.0f;
                break;
            case 1:
                MaxWeight = 7.0f;
                break;
            case 2:
                MaxWeight = 8.0f;
                break;
            case 3:
                MaxWeight = 9.0f;
                break;
            case 4:
                MaxWeight = 11.0f;
                break;
            case 5:
                MaxWeight = 12.0f;
                break;
            case 6:
                MaxWeight = 14.0f;
                break;
            case 7:
                MaxWeight = 15.0f;
                break;
            case 8:
                MaxWeight = 16.0f;
                break;
            case 9:
                MaxWeight = 18.0f;
                break;
            case 10:
                MaxWeight = 20.0f;
                break;
            default:
                break;
        }

    }


}
