using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill_ActivationProbability
{
    // ��� Ȯ��
    float Defence_probability = 0.0f;
    public float DefenceProbabilityChange_forPassiveSkill(float Level) // �ٷ�, ü�� ������ ���� ��� Ȯ��
    {
        Defence_probability = 2.0f * Level;

        return Defence_probability;
    }


}

