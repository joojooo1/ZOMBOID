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
    /* �ɰ��� 1 */
    Scratches = 0,   // ���� ���� ����
    Glass = 1,  // �������� ����   ( ���� â�� ������, �������� ������ )
    Abrasion = 2,  // �� ���� �Ϲ����� ��ó  ( ��� �������� ���ݴ��Ҷ� )
    /* �ɰ��� 2 */
    Lacerations = 3,  // ���� ���� ����  ( + ��� �������� ���ϰ� ���ݴ��Ҷ�(������ó) )
    Infection = 4,  // ���հ���
    bullet = 5,  // �ѻ�  ( ��� �������� ���ݴ��Ҷ� )
    /* �ɰ��� 3 */
    Bites = 6,  // ���� ���� ����
    Fracture = 7,  // ����  ( ��� �������� ���ݴ��Ҷ� )
    Burn = 8  // ȭ��
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
    // ����Ư�� �� �ݿ��ȵ� �⺻ �ɷ�ġ (���Ƿ� ����)
    [SerializeField] float Weight = 83.0f; // ü�� 0 ~ 150
    [SerializeField] float Calories = 800.0f; // Į�θ� -2200 ~ 3700   // Stuffed 3�ܰ���ʹ� Į�θ� 1000 �̻��̸� ���ļ��� �Ұ���
    [SerializeField] float Satiety = 0.0f;  // ������ -300 ~ 300
    [SerializeField] float Rate_of_Hunger_increase = 1f;  // ��İ�: 150% (�ʴ� -0.09)  �Ϲ�: 100% (�ʴ� -0.06)  �ҽİ�: 0.75% (�ʴ� -0.045)

    [SerializeField] float Min_Attack_Power = 8.0f; // ���ݷ�
    [SerializeField] float Max_Attack_Power = 8.0f;
    [SerializeField] float Evasion = 0.15f;  // ȸ����
    [SerializeField] float Moving_Speed = 3f;  // �̵��ӵ�
    [SerializeField] float Action_Speed = 1f;  // �ൿ�ӵ�
    [SerializeField] float Coughing_Noise_radius = 15f;  // ��ħ ��׷� ����
    [SerializeField] float Endurance = 100f;  // ������

    [SerializeField] float Driving_control = 1f;  // ���� �����
    public float Driving_Speed_min = 2f;  // ���� ���� �ӵ�
    public float Driving_Speed_max = 5f;  // ���� �ְ� �ӵ�
    public float Read_Speed = 1f;  // å �д� �ӵ�

    public bool ability_Sleeping = true;
    public bool ability_Eat = true;
    public bool ability_Read = true;
    public bool ability_Hear = true;

    public bool Is_Equipping_Weapons = false;
    public Item_Weapons Current_equipping_Weapon = null;  // ���� �����, ������ ����� ����
    public bool Is_Aiming = false;  // ����
    public bool Is_Running = false;  // �޸���
    public bool Is_Crouch = false;  // �ɱ׷�������
    public bool Is_Crawl = false;  // ����
    public bool Is_Resting = false;
    public bool Is_drunk = false;
    public bool Is_Cold = false;
    public bool Is_Sleeping = false;
    public bool Is_Smoking = false;
    public bool Is_Outdoor = false;
    public bool Is_Driving = false;
    public bool Is_Eating = false;
    public bool Is_food_poisoning = false;  // ���ߵ�
    public bool Is_Reading = false;

    public float Likelihood_of_food_poisoning = 0.2f;  // ���ߵ��� �ɸ� Ȯ��
    public float Time_for_food_poisoning = 200f;  // ���ߵ� ���� �ð�
    public float Satiety_value = 0.25f;  // ������ ���ҵǴ� ��
    public float Panic_value = 0.15f;

    public Skill_Type current_SkillBook_type;
    public int current_SKillBook_level = -1;
    float Skillbook_Readpage = 0;

    float Enemy_Damage = 0;  // ��������� ���ݷ�
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

            UI_Craft.UI_Craft_main.Add_Crafting_list(Type.literature, 0, Crafting_type.Crafting_General, aaa, "����_General_1", "����_General_1_kr");
            UI_Craft.UI_Craft_main.Crafting_General_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General)].Add_Ingredients(bbb, "ing", "���", 1);

            UI_Craft.UI_Craft_main.Add_Crafting_list(Type.literature, 3, Crafting_type.Crafting_General, bbb, "����_General_2", "����_General_2_kr");
            UI_Craft.UI_Craft_main.Crafting_General_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General)].Add_Ingredients(ccc, "ing", "���", 4);

            UI_Craft.UI_Craft_main.Add_Crafting_list(Type.food, 2, Crafting_type.Crafting_Cook, ccc, "����_Cook_1", "����_Cook_1_kr");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            UI_Craft.UI_Craft_main.Crafting_Cook_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Cook)].Add_Ingredients(aaa, "ing", "���", 1);
            Skill.Fishing_Level.SetEXP(700);
        }

        Weight_text.text = Weight.ToString();
        if (!ability_Sleeping) { Is_Sleeping = false; }
        else { Is_Sleeping = true; }

        if (UI_main.ui_main.Playing)
        {
            /************************************* Player_Satiety **************************************/
            Satiety_Timer += Time.deltaTime;
            if (Satiety_Timer > 1.0f)  // ������ 1�ʿ� 0.25�� ����
            {
                Satiety -= Satiety_value;  // ������ -300 ~ 300
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
            // ��İ�: 150% (�ʴ� -0.09)  �Ϲ�: 100% (�ʴ� -0.06)  �ҽİ�: 0.75% (�ʴ� -0.045)


            /************************************* Player_Calories **************************************/

            Calories_Timer += Time.deltaTime;  // Į�θ� -2200 ~ 3700 
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
                if (Panic_Timer > 1.0f)  // �޽��߿� Panic ��ġ down
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
        // ���ĸ��� �� Calculating_Food_Poisoning ȣ��

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
                /* ��ä��: ���� ������̴� ��׷� ( �̱��� ���� )*/
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

    // Player �̵��ӵ�
    public float Get_Moving_Speed()  
    {
        float Speed = Moving_Speed;

        float speed_forMoodle = Moving_Speed_forMoodle;
        if (playerMoodles.Moodle_Drunk.Get_Moodle_current_step() > 0)
        {
            speed_forMoodle = Moving_Speed_forMoodle / Speed_rate_for_Pain;
        }


       // �޸��� // ����
        // �޸��� + �ɱ׷�
        // ���� + ���
        // ���� // �ɱ׷�

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

    // Player �ൿ�ӵ�
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

    public void Set_Weight(float value)   // ���۽� 83 + value
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


    public void Set_Attack_Power_for_Equipping_Weapons(Item_Weapons Current_Equipping_weapon)  // ���⸦ ���� �Լ� ȣ��
    {
        // ���� Script ��������
        // ���⺰ Ÿ��
        // ���⺰ ���ݷ�
        // ���⺰ ������

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


    // ���ݹ��� �� ����
    // 1. ���� ������ ���ĳ� Ȯ�� ���
    public void Calculate_HitForce(GameObject zom, string Zom_Type, bool IsBack, bool IsDown)  // ���� -> �÷��̾�: ������ ���� ��������, ������ ����, �Ĺ� ����, ����� ����
    {
        Debug.Log("���� ������ !!");

        playerMoodles.Moodle_Panic.Set_Moodles_state(0.01f);  /* ����ģ ������ �� Ȯ�ΰ����ϸ� �޾Ƽ�   0.01 x �����  �� ����*/
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (((float)randomNumber / 100) > playerSkill_ActivationProbability.Get_HitForce())
        {
            Calculating_Probability_of_Injury_Location(Zom_Type, IsBack, IsDown);
            Debug.Log("���� !!");
        }
        else
        {
            //zom.GetComponent<zom_anime>().animatorsetBool("playeratk", true);
            Debug.Log("Miss !!");
        }
    }

    // �� ���ĳ�����
    // 2. ���ݹ��� ��ü ��ġ Ȯ�� ���

    Player_body_Location Random_Damage_Location(Player_body_Location Attack_point, bool IsBack, bool IsDown)
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (!IsBack && !IsDown)  // ���ִ� �������� ���鿡�� ���� ���ϴ� ���
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
        else if (IsBack && !IsDown) // ���ִ� �������� �Ĺ濡�� ���� ���ϴ� ���
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
        else  // ���ٴϴ� �������� ���� ���ϴ� ���
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

    void Calculating_Probability_of_Injury_Location(string Zom_Type, bool IsBack, bool IsDown)  // ���� -> �÷��̾�: ������ ����, �Ĺ� ����
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
                    Debug.Log("3�� �ʰ��� �λ���ġ �ٽ� ���");
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

    // 3. ������ ���� ���� Ȯ�� ���

    void Calculating_the_Probability_of_Zombie_Attack_Pattern(Player_body_Location Attack_point, string Zom_Type, bool IsBack)  // ���� -> �÷��̾�: ���� ���ϴ� ��ġ, ������ ����, �Ĺ� ����
    {
        System.Random rand = new System.Random();
        int Rand_pattern = rand.Next(100);


        if (!IsBack)  // �տ��� ���� ���ϴ� ���
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
        else  // �ڿ��� ���� ���ϴ� ���
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

    public float Calculate_damage_to_Zombie()  // Player -> Zombie ����
    {
        System.Random rand_Damage = new System.Random();
        float Total_Damage = (rand_Damage.Next((int)(Min_Attack_Power*100), (int)(Max_Attack_Power*100)))/100;

        if (Is_Equipping_Weapons)
        {
            float Weapon_Power = 0;
            // ���� ���ݷ� �ҷ����� �Լ�
            // + ���� ������ ��� * ���� ���ݷ�
            // + �ѱ� ���� ���� �� �ݿ�
            Weapon_Power *= playerSkill_ActivationProbability.Get_Increase_in_Attack_Power(Current_equipping_Weapon);  // ���� ������ ���� ���ݷ� ����
        }

        // ġ��Ÿ Ȯ��
        float Critical_Attack_Bonus = 0;
        System.Random rand = new System.Random();
        int rand_Critical = rand.Next(100);
        if(rand_Critical/100 > playerSkill_ActivationProbability.Get_Critical_Hit_Chance())
        {
            Total_Damage *= 1.2f;
        }




        return Total_Damage;
        /* �������

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
 ���� �̱��� ����

 1. �� ��ų���� ����ġ ������ ����




 */