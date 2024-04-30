using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UI_inventory_Using : MonoBehaviour
{
    public static UI_inventory_Using Using_item;
    public Type itemtype;   // ��Ŭ�� ��ȣ�ۿ�� Ȯ���ϴ� ����
    public int item_ID;   // ��Ŭ�� ��ȣ�ۿ�� Ȯ���ϴ� ����
    bool Possibility;

    private void OnEnable()
    {
        Possibility = false;
        switch (itemtype)
        {
            case Type.literature:
                Check_item_Literature(item_ID);
                break;
            case Type.food:
                Check_item_Food(item_ID);
                break;
        }

        // ����� �� ȣ���ϴ� �Լ�
        // if (Possibility) Using_item_in_inven(itemtype);
    }


    public void Check_item_Literature(int item_ID)
    {
        switch (Item_DataBase.item_database.literature_Ins[item_ID].LiteratureType)
        {
            case Book_Type.SkillBook:
                if (Player_main.player_main.ability_Read)
                {
                    switch (Item_DataBase.item_database.literature_Ins[item_ID].LiteratureSkillType)
                    {
                        case Skill_Type.Fishing:
                            if (Player_main.player_main.Skill.Fishing_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
                            {
                                Possibility = true;
                            }
                            break;
                        case Skill_Type.Hunting:
                            if (Player_main.player_main.Skill.Hunting_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
                            {
                                Possibility = true;
                            }
                            break;
                        case Skill_Type.Foraging:
                            if (Player_main.player_main.Skill.Foraging_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
                            {
                                Possibility = true;
                            }
                            break;
                        case Skill_Type.Riding:
                            if (Player_main.player_main.Skill.Riding_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
                            {
                                Possibility = true;
                            }
                            break;
                        case Skill_Type.Carpentry:
                            if (Player_main.player_main.Skill.Carpentry_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
                            {
                                Possibility = true;
                            }
                            break;
                        case Skill_Type.Cooking:
                            if (Player_main.player_main.Skill.Cooking_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
                            {
                                Possibility = true;
                            }
                            break;
                        case Skill_Type.Farming:
                            if (Player_main.player_main.Skill.Farming_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
                            {
                                Possibility = true;
                            }
                            break;
                        case Skill_Type.FirstAid:
                            if (Player_main.player_main.Skill.FirstAid_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
                            {
                                Possibility = true;
                            }
                            break;
                        case Skill_Type.Electrical:
                            if (Player_main.player_main.Skill.Electrical_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
                            {
                                Possibility = true;
                            }
                            break;
                    }
                }
                break;
            case Book_Type.Leisure:
                if (Player_main.player_main.ability_Read)
                {
                    Possibility = true;
                }
                break;
            case Book_Type.Magazine:
                if (Player_main.player_main.ability_Read)
                {
                    switch (Item_DataBase.item_database.literature_Ins[item_ID].LiteratureSkillType)   // �̹� ���� ���������ƴ��� Ȯ��
                    {
                        case Skill_Type.Fishing:

                            break;
                        case Skill_Type.Hunting:

                            break;
                        case Skill_Type.Foraging:

                            break;
                        case Skill_Type.Riding:

                            break;
                        case Skill_Type.Carpentry:

                            break;
                        case Skill_Type.Cooking:

                            break;
                        case Skill_Type.Farming:

                            break;
                        case Skill_Type.FirstAid:

                            break;
                        case Skill_Type.Electrical:

                            break;
                    }
                }
                break;
            case Book_Type.Map:
                Possibility = true;
                break;
        }
    }

    public void Check_item_Food(int item_ID)
    {

    }

    public void Using_item_in_inven(Type item_type)
    {
        switch (item_type)
        {
            case Type.literature:
                Player_main.player_main.Is_Reading = true;
                break;
            case Type.food:
                Player_main.player_main.Is_Eating = true;
                break;
        }
    }



}
