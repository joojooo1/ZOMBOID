using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public static Player_HP player_HP;

    [SerializeField] float Player_Max_Health = 100.0f;  // 체력 ( Fitness_Level: 5 / Strength_Level: 5 )
    float Player_Min_Health = 0f;
    [SerializeField] float Player_current_Health = 0f;
    [SerializeField] float HP_Recovery_Speed = 1f;  // 체력 회복속도

    bool Is_HP_Recovery = true;

    private void Awake()
    {
        player_HP = this;
        Player_current_Health = Player_Max_Health;
    }

    float Bleeding_Timer = 0.0f;
    float HP_Recovery_Timer = 0.0f;
    private void Update()
    {
        if (Is_HP_Recovery)  // 1초마다 체력 회복
        {
            HP_Recovery_Timer += Time.deltaTime;
            if (HP_Recovery_Timer > HP_Recovery_Speed)
            {



                HP_Recovery_Timer = 0.0f;
            }
        }
        else
        {
            HP_Recovery_Timer = 0.0f;
        }


        if (Player_current_Health > Player_Min_Health)
        {
            if (Player_main.player_main.playerMoodles.Moodle_Bleeding.Get_Moodle_current_step() > 0)
            {
                // 출혈 발생 시 2초마다 체력 감소 ( Bleeding step에 따라 감소량 다름 )
                Bleeding_Timer += Time.deltaTime;
                if (Bleeding_Timer > 2.0f)
                {
                    Player_current_Health -= Player_main.player_main.playerMoodles.Moodle_Bleeding.Get_Moodle_current_value();
                    Bleeding_Timer = 0;
                }
            }
            else
            {
                Bleeding_Timer = 0;
            }

            Player_main.player_main.playerMoodles.Moodle_Injured.Set_Moodles_state(Player_current_Health/Player_Max_Health);
        }
        else
        {
            Player_current_Health = 0;
            if (Player_main.player_main.playerState.Get_Is_Infection())
            {
                Player_main.player_main.playerMoodles.Moodle_Zombie.Set_Moodles_state(0);
            }
            else
            {
                Player_main.player_main.playerMoodles.Moodle_Dead.Set_Moodles_state(0);
            }
        }

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
