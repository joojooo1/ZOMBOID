using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public static Player_HP player_HP;

    float Player_Max_Health = 100.0f;  // Ã¼·Â ( Fitness_Level: 5 / Strength_Level: 5 )
    float Player_Min_Health = 0f;
    float Player_current_Health = 0f;
    float HP_Reduction_Rate = 0f;

    private void Awake()
    {
        player_HP = this;
        Player_current_Health = Player_Max_Health;
    }

    public void Set_HP_Reduction_Rate()
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
