using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    float MinWeight = 0.0f;
    float MaxWeight = 6.0f;
    // �ٷ� 0�� �� MaxWeight = 6.0f
    // �ٷ� 10�� �� MaxWeight = 20.0f
    // �������� ���� �� ����

    public float MaxWeightChange_forStrength(float Level)  // �ٷ� ������ ���� ���� ������ up
    {
        MaxWeight = 6.0f + 1.5f * Level;

        return MaxWeight;
    }


}
