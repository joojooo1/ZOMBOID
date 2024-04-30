using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;
//using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;
public enum Damage_Pattern
{
    /* 심각도 1 */
    Scratches = 0,   // 좀비에 의한 긁힘
    Glass = 1,  // 유리조각 박힘   ( 깨진 창문 넘을때, 유리조각 밟을때 )
    Abrasion = 2,  // 그 외의 일반적인 상처  ( 상대 유저한테 공격당할때 )
    /* 심각도 2 */
    Lacerations = 3,  // 좀비에 의한 찢김  ( + 상대 유저한테 심하게 공격당할때(깊은상처) )
    Infection = 4,  // 세균감염
    bullet = 5,  // 총상  ( 상대 유저한테 공격당할때 )
    /* 심각도 3 */
    Bites = 6,  // 좀비에 의한 물림
    Fracture = 7,  // 골절  ( 상대 유저한테 공격당할때 )
    Burn = 8  // 화상
}



public class Player_main : MonoBehaviour
{
    public static Player_main player_main;

    public PlayerInventory_main Inven_main;
    public PlayerSkill Skill;

    public PlayerSkill_ActivationProbability playerSkill_ActivationProbability = new PlayerSkill_ActivationProbability();
    public PlayerState playerState;
    public Player_HP player_HP;
    public Player_Moodles playerMoodles;
   

    [SerializeField] UnityEngine.UI.Text Weight_text;

    /* --------------------------------------------------------------------------------- */
    // 직업특성 등 반영안된 기본 능력치 (임의로 설정)
    [SerializeField] float Weight = 83.0f; // 체중 0 ~ 150
    [SerializeField] float Calories = 800.0f; // 칼로리 -2200 ~ 3700   // Stuffed 3단계부터는 칼로리 1000 이상이면 음식섭취 불가능
    [SerializeField] float Satiety = 0.0f;  // 포만감 -300 ~ 300
    [SerializeField] float Rate_of_Hunger_increase = 1f;  // 대식가: 150% (초당 -0.09)  일반: 100% (초당 -0.06)  소식가: 0.75% (초당 -0.045)

    [SerializeField] float Min_Attack_Power = 8.0f; // 공격력
    [SerializeField] float Max_Attack_Power = 8.0f;
    [SerializeField] float Evasion = 0.15f;  // 회피율
    [SerializeField] float Moving_Speed = 3f;  // 이동속도
    [SerializeField] float Action_Speed = 1f;  // 행동속도
    [SerializeField] float Coughing_Noise_radius = 15f;  // 기침 어그로 범위
    [SerializeField] float Endurance = 100f;  // 지구력

    [SerializeField] float Driving_control = 1f;  // 운전 제어력
    public float Driving_Speed_min = 2f;  // 운전 최저 속도
    public float Driving_Speed_max = 5f;  // 운전 최고 속도
    public float Read_Speed = 1f;  // 책 읽는 속도

    public bool ability_Sleeping = true;
    public bool ability_Eat = true;
    public bool ability_Read = true;
    public bool ability_Hear = true;

    public bool Is_Equipping_Weapons = false;
    public Item_Weapons Current_equipping_Weapon = null;  // 무기 착용시, 착용한 무기로 변경
    public bool Is_Aiming = false;  // 조준
    public bool Is_Running = false;  // 달릴때
    public bool Is_Crouch = false;  // 쪼그려앉을때
    public bool Is_Crawl = false;  // 기어갈때
    public bool Is_Resting = false;
    public bool Is_drunk = false;
    public bool Is_Cold = false;
    public bool Is_Sleeping = false;
    public bool Is_Smoking = false;
    public bool Is_Outdoor = false;
    public bool Is_Driving = false;
    public bool Is_Eating = false;
    public bool Is_food_poisoning = false;  // 식중독
    public bool Is_Reading = false;

    public float Likelihood_of_food_poisoning = 0.2f;  // 식중독에 걸릴 확률
    public float Time_for_food_poisoning = 200f;  // 식중독 유지 시간
    public float Satiety_value = 0.25f;  // 포만감 감소되는 양
    public float Panic_value = 0.15f;

    public Skill_Type current_SkillBook_type;
    public int current_SKillBook_level = -1;
    float Skillbook_Readpage = 0;

    float Enemy_Damage = 0;  // 상대유저의 공격력
    /* --------------------------------------------------------------------------------- */

    void Awake()
    {
        player_main = this;

        Skill = GetComponent<PlayerSkill>();
        Weight_text.text = Weight.ToString();

    }

    public Sprite aaa;
    public Sprite bbb;
    public Sprite ccc;

    float Calories_Timer = 0.0f;
    float Satiety_Timer = 0.0f;
    float Panic_Timer = 0.0f;
    float Panic_Timer_for_Agoraphobic = 0.0f;
    float Cold_Timer = 0.0f;
    float Smoker_Timer = 0.0f;
    float Sleeping_Timer = 0.0f;
    float Food_Poison_Timer = 0.0f;
    float Read_Timer = 0.0f;
    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Skill.Fishing_Level.Set_S_Level(3);
            //Skill.Fishing_Level.Set_S_Books_Point(3);

            //Skill.Fishing_Level.Set_S_Level(3);
            //Skill.Fishing_Level.Set_S_Books_Point(3);

            UI_Craft.UI_Craft_main.Add_Crafting_list(Type.literature, 0, Crafting_type.Crafting_General, aaa, "제작_General_1", "제작_General_1_kr");
            UI_Craft.UI_Craft_main.Crafting_General_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General)].Add_Ingredients(bbb, "ing", "재료", 1);

            UI_Craft.UI_Craft_main.Add_Crafting_list(Type.literature, 3, Crafting_type.Crafting_General, bbb, "제작_General_2", "제작_General_2_kr");
            UI_Craft.UI_Craft_main.Crafting_General_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General)].Add_Ingredients(ccc, "ing", "재료", 4);

            UI_Craft.UI_Craft_main.Add_Crafting_list(Type.food, 2, Crafting_type.Crafting_Cook, ccc, "제작_Cook_1", "제작_Cook_1_kr");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            UI_Craft.UI_Craft_main.Crafting_Cook_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Cook)].Add_Ingredients(aaa, "ing", "재료", 1);
            Skill.Fishing_Level.SetEXP(700);
        }

        Weight_text.text = Weight.ToString();
        if (!ability_Sleeping) { Is_Sleeping = false; }
        else { Is_Sleeping = true; }

        if (UI_main.ui_main.Playing)
        {
            /************************************* Player_Satiety **************************************/
            Satiety_Timer += Time.deltaTime;
            if (Satiety_Timer > 1.0f)  // 포만감 1초에 0.25씩 감소
            {
                Satiety -= Satiety_value;  // 포만감 -300 ~ 300
                if (Satiety < -300) { Satiety = -300.0f; }
                else if (Satiety > 300) { Satiety = 300.0f; }

                if (Satiety >= 0)
                {
                    playerMoodles.Moodle_Stuffed.Set_Moodles_state(Satiety);
                }
                else
                {
                    playerMoodles.Moodle_Hungry.Set_Moodles_state(-Satiety);
                }
                Satiety_Timer = 0.0f;
            }
            // 대식가: 150% (초당 -0.09)  일반: 100% (초당 -0.06)  소식가: 0.75% (초당 -0.045)


            /************************************* Player_Calories **************************************/

            Calories_Timer += Time.deltaTime;  // 칼로리 -2200 ~ 3700 
            if (Calories_Timer > 1f)
            {
                if (Is_Running)
                {
                    Set_Calories(-1f);
                }
                else
                {
                    Set_Calories(-0.5f);
                }
                Calories_Timer = 0;
            }

            /************************************* Player_Panic **************************************/
            if (Player_Characteristic.current.Agoraphobic_characteristics)
            {
                if (Is_Outdoor)
                {
                    Panic_Timer_for_Agoraphobic += Time.deltaTime;
                    if (Panic_Timer > 1f)
                    {
                        playerMoodles.Moodle_Panic.Set_Moodles_state(Panic_value);
                        Panic_Timer_for_Agoraphobic = 0;
                    }
                }
            }
            else if (Player_Characteristic.current.Claustrophobic_characteristics)
            {
                if (!Is_Outdoor)
                {
                    Panic_Timer_for_Agoraphobic += Time.deltaTime;
                    if (Panic_Timer > 1f)
                    {
                        playerMoodles.Moodle_Panic.Set_Moodles_state(Panic_value);
                        Panic_Timer_for_Agoraphobic = 0;
                    }
                }
            }

            if (Is_Resting)
            {
                Panic_Timer += Time.deltaTime;
                if (Panic_Timer > 1.0f)  // 휴식중에 Panic 수치 down
                {
                    if (Is_drunk == false)
                    {
                        playerMoodles.Moodle_Panic.Set_Moodles_state(-0.05f);
                    }
                    else
                    {
                        playerMoodles.Moodle_Panic.Set_Moodles_state(-0.08f);
                    }
                    Panic_Timer = 0.0f;
                }
            }

            /************************************* Player_Stressed **************************************/
            if (Player_Characteristic.current.Smoker_characteristics)
            {
                Smoker_Timer += Time.deltaTime;
                if (Is_Smoking)
                {
                    Smoker_Timer = 0f;
                    Is_Smoking = false;
                    playerMoodles.Moodle_Stressed.Set_Moodles_state(-1);
                    playerMoodles.Moodle_Unhappy.Set_Moodles_state(-0.1f);
                }
                else
                {
                    if (Smoker_Timer > 5f)
                    {
                        Smoker_Timer = 0f;
                        if (playerMoodles.Moodle_Stressed.Get_Moodle_current_step() <= 2)
                        {
                            playerMoodles.Moodle_Stressed.Set_Moodles_state(0.03f);
                        }
                    }
                }
            }
            else
            {
                if (Is_Smoking)
                {
                    Is_Smoking = false;
                    playerMoodles.Moodle_Stressed.Set_Moodles_state(-0.05f);
                }
            }

            /************************************* Player_Sleep **************************************/
            if (Player_Characteristic.current.Restless_Sleeper_characteristics)
            {
                if (Is_Sleeping)
                {
                    Sleeping_Timer += Time.deltaTime;
                    if (Sleeping_Timer > 144)
                    {
                        ability_Sleeping = false;
                        Sleeping_Timer = 0f;
                    }
                }
                else
                {
                    Sleeping_Timer += Time.deltaTime;
                    if (Sleeping_Timer > 48)
                    {
                        ability_Sleeping = true;
                        Sleeping_Timer = 0f;
                    }
                }
            }
        }

        /* -------------------------- Is_Eating -------------------------- */
        // 음식먹을 때 Calculating_Food_Poisoning 호출

        if (Is_food_poisoning)
        {
            Food_Poison_Timer += Time.deltaTime;
            if (Food_Poison_Timer > Time_for_food_poisoning)
            {
                Food_Poison_Timer = 0;
                Is_food_poisoning = false;
            }
            else if (Food_Poison_Timer > 0 && Food_Poison_Timer < 200)
            {
                playerMoodles.Moodle_Sick.Set_Moodles_state(0.03f);
            }
        }

        /************************************* Player_Heavy_Load **************************************/
        if (playerMoodles.Moodle_Heavy_Load.Get_Moodle_current_step() >= 2)
            Is_Running = false;

        /****************** Player_Has_a_Cold ******************/
        if (Is_Cold)
        {
            Cold_Timer += Time.deltaTime;
            if (Cold_Timer > (20 / playerMoodles.Moodle_Has_a_Cold.Get_Moodle_current_step()))
            {
                /* 재채기: 좀비를 끌어들이는 어그로 ( 미구현 사항 )*/
            }
        }

        /****************** Player_Is_Reading ******************/
        if (Is_Reading)
        {
            Read_Timer += Time.deltaTime;
            if(Read_Timer >= 5f)
            {
                Skillbook_Readpage++;
                Read_Timer = 0;
                switch (current_SkillBook_type)
                {
                    case Skill_Type.Fishing:
                        Skill.Fishing_Level.Set_S_Books_Point(current_SKillBook_level, Skillbook_Readpage);
                        if (Skill.Fishing_Level.Check_S_Book_Reading_finish(current_SKillBook_level, Skillbook_Readpage) >= 1)
                        {
                            Is_Reading = false;
                            Skillbook_Readpage = 0;
                        }
                        break;
                    case Skill_Type.Hunting:
                        Skill.Hunting_Level.Set_S_Books_Point(current_SKillBook_level, Skillbook_Readpage);
                        if (Skill.Hunting_Level.Check_S_Book_Reading_finish(current_SKillBook_level, Skillbook_Readpage) >= 1)
                        {
                            Is_Reading = false;
                            Skillbook_Readpage = 0;
                        }
                        break;
                    case Skill_Type.Foraging:
                        Skill.Foraging_Level.Set_S_Books_Point(current_SKillBook_level, Skillbook_Readpage);
                        if (Skill.Foraging_Level.Check_S_Book_Reading_finish(current_SKillBook_level, Skillbook_Readpage) >= 1)
                        {
                            Is_Reading = false;
                            Skillbook_Readpage = 0;
                        }
                        break;
                    case Skill_Type.Riding:
                        Skill.Riding_Level.Set_S_Books_Point(current_SKillBook_level, Skillbook_Readpage);
                        if (Skill.Riding_Level.Check_S_Book_Reading_finish(current_SKillBook_level, Skillbook_Readpage) >= 1)
                        {
                            Is_Reading = false;
                            Skillbook_Readpage = 0;
                        }
                        break;                    
                    case Skill_Type.Carpentry:
                        Skill.Carpentry_Level.Set_C_Books_Point(current_SKillBook_level, Skillbook_Readpage);
                        if(Skill.Carpentry_Level.Check_C_Book_Reading_finish(current_SKillBook_level, Skillbook_Readpage) >= 1)
                        {
                            Is_Reading = false;
                            Skillbook_Readpage = 0;
                        }
                        break;
                    case Skill_Type.Cooking:
                        Skill.Cooking_Level.Set_C_Books_Point(current_SKillBook_level, Skillbook_Readpage);
                        if (Skill.Cooking_Level.Check_C_Book_Reading_finish(current_SKillBook_level, Skillbook_Readpage) >= 1)
                        {
                            Is_Reading = false;
                            Skillbook_Readpage = 0;
                        }
                        break;
                    case Skill_Type.Farming:
                        Skill.Farming_Level.Set_C_Books_Point(current_SKillBook_level, Skillbook_Readpage);
                        if (Skill.Farming_Level.Check_C_Book_Reading_finish(current_SKillBook_level, Skillbook_Readpage) >= 1)
                        {
                            Is_Reading = false;
                            Skillbook_Readpage = 0;
                        }
                        break;
                    case Skill_Type.FirstAid:
                        Skill.FirstAid_Level.Set_C_Books_Point(current_SKillBook_level, Skillbook_Readpage);
                        if (Skill.FirstAid_Level.Check_C_Book_Reading_finish(current_SKillBook_level, Skillbook_Readpage) >= 1)
                        {
                            Is_Reading = false;
                            Skillbook_Readpage = 0;
                        }
                        break;
                    case Skill_Type.Electrical:
                        Skill.Electrical_Level.Set_C_Books_Point(current_SKillBook_level, Skillbook_Readpage);
                        if (Skill.Electrical_Level.Check_C_Book_Reading_finish(current_SKillBook_level, Skillbook_Readpage) >= 1)
                        {
                            Is_Reading = false;
                            Skillbook_Readpage = 0;
                        }
                        break;
                }
            }
        }
        else
        {
            Read_Timer = 0;
        }
    }

    public void Set_Endurance(float value)
    {
        Endurance += value;
        if (Endurance > 100) { Endurance = 100; }
        else if (Endurance < 0) { Endurance = 0; }

        playerMoodles.Moodle_Endurance.Set_Moodles_state(Endurance);
    }

    public float Get_Endurance() { return Endurance; }

    // Player 이동속도
    public float Get_Moving_Speed()  
    {
        float Speed = Moving_Speed;

        float speed_forMoodle = Moving_Speed_forMoodle;
        if (playerMoodles.Moodle_Drunk.Get_Moodle_current_step() > 0)
        {
            speed_forMoodle = Moving_Speed_forMoodle / Speed_rate_for_Pain;
        }


       // 달리기 // 조준
        // 달리기 + 쪼그려
        // 조준 + 기는
        // 조준 // 쪼그려

        if (Is_Running)
        {
            Speed *= 1.2f;
            if (Is_Crouch)
            {
                Speed *= 0.8f;
            }
        }
        else if (Is_Aiming)
        {
            Speed *= playerSkill_ActivationProbability.Get_Movement_Speed_while_Aiming();
            if (Is_Crawl)
            {
                Speed *= 0.8f;
            }
        }
        else if (Is_Crouch)
        {
            Speed *= 0.8f;
            if (Is_Running)
            {
                Speed *= 1.2f;
            }
        }
        else if (Is_Crawl)
        {
            Speed *= 0.3f;
            if (Is_Aiming)
            {
                Speed *= playerSkill_ActivationProbability.Get_Movement_Speed_while_Aiming();
            }
        }

        return Speed * speed_forMoodle;
    }

    float Moving_Speed_forMoodle = 1f;
    float Speed_rate_for_Endurance = 1f;
    float Speed_rate_for_Has_a_Cold = 1f;
    float Speed_rate_for_Heavy_Load = 1f;
    float Speed_rate_for_Pain = 1f;
    float Speed_rate_for_Hyperthermia_Hot = 1f;
    float Speed_rate_for_Hyperthermia_Cold = 1f;
    float Speed_rate_for_Unhappy = 1f;
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
            case Moodles_private_code.Hyperthermia_Hot:
                Speed_rate_for_Hyperthermia_Hot = (1 - Speed_rate);
                break;
            case Moodles_private_code.Hyperthermia_Cold:
                Speed_rate_for_Hyperthermia_Cold = (1 - Speed_rate);
                break;
            case Moodles_private_code.Unhappy:
                Speed_rate_for_Unhappy = (1 - Speed_rate/100);
                break;
        }
        Moving_Speed_forMoodle = Speed_rate_for_Endurance * Speed_rate_for_Has_a_Cold * Speed_rate_for_Heavy_Load * Speed_rate_for_Pain * Speed_rate_for_Hyperthermia_Hot * Speed_rate_for_Hyperthermia_Cold * Speed_rate_for_Unhappy;
    }

    // Player 행동속도
    public float Get_Action_Speed()
    {
        return Action_Speed * Action_Speed_forMoodle;
    }

    float Action_Speed_forMoodle = 1f;
    public void Set_Action_Speed_forMoodle(float value)  // Unhappy
    {
        Action_Speed_forMoodle = (1 - (value/100));
    }

    public float Get_Driving_Speed(float value)
    {
        return Driving_Speed * Driving_control;
    }

    float Driving_Speed = 1f;
    public void Set_Driving_Speed(float value)
    {
        float speed = Driving_Speed_min;
        speed *= value;
        if (speed < Driving_Speed_min) { speed = Driving_Speed_min; }
        else if (speed > Driving_Speed_max) { speed = Driving_Speed_max; }
        Driving_Speed = speed;
    }

    public void Set_Driving_control(float value)
    {
        Driving_control = value;
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

    public float Get_Calories()
    {
        return Calories;
    }

    public void Set_Calories(float value)
    {
        Calories += value;

        if (Calories < -2200) { Calories = -2200.0f; }
        else if (Calories > 3700) { Calories = 3700.0f; }
    }

    public float Get_Weight()
    {
        return Weight;
    }

    public void Set_Weight(float value)   // 시작시 83 + value
    {
        Weight += value;
        if (Weight < 0) { Weight = 0.0f; }
        else if (Weight > 150) { Weight = 150.0f; }

        Player_Characteristic.current.Set_Characteristic_for_Weight(Get_Weight());
    }

    public void Calculating_Food_Poisoning(float food_value)
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (((float)randomNumber / 100) < Likelihood_of_food_poisoning + food_value)
        {
            Is_food_poisoning = true;
        }
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
    public void Calculate_HitForce(GameObject zom, string Zom_Type, bool IsBack, bool IsDown)  // 좀비 -> 플레이어: 좀비의 공격 성공여부, 좀비의 강도, 후방 여부, 기는지 여부
    {
        Debug.Log("좀비가 공격함 !!");

        playerMoodles.Moodle_Panic.Set_Moodles_state(0.01f);  /* 마주친 좀비의 수 확인가능하면 받아서   0.01 x 좀비수  로 수정*/
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (((float)randomNumber / 100) > playerSkill_ActivationProbability.Get_HitForce())
        {
            Calculating_Probability_of_Injury_Location(Zom_Type, IsBack, IsDown);
            Debug.Log("성공 !!");
        }
        else
        {
            //zom.GetComponent<zom_anime>().animatorsetBool("playeratk", true);
            Debug.Log("Miss !!");
        }
    }

    // 못 밀쳐냈을때
    // 2. 공격받을 신체 위치 확률 계산

    Player_body_Location Random_Damage_Location(Player_body_Location Attack_point, bool IsBack, bool IsDown)
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (!IsBack && !IsDown)  // 서있는 좀비한테 정면에서 공격 당하는 경우
        {
            if (randomNumber >= 0 && randomNumber < 12)  // 12%
            {
                Attack_point = playerState.Left_lowerarm;
            }
            else if (randomNumber >= 12 && randomNumber < 24)  // 12%
            {
                Attack_point = playerState.Right_lowerarm;
            }
            else if (randomNumber >= 24 && randomNumber < 35)  // 11%
            {
                Attack_point = playerState.Left_upperarm;
            }
            else if (randomNumber >= 35 && randomNumber < 46)  // 11%
            {
                Attack_point = playerState.Right_upperarm;
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
                Attack_point = playerState.Chest;
            }
            else if (randomNumber >= 84 && randomNumber < 90)  // 6%
            {
                Attack_point = playerState.Abdomen;
            }
            else if (randomNumber >= 90 && randomNumber < 94)  // 4%
            {
                Attack_point = playerState.Head;
            }
            else if (randomNumber >= 94 && randomNumber < 95)  // 1%
            {
                Attack_point = playerState.Left_upperleg;
            }
            else if (randomNumber >= 95 && randomNumber < 96)  // 1%
            {
                Attack_point = playerState.Right_upperleg;
            }
            else if (randomNumber >= 96 && randomNumber < 97)  // 1%
            {
                Attack_point = playerState.Left_lowerleg;
            }
            else if (randomNumber >= 97 && randomNumber < 98)  // 1%
            {
                Attack_point = playerState.Right_lowerleg;
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
                Attack_point = playerState.Chest;
            }
            else if (randomNumber >= 92 && randomNumber < 94)  // 6% -> 2%
            {
                Attack_point = playerState.Abdomen;
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
                Attack_point = playerState.Left_upperarm;
            }
            else if (randomNumber >= 97 && randomNumber < 98)  // 11% -> 1%
            {
                Attack_point = playerState.Right_upperarm;
            }
            else if (randomNumber >= 98 && randomNumber < 99)  // 12% -> 1%
            {
                Attack_point = playerState.Left_lowerarm;
            }
            else if (randomNumber >= 99 && randomNumber < 100)  // 12% -> 1%
            {
                Attack_point = playerState.Right_lowerarm;
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
                Attack_point = playerState.Left_lowerleg;
            }
            else if (randomNumber >= 49 && randomNumber < 64)  // 1% -> 15%
            {
                Attack_point = playerState.Right_lowerleg;
            }
            else if (randomNumber >= 64 && randomNumber < 77)  // 1% -> 13%
            {
                Attack_point = playerState.Left_upperleg;
            }
            else if (randomNumber >= 77 && randomNumber < 90)  // 1% -> 13%
            {
                Attack_point = playerState.Right_upperleg;
            }
            else if (randomNumber >= 90 && randomNumber < 100)  // 10%
            {
                Attack_point = playerState.Groin;
            }
        }

        return Attack_point;
    }

    void Calculating_Probability_of_Injury_Location(string Zom_Type, bool IsBack, bool IsDown)  // 좀비 -> 플레이어: 좀비의 강도, 후방 여부
    {
        Player_body_Location Attack_point = new Player_body_Location(0);

        List<Player_body_Location> Full_Location = new List<Player_body_Location>();
        for (int i = 0; i < playerState.Player_body_point.Count; i++)
        {
            int damage_fullcount = 0;
            for (int j = 0; j < playerState.Player_body_point[i].Body_Damage_array.Length; j++)
            {
                if (playerState.Player_body_point[i].Body_Damage_array[j] != null)
                    damage_fullcount++;
            }

            if(damage_fullcount == 3)
                Full_Location.Add(playerState.Player_body_point[i]);
        }

        Attack_point = Random_Damage_Location(Attack_point, IsBack, IsDown);
        Debug.Log(Attack_point.Get_body_point().ToString());
        Debug.Log(Attack_point.Get_DamageCount());

        if(Full_Location.Count != 0)
        {
            for (int i = 0; i < Full_Location.Count;)
            {
                if (Full_Location[i].Get_body_point() == Attack_point.Get_body_point())
                {
                    Attack_point = Random_Damage_Location(Attack_point, IsBack, IsDown);
                    i = 0;
                    Debug.Log("3개 초과로 부상위치 다시 계산");
                }
                else
                {
                    i++;
                }

                // i == Full_Location.Count && Full_Location[i].Get_body_point() != Attack_point.Get_body_point()
                if (i == Full_Location.Count)
                {
                    Calculating_the_Probability_of_Zombie_Attack_Pattern(Attack_point, Zom_Type, IsBack);
                }
            }
        }
        else
        {
            Calculating_the_Probability_of_Zombie_Attack_Pattern(Attack_point, Zom_Type, IsBack);
        }

    }

    // 3. 좀비의 공격 패턴 확률 계산

    void Calculating_the_Probability_of_Zombie_Attack_Pattern(Player_body_Location Attack_point, string Zom_Type, bool IsBack)  // 좀비 -> 플레이어: 공격 당하는 위치, 좀비의 강도, 후방 여부
    {
        System.Random rand = new System.Random();
        int Rand_pattern = rand.Next(100);


        if (!IsBack)  // 앞에서 공격 당하는 경우
        {
            Debug.Log(IsBack);
            if (Rand_pattern >= 0 && Rand_pattern < 33)  // 33%
            {
                Attack_point.Set_Body_state(Damage_Pattern.Scratches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 33 && Rand_pattern < 66)  // 33%
            {
                Attack_point.Set_Body_state(Damage_Pattern.Lacerations, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 66 && Rand_pattern < 100)  // 34%
            {
                Attack_point.Set_Body_state(Damage_Pattern.Bites, Zom_Type, IsBack);
            }
        }
        else  // 뒤에서 공격 당하는 경우
        {
            Debug.Log(IsBack);
            if (Rand_pattern >= 0 && Rand_pattern < 70)  // 70%
            {
                Attack_point.Set_Body_state(Damage_Pattern.Bites, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 70 && Rand_pattern < 85)  // 15%
            {
                Attack_point.Set_Body_state(Damage_Pattern.Scratches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 85 && Rand_pattern < 100)  // 15%
            {
                Attack_point.Set_Body_state(Damage_Pattern.Lacerations, Zom_Type, IsBack);
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
            Weapon_Power *= playerSkill_ActivationProbability.Get_Increase_in_Attack_Power(Current_equipping_Weapon);  // 무기 레벨에 따른 공격력 증가
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