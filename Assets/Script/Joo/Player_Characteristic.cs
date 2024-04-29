using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements.Experimental;
using UnityEngine.XR;

public enum Characteristic_type
{
    Positives = 0,
    Negatives = 1,
    Occupation = 2
}

public enum Player_Job
{
    None = 0,
    fisher = 1,
    Burglar = 2,
    Veteran = 3
}

public class Characteristic
{
    public string name;
    public string name_kr;
    public string Explanation_for_Characteristic;
    public string Explanation_for_Characteristic_kr;
    public int Characteristic_number;
    public Sprite Sprite;

    public int Points;
    public Characteristic_type type;
    public bool Choice;
    public List<float> value_list = new List<float>();
}

public class Player_Characteristic : MonoBehaviour
{
    [SerializeField] Transform Characteristic_P_Window;
    [SerializeField] Transform Characteristic_N_Window;
    [SerializeField] Transform Characteristic_S_Window;
    [SerializeField] Sprite[] Characteristic_Image;
    [SerializeField] GameObject Characteristic_Prefab;

    public Player_Job player_Job = Player_Job.None;

    public bool Smoker_characteristics = false;
    public bool Agoraphobic_characteristics = false;
    public bool Claustrophobic_characteristics = false;
    public bool Outdoorsman_characteristics = false;
    public bool Restless_Sleeper_characteristics = false;
    public bool Resilient_Characteristic = false;
    public bool Prone_to_Illness_Characteristic = false;
    public bool Fast_Healer_Characteristic = false;
    public bool Fast_Learner_Characteristic = false;
    public bool Thick_Skinned_Characteristic = false;
    public bool Thin_skinned_Characteristic = false;
    public bool Adrenaline_Junkie_Characteristic = false;

    public static Player_Characteristic current = null;
    private void Awake()
    {
        current = this;
        for (int i = 0; i < 52; i++)
        {
            if(i != 49)
            {
                GameObject tempObj = null;
                Set_Characteristic(i, false, tempObj);
            }
        }
    }

    /* ĳ���� ������ ������ Ư�� */

    /*  ü��
     
     ��: ���ý� �ʱ� ������ 105kg. �����԰� 100 �̻��� �� Ȱ��ȭ.  ( Characteristic_number = 46 )
     ��ü��: ���ý� �ʱ� ������ 95kg. �����԰� 85~99 ������ �� Ȱ��ȭ.  ( Characteristic_number = 37 )
     ��ü��: ���ý� �ʱ� ������ 70kg. �����԰� 66~75 ������ �� Ȱ��ȭ.  ( Characteristic_number = 43 )
     ���� ��ü��: ���ý� �ʱ� ������ 60kg. �����԰� 51~65 ������ �� Ȱ��ȭ.  ( Characteristic_number = 48 )
     ��ô��: �����԰� 50 ������ �� Ȱ��ȭ.  ( Characteristic_number = 49 )

     */

    /*   �ٷ�/ü��

     ���� �ٷ��� 0~1 ������ �� Ȱ��ȭ  ( Characteristic_number = 50 )
     ������: �ٷ��� 2~4 ������ �� Ȱ��ȭ  ( Characteristic_number = 42 )
     ������: �������� �ʾƵ� �ٷ��� 6~8 ������ �� Ȱ��ȭ  ( Characteristic_number = 15 )
     ưư��: �������� �ʾƵ� �ٷ��� 9 �̻��� �� Ȱ��ȭ  ( Characteristic_number = 20 )

     �����: ü���� 0~1 ������ �� Ȱ��ȭ  ( Characteristic_number = 47 )
     �ǰ� �̻�: ü���� 2~4 ������ �� Ȱ��ȭ  ( Characteristic_number = 36 )
     �ǰ���: �������� �ʾƵ� ü���� 6~8 ������ �� Ȱ��ȭ  ( Characteristic_number = 10 )
     ���� ����: �������� �ʾƵ� ü���� 9 �̻��� �� Ȱ��ȭ  ( Characteristic_number = 19 )

     */

    public void Start_Setting()
    {
        UI_Title.ui_title.Set_Player_Setting_Job();

        for (int i = 0; i < characteristics_Player.Count; i++)
        {
            switch (characteristics_Player[i].Prefab.Characteristic_number)
            {
                // ü��
                case 46:
                    Player_main.player_main.Set_Weight(22);
                    break;
                case 37:
                    Player_main.player_main.Set_Weight(12);
                    break;
                case 43:
                    Player_main.player_main.Set_Weight(-13);
                    break;
                case 48:
                    Player_main.player_main.Set_Weight(-23);
                    break;

                // �ٷ�
                case 50:
                    Player_main.player_main.Skill.Strength_Level.Set_P_Level(1);
                    break;
                case 42:
                    Player_main.player_main.Skill.Strength_Level.Set_P_Level(2);
                    break;
                case 15:
                    Player_main.player_main.Skill.Strength_Level.Set_P_Level(6);
                    break;
                case 20:
                    Player_main.player_main.Skill.Strength_Level.Set_P_Level(9);
                    Player_main.player_main.playerSkill_ActivationProbability.Characteristic_Strong = true;
                    break;

                // ü��
                case 47:
                    Player_main.player_main.Skill.Fitness_Level.Set_P_Level(1);
                    
                    break;
                case 36:
                    Player_main.player_main.Skill.Fitness_Level.Set_P_Level(2);
                    
                    break;
                case 10:
                    Player_main.player_main.Skill.Fitness_Level.Set_P_Level(7);                    
                    break;
                case 19:
                    Player_main.player_main.Skill.Fitness_Level.Set_P_Level(9);
                    Player_main.player_main.playerSkill_ActivationProbability.Characteristic_Athletic = true;
                    break;

                // Bool type
                case 27:
                    Smoker_characteristics = true;
                    break;
                case 28:
                    Agoraphobic_characteristics = true;
                    break;
                case 30:
                    Claustrophobic_characteristics = true;
                    break;
                case 2:
                    Outdoorsman_characteristics = true;
                    break;
                case 6:
                    Resilient_Characteristic = true;
                    break;
                case 13:
                    Fast_Healer_Characteristic = true;
                    break;
                case 16:
                    Fast_Learner_Characteristic = true;
                    break;
                case 17:
                    Thick_Skinned_Characteristic = true;
                    break;
                case 45:
                    Thin_skinned_Characteristic = true;
                    break;
                case 18:
                    Adrenaline_Junkie_Characteristic = true;
                    break;



                case 0:
                    Player_main.player_main.Driving_Speed_max *= characteristics_Player[i].Prefab.value_list[0];
                    break;
                case 3:
                    Player_main.player_main.Read_Speed += characteristics_Player[i].Prefab.value_list[0];
                    break;
                case 4:
                    Player_main.player_main.playerState.Tired_reduction_for_Sleeping *= (1 + characteristics_Player[i].Prefab.value_list[0]);                    
                    if(Player_main.player_main.playerState.Tired_value * (1 + characteristics_Player[i].Prefab.value_list[1]) < 0)
                    {
                        Player_main.player_main.playerState.Tired_value = 0.0005f;   // �Ƿε� ������ ���� ���� ������ ����
                    }
                    else
                    {
                        Player_main.player_main.playerState.Tired_value *= (1 + characteristics_Player[i].Prefab.value_list[1]);
                    }
                    break;
                case 5:
                    if ((Player_main.player_main.Likelihood_of_food_poisoning + characteristics_Player[i].Prefab.value_list[0]) < 0)
                    {
                        Player_main.player_main.Likelihood_of_food_poisoning = 0.0005f;   // ���ߵ��� �ɸ� Ȯ�� ���� ���� ������ ����
                    }
                    else
                    {
                        Player_main.player_main.Likelihood_of_food_poisoning += characteristics_Player[i].Prefab.value_list[0];
                    }
                    Player_main.player_main.Time_for_food_poisoning *= characteristics_Player[i].Prefab.value_list[1];
                    break;
                case 7:
                    Player_main.player_main.Satiety_value *= characteristics_Player[i].Prefab.value_list[0];
                    break;
                case 29:
                    Player_main.player_main.Satiety_value *= characteristics_Player[i].Prefab.value_list[0];
                    Player_main.player_main.Skill.Foraging_Level.S_Exp_characteristic = characteristics_Player[i].Prefab.value_list[1];
                    break;
                case 8:
                    Player_main.player_main.Panic_value *= characteristics_Player[i].Prefab.value_list[0];
                    break;
                case 11:
                    Player_main.player_main.playerState.Thirsty_Speed *= characteristics_Player[i].Prefab.value_list[0];
                    break;
                case 33:
                    Prone_to_Illness_Characteristic = true;

                    break;
                case 41:
                    Restless_Sleeper_characteristics = true;
                    Player_main.player_main.playerState.Tired_reduction_for_Sleeping *= characteristics_Player[i].Prefab.value_list[0];
                    break;
                case 21:
                    Player_main.player_main.Driving_Speed *= characteristics_Player[i].Prefab.value_list[0];
                    break;
                case 22:
                    Player_main.player_main.Panic_value *= characteristics_Player[i].Prefab.value_list[0];
                    break;
                case 24:
                    Player_main.player_main.Read_Speed *= characteristics_Player[i].Prefab.value_list[0];
                    break;
                case 26:
                    Player_main.player_main.Likelihood_of_food_poisoning *= characteristics_Player[i].Prefab.value_list[0];
                    Player_main.player_main.Time_for_food_poisoning *= characteristics_Player[i].Prefab.value_list[1];
                    break;
                case 32:
                    Player_main.player_main.playerSkill_ActivationProbability.Characteristic_Sleepyhead = true;
                    Player_main.player_main.playerState.Tired_reduction_for_Sleeping *= characteristics_Player[i].Prefab.value_list[0];
                    break;



                case 1:
                    // ������� �� ( �߰� �þ� ���� +20% ( �߰� ��� ����, ������, ���� ������ ���� ������ ���� ������ ) )
                    break;
                case 9:
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling(characteristics_Player[i].Prefab.value_list[0]);
                    // ����� ( ������ �� �߻��ϴ� �����ݰ� -40%)
                    break;
                case 12:
                    // ���� �� ( �þ� ���� ���� (���Ǽ��� +30%), �þ� Ȯ�� �ӵ� ���� (���Ǽ��� +30%) )
                    break;
                case 14:
                    // ������ û�� ( �Ҹ� ���� �ݰ� +100%(200%), �ֺ� �þ� ���� ���� (���Ǽ��� +30%) )
                    break;
                case 23:
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling(characteristics_Player[i].Prefab.value_list[0]);
                    // ������ ( ������ �� �߻��ϴ� �����ݰ� +20% )
                    break;
                case 25:
                    // ª�� �þ� ( �þ� Ȯ�� �ӵ� ���� ( ���Ǽ��� -20% ) )
                    break;
                case 31:
                    // ��ο� �� ( �Ҹ� ���� ���� ���� ( ���Ǽ��� -30% ) , �Ҹ��� �Ը��ϰ� �鸲, �ֺ� ��� ���� ( ���Ǽ��� -30% ) )
                    break;
            }

        }
    }


    public void Set_Characteristic_for_Weight(float weight)
    {
        if (weight >= 100)  // Characteristic_number = 46
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 37
                    || characteristics_Player[i].Prefab.Characteristic_number == 43
                    || characteristics_Player[i].Prefab.Characteristic_number == 48
                    || characteristics_Player[i].Prefab.Characteristic_number == 49)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 45)
                    break;

                if (i == characteristics_Player.Count - 1)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(46, true, tempObj);
                }
            }
        }
        else if (weight >= 85 && weight < 100)  // Characteristic_number = 37
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 46
                    || characteristics_Player[i].Prefab.Characteristic_number == 43
                    || characteristics_Player[i].Prefab.Characteristic_number == 48
                    || characteristics_Player[i].Prefab.Characteristic_number == 49)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 37)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 37)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(37, true, tempObj);
                }
            }
        }
        else if (weight >= 76 && weight < 85)  // ����
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 46
                    || characteristics_Player[i].Prefab.Characteristic_number == 37
                    || characteristics_Player[i].Prefab.Characteristic_number == 43
                    || characteristics_Player[i].Prefab.Characteristic_number == 48
                    || characteristics_Player[i].Prefab.Characteristic_number == 49)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }
        }
        else if (weight >= 66 && weight < 76)  // Characteristic_number = 43
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 46
                    || characteristics_Player[i].Prefab.Characteristic_number == 37
                    || characteristics_Player[i].Prefab.Characteristic_number == 48
                    || characteristics_Player[i].Prefab.Characteristic_number == 49)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 43)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 43)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(43, true, tempObj);
                }
            }
        }
        else if (weight >= 51 && weight < 66)  // Characteristic_number = 48
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 46
                    || characteristics_Player[i].Prefab.Characteristic_number == 37
                    || characteristics_Player[i].Prefab.Characteristic_number == 43
                    || characteristics_Player[i].Prefab.Characteristic_number == 49)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 48)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 48)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(48, true, tempObj);
                }
            }
        }
        else if (weight < 51)  // Characteristic_number = 49
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 46
                    || characteristics_Player[i].Prefab.Characteristic_number == 37
                    || characteristics_Player[i].Prefab.Characteristic_number == 43
                    || characteristics_Player[i].Prefab.Characteristic_number == 48)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 49)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 49)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(49, true, tempObj);
                }
            }
        }
    }

    public void Set_Characteristic_for_Strength(float level)
    {
        if (level < 2) // Characteristic_number = 50
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 42
                    || characteristics_Player[i].Prefab.Characteristic_number == 15
                    || characteristics_Player[i].Prefab.Characteristic_number == 20)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 50)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 50)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(50, true, tempObj);
                }
            }
        }
        else if (level >= 2 && level < 5) // Characteristic_number = 42
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 50
                    || characteristics_Player[i].Prefab.Characteristic_number == 15
                    || characteristics_Player[i].Prefab.Characteristic_number == 20)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 42)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 42)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(42, true, tempObj);
                }
            }
        }
        else if (level == 5)  // ����
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 50
                    || characteristics_Player[i].Prefab.Characteristic_number == 42
                    || characteristics_Player[i].Prefab.Characteristic_number == 15
                    || characteristics_Player[i].Prefab.Characteristic_number == 20)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }
        }
        else if (level >= 6 && level < 9) // Characteristic_number = 15
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 50
                    || characteristics_Player[i].Prefab.Characteristic_number == 42
                    || characteristics_Player[i].Prefab.Characteristic_number == 20)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 15)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 15)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(15, true, tempObj);
                }
            }
        }
        else if (level >= 9) // Characteristic_number = 20
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 50
                    || characteristics_Player[i].Prefab.Characteristic_number == 42
                    || characteristics_Player[i].Prefab.Characteristic_number == 15)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 20)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 20)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(20, true, tempObj);
                }
            }
        }
    }

    public void Set_Characteristic_for_Fitness(float level)
    {
        if (level < 2) // Characteristic_number = 47
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 36
                    || characteristics_Player[i].Prefab.Characteristic_number == 10
                    || characteristics_Player[i].Prefab.Characteristic_number == 19)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 47)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 47)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(47, true, tempObj);
                }
            }
        }
        else if (level >= 2 && level < 5) // Characteristic_number = 36
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 47
                    || characteristics_Player[i].Prefab.Characteristic_number == 10
                    || characteristics_Player[i].Prefab.Characteristic_number == 19)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 36)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 36)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(36, true, tempObj);
                }
            }
        }
        else if (level == 5) // ����
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 47
                    || characteristics_Player[i].Prefab.Characteristic_number == 36
                    || characteristics_Player[i].Prefab.Characteristic_number == 10
                    || characteristics_Player[i].Prefab.Characteristic_number == 19)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }
        }
        else if (level >= 6 && level < 9) // Characteristic_number = 10
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 47
                    || characteristics_Player[i].Prefab.Characteristic_number == 36
                    || characteristics_Player[i].Prefab.Characteristic_number == 19)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 10)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 10)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(10, true, tempObj);
                }
            }
        }
        else if (level >= 9) // Characteristic_number = 19
        {
            for (int i = 0; i < characteristics_Player.Count;)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 47
                    || characteristics_Player[i].Prefab.Characteristic_number == 36
                    || characteristics_Player[i].Prefab.Characteristic_number == 10)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
                else
                    i++;
            }

            for (int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == 19)
                    break;

                if (i == characteristics_Player.Count - 1 && characteristics_Player[i].Prefab.Characteristic_number != 19)
                {
                    GameObject tempObj = null;
                    Set_Characteristic(19, true, tempObj);
                }
            }
        }
    }

    public List<UI_Title_Characteristic_prefab> characteristics_list = new List<UI_Title_Characteristic_prefab>();
    public List<UI_Title_Characteristic_prefab> characteristics_Player = new List<UI_Title_Characteristic_prefab>();

    public void Remove_Selected_list(int Characteristic_number, bool selected)
    {
        if (selected)
        {
            for(int i = 0; i < characteristics_Player.Count; i++)
            {
                if (characteristics_Player[i].Prefab.Characteristic_number == Characteristic_number)
                {
                    Destroy(characteristics_Player[i].gameObject);
                    characteristics_Player.RemoveAt(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < characteristics_list.Count; i++)
            {
                if (characteristics_list[i].Prefab.Characteristic_number == Characteristic_number)
                {
                    Destroy(characteristics_list[i].gameObject);
                    characteristics_list.RemoveAt(i);
                }
            }
        }
    }


    public void Set_Characteristic_in_list(int value, bool Choice, GameObject tempObj)
    {
        for (int i = 0; i < characteristics_list.Count; i++)
        {
            if (characteristics_list[i].Prefab.Characteristic_number == value)
                break;

            if(i == characteristics_list.Count -1 && characteristics_list[i].Prefab.Characteristic_number != value)
                Set_Characteristic(value, Choice, tempObj);
        }
    }

    public void Set_Characteristic(int value, bool Choice, GameObject tempObj)
    {
        Characteristic temp = new Characteristic();
        switch (value)
        {
            case 0:
                temp = Characteristic_Speed_Demon(temp, Choice);
                break;
            case 1:
                temp = Characteristic_Cats_Eyes(temp, Choice);
                break;
            case 2:
                temp = Characteristic_Outdoorsman(temp, Choice);
                break;
            case 3:
                temp = Characteristic_Fast_Reader(temp, Choice);
                break;
            case 4:
                temp = Characteristic_Wakeful(temp, Choice);
                break;
            case 5:
                temp = Characteristic_Iron_Gut(temp, Choice);
                break;
            case 6:
                temp = Characteristic_Resilient(temp, Choice);
                break;
            case 7:
                temp = Characteristic_Light_Eater(temp, Choice);
                break;
            case 8:
                temp = Characteristic_Brave(temp, Choice);
                break;
            case 9:
                temp = Characteristic_Graceful(temp, Choice);
                break;
            case 10:
                temp = Characteristic_Fit(temp, Choice);
                break;
            case 11:
                temp = Characteristic_Low_Thirst(temp, Choice);
                break;
            case 12:
                temp = Characteristic_Eagle_Eyed(temp, Choice);
                break;
            case 13:
                temp = Characteristic_Fast_Healer(temp, Choice);
                break;
            case 14:
                temp = Characteristic_Keen_Hearing(temp, Choice);
                break;
            case 15:
                temp = Characteristic_Stout(temp, Choice);
                break;
            case 16:
                temp = Characteristic_Fast_Learner(temp, Choice);
                break;
            case 17:
                temp = Characteristic_Thick_Skinned(temp, Choice);
                break;
            case 18:
                temp = Characteristic_Adrenaline_Junkie(temp, Choice);
                break;
            case 19:
                temp = Characteristic_Athletic(temp, Choice);
                break;
            case 20:
                temp = Characteristic_Strong(temp, Choice);
                break;
            case 21:
                temp = Characteristic_Sunday_driver(temp, Choice);
                break;
            case 22:
                temp = Characteristic_Cowardly(temp, Choice);
                break;
            case 23:
                temp = Characteristic_Clumsy(temp, Choice);
                break;
            case 24:
                temp = Characteristic_Slow_Reader(temp, Choice);
                break;
            case 25:
                temp = Characteristic_Short_Sighted(temp, Choice);
                break;
            case 26:
                temp = Characteristic_Weak_Stomach(temp, Choice);
                break;
            case 27:
                temp = Characteristic_Smoker(temp, Choice);
                break;
            case 28:
                temp = Characteristic_Agoraphobic(temp, Choice);
                break;
            case 29:
                temp = Characteristic_Hearty_Appetite(temp, Choice);
                break;
            case 30:
                temp = Characteristic_Claustrophobic(temp, Choice);
                break;
            case 31:
                temp = Characteristic_Hard_of_Hearing(temp, Choice);
                break;
            case 32:
                temp = Characteristic_Sleepyhead(temp, Choice);
                break;
            case 33:
                temp = Characteristic_Prone_to_Illness(temp, Choice);
                break;
            case 34:
                temp = Characteristic_Pacifist(temp, Choice);
                break;
            case 35:
                temp = Characteristic_Asthmatic(temp, Choice);
                break;
            case 36:
                temp = Characteristic_Out_of_Shape(temp, Choice);
                break;
            case 37:
                temp = Characteristic_Overweight(temp, Choice);
                break;
            case 38:
                temp = Characteristic_High_Thirst(temp, Choice);
                break;
            case 39:
                temp = Characteristic_Slow_Healer(temp, Choice);
                break;
            case 40:
                temp = Characteristic_Slow_Learner(temp, Choice);
                break;
            case 41:
                temp = Characteristic_Restless_Sleeper(temp, Choice);
                break;
            case 42:
                temp = Characteristic_Feeble(temp, Choice);
                break;
            case 43:
                temp = Characteristic_Underweight(temp, Choice);
                break;
            case 44:
                temp = Characteristic_Illiterate(temp, Choice);
                break;
            case 45:
                temp = Characteristic_Thin_skinned(temp, Choice);
                break;
            case 46:
                temp = Characteristic_Obese(temp, Choice);
                break;
            case 47:
                temp = Characteristic_Unfit(temp, Choice);
                break;
            case 48:
                temp = Characteristic_Very_Underweight(temp, Choice);
                break;
            case 49:
                temp = Characteristic_Emaciated(temp, Choice);
                break;
            case 50:
                temp = Characteristic_Weak(temp, Choice);
                break;
            case 51:
                temp = Characteristic_Deaf(temp, Choice);
                break;
            default: break;
        }

        if (temp.type == Characteristic_type.Negatives && temp.Choice == false)
        {
            tempObj = Instantiate(Characteristic_Prefab, Characteristic_N_Window);
        }
        else if (temp.type == Characteristic_type.Positives && temp.Choice == false)
        {
            tempObj = Instantiate(Characteristic_Prefab, Characteristic_P_Window);
        }
        else if (temp.type == Characteristic_type.Occupation || temp.Choice == true)
        {
            tempObj = Instantiate(Characteristic_Prefab, Characteristic_S_Window);
        }
        tempObj.GetComponent<UI_Title_Characteristic_prefab>().SetCharacteristic(temp);

        if (Choice)
        {
            characteristics_Player.Add(tempObj.GetComponent<UI_Title_Characteristic_prefab>());
        }
        else
        {
            characteristics_list.Add(tempObj.GetComponent<UI_Title_Characteristic_prefab>());
        }
    }

    /*
     ������ Ư��
     : �ӵ���, ������� ��, ����ȣ��, ��ø��, �ӵ�, ���� ����, ��ö ����, ���� ȸ����, ������ ���簨, �ҽİ�,
       �밨��, �����, ���, �ǰ���, ���� ����, ���� ��, ���� ȸ��, ������ û��, ��������, ������, 
       ����, �β��� �Ǻ�, �Ƶ巹���� �ߵ�, ���� ����, ưư��
    */

    Characteristic Characteristic_Speed_Demon(Characteristic Speed_Demon, bool Choice)
    {
        Speed_Demon.name = "Speed Demon";
        Speed_Demon.name_kr = "�ӵ���";
        Speed_Demon.Explanation_for_Characteristic = "The fast driver.";
        Speed_Demon.Explanation_for_Characteristic_kr = "���� ������ �մϴ�.";
        Speed_Demon.Characteristic_number = 0;
        Speed_Demon.Sprite = Characteristic_Image[0];
        Speed_Demon.Points = -1;
        Speed_Demon.type = Characteristic_type.Positives;
        Speed_Demon.Choice = Choice;
        Speed_Demon.value_list.Add(0.15f);

        return Speed_Demon;
        // ��� ������ ��� ��ȯ �ӵ� +100%(200%)  ( �̱������� )
        // �ְ� �ӵ� +15%(115%) [0]
        // ��Ȱ��ȭ�Ǵ� Ư��: �ʺ� ����
    }

    Characteristic Characteristic_Cats_Eyes(Characteristic Cats_Eyes, bool Choice)
    {
        Cats_Eyes.name = "Cat's Eyes";
        Cats_Eyes.name_kr = "������� ��";
        Cats_Eyes.Explanation_for_Characteristic = "Better vision at night.";
        Cats_Eyes.Explanation_for_Characteristic_kr = "�㿡 �� ���� �÷��� �����ϴ�.";
        Cats_Eyes.Characteristic_number = 1;
        Cats_Eyes.Sprite = Characteristic_Image[1];
        Cats_Eyes.Points = -2;
        Cats_Eyes.type = Characteristic_type.Positives;
        Cats_Eyes.Choice = Choice;
        Cats_Eyes.value_list.Add(0.2f);
        return Cats_Eyes;
        // �߰� �þ� ���� +20% ( �߰� ��� ����, ������, ���� ������ ���� ������ ���� ������ )  ( �̱������� )
    }

    Characteristic Characteristic_Outdoorsman(Characteristic Outdoorsman, bool Choice)
    {
        Outdoorsman.name = "Outdoorsman";
        Outdoorsman.name_kr = "����ȣ��";
        Outdoorsman.Explanation_for_Characteristic = "Not affected by harsh weather conditions.";
        Outdoorsman.Explanation_for_Characteristic_kr = "Ȥ���� �������� ������ ���� �ʽ��ϴ�.";
        Outdoorsman.Characteristic_number = 2;
        Outdoorsman.Sprite = Characteristic_Image[2];
        Outdoorsman.Points = -2;
        Outdoorsman.type = Characteristic_type.Positives;
        Outdoorsman.Choice = Choice;
        Outdoorsman.value_list.Add(-0.5f);
        return Outdoorsman;
        // ���⿡ �ɸ� Ȯ�� -90%
        // ������ ���� �� ��ĥ Ȯ�� -50%, ���۳� ���ڷ� ���� �� ���� �ǿ� ( �̱������� )
    }

    Characteristic Characteristic_Fast_Reader(Characteristic Fast_Reader, bool Choice)
    {
        Fast_Reader.name = "Fast Reader";
        Fast_Reader.name_kr = "�ӵ�";
        Fast_Reader.Explanation_for_Characteristic = "Increases XP gains.";
        Fast_Reader.Explanation_for_Characteristic_kr = "å�� �дµ� �ð��� ���� �ҿ�˴ϴ�.";
        Fast_Reader.Characteristic_number = 3;
        Fast_Reader.Sprite = Characteristic_Image[3];
        Fast_Reader.Points = -2;
        Fast_Reader.type = Characteristic_type.Positives;
        Fast_Reader.Choice = Choice;
        Fast_Reader.value_list.Add(0.3f);
        return Fast_Reader;
        // ���� �ӵ� +30%
        // ��Ȱ��ȭ�Ǵ� Ư��: ����, ����
    }

    Characteristic Characteristic_Wakeful(Characteristic Wakeful, bool Choice)
    {
        Wakeful.name = "Wakeful";
        Wakeful.name_kr = "���� ����";
        Wakeful.Explanation_for_Characteristic = "Needs less sleep.";
        Wakeful.Explanation_for_Characteristic_kr = "���� �� �ʿ�� �մϴ�.";
        Wakeful.Characteristic_number = 4;
        Wakeful.Sprite = Characteristic_Image[4];
        Wakeful.Points = -2;
        Wakeful.type = Characteristic_type.Positives;
        Wakeful.Choice = Choice;
        Wakeful.value_list.Add(0.1f);
        Wakeful.value_list.Add(-0.3f);
        return Wakeful;
        // ���� ȿ�� +10%, �Ƿε� ������ -30%
        // ��Ȱ��ȭ�Ǵ� Ư��: ��ٷ���
    }

    Characteristic Characteristic_Iron_Gut(Characteristic Iron_Gut, bool Choice)
    {
        Iron_Gut.name = "Iron Gut";
        Iron_Gut.name_kr = "��ö ����";
        Iron_Gut.Explanation_for_Characteristic = "Less chance to have food illness.";
        Iron_Gut.Explanation_for_Characteristic_kr = "�������� ���� ������ �ɸ� Ȯ���� �����մϴ�.";
        Iron_Gut.Characteristic_number = 5;
        Iron_Gut.Sprite = Characteristic_Image[5];
        Iron_Gut.Points = -3;
        Iron_Gut.type = Characteristic_type.Positives;
        Iron_Gut.Choice = Choice;
        Iron_Gut.value_list.Add(-0.5f);
        Iron_Gut.value_list.Add(-0.2f);
        return Iron_Gut;
        // ���ߵ��� �ɸ� Ȯ�� -50%, ���ߵ� �����ð� ���� (���Ǽ��� -20%)
        // ��Ȱ��ȭ�Ǵ� Ư��: ��ȭ�ҷ�
    }

    Characteristic Characteristic_Resilient(Characteristic Resilient, bool Choice)
    {
        Resilient.name = "Resilient";
        Resilient.name_kr = "���� ȸ����";
        Resilient.Explanation_for_Characteristic = "Less prone to disease. Slower rate of zombification.";
        Resilient.Explanation_for_Characteristic_kr = "������ �ɸ� ���ɼ��� �����մϴ�.\r\n����ȭ ���°� �Ǿ��� �� ����Ǵ� �ӵ��� ������ �մϴ�.";
        Resilient.Characteristic_number = 6;
        Resilient.Sprite = Characteristic_Image[6];
        Resilient.Points = -4;
        Resilient.type = Characteristic_type.Positives;
        Resilient.Choice = Choice;
        return Resilient;
        // ���⿡ �ɸ� Ȯ�� -55%, ����ȭ �ӵ� -75%,
        // ���� ���� -20%, ���� ���� �ӵ� -50%  ( �̱�������: ���ӿ� ū ���� x )
        // ��Ȱ��ȭ�Ǵ� Ư��: ������ �����
    }

    Characteristic Characteristic_Light_Eater(Characteristic Light_Eater, bool Choice)
    {
        Light_Eater.name = "Light Eater";
        Light_Eater.name_kr = "�ҽİ�";
        Light_Eater.Explanation_for_Characteristic = "Needs to eat less regularly.";
        Light_Eater.Explanation_for_Characteristic_kr = "�� �ֱ������� �Ļ縦 �մϴ�.";
        Light_Eater.Characteristic_number = 7;
        Light_Eater.Sprite = Characteristic_Image[7];
        Light_Eater.Points = -4;
        Light_Eater.type = Characteristic_type.Positives;
        Light_Eater.Choice = Choice;
        Light_Eater.value_list.Add(0.75f);
        return Light_Eater;
        // ����� ����ӵ� 75%
        // ��Ȱ��ȭ�Ǵ� Ư��: ��İ�
    }

    Characteristic Characteristic_Brave(Characteristic Brave, bool Choice)
    {
        Brave.name = "Brave";
        Brave.name_kr = "�밨��";
        Brave.Explanation_for_Characteristic = "Less prone to becoming panicked.";
        Brave.Explanation_for_Characteristic_kr = "��Ȳ���¿� �� ������ �ʽ��ϴ�.";
        Brave.Characteristic_number = 8;
        Brave.Sprite = Characteristic_Image[8];
        Brave.Points = -4;
        Brave.type = Characteristic_type.Positives;
        Brave.Choice = Choice;
        Brave.value_list.Add(0.7f);
        return Brave;
        // ���� ��·� -70%
        // ��Ȱ��ȭ�Ǵ� Ư��: ������, ���������, �нǰ�����
    }

    Characteristic Characteristic_Graceful(Characteristic Graceful, bool Choice)
    {
        Graceful.name = "Graceful";
        Graceful.name_kr = "�����";
        Graceful.Explanation_for_Characteristic = "Makes less noise when moving.";
        Graceful.Explanation_for_Characteristic_kr = "������ �� ���� �Ҹ��� �����մϴ�.";
        Graceful.Characteristic_number = 9;
        Graceful.Sprite = Characteristic_Image[9];
        Graceful.Points = -4;
        Graceful.type = Characteristic_type.Positives;
        Graceful.Choice = Choice;
        Graceful.value_list.Add(-0.1f);
        Graceful.value_list.Add(-0.4f);
        return Graceful;
        // ������ �� �߻��ϴ� �����ݰ� -40%,
        // �޸���/���ַ� ���� ��Ÿ���� �پ� �Ѱų� ���� ������ �� �Ѿ��� Ȯ�� -10%
        // ������ �߻��ϴ� �����̳� ������ ���� �� �� �ٸ� �������� ������ ���� �ʰ�, ���� �߼Ҹ��� �ٿ���
        // ��Ȱ��ȭ�Ǵ� Ư��: ������
    }

    Characteristic Characteristic_Fit(Characteristic Fit, bool Choice)
    {
        Fit.name = "Fit";
        Fit.name_kr = "�ǰ���";
        Fit.Explanation_for_Characteristic = "In good physical shape.";
        Fit.Explanation_for_Characteristic_kr = "�޸��� �ӵ��� �����ϴ�.";
        Fit.Characteristic_number = 10;
        Fit.Sprite = Characteristic_Image[10];
        Fit.Points = -6;
        Fit.type = Characteristic_type.Positives;
        Fit.Choice = Choice;
        Fit.value_list.Add(2);
        return Fit;
        // ü�� +2
    }

    Characteristic Characteristic_Low_Thirst(Characteristic Low_Thirst, bool Choice)
    {
        Low_Thirst.name = "Low Thirst";
        Low_Thirst.name_kr = "���� ����";
        Low_Thirst.Explanation_for_Characteristic = "Needs to drink water less regularly.";
        Low_Thirst.Explanation_for_Characteristic_kr = "������ ���� ���� �Ҹ��� �����մϴ�.";
        Low_Thirst.Characteristic_number = 11;
        Low_Thirst.Sprite = Characteristic_Image[11];
        Low_Thirst.Points = -6;
        Low_Thirst.type = Characteristic_type.Positives;
        Low_Thirst.Choice = Choice;
        Low_Thirst.value_list.Add(0.5f);
        return Low_Thirst;
        // ���� ���� �ӵ� -50%
        // ��Ȱ��ȭ�Ǵ� Ư��: ���� ����
    }

    Characteristic Characteristic_Eagle_Eyed(Characteristic Eagle_Eyed, bool Choice)
    {
        Eagle_Eyed.name = "Eagle Eyed";
        Eagle_Eyed.name_kr = "���� ��";
        Eagle_Eyed.Explanation_for_Characteristic = "Has a faster visibility fade and a higher visibility arc.";
        Eagle_Eyed.Explanation_for_Characteristic_kr = "�þ� Ȯ�� �ӵ��� �������ϴ�. \r\n �� �� �ִ� �þ߰� �о����ϴ�.";
        Eagle_Eyed.Characteristic_number = 12;
        Eagle_Eyed.Sprite = Characteristic_Image[12];
        Eagle_Eyed.Points = -6;
        Eagle_Eyed.type = Characteristic_type.Positives;
        Eagle_Eyed.Choice = Choice;
        Eagle_Eyed.value_list.Add(0.3f);
        Eagle_Eyed.value_list.Add(0.3f);
        return Eagle_Eyed;
        // �þ� ���� ���� (���Ǽ��� +30%), �þ� Ȯ�� �ӵ� ���� (���Ǽ��� +30%)
        // ��Ȱ��ȭ�Ǵ� Ư��: ª�� �þ�
    }

    Characteristic Characteristic_Fast_Healer(Characteristic Fast_Healer, bool Choice)
    {
        Fast_Healer.name = "Fast Healer";
        Fast_Healer.name_kr = "���� ȸ��";
        Fast_Healer.Explanation_for_Characteristic = "Has a faster visibility fade and a higher visibility arc.";
        Fast_Healer.Explanation_for_Characteristic_kr = "�λ�� ������ ������ ȸ���մϴ�.";
        Fast_Healer.Characteristic_number = 13;
        Fast_Healer.Sprite = Characteristic_Image[13];
        Fast_Healer.Points = -6;
        Fast_Healer.type = Characteristic_type.Positives;
        Fast_Healer.Choice = Choice;
        return Fast_Healer;
        // ����, ������, ����, ���� ��ó, ȭ�� ��ó �ɰ��� -20%
        // ��Ȱ��ȭ�Ǵ� Ư��: ���� ġ��
    }

    Characteristic Characteristic_Keen_Hearing(Characteristic Keen_Hearing, bool Choice)
    {
        Keen_Hearing.name = "Keen Hearing";
        Keen_Hearing.name_kr = "������ û��";
        Keen_Hearing.Explanation_for_Characteristic = "Larger perception radius.";
        Keen_Hearing.Explanation_for_Characteristic_kr = "�Ҹ��� �����ϴ� �ݰ��� Ŀ���ϴ�.\r\n�鸮�� ������ �о����ϴ�.";
        Keen_Hearing.Characteristic_number = 14;
        Keen_Hearing.Sprite = Characteristic_Image[14];
        Keen_Hearing.Points = -6;
        Keen_Hearing.type = Characteristic_type.Positives;
        Keen_Hearing.Choice = Choice;
        Keen_Hearing.value_list.Add(1f);
        Keen_Hearing.value_list.Add(0.3f);
        return Keen_Hearing;
        // �Ҹ� ���� �ݰ� +100%(200%), �ֺ� �þ� ���� ���� (���Ǽ��� +30%)
        // ��Ȱ��ȭ�Ǵ� Ư��: ��ο� ��, û�� ���
    }

    Characteristic Characteristic_Stout(Characteristic Stout, bool Choice)
    {
        Stout.name = "Stout";
        Stout.name_kr = "������";
        Stout.Explanation_for_Characteristic = "Extra knockback from melee weapons and increased carry weight.";
        Stout.Explanation_for_Characteristic_kr = "�������� ��� �ÿ� �ڷ� ��ĥ Ȯ���� �����մϴ�.\r\n�ű� �� �ִ� ���Է��� �����մϴ�.";
        Stout.Characteristic_number = 15;
        Stout.Sprite = Characteristic_Image[15];
        Stout.Points = -6;
        Stout.type = Characteristic_type.Positives;
        Stout.Choice = Choice;
        Stout.value_list.Add(0.25f);
        return Stout;
        // �ٷ� +2
        // ���ĳ��� Ȯ�� 25% ���� ( �̱�������. �ٷ� ������ ���� �����ϴ� ���ĳ� Ȯ���� ���� )
    }

    Characteristic Characteristic_Fast_Learner(Characteristic Fast_Learner, bool Choice)
    {
        Fast_Learner.name = "Fast Learner";
        Fast_Learner.name_kr = "����";
        Fast_Learner.Explanation_for_Characteristic = "Increases XP gains.";
        Fast_Learner.Explanation_for_Characteristic_kr = "����ġ ȹ�淮�� �����մϴ�.";
        Fast_Learner.Characteristic_number = 16;
        Fast_Learner.Sprite = Characteristic_Image[16];
        Fast_Learner.Points = -6;
        Fast_Learner.type = Characteristic_type.Positives;
        Fast_Learner.Choice = Choice;
        return Fast_Learner;
        // ��ü �ɷ�(�ٷ�, ü��)�� ������ ��� ��ų�� ����ġ ȹ�淮 +30%
        // ��Ȱ��ȭ�Ǵ� Ư��: ���� �н�
    }

    Characteristic Characteristic_Thick_Skinned(Characteristic Thick_Skinned, bool Choice)
    {
        Thick_Skinned.name = "Thick Skinned";
        Thick_Skinned.name_kr = "�β��� �Ǻ�";
        Thick_Skinned.Explanation_for_Characteristic = "Less chance of scratches or bites breaking the skin.";
        Thick_Skinned.Explanation_for_Characteristic_kr = "�����ų� ���� ������ �������ϴ�.";
        Thick_Skinned.Characteristic_number = 17;
        Thick_Skinned.Sprite = Characteristic_Image[17];
        Thick_Skinned.Points = -8;
        Thick_Skinned.type = Characteristic_type.Positives;
        Thick_Skinned.Choice = Choice;
        return Thick_Skinned;
        // ����, ������, ���� Ȯ�� -30%
        // ȸ���� : 15 + (���� ���õ��� ���� ��ġ -5% ~ 7%) * {1.3(�β��� �Ǻ�) or 0.77(���� �Ǻ�)}
        // ��Ȱ��ȭ�Ǵ� Ư��: ���� �Ǻ�
    }

    Characteristic Characteristic_Adrenaline_Junkie(Characteristic Adrenaline_Junkie, bool Choice)
    {
        Adrenaline_Junkie.name = "Adrenaline Junkie";
        Adrenaline_Junkie.name_kr = "�Ƶ巹���� �ߵ�";
        Adrenaline_Junkie.Explanation_for_Characteristic = "Moves faster when highly panicked.";
        Adrenaline_Junkie.Explanation_for_Characteristic_kr = "��Ȳ������ �� �� ���� �����Դϴ�.";
        Adrenaline_Junkie.Characteristic_number = 18;
        Adrenaline_Junkie.Sprite = Characteristic_Image[18];
        Adrenaline_Junkie.Points = -8;
        Adrenaline_Junkie.type = Characteristic_type.Positives;
        Adrenaline_Junkie.Choice = Choice;
        return Adrenaline_Junkie;
        // 3�ܰ� �����̸� 0.2, 4�ܰ� �����̸� 0.25�� �߰� �̵��ӵ��� ��´�.
        // ��Ȱ��ȭ�Ǵ� Ư��: ������, ���������, �нǰ�����
    }

    Characteristic Characteristic_Athletic(Characteristic Athletic, bool Choice)
    {
        Athletic.name = "Athletic";
        Athletic.name_kr = "���� ����";
        Athletic.Explanation_for_Characteristic = "Can run faster and longer without tiring.";
        Athletic.Explanation_for_Characteristic_kr = "�޸��� �ӵ��� �������ϴ�.\r\n�� ���� ��ġ�� �ʰ� �޸� �� �ֽ��ϴ�.";
        Athletic.Characteristic_number = 19;
        Athletic.Sprite = Characteristic_Image[19];
        Athletic.Points = -10;
        Athletic.type = Characteristic_type.Positives;
        Athletic.Choice = Choice;
        return Athletic;
        // ü�� +4, �޸��� �ӵ� +20%, �̵����� ���� ������ �Ҹ��� -20%
    }

    Characteristic Characteristic_Strong(Characteristic Strong, bool Choice)
    {
        Strong.name = "Strong";
        Strong.name_kr = "ưư��";
        Strong.Explanation_for_Characteristic = "Extra knockback from melee weapons and increased carry weight.";
        Strong.Explanation_for_Characteristic_kr = "�������� ��� �ÿ� �ڷ� ��ĥ Ȯ���� �����մϴ�.\r\n�ű� �� �ִ� ���Է��� �����մϴ�.";
        Strong.Characteristic_number = 20;
        Strong.Sprite = Characteristic_Image[20];
        Strong.Points = -10;
        Strong.type = Characteristic_type.Positives;
        Strong.Choice = Choice;
        return Strong;
        // �ٷ� +4, ���ĳ� Ȯ�� +40%
    }




    /*
     ������ Ư��
     : �ʺ� ����, ������, ������, ������, ����, ª�� �þ�, ��ȭ�ҷ�, ����, ���������, ��ġ�� ���簨
       ��İ�, �нǰ�����, �ҿ�, ��ü������, ��ο� ��, ��ٷ���, ������ �����, ��ȭ������, õ��ȯ��, �� ������,
       �ǰ� �̻�, ��ü��, ���� ����, ���� ġ��, ���� �н�, �������, ������, ��ü��, ����, ���� �Ǻ�,
       ��, �����, ���� ��ü��, ��ô��, ����, û�� ���
    */

    Characteristic Characteristic_Sunday_driver(Characteristic Sunday_driver, bool Choice)
    {
        Sunday_driver.name = "Sunday driver";
        Sunday_driver.name_kr = "�ʺ� ����";
        Sunday_driver.Explanation_for_Characteristic = "The very slow driver";
        Sunday_driver.Explanation_for_Characteristic_kr = "���� ������ �մϴ�.";
        Sunday_driver.Characteristic_number = 21;
        Sunday_driver.Sprite = Characteristic_Image[21];
        Sunday_driver.Points = +1;
        Sunday_driver.type = Characteristic_type.Negatives;
        Sunday_driver.Choice = Choice;
        Sunday_driver.value_list.Add(0.6f);
        return Sunday_driver;
        // ���� ���ӷ� -40%
        // �ִ� �ӵ��� 30mph[= 48km]�� ����, �ִ� �ӵ��� ������ �⸧�� �߰��� �Ҹ��   ( �̱������� )
        // ��Ȱ��ȭ�Ǵ� Ư��: �ӵ���
    }

    Characteristic Characteristic_Cowardly(Characteristic Cowardly, bool Choice)
    {
        Cowardly.name = "Cowardly";
        Cowardly.name_kr = "������";
        Cowardly.Explanation_for_Characteristic = "Especially prone to becoming panicked";
        Cowardly.Explanation_for_Characteristic_kr = "��Ȳ���¿� ������ �����ϴ�.";
        Cowardly.Characteristic_number = 22;
        Cowardly.Sprite = Characteristic_Image[22];
        Cowardly.Points = +2;
        Cowardly.type = Characteristic_type.Negatives;
        Cowardly.Choice = Choice;
        Cowardly.value_list.Add(2f);
        return Cowardly;
        // ���� ��·� +100%
        // ��Ȱ��ȭ�Ǵ� Ư��: �밨��, �Ƶ巹���� �ߵ�
    }

    Characteristic Characteristic_Clumsy(Characteristic Clumsy, bool Choice)
    {
        Clumsy.name = "Clumsy";
        Clumsy.name_kr = "������";
        Clumsy.Explanation_for_Characteristic = "Makes more noise when moving";
        Clumsy.Explanation_for_Characteristic_kr = "������ �� ���� �Ҹ��� �����մϴ�.";
        Clumsy.Characteristic_number = 23;
        Clumsy.Sprite = Characteristic_Image[23];
        Clumsy.Points = +2;
        Clumsy.type = Characteristic_type.Negatives;
        Clumsy.Choice = Choice;
        Clumsy.value_list.Add(0.1f);
        Clumsy.value_list.Add(0.2f);
        return Clumsy;
        // �Ѿ��� Ȯ�� +10%
        // ������ �� �߻��ϴ� �����ݰ� +20%
        // ��Ȱ��ȭ�Ǵ� Ư��: �����
    }

    Characteristic Characteristic_Slow_Reader(Characteristic Slow_Reader, bool Choice)
    {
        Slow_Reader.name = "Slow Reader";
        Slow_Reader.name_kr = "����";
        Slow_Reader.Explanation_for_Characteristic = "Takes longer to read books";
        Slow_Reader.Explanation_for_Characteristic_kr = "å�� �дµ� �ð��� ���� �ҿ�˴ϴ�.";
        Slow_Reader.Characteristic_number = 24;
        Slow_Reader.Sprite = Characteristic_Image[24];
        Slow_Reader.Points = +2;
        Slow_Reader.type = Characteristic_type.Negatives;
        Slow_Reader.Choice = Choice;
        Slow_Reader.value_list.Add(-0.3f);
        return Slow_Reader;
        // ���� �ӵ� -30%
        // ��Ȱ��ȭ�Ǵ� Ư��: �ӵ�, ����
    }

    Characteristic Characteristic_Short_Sighted(Characteristic Short_Sighted, bool Choice)
    {
        Short_Sighted.name = "Short Sighted";
        Short_Sighted.name_kr = "ª�� �þ�";
        Short_Sighted.Explanation_for_Characteristic = "Small view distance. Slower visibility fade.";
        Short_Sighted.Explanation_for_Characteristic_kr = "�þ� �Ÿ��� ª�����ϴ�.\r\n�þ� Ȯ�� �ӵ��� �������ϴ�.";
        Short_Sighted.Characteristic_number = 25;
        Short_Sighted.Sprite = Characteristic_Image[25];
        Short_Sighted.Points = +2;
        Short_Sighted.type = Characteristic_type.Negatives;
        Short_Sighted.Choice = Choice;
        Short_Sighted.value_list.Add(-0.2f);
        return Short_Sighted;
        // �þ� Ȯ�� �ӵ� ����  ( ���Ǽ��� -20% )
        // ( �Ȱ��̳� ������ �Ȱ��� ����ϸ� ���Ƽ�� �ƿ� ��ȿȭ�� )
        // ��Ȱ��ȭ�Ǵ� Ư��: ���� ��
    }

    Characteristic Characteristic_Weak_Stomach(Characteristic Weak_Stomach, bool Choice)
    {
        Weak_Stomach.name = "Weak Stomach";
        Weak_Stomach.name_kr = "��ȭ�ҷ�";
        Weak_Stomach.Explanation_for_Characteristic = "Higher chance to have food illness.";
        Weak_Stomach.Explanation_for_Characteristic_kr = "�������� ���� ������ �ɸ� Ȯ���� ũ�� �����մϴ�.";
        Weak_Stomach.Characteristic_number = 26;
        Weak_Stomach.Sprite = Characteristic_Image[26];
        Weak_Stomach.Points = +3;
        Weak_Stomach.type = Characteristic_type.Negatives;
        Weak_Stomach.Choice = Choice;
        Weak_Stomach.value_list.Add(2f);
        Weak_Stomach.value_list.Add(1.3f);
        return Weak_Stomach;
        // ���ߵ��� �ɸ� Ȯ�� +100%, ���ߵ� ���� �ð� ����  ( ���Ǽ��� 30% )
        // ��Ȱ��ȭ�Ǵ� Ư��: ��ö ����
    }

    Characteristic Characteristic_Smoker(Characteristic Smoker, bool Choice)
    {
        Smoker.name = "Smoker";
        Smoker.name_kr = "����";
        Smoker.Explanation_for_Characteristic = "Stress and unhappiness decrease after smoking tobacco. Unhappiness rises when tobacco is not smoked.";
        Smoker.Explanation_for_Characteristic_kr = "��踦 �ǿ�� ��Ʈ������ ������ �����մϴ�.\r\n��踦 �ǿ��� ������ ��Ʈ������ ������ �ö󰩴ϴ�.";
        Smoker.Characteristic_number = 27;
        Smoker.Sprite = Characteristic_Image[27];
        Smoker.Points = +4;
        Smoker.type = Characteristic_type.Negatives;
        Smoker.Choice = Choice;
        return Smoker;
        // ��Ʈ���� ��� ��� ( ���Ǽ��� 5�ʴ� 3 ��� ), ������ ���� ���� ������ �߻����� ����
        // ���� ���� -10, ���� ��Ʈ���� 0���� ����
        // ��踦 �ǿ��� ������ ��Ʈ������ 2�ܰ� ������ '������'���� ���
    }

    Characteristic Characteristic_Agoraphobic(Characteristic Agoraphobic, bool Choice)
    {
        Agoraphobic.name = "Agoraphobic";
        Agoraphobic.name_kr = "���������";
        Agoraphobic.Explanation_for_Characteristic = "Gets panicked when outdoors";
        Agoraphobic.Explanation_for_Characteristic_kr = "�� ���� ������ ���� ��Ȳ���°� �Ǿ� ���ϴ�.";
        Agoraphobic.Characteristic_number = 28;
        Agoraphobic.Sprite = Characteristic_Image[28];
        Agoraphobic.Points = +4;
        Agoraphobic.type = Characteristic_type.Negatives;
        Agoraphobic.Choice = Choice;
        return Agoraphobic;
        // �߿ܿ� ���� �� ��Ȳ �߻�
        // ( ������ ������ �ſ� ������ ������ �ö� 7�ʵ� �ȵż� ��Ȳ���¿� ���� )
        // ��Ȱ��ȭ�Ǵ� Ư��: �밨��, �Ƶ巹���� �ߵ�, �нǰ�����
    }

    Characteristic Characteristic_Hearty_Appetite(Characteristic Hearty_Appetite, bool Choice)
    {
        Hearty_Appetite.name = "Hearty Appetite";
        Hearty_Appetite.name_kr = "��İ�";
        Hearty_Appetite.Explanation_for_Characteristic = "Needs to eat more regularly";
        Hearty_Appetite.Explanation_for_Characteristic_kr = "�ֱ������� �Ļ縦 �� �ؾ� �մϴ�.";
        Hearty_Appetite.Characteristic_number = 29;
        Hearty_Appetite.Sprite = Characteristic_Image[29];
        Hearty_Appetite.Points = +4;
        Hearty_Appetite.type = Characteristic_type.Negatives;
        Hearty_Appetite.Choice = Choice;
        Hearty_Appetite.value_list.Add(1.5f);
        Hearty_Appetite.value_list.Add(1.03f);
        return Hearty_Appetite;
        // ����� ���� �ӵ� 150%, ä�����ʽ�: ���� / ����� / ���� / �����ǰ +3%
        // ��Ȱ��ȭ�Ǵ� Ư��: �ҽİ�
    }

    Characteristic Characteristic_Claustrophobic(Characteristic Claustrophobic, bool Choice)
    {
        Claustrophobic.name = "Claustrophobic";
        Claustrophobic.name_kr = "�нǰ�����";
        Claustrophobic.Explanation_for_Characteristic = "Gets panicked when indoors";
        Claustrophobic.Explanation_for_Characteristic_kr = "�ǳ��� ���� �� ���� ��Ȳ���°� �Ǿ� ���ϴ�.";
        Claustrophobic.Characteristic_number = 30;
        Claustrophobic.Sprite = Characteristic_Image[30];
        Claustrophobic.Points = +4;
        Claustrophobic.type = Characteristic_type.Negatives;
        Claustrophobic.Choice = Choice;
        return Claustrophobic;
        // �ǳ��� ���� �� ��Ȳ �߻�
        // ��Ȱ��ȭ�Ǵ� Ư��: �밨��, �Ƶ巹���� �ߵ�, ���������
    }

    Characteristic Characteristic_Hard_of_Hearing(Characteristic Hard_of_Hearing, bool Choice)
    {
        Hard_of_Hearing.name = "Hard of Hearing";
        Hard_of_Hearing.name_kr = "��ο� ��";
        Hard_of_Hearing.Explanation_for_Characteristic = "Smaller perception radius. Smaller hearing range.";
        Hard_of_Hearing.Explanation_for_Characteristic_kr = "�Ҹ��� �����ϴ� �ݰ��� �۾����ϴ�.\r\n�鸮�� ������ ª�����ϴ�.";
        Hard_of_Hearing.Characteristic_number = 31;
        Hard_of_Hearing.Sprite = Characteristic_Image[31];
        Hard_of_Hearing.Points = +4;
        Hard_of_Hearing.type = Characteristic_type.Negatives;
        Hard_of_Hearing.Choice = Choice;
        Hard_of_Hearing.value_list.Add(-0.3f);
        Hard_of_Hearing.value_list.Add(-0.3f);
        return Hard_of_Hearing;
        // �Ҹ� ���� ���� ���� ( ���Ǽ��� -30% ) , �Ҹ��� �Ը��ϰ� �鸲, �ֺ� ��� ���� ( ���Ǽ��� -30% )
        // ��Ȱ��ȭ�Ǵ� Ư��: ������ û��, û�� ���
    }

    Characteristic Characteristic_Sleepyhead(Characteristic Sleepyhead, bool Choice)
    {
        Sleepyhead.name = "Sleepyhead";
        Sleepyhead.name_kr = "��ٷ���";
        Sleepyhead.Explanation_for_Characteristic = "Needs more sleep";
        Sleepyhead.Explanation_for_Characteristic_kr = "�� ���� ���� �ʿ�� �մϴ�.";
        Sleepyhead.Characteristic_number = 32;
        Sleepyhead.Sprite = Characteristic_Image[32];
        Sleepyhead.Points = +4;
        Sleepyhead.type = Characteristic_type.Negatives;
        Sleepyhead.Choice = Choice;
        Sleepyhead.value_list.Add(0.9f);
        return Sleepyhead;
        // �Ƿε� ��·� +30%, ���� ȿ�� -10%
        // ��Ȱ��ȭ�Ǵ� Ư��: ���� ����
    }

    Characteristic Characteristic_Prone_to_Illness(Characteristic Prone_to_Illness, bool Choice)
    {
        Prone_to_Illness.name = "Prone to Illness";
        Prone_to_Illness.name_kr = "������ �����";
        Prone_to_Illness.Explanation_for_Characteristic = "More prone to disease. Faster rate of zombification.";
        Prone_to_Illness.Explanation_for_Characteristic_kr = "������ �ɸ� ���ɼ��� �����մϴ�.\r\n����ȭ ���°� �Ǿ��� �� ����Ǵ� �ӵ��� �������ϴ�.";
        Prone_to_Illness.Characteristic_number = 33;
        Prone_to_Illness.Sprite = Characteristic_Image[33];
        Prone_to_Illness.Points = +4;
        Prone_to_Illness.type = Characteristic_type.Negatives;
        Prone_to_Illness.Choice = Choice;
        Prone_to_Illness.value_list.Add(0.7f);
        Prone_to_Illness.value_list.Add(-0.2f);
        Prone_to_Illness.value_list.Add(0.5f);
        Prone_to_Illness.value_list.Add(0.25f);
        return Prone_to_Illness;
        // ���⿡ �ɸ� Ȯ�� +70%, ���� ���� -20%, ���� ���� �ӵ� +50%, ����ȭ �ӵ� +25%
        // ��Ȱ��ȭ�Ǵ� Ư��: ���� ȸ����
    }

    Characteristic Characteristic_Pacifist(Characteristic Pacifist, bool Choice)
    {
        Pacifist.name = "Pacifist";
        Pacifist.name_kr = "��ȭ������";
        Pacifist.Explanation_for_Characteristic = "Less effective with weapons";
        Pacifist.Explanation_for_Characteristic_kr = "������ ȿ���� �����մϴ�.";
        Pacifist.Characteristic_number = 34;
        Pacifist.Sprite = Characteristic_Image[34];
        Pacifist.Points = +4;
        Pacifist.type = Characteristic_type.Negatives;
        Pacifist.Choice = Choice;
        Pacifist.value_list.Add(-0.25f);
        return Pacifist;
        // ��� ����, ���ǰ���, ���� ��ų�� ����ġ ����� -25%
    }

    Characteristic Characteristic_Asthmatic(Characteristic Asthmatic, bool Choice)
    {
        Asthmatic.name = "Asthmatic";
        Asthmatic.name_kr = "õ��ȯ��";
        Asthmatic.Explanation_for_Characteristic = "Faster endurance loss";
        Asthmatic.Explanation_for_Characteristic_kr = "������ ��ģ ���°� �˴ϴ�.";
        Asthmatic.Characteristic_number = 35;
        Asthmatic.Sprite = Characteristic_Image[35];
        Asthmatic.Points = +5;
        Asthmatic.type = Characteristic_type.Negatives;
        Asthmatic.Choice = Choice;
        Asthmatic.value_list.Add(0.4f);
        Asthmatic.value_list.Add(0.3f);
        return Asthmatic;
        // �޸���� ������ ������ �Ҹ� +40%, ������ ���� ����� ������ �Ҹ� +30%
    }

    Characteristic Characteristic_Out_of_Shape(Characteristic Out_of_Shape, bool Choice)
    {
        Out_of_Shape.name = "Out of Shape";
        Out_of_Shape.name_kr = "�ǰ� �̻�";
        Out_of_Shape.Explanation_for_Characteristic = "Low endurance, low endurance regeneration.";
        Out_of_Shape.Explanation_for_Characteristic_kr = "���� �����°� ���� ������ ȸ���� �����ϴ�.";
        Out_of_Shape.Characteristic_number = 36;
        Out_of_Shape.Sprite = Characteristic_Image[36];
        Out_of_Shape.Points = +6;
        Out_of_Shape.type = Characteristic_type.Negatives;
        Out_of_Shape.Choice = Choice;
        Out_of_Shape.value_list.Add(-2);
        return Out_of_Shape;
        // ü�� -2
    }

    Characteristic Characteristic_Overweight(Characteristic Overweight, bool Choice)
    {
        Overweight.name = "Overweight";
        Overweight.name_kr = "��ü��";
        Overweight.Explanation_for_Characteristic = "Reduced running speed, low endurance and prone to injury.";
        Overweight.Explanation_for_Characteristic_kr = "�޸��� �ӵ��� �������ϴ�.\r\n�޸���� ���� �� ���� ��Ĩ�ϴ�.";
        Overweight.Characteristic_number = 37;
        Overweight.Sprite = Characteristic_Image[37];
        Overweight.Points = +6;
        Overweight.type = Characteristic_type.Negatives;
        Overweight.Choice = Choice;
        Overweight.value_list.Add(-1);
        Overweight.value_list.Add(0.1f);
        Overweight.value_list.Add(-0.3f);
        Overweight.value_list.Add(-0.15f);
        Overweight.value_list.Add(0.1f);

        return Overweight;
        // ���� ������: 95kg
        // ������ ����: 85~99kg
        // ü�� -1
        // �Ѿ��� Ȯ�� +10%
        // ������ ȸ���� -30%
        // ���� ������ ���� Ȯ�� -15%
        // ���� ������ �پ���� �� �Ѿ����� ���� Ȯ�� +10%
    }

    Characteristic Characteristic_High_Thirst(Characteristic High_Thirst, bool Choice)
    {
        High_Thirst.name = "High Thirst";
        High_Thirst.name_kr = "���� ����";
        High_Thirst.Explanation_for_Characteristic = "Needs more water to survive";
        High_Thirst.Explanation_for_Characteristic_kr = "������ ���� ���� �Ҹ��� �����մϴ�.";
        High_Thirst.Characteristic_number = 38;
        High_Thirst.Sprite = Characteristic_Image[38];
        High_Thirst.Points = +6;
        High_Thirst.type = Characteristic_type.Negatives;
        High_Thirst.Choice = Choice;
        High_Thirst.value_list.Add(1f);
        return High_Thirst;
        // ���� ���� �ӵ� +100%
        // ��Ȱ��ȭ�Ǵ� Ư��: ���� ����
    }

    Characteristic Characteristic_Slow_Healer(Characteristic Slow_Healer, bool Choice)
    {
        Slow_Healer.name = "Slow Healer";
        Slow_Healer.name_kr = "���� ġ��";
        Slow_Healer.Explanation_for_Characteristic = "Recovers slowly from injuries and illness";
        Slow_Healer.Explanation_for_Characteristic_kr = "�λ�� ������ ������ ȸ���մϴ�.";
        Slow_Healer.Characteristic_number = 39;
        Slow_Healer.Sprite = Characteristic_Image[39];
        Slow_Healer.Points = +6;
        Slow_Healer.type = Characteristic_type.Negatives;
        Slow_Healer.Choice = Choice;
        return Slow_Healer;
        // ����, ������, ����, ���� ��ó, ȭ�� ��ó �ɰ��� ����
        // ��Ȱ��ȭ�Ǵ� Ư��: ���� ȸ��
    }
    Characteristic Characteristic_Slow_Learner(Characteristic Slow_Learner, bool Choice)
    {
        Slow_Learner.name = "Slow Learner";
        Slow_Learner.name_kr = "���� �н�";
        Slow_Learner.Explanation_for_Characteristic = "Decreased XP gains";
        Slow_Learner.Explanation_for_Characteristic_kr = "����ġ ȹ�淮�� �����մϴ�.";
        Slow_Learner.Characteristic_number = 40;
        Slow_Learner.Sprite = Characteristic_Image[40];
        Slow_Learner.Points = +6;
        Slow_Learner.type = Characteristic_type.Negatives;
        Slow_Learner.Choice = Choice;
        Slow_Learner.value_list.Add(-0.3f);
        return Slow_Learner;
        // ��� ��ų�� ����ġ ȹ�淮 -30%
        // ��Ȱ��ȭ�Ǵ� Ư��: ����
    }

    Characteristic Characteristic_Restless_Sleeper(Characteristic Restless_Sleeper, bool Choice)
    {
        Restless_Sleeper.name = "Restless Sleeper";
        Restless_Sleeper.name_kr = "�������";
        Restless_Sleeper.Explanation_for_Characteristic = "Slow loss of tiredness while sleeping";
        Restless_Sleeper.Explanation_for_Characteristic_kr = "������ �ǰ����� �ؼ��ϴ� ���� �������ϴ�.";
        Restless_Sleeper.Characteristic_number = 41;
        Restless_Sleeper.Sprite = Characteristic_Image[41];
        Restless_Sleeper.Points = +6;
        Restless_Sleeper.type = Characteristic_type.Negatives;
        Restless_Sleeper.Choice = Choice;
        Restless_Sleeper.value_list.Add(0.7f);
        return Restless_Sleeper;
        // �ִ� ���� �ð��� 3�ð����� ���ѵ� ( 1�ð� �Ŀ� �ٽ� ��ħ ���� )
        // �������� �氨�Ǵ� �Ƿε� ���� ( ���Ǽ��� -30% )
    }

    Characteristic Characteristic_Feeble(Characteristic Feeble, bool Choice)
    {
        Feeble.name = "Feeble";
        Feeble.name_kr = "������";
        Feeble.Explanation_for_Characteristic = "Less knockback from melee weapons. Decreased carrying weight.";
        Feeble.Explanation_for_Characteristic_kr = "�������� ��� �ÿ� �ڷ� ��ĥ Ȯ���� �����մϴ�.\r\n�ű� �� �ִ� ���Է��� �����մϴ�.";
        Feeble.Characteristic_number = 42;
        Feeble.Sprite = Characteristic_Image[42];
        Feeble.Points = +6;
        Feeble.type = Characteristic_type.Negatives;
        Feeble.Choice = Choice;
        Feeble.value_list.Add(-2);
        return Feeble;
        // �ٷ� -2
    }

    Characteristic Characteristic_Underweight(Characteristic Underweight, bool Choice)
    {
        Underweight.name = "Underweight";
        Underweight.name_kr = "��ü��";
        Underweight.Explanation_for_Characteristic = "Low strength, low endurance and prone to injury.";
        Underweight.Explanation_for_Characteristic_kr = "���� ���� ���� ������ �׸��� �λ� ���ϱ� �����ϴ�.";
        Underweight.Characteristic_number = 43;
        Underweight.Sprite = Characteristic_Image[43];
        Underweight.Points = +6;
        Underweight.type = Characteristic_type.Negatives;
        Underweight.Choice = Choice;
        Underweight.value_list.Add(-1);
        Underweight.value_list.Add(-0.2f);
        Underweight.value_list.Add(0.1f);
        Underweight.value_list.Add(-0.15f);
        return Underweight;
        // ���� ������: 70kg
        // ������ ����: 65~75kg
        // ü�� -1
        // ���� ������ -20%
        // �Ѿ��� Ȯ�� +10%
        // ���� ������ ���� Ȯ�� -15%
    }

    Characteristic Characteristic_Illiterate(Characteristic Illiterate, bool Choice)
    {
        Illiterate.name = "Illiterate";
        Illiterate.name_kr = "����";
        Illiterate.Explanation_for_Characteristic = "Cannot read books";
        Illiterate.Explanation_for_Characteristic_kr = "å�� ���� �� �����ϴ�.";
        Illiterate.Characteristic_number = 44;
        Illiterate.Sprite = Characteristic_Image[44];
        Illiterate.Points = +8;
        Illiterate.type = Characteristic_type.Negatives;
        Illiterate.Choice = Choice;
        Illiterate.value_list.Add(0);  // Player_main �� ability_Read = false �� �����ϱ� ����
        return Illiterate;
        // �б� ��Ȱ��ȭ
        // ��Ȱ��ȭ�Ǵ� Ư��: �ӵ�, ����
    }

    Characteristic Characteristic_Thin_skinned(Characteristic Thin_skinned, bool Choice)
    {
        Thin_skinned.name = "Thin skinned";
        Thin_skinned.name_kr = "���� �Ǻ�";
        Thin_skinned.Explanation_for_Characteristic = "Increased chance of scratches, lacerations, or bites breaking the skin.";
        Thin_skinned.Explanation_for_Characteristic_kr = "�����ų� �������ų� ���� ������ �������ϴ�.";
        Thin_skinned.Characteristic_number = 45;
        Thin_skinned.Sprite = Characteristic_Image[45];
        Thin_skinned.Points = +8;
        Thin_skinned.type = Characteristic_type.Negatives;
        Thin_skinned.Choice = Choice;
        Thin_skinned.value_list.Add(0.23f);
        Thin_skinned.value_list.Add(0.3f);
        Thin_skinned.value_list.Add(0.77f);
        return Thin_skinned;
        // ��� ����, ������, ���� Ȯ�� +23%
        // ȸ���� : 15 + (���� ���õ��� ���� ��ġ -5% ~ 7%) * {1.3(�β��� �Ǻ�) or 0.77(���� �Ǻ�)}
        // ������ ������ �� �λ��� ���� Ȯ�� +30%  ( �̱��� ���� )
        // ��Ȱ��ȭ�Ǵ� Ư��: �β��� �Ǻ�
    }

    Characteristic Characteristic_Obese(Characteristic Obese, bool Choice)
    {
        Obese.name = "Obese";
        Obese.name_kr = "��";
        Obese.Explanation_for_Characteristic = "Reduced running speed, very low endurance and prone to injury.";
        Obese.Explanation_for_Characteristic_kr = "�޸��� �ӵ��� ������ �ſ� ���� ������, ��ġ�� ���� ������ �ֽ��ϴ�.";
        Obese.Characteristic_number = 46;
        Obese.Sprite = Characteristic_Image[46];
        Obese.Points = +10;
        Obese.type = Characteristic_type.Negatives;
        Obese.Choice = Choice;
        Obese.value_list.Add(-2);
        Obese.value_list.Add(-0.3f);
        Obese.value_list.Add(0.2f);
        Obese.value_list.Add(0.2f);
        Obese.value_list.Add(-0.6f);
        Obese.value_list.Add(-0.25f);
        Obese.value_list.Add(-0.1f);
        return Obese;
        // ü�� -2
        // �޸��� �ӵ� ���� ( ���Ǽ��� -30% )
        // �Ѿ��� Ȯ�� +20%, ���� ������ +20%
        // ������ ȸ���� -60%
        // ���� ������ ���� Ȯ�� -25%
        // ����� �ε�ĥ �� �Ѿ��� Ȯ�� -10%
    }

    Characteristic Characteristic_Unfit(Characteristic Unfit, bool Choice)
    {
        Unfit.name = "Unfit";
        Unfit.name_kr = "�����";
        Unfit.Explanation_for_Characteristic = "Very low endurance, very low endurance regeneration.";
        Unfit.Explanation_for_Characteristic_kr = "�ſ� ���� �����°� �ſ� ���� ������ ȸ���� �����ϴ�.";
        Unfit.Characteristic_number = 47;
        Unfit.Sprite = Characteristic_Image[47];
        Unfit.Points = +10;
        Unfit.type = Characteristic_type.Negatives;
        Unfit.Choice = Choice;
        Unfit.value_list.Add(-4);
        return Unfit;
        // ü�� -4
    }

    Characteristic Characteristic_Very_Underweight(Characteristic Very_Underweight, bool Choice)
    {
        Very_Underweight.name = "Very Underweight";
        Very_Underweight.name_kr = "���� ��ü��";
        Very_Underweight.Explanation_for_Characteristic = "Very low strength, very low endurance and prone to injury.";
        Very_Underweight.Explanation_for_Characteristic_kr = "�ſ� ���� ���� �ſ� ���� ������ �׸��� �λ� ���ϱ� �����ϴ�.";
        Very_Underweight.Characteristic_number = 48;
        Very_Underweight.Sprite = Characteristic_Image[48];
        Very_Underweight.Points = +10;
        Very_Underweight.type = Characteristic_type.Negatives;
        Very_Underweight.Choice = Choice;
        Very_Underweight.value_list.Add(-2);
        Very_Underweight.value_list.Add(-0.4f);
        Very_Underweight.value_list.Add(0.2f);
        Very_Underweight.value_list.Add(0.1f);
        Very_Underweight.value_list.Add(-0.25f);
        return Very_Underweight;
        // ���� ������: 60kg
        // ������ ����: 50~64kg
        // ü�� -2
        // ���� ������ -40%
        // �Ѿ��� Ȯ�� +20%
        // ���� ������ +10%
        // ���� ������ ���� Ȯ�� -25%
    }

    Characteristic Characteristic_Emaciated(Characteristic Emaciated, bool Choice)
    {
        Emaciated.name = "Emaciated";
        Emaciated.name_kr = "��ô��";
        Emaciated.Explanation_for_Characteristic = "Low strength, low endurance and prone to injury";
        Emaciated.Explanation_for_Characteristic_kr = "���� ���ϰ� �������� ���ϸ� �λ��� ���ϱ� �����ϴ�";
        Emaciated.Characteristic_number = 49;
        Emaciated.Sprite = Characteristic_Image[49];
        Emaciated.Points = +0;  // ���úҰ�
        Emaciated.type = Characteristic_type.Negatives;
        Emaciated.Choice = Choice;
        Emaciated.value_list.Add(-2);
        Emaciated.value_list.Add(-0.6f);
        Emaciated.value_list.Add(0.25f);
        Emaciated.value_list.Add(0.20f);
        Emaciated.value_list.Add(-0.25f);
        Emaciated.value_list.Add(-0.7f);
        Emaciated.value_list.Add(35);
        return Emaciated;
        // ������ ����: 49kg ����
        // ü�� -2
        // ���� ������ -60%
        // �Ѿ��� Ȯ�� +25%
        // ���� ������ +20%
        // ���� ������ ���� Ȯ�� -25%
        // ������ ȸ���� -70%
        // ü���� 35kg ���Ϸ� �������� ��������� �װ� ��
    }

    Characteristic Characteristic_Weak(Characteristic Weak, bool Choice)
    {
        Weak.name = "Weak";
        Weak.name_kr = "����";
        Weak.Explanation_for_Characteristic = "Less knockback from melee weapons. Decreased carrying weight.";
        Weak.Explanation_for_Characteristic_kr = "�������� ��� �ÿ� �ڷ� ��ĥ Ȯ���� �����մϴ�.\r\n�ű� �� �ִ� ���Է��� �����մϴ�.";
        Weak.Characteristic_number = 50;
        Weak.Sprite = Characteristic_Image[50];
        Weak.Points = +10;
        Weak.type = Characteristic_type.Negatives;
        Weak.Choice = Choice;
        Weak.value_list.Add(-5);
        Weak.value_list.Add(6);
        return Weak;
        // �ٷ� -5, �������� 6���� ���ҵ�
    }

    Characteristic Characteristic_Deaf(Characteristic Deaf, bool Choice)
    {
        Deaf.name = "Deaf";
        Deaf.name_kr = "û�� ���";
        Deaf.Explanation_for_Characteristic = "Smaller perception radius and hearing range";
        Deaf.Explanation_for_Characteristic_kr = "�Ҹ��� ���� �� �����ϴ�.";
        Deaf.Characteristic_number = 51;
        Deaf.Sprite = Characteristic_Image[51];
        Deaf.Points = +12;
        Deaf.type = Characteristic_type.Negatives;
        Deaf.Choice = Choice;
        Deaf.value_list.Add(0);  // Player_main �� ability_Hear = false �� �����ϱ� ����
        return Deaf;
        // �Ҹ��� �鸮�� �ʴ´�
        // ��Ȱ��ȭ�Ǵ� Ư��: ������ û��, ��ο� ��
        // �ڷ������� ������ ��û �����ϰ� ����ġ�� ���� �� ����
    }


}
