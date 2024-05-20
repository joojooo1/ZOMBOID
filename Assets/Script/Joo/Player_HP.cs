using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public GameObject Ending;

    [SerializeField] float Player_Max_Health = 100.0f;  // 체력 ( Fitness_Level: 5 / Strength_Level: 5 )
    float Player_Min_Health = 0f;
    [SerializeField] float Player_current_Health = 100.0f;
    [SerializeField] float HP_Recovery_Speed = 4f;  // 체력 회복속도
    float HP_Recovery_Speed_forMoodle = 1.0f;

    bool Is_HP_Recovery = true;

    private void Awake()
    {
        Player_current_Health = Player_Max_Health;
    }

    float Hungry_Timer = 0.0f;
    float Bleeding_Timer = 0.0f;
    float HP_Recovery_Timer = 0.0f;
    float Thirsty_Timer = 0.0f;
    float Hyperthermia_Cold_Timer = 0.0f;
    float Sick_Timer = 0.0f;
    private void Update()
    {
        if (UI_main.ui_main.Playing)
        {
            if (Is_HP_Recovery)  // 2초 * 체력회복속도(Moodle)마다 체력 회복
            {
                HP_Recovery_Timer += Time.deltaTime;
                if (HP_Recovery_Timer > HP_Recovery_Speed * HP_Recovery_Speed_forMoodle)
                {
                    if (Player_current_Health < Player_Max_Health)
                    {
                        if (Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Get_Moodle_current_step() < 4)
                        {
                            Set_Player_HP_for_Heal(3.0f);
                        }
                        else
                        {
                            Set_Player_HP_for_Heal(2.2f);
                        }
                    }
                    HP_Recovery_Timer = 0.0f;
                }
            }
            else
            {
                HP_Recovery_Timer = 0.0f;
            }


            if (Player_current_Health > Player_Min_Health)
            {
                /************************* Player_Hungry *************************/
                if (Player_main.player_main.playerMoodles.Moodle_Hungry.Get_Moodle_current_step() > 3)
                {
                    Hungry_Timer += Time.deltaTime;
                    if (Hungry_Timer > 5f)
                    {
                        Player_current_Health -= 0.0025f;
                        Hungry_Timer = 0.0f;
                    }
                }
                else
                {
                    Hungry_Timer = 0.0f;
                }

                /************************* Player_Bleeding *************************/
                if (Player_main.player_main.playerMoodles.Moodle_Bleeding.Get_Moodle_current_step() > 0)
                {
                    // 출혈 발생 시 4초마다 체력 감소 ( Bleeding step에 따라 감소량 다름 )
                    Bleeding_Timer += Time.deltaTime;
                    if (Bleeding_Timer > 4.0f)
                    {
                        switch (Player_main.player_main.playerMoodles.Moodle_Bleeding.Get_Moodle_current_step())
                        {
                            case 0:
                                Player_current_Health -= 0;
                                break;
                            case 1:
                                Player_current_Health -= 2;
                                break;
                            case 2:
                                Player_current_Health -= 5;
                                break;
                            case 3:
                                Player_current_Health -= 10;
                                break;
                            case 4:
                                Player_current_Health -= 20;
                                break;
                            default: break;
                        }

                        if (Player_main.player_main.playerMoodles.Moodle_Heavy_Load.Get_Moodle_current_step() >= 3 && Player_current_Health / Player_Max_Health > 0.25)
                        {
                            Player_current_Health -= 2;
                        }
                        Bleeding_Timer = 0;
                    }
                }
                else
                {
                    Bleeding_Timer = 0;
                }

                /************************* Player_Thirsty *************************/
                if (Player_main.player_main.playerMoodles.Moodle_Thirsty.Get_Moodle_current_step() > 3)  // Thirsty 4단계 이상
                {
                    Thirsty_Timer += Time.deltaTime;
                    if (Thirsty_Timer > 4.0f)
                    {
                        Player_current_Health -= 1;
                        Thirsty_Timer = 0f;
                    }
                }
                else
                {
                    Thirsty_Timer = 0f;
                }

                /************************* Player_Hyperthermia_Cold *************************/
                if (Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Cold.Get_Moodle_current_step() > 3 && (Player_current_Health / Player_Max_Health) > 0.01f)
                {
                    Hyperthermia_Cold_Timer += Time.deltaTime;
                    if (Hyperthermia_Cold_Timer > 5f)
                    {
                        Set_Player_HP_for_Damage(1f);
                        Hyperthermia_Cold_Timer = 0f;
                    }
                }
                else
                {
                    Hyperthermia_Cold_Timer = 0;
                }

                /************************* Player_Sick *************************/
                if (Player_main.player_main.playerMoodles.Moodle_Sick.Get_Moodle_current_step() > 3)
                {
                    Sick_Timer += Time.deltaTime;
                    if (Sick_Timer > 6f)
                    {
                        Set_Player_HP_for_Damage(2.5f);
                        Sick_Timer = 0f;
                    }
                }

                /************************* Player_Injured *************************/
                Player_main.player_main.playerMoodles.Moodle_Injured.Set_Moodles_state(Player_current_Health / Player_Max_Health);

                /************************* Player_Pain *************************/
                Player_main.player_main.playerMoodles.Moodle_Pain.Set_Moodles_state(Player_current_Health / Player_Max_Health);
            }
            else
            {
                /************************* Player_Zombie, Dead *************************/
                UI_main.ui_main.Playing = false;
                if (Player_main.player_main.playerState.Get_Is_Infection())
                {
                    Player_main.player_main.playerMoodles.Moodle_Zombie.Set_Moodles_state(1);
                }
                else
                {
                    Player_main.player_main.playerMoodles.Moodle_Dead.Set_Moodles_state(1);
                }
                Ending.SetActive(true);
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

    float HP_Recovery_Speed_for_Hungry = 1;
    float HP_Recovery_Speed_for_Stuffed = 1;
    float HP_Recovery_Speed_for_Has_A_Cold = 1;
    float HP_Recovery_Speed_for_Sick = 1;
    public void Set_HP_Recovery_Speed_forMoodle(Moodles_private_code _Moodle_Code, float value)
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Hungry:
                HP_Recovery_Speed_for_Hungry = 1 + value;
                break;
            case Moodles_private_code.Stuffed:
                HP_Recovery_Speed_for_Stuffed = 1 - value;
                break;
            case Moodles_private_code.Has_a_Cold:
                HP_Recovery_Speed_for_Has_A_Cold = 1 + value;
                break;
            case Moodles_private_code.Sick:
                HP_Recovery_Speed_for_Sick = 1 + value;
                break;
        }
        HP_Recovery_Speed_forMoodle = HP_Recovery_Speed_for_Hungry * HP_Recovery_Speed_for_Stuffed * HP_Recovery_Speed_for_Has_A_Cold * HP_Recovery_Speed_for_Sick;
    }

    public float Get_HP_Recovery_Speed() { return HP_Recovery_Speed; }
}
