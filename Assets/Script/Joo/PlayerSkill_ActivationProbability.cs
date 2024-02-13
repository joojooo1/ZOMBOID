using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill_ActivationProbability
{
    // 방어 확률
    float Defence_probability = 0.0f;
    public float DefenceProbabilityChange_forPassiveSkill(float Level) // 근력, 체력 레벨에 따른 방어 확률
    {
        Defence_probability = 2.0f * Level;

        return Defence_probability;
    }


}

