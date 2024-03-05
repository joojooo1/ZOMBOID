using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;


public enum Weapon_type
{
    Axe = 0,
    LongBlunt = 1,
    ShortBlunt = 2,
    LongBlade = 3,
    ShortBlade = 4,
    Spear = 5,
    Gun = 6,
}

public enum Zombie_Attack_Pattern
{
    punches = 0,
    Scratches = 1,
    Lacerations = 2,
    Bites = 3
}

public class Player_main : MonoBehaviour
{
    public static Player_main player_main;

    public PlayerInventory_main Inven_main = new PlayerInventory_main();
    public PlayerSkill Skill;

    public PlayerSkill_ActivationProbability playerSkill_ActivationProbability = new PlayerSkill_ActivationProbability();
    public PlayerState playerState = new PlayerState();
    public Player_HP player_HP = new Player_HP();
    public Player_Moodles playerMoodles = new Player_Moodles();

    /* --------------------------------------------------------------------------------- */
    // 직업특성 등 반영안된 기본 능력치 (임의로 설정)
    [SerializeField] float Weight = 83.0f; // 체중
    [SerializeField] float Calories = 300.0f; // 칼로리 0 - 1000   // Stuffed 3단계부터는 칼로리 1000 이상이면 음식섭취 불가능
    [SerializeField] float Temperature = 36.0f; // 온도 20 - 50
    [SerializeField] float Satiety = 50.0f;  // 포만감 -100 - 100

    [SerializeField] float Min_Attack_Power = 8.0f; // 공격력
    [SerializeField] float Max_Attack_Power = 8.0f;
    [SerializeField] float Evasion = 0.15f;  // 회피율
    [SerializeField] float Moving_Speed = 3f;  // 이동속도

    public bool Is_Equipping_Weapons = false;
    public bool Is_Aiming = false;
    public bool Is_Running = false;
    public bool Is_Sleeping = false;
    /* --------------------------------------------------------------------------------- */

    void Awake()
    {
        player_main = this;

        Skill = GetComponent<PlayerSkill>();
        
    }

    float Satiety_Timer = 0.0f;
    void Update()
    {

        // test 함수 -------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            player_HP.Set_Player_HP_for_Damage(20f);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            player_HP.Set_Player_HP_for_Heal(20f);
        }

        // ------------------------------------------------------------- test 함수 

        /************************************* Player_Movement *************************************/
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        Vector3 pos = transform.position;
        pos += input * Time.deltaTime * Get_Moving_Speed();

        transform.position = pos;

        /************************************* Player_Satiety **************************************/
        Satiety_Timer += Time.deltaTime;
        if (Satiety_Timer > 2.0f)  // 포만감 2초에 1.5씩 감소
        {
            Satiety -= 1.5f;
            if(Satiety <= -100) { Satiety = -100.0f; }
            else if (Satiety >= 100) { Satiety = 100.0f; }

            if(Satiety >= 0)
            {
                playerMoodles.Moodle_Stuffed.Set_Moodles_state(Satiety);
            }
            else
            {
                playerMoodles.Moodle_Hungry.Set_Moodles_state(Satiety);
            }
            Satiety_Timer = 0.0f;
        }

        if (playerMoodles.Moodle_Heavy_Load.Get_Moodle_current_step() >= 2)
            Is_Running = false;

        /************************************* Player_Sleeping **************************************/
        if(playerMoodles.Moodle_Pain.Get_Moodle_current_step() > 1)  // Moodle_Pain 2단계부터 수면 불가
        {
            Is_Sleeping = false;
        }

    }



    public float Get_Moving_Speed()
    {
        if (Is_Aiming)
            return Moving_Speed * Moving_Speed_forMoodle * playerSkill_ActivationProbability.Get_Movement_Speed_while_Aiming();
        else
        {
            if (Is_Running)  // 달리면 1.2배로 빨라짐.
            {
                return Moving_Speed * 1.2f * Moving_Speed_forMoodle;
            }
            else
            {
                return Moving_Speed * Moving_Speed_forMoodle;
            }
        }
    }

    float Moving_Speed_forMoodle = 1f;
    float Speed_rate_for_Endurance = 1f;
    float Speed_rate_for_Has_a_Cold = 1f;
    float Speed_rate_for_Heavy_Load = 1f;
    float Speed_rate_for_Pain = 1f;
    public void Set_Moving_Speed_forMoodle(Moodles_private_code _Moodle_Code, float Speed_rate) 
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Endurance:
                Speed_rate_for_Endurance = (1 - Speed_rate);
                break;
            case Moodles_private_code.Has_a_Cold:
                Speed_rate_for_Has_a_Cold = (1 - Speed_rate);
                break;
            case Moodles_private_code.Heavy_Load:
                Speed_rate_for_Heavy_Load = (1 - Speed_rate);
                break;
            case Moodles_private_code.Pain:
                Speed_rate_for_Pain = (1 - Speed_rate);
                break;
        }
        Moving_Speed_forMoodle = Speed_rate_for_Endurance * Speed_rate_for_Has_a_Cold * Speed_rate_for_Heavy_Load + Speed_rate_for_Pain;
    }

    public float Get_Accuracy_forMoodle()
    {
        return Accuracy_forMoodle;
    }


    float Accuracy_forMoodle = 0f;
    float Accuracy_for_Pain = 0f;
    public void Set_Accuracy_forMoodle(Moodles_private_code _Moodle_Code, float value)
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Pain:
                Speed_rate_for_Pain = value;
                break;
        }
        Accuracy_forMoodle = Accuracy_for_Pain;
    }

    public float Get_Evasion()
    {
        return Evasion + playerSkill_ActivationProbability.Get_Injury_chance();
    }


    public void Set_Attack_Power_for_Equipping_Weapons(Item_Weapons Current_Equipping_weapon)  // 무기를 끼면 함수 호출
    {
        // 무기 Script 구현사항
        // 무기별 타입
        // 무기별 공격력
        // 무기별 내구도

        switch ((Weapon_type)Current_Equipping_weapon.WeaponType)
        {
            case Weapon_type.Axe:
                Skill.Axe_Level.Set_Weapon_Equipping_Effect(Current_Equipping_weapon.Is_Equipping);
                break;
            case Weapon_type.LongBlunt:
                Skill.LongBlunt_Level.Set_Weapon_Equipping_Effect(Current_Equipping_weapon.Is_Equipping);
                break;
            case Weapon_type.ShortBlunt:
                Skill.ShortBlunt_Level.Set_Weapon_Equipping_Effect(Current_Equipping_weapon.Is_Equipping);
                break;
            case Weapon_type.LongBlade:
                Skill.LongBlade_Level.Set_Weapon_Equipping_Effect(Current_Equipping_weapon.Is_Equipping);
                break;
            case Weapon_type.ShortBlade:
                Skill.ShortBlade_Level.Set_Weapon_Equipping_Effect(Current_Equipping_weapon.Is_Equipping);
                break;
            case Weapon_type.Spear:
                Skill.Spear_Level.Set_Weapon_Equipping_Effect(Current_Equipping_weapon.Is_Equipping);
                break;
            case Weapon_type.Gun:
                break;
            default:
                break;
        }

    }


    // 공격받을 때 순서
    // 1. 공격 받으면 밀쳐낼 확률 계산
    public void Calculate_HitForce(bool Zombie_Attack, string Zom_Type, bool IsBack, bool IsDown)  // 좀비 -> 플레이어: 좀비의 공격 성공여부, 좀비의 강도, 후방 여부, 기는지 여부
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (((float)randomNumber / 100) > playerSkill_ActivationProbability.Get_HitForce())
        {
            Calculating_Probability_of_Injury_Location(Zom_Type, IsBack, IsDown);
        }
        else
        {
            Debug.Log("Miss !!");
            // 밀쳐낸 애니메이션
        }
    }

    // 못 밀쳐냈을때
    // 2. 공격받을 신체 위치 확률 계산

    void Calculating_Probability_of_Injury_Location(string Zom_Type, bool IsBack, bool IsDown)  // 좀비 -> 플레이어: 좀비의 강도, 후방 여부
    {
        Player_body_Location Attack_point  = new Player_body_Location(0);
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (!IsBack && !IsDown)  // 서있는 좀비한테 정면에서 공격 당하는 경우
        {
            if (randomNumber >= 0 && randomNumber < 12)  // 12%
            {
                Attack_point = playerState.Left_forearm;
            }
            else if (randomNumber >= 12 && randomNumber < 24)  // 12%
            {
                Attack_point = playerState.Right_forearm;
            }
            else if (randomNumber >= 24 && randomNumber < 35)  // 11%
            {
                Attack_point = playerState.Left_upper_arm;
            }
            else if (randomNumber >= 35 && randomNumber < 46)  // 11%
            {
                Attack_point = playerState.Right_upper_arm;
            }
            else if (randomNumber >= 46 && randomNumber < 55)  // 9%
            {
                Attack_point = playerState.Groin;
            }
            else if (randomNumber >= 55 && randomNumber < 63)  // 8%
            {
                Attack_point = playerState.Left_hand;
            }
            else if (randomNumber >= 63 && randomNumber < 71)  // 8%
            {
                Attack_point = playerState.Right_hand;
            }
            else if (randomNumber >= 71 && randomNumber < 78)  // 7%
            {
                Attack_point = playerState.Neck;
            }
            else if (randomNumber >= 78 && randomNumber < 84)  // 6%
            {
                Attack_point = playerState.upper_torso;
            }
            else if (randomNumber >= 84 && randomNumber < 90)  // 6%
            {
                Attack_point = playerState.Lower_torso;
            }
            else if (randomNumber >= 90 && randomNumber < 94)  // 4%
            {
                Attack_point = playerState.Head;
            }
            else if (randomNumber >= 94 && randomNumber < 95)  // 1%
            {
                Attack_point = playerState.Left_thigh;
            }
            else if (randomNumber >= 95 && randomNumber < 96)  // 1%
            {
                Attack_point = playerState.Right_thigh;
            }
            else if (randomNumber >= 96 && randomNumber < 97)  // 1%
            {
                Attack_point = playerState.Left_shin;
            }
            else if (randomNumber >= 97 && randomNumber < 98)  // 1%
            {
                Attack_point = playerState.Right_shin;
            }
            else if (randomNumber >= 98 && randomNumber < 99)  // 1%
            {
                Attack_point = playerState.Left_foot;
            }
            else if (randomNumber >= 99 && randomNumber < 100)  // 1%
            {
                Attack_point = playerState.Right_foot;
            }
        }
        else if (IsBack && !IsDown) // 서있는 좀비한테 후방에서 공격 당하는 경우
        {
            if (randomNumber >= 0 && randomNumber < 50)  // 7% -> 50%
            {
                Attack_point = playerState.Neck;
            }
            else if (randomNumber >= 50 && randomNumber < 90)  // 4% -> 40%
            {
                Attack_point = playerState.Head;
            }
            else if (randomNumber >= 90 && randomNumber < 92)  // 6% -> 2%
            {
                Attack_point = playerState.upper_torso;
            }
            else if (randomNumber >= 92 && randomNumber < 94)  // 6% -> 2%
            {
                Attack_point = playerState.Lower_torso;
            }
            else if (randomNumber >= 94 && randomNumber < 95)  // 8% -> 1%
            {
                Attack_point = playerState.Left_hand;
            }
            else if (randomNumber >= 95 && randomNumber < 96)  // 8% -> 1%
            {
                Attack_point = playerState.Right_hand;
            }
            else if (randomNumber >= 96 && randomNumber < 97)  // 11% -> 1%
            {
                Attack_point = playerState.Left_upper_arm;
            }
            else if (randomNumber >= 97 && randomNumber < 98)  // 11% -> 1%
            {
                Attack_point = playerState.Right_upper_arm;
            }
            else if (randomNumber >= 98 && randomNumber < 99)  // 12% -> 1%
            {
                Attack_point = playerState.Left_forearm;
            }
            else if (randomNumber >= 99 && randomNumber < 100)  // 12% -> 1%
            {
                Attack_point = playerState.Right_forearm;
            }
        }
        else  // 기어다니는 좀비한테 공격 당하는 경우
        {
            if (randomNumber >= 0 && randomNumber < 17)  // 1% -> 17%
            {
                Attack_point = playerState.Left_foot;
            }
            else if (randomNumber >= 17 && randomNumber < 34)  // 1% -> 17%
            {
                Attack_point = playerState.Right_foot;
            }
            else if (randomNumber >= 34 && randomNumber < 49)  // 1% -> 15%
            {
                Attack_point = playerState.Left_shin;
            }
            else if (randomNumber >= 49 && randomNumber < 64)  // 1% -> 15%
            {
                Attack_point = playerState.Right_shin;
            }
            else if (randomNumber >= 64 && randomNumber < 77)  // 1% -> 13%
            {
                Attack_point = playerState.Left_thigh;
            }
            else if (randomNumber >= 77 && randomNumber < 90)  // 1% -> 13%
            {
                Attack_point = playerState.Right_thigh;
            }
            else if (randomNumber >= 90 && randomNumber < 100)  // 10%
            {
                Attack_point = playerState.Groin;
            }
        }
        
        Calculating_the_Probability_of_Zombie_Attack_Pattern(Attack_point, Zom_Type, IsBack);
    }

    // 3. 좀비의 공격 패턴 확률 계산

    void Calculating_the_Probability_of_Zombie_Attack_Pattern(Player_body_Location Attack_point, string Zom_Type, bool IsBack)  // 좀비 -> 플레이어: 공격 당하는 위치, 좀비의 강도, 후방 여부
    {
        System.Random rand = new System.Random();
        int Rand_pattern = rand.Next(100);


        if (!IsBack)  // 앞에서 공격 당하는 경우
        {
            if (Rand_pattern >= 0 && Rand_pattern < 25)  // 25%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.punches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 25 && Rand_pattern < 50)  // 25%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Scratches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 50 && Rand_pattern < 75)  // 25%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Lacerations, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 75 && Rand_pattern < 100)  // 25%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Bites, Zom_Type, IsBack);
            }
        }
        else  // 뒤에서 공격 당하는 경우
        {
            if (Rand_pattern >= 0 && Rand_pattern < 70)  // 70%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Bites, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 70 && Rand_pattern < 80)  // 10%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.punches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 80 && Rand_pattern < 90)  // 10%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Scratches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 90 && Rand_pattern < 100)  // 10%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Lacerations, Zom_Type, IsBack);
            }
        }


    }


    public float Calculate_damage_to_Zombie()  // Player -> Zombie 공격
    {
        System.Random rand_Damage = new System.Random();
        float Total_Damage = (rand_Damage.Next((int)(Min_Attack_Power*100), (int)(Max_Attack_Power*100)))/100;

        if (Is_Equipping_Weapons)
        {
            float Weapon_Power = 0;
            // 무기 공격력 불러오는 함수
            // + 근접 무기일 경우 * 근접 공격력
            // + 총기 사용시 조준 등 반영
            Weapon_Power *= playerSkill_ActivationProbability.Get_Increase_in_Attack_Power();  // 무기 레벨에 따른 공격력 증가
        }

        // 치명타 확률
        float Critical_Attack_Bonus = 0;
        System.Random rand = new System.Random();
        int rand_Critical = rand.Next(100);
        if(rand_Critical/100 > playerSkill_ActivationProbability.Get_Critical_Hit_Chance())
        {
            Total_Damage *= 1.2f;
        }


        return Total_Damage;
        /* 참고사항

          1. Get damage from weapon/wielder.
          2. If damage is more than 0.7, reduce to 0.7 (unarmed).
          3. damage *= 0.3+AxeLevel*0.1
          4. damage *= 0.3+BluntLevel*0.1
          5. critical chance = weapon.critchance + weapon.AimingPerkCritModifier * (AimingLevel/2)
          6. damage = damage*2 (Axe)
 
         */


    }
}

/*
 아직 미구현 사항

 1. 각 스킬마다 경험치 오르는 조건




 */