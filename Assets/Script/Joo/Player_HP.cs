using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public static Player_HP player_HP;

    float Player_Max_Health = 100.0f;  // 체력 ( Fitness_Level: 5 / Strength_Level: 5 )
    float Player_Min_Health = 0f;
    float Player_current_Health = 0f;
    float HP_Reduction_Rate = 0f;

    private void Awake()
    {
        player_HP = this;
        Player_current_Health = Player_Max_Health;
    }

    float Bleeding_Timer = 0.0f;
    private void Update()
    {
        Bleeding_Timer += Time.deltaTime;

        //if (Timer > 3.0f)
        //{
        //    // 3초마다 피로도 +3.0f * 피로도 생성 비율 (임의로 설정)
        //    // Moodle_Tired.Set_Moodles_state();
        //    Timer = 0.0f;
        //}

        if (Get_HP_Reduction_Rate() != 0)
        {

        }

        if (Player_main.player_main.playerMoodles.Moodle_Bleeding.Get_Moodle_current_step() > 0)
        {
            if (Bleeding_Timer > 3.0f)
            {
                Player_current_Health -= Player_main.player_main.playerMoodles.Moodle_Bleeding.Get_Moodle_current_value();
                Bleeding_Timer = 0;
            }
        }
    }

    public float Get_HP_Reduction_Rate()
    {
        return HP_Reduction_Rate;
    }

    public void Set_HP_Reduction_Rate(float Persistent_Damage)
    {

    }

    public void Set_Player_HP_for_Damage(float damage)
    {
        Player_current_Health -= damage;
    }

    public void Set_Player_HP_for_Heal(float Heal)
    {
        Player_current_Health += Heal;
    }

    public float Get_Player_HP()
    {
        return Player_current_Health;
    }

}
