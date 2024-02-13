using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    float MinWeight = 0.0f;
    float MaxWeight = 6.0f;
    // 근력 0일 때 MaxWeight = 6.0f
    // 근력 10일 때 MaxWeight = 20.0f
    // 수납도구 착용 시 증가

    public float MaxWeightChange_forStrength(float Level)  // 근력 레벨에 따라 물건 소지량 up
    {
        MaxWeight = 6.0f + 1.5f * Level;

        return MaxWeight;
    }


}
