using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UI_inventory_Using : MonoBehaviour
{
    public static UI_inventory_Using Using_item;
    public Type itemtype;   // 우클릭 상호작용시 확인하는 변수
    public int item_ID;   // 우클릭 상호작용시 확인하는 변수
    bool Possibility;

    private void Start()
    {
        Using_item = this;
    }

    public void Open_Choice_Window(Type _itemtype, int _item_ID)
    {
        itemtype = _itemtype;
        item_ID = _item_ID;

        Possibility = false;
        switch (itemtype)
        {
            case Type.literature:
                Check_item_Literature(item_ID);
                break;
            case Type.food:
                Check_item_Food(item_ID);
                break;
            case Type.Farming:
                // 농사 가능한 타일인지 확인
                break;
            case Type.Tool:
                //
                break;
            case Type.Electronics:
                //
                break;
        }

        // 사용할 때 호출하는 함수
        // if (Possibility) Using_item_in_inven(itemtype);
    }

    public void Check_item_Literature(int item_ID)
    {
        switch (Item_DataBase.item_database.literature_Ins[item_ID].LiteratureType)
        {
            case Book_Type.SkillBook:
                if (Player_main.player_main.ability_Read)
                {
                    UI_main.ui_main.ui_text.text_window_playing("Cannot read the text", "글을 읽을 줄 모름");
                    switch (Item_DataBase.item_database.literature_Ins[item_ID].LiteratureSkillType)
                    {
                        case Skill_Type.Fishing:
                            if (Player_main.player_main.Skill.Fishing_Level.Check_reading(Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level))
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
                    // 이미 읽은 잡지인지아닌지 확인
                    for(int i = 0; i < Player_main.player_main.crafting_recipe.Recipe_Crafting_list.Count;)
                    {
                        if(Player_main.player_main.crafting_recipe.Recipe_Crafting_list[i].Magazine_ID == item_ID)
                        {
                            if (Player_main.player_main.crafting_recipe.Recipe_Crafting_list[i].Is_Craftng == false)
                            {
                                Possibility = true;
                            }
                            else
                            {
                                UI_main.ui_main.ui_text.text_window_playing("It's already known", "이미 읽은 잡지임");                                
                            }
                            break;
                        }

                        i++;
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
        if (Item_DataBase.item_database.food_Ins[item_ID].FoodType == Food_Type.Canned_food)
        {
            if (Item_DataBase.item_database.food_Ins[item_ID].Is_Canned == false
                && Player_main.player_main.ability_Eat && !Player_main.player_main.Is_Eating)
            {
                Possibility = true;
            }
        }
        else if(Item_DataBase.item_database.food_Ins[item_ID].FoodType == Food_Type.Ingredients_food)
        {
            Possibility = false;
        }
        else
        {
            if (Player_main.player_main.ability_Eat && !Player_main.player_main.Is_Eating)
            {
                Possibility = true;
            }
        }

    }

    public void Using_item_in_inven(Type item_type)
    {
        if (Possibility)
        {
            switch (item_type)
            {
                case Type.literature:
                    Player_main.player_main.Is_Reading = true;
                    switch (Item_DataBase.item_database.literature_Ins[item_ID].LiteratureType)
                    {
                        case Book_Type.Leisure:
                            Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.literature_Ins[item_ID].L_Unhappiness);
                            Player_main.player_main.playerMoodles.Moodle_Stressed.Set_Moodles_state(Item_DataBase.item_database.literature_Ins[item_ID].L_Stress);
                            Player_main.player_main.playerMoodles.Moodle_Bored.Set_Moodles_state(Item_DataBase.item_database.literature_Ins[item_ID].L_Boredom);
                            break;
                        case Book_Type.SkillBook:
                            Player_main.player_main.current_SkillBook_type = Item_DataBase.item_database.literature_Ins[item_ID].LiteratureSkillType;
                            Player_main.player_main.current_SKillBook_level = Item_DataBase.item_database.literature_Ins[item_ID].Literature_Level;
                            switch (Player_main.player_main.current_SkillBook_type)
                            {
                                case Skill_Type.Fishing:
                                    Player_main.player_main.Skillbook_Readpage = Player_main.player_main.Skill.Fishing_Level.Get_S_reading_page();
                                    break;
                                case Skill_Type.Carpentry:
                                    Player_main.player_main.Skillbook_Readpage = Player_main.player_main.Skill.Carpentry_Level.Get_C_reading_page();
                                    break;
                                case Skill_Type.Cooking:
                                    Player_main.player_main.Skillbook_Readpage = Player_main.player_main.Skill.Cooking_Level.Get_C_reading_page();
                                    break;
                                case Skill_Type.Farming:
                                    Player_main.player_main.Skillbook_Readpage = Player_main.player_main.Skill.Farming_Level.Get_C_reading_page();
                                    break;
                                case Skill_Type.FirstAid:
                                    Player_main.player_main.Skillbook_Readpage = Player_main.player_main.Skill.FirstAid_Level.Get_C_reading_page();
                                    break;
                                case Skill_Type.Electrical:
                                    Player_main.player_main.Skillbook_Readpage = Player_main.player_main.Skill.Electrical_Level.Get_C_reading_page();
                                    break;
                            }
                            break;
                        case Book_Type.Magazine:
                            for(int i = 0; i < Player_main.player_main.crafting_recipe.Recipe_Crafting_list.Count; i++)
                            {
                                if (Player_main.player_main.crafting_recipe.Recipe_Crafting_list[i].Magazine_ID == item_ID)
                                {
                                    Player_main.player_main.crafting_recipe.Recipe_Crafting_list[i].Is_Craftng = true;
                                }
                            }
                            break;
                        default: break;
                    }
                    break;
                case Type.food:
                    Player_main.player_main.Is_Eating = true;
                    switch (Item_DataBase.item_database.food_Ins[item_ID].FoodType)
                    {
                        case Food_Type.Spice:
                            Player_main.player_main.Set_Calories(Item_DataBase.item_database.food_Ins[item_ID].F_Calories);
                            Player_main.player_main.Set_Satiety(Item_DataBase.item_database.food_Ins[item_ID].F_Satiety[0]);
                            Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Unhappiness[0]);
                            break;
                        case Food_Type.Canned_food:
                        case Food_Type.Vegetable:
                        case Food_Type.Fruit:
                        case Food_Type.Grain:
                        case Food_Type.Fish:
                        case Food_Type.Meat:
                        case Food_Type.Cooking:
                            if (Item_DataBase.item_database.food_Ins[item_ID].Is_Perishable)
                            {
                                if (Item_DataBase.item_database.food_Ins[item_ID].Freshness == Freshness_Level.rotten)
                                {
                                    Player_main.player_main.Set_Calories(Item_DataBase.item_database.food_Ins[item_ID].F_Calories);
                                    Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Thirst);
                                    Player_main.player_main.Set_Satiety(Item_DataBase.item_database.food_Ins[item_ID].F_Satiety[0]);
                                    Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Unhappiness[0]);
                                    Player_main.player_main.playerMoodles.Moodle_Bored.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Boredom[0]);
                                    Player_main.player_main.Calculating_Food_Poisoning(Item_DataBase.item_database.food_Ins[item_ID].Probability_of_poisoning);
                                }
                                else
                                {
                                    Player_main.player_main.Set_Calories(Item_DataBase.item_database.food_Ins[item_ID].F_Calories);
                                    Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Thirst);
                                    Player_main.player_main.Set_Satiety(Item_DataBase.item_database.food_Ins[item_ID].F_Satiety[(int)Item_DataBase.item_database.food_Ins[item_ID].Freshness]);
                                    Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Unhappiness[(int)Item_DataBase.item_database.food_Ins[item_ID].Freshness]);
                                    Player_main.player_main.playerMoodles.Moodle_Bored.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Boredom[(int)Item_DataBase.item_database.food_Ins[item_ID].Freshness]);
                                    Player_main.player_main.Calculating_Food_Poisoning(Item_DataBase.item_database.food_Ins[item_ID].Probability_of_poisoning);
                                }

                            }
                            else
                            {
                                Player_main.player_main.Set_Calories(Item_DataBase.item_database.food_Ins[item_ID].F_Calories);
                                Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Thirst);
                                Player_main.player_main.Set_Satiety(Item_DataBase.item_database.food_Ins[item_ID].F_Satiety[(int)Item_DataBase.item_database.food_Ins[item_ID].Freshness]);
                                Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Unhappiness[0]);
                                Player_main.player_main.playerMoodles.Moodle_Bored.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Boredom[0]);
                                Player_main.player_main.Calculating_Food_Poisoning(Item_DataBase.item_database.food_Ins[item_ID].Probability_of_poisoning);
                            }
                            break;
                        case Food_Type.Sweet:
                            if (Item_DataBase.item_database.food_Ins[item_ID].Is_Perishable)
                            {
                                Player_main.player_main.Set_Calories(Item_DataBase.item_database.food_Ins[item_ID].F_Calories);
                                Player_main.player_main.Set_Satiety(Item_DataBase.item_database.food_Ins[item_ID].F_Satiety[(int)Item_DataBase.item_database.food_Ins[item_ID].Freshness]);
                                Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Unhappiness[(int)Item_DataBase.item_database.food_Ins[item_ID].Freshness]);
                                Player_main.player_main.playerMoodles.Moodle_Bored.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Boredom[(int)Item_DataBase.item_database.food_Ins[item_ID].Freshness]);
                                Player_main.player_main.Calculating_Food_Poisoning(Item_DataBase.item_database.food_Ins[item_ID].Probability_of_poisoning);
                            }
                            else
                            {
                                Player_main.player_main.Set_Calories(Item_DataBase.item_database.food_Ins[item_ID].F_Calories);
                                Player_main.player_main.Set_Satiety(Item_DataBase.item_database.food_Ins[item_ID].F_Satiety[0]);
                                Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Unhappiness[0]);
                                Player_main.player_main.playerMoodles.Moodle_Bored.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Boredom[0]);
                                Player_main.player_main.Calculating_Food_Poisoning(Item_DataBase.item_database.food_Ins[item_ID].Probability_of_poisoning);
                            }
                            break;
                        case Food_Type.Drink:
                        case Food_Type.Water:
                            if (Item_DataBase.item_database.food_Ins[item_ID].Is_Perishable)
                            {
                                Player_main.player_main.Set_Calories(Item_DataBase.item_database.food_Ins[item_ID].F_Calories);
                                Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Thirst);
                                Player_main.player_main.Set_Satiety(Item_DataBase.item_database.food_Ins[item_ID].F_Satiety[0]);
                                Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Unhappiness[(int)Item_DataBase.item_database.food_Ins[item_ID].Freshness]);
                                Player_main.player_main.playerMoodles.Moodle_Bored.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Boredom[(int)Item_DataBase.item_database.food_Ins[item_ID].Freshness]);
                                Player_main.player_main.Calculating_Food_Poisoning(Item_DataBase.item_database.food_Ins[item_ID].Probability_of_poisoning);
                            }
                            else
                            {
                                if (Item_DataBase.item_database.food_Ins[item_ID].Is_Alcoholic)
                                {
                                    Player_main.player_main.Set_Calories(Item_DataBase.item_database.food_Ins[item_ID].F_Calories);
                                    Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Thirst);
                                    Player_main.player_main.Set_Satiety(Item_DataBase.item_database.food_Ins[item_ID].F_Satiety[0]);
                                    Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Unhappiness[0]);
                                    Player_main.player_main.Calculating_Food_Poisoning(Item_DataBase.item_database.food_Ins[item_ID].Probability_of_poisoning);
                                }
                                else
                                {
                                    Player_main.player_main.Set_Calories(Item_DataBase.item_database.food_Ins[item_ID].F_Calories);
                                    Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Thirst);
                                    Player_main.player_main.Set_Satiety(Item_DataBase.item_database.food_Ins[item_ID].F_Satiety[0]);
                                    Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Unhappiness[0]);
                                    Player_main.player_main.playerMoodles.Moodle_Tired.Set_Moodles_state(Item_DataBase.item_database.food_Ins[item_ID].F_Fatigue[0]);
                                    Player_main.player_main.Calculating_Food_Poisoning(Item_DataBase.item_database.food_Ins[item_ID].Probability_of_poisoning);
                                }
                            }
                            break;
                        default: break;
                    }

                    break;
                case Type.weapon:
                    if(Player_main.player_main.Current_equipping_Weapon >= 0)
                    {           
                        Player_main.player_main.Set_Attack_Power_for_Basic();
                    }
                    Player_main.player_main.Set_Attack_Power_for_Equipping_Weapons(item_ID);
                    break;
                case Type.clothing:
                    if (Player_main.player_main.playerState.Clothing_list[(int)Item_DataBase.item_database.clothing_Ins[item_ID].ClothingType][5] == 1)
                    {
                        Player_main.player_main.playerState.Set_Wear_Basic(item_ID);
                    }
                    Player_main.player_main.playerState.Set_Wear(item_ID);
                    break;
                case Type.Medical:
                    // UI_main.ui_main.ui_player_state.Use_Medical_item(Item_DataBase.item_database.medical_Ins[item_ID].MedicalType, item_ID);
                    // 상태창에서 상처프리팹 통해서 들어가야 상처위치, 상처index 정보 받아올 수 있음
                    break;
                case Type.Normal:
                    if(Item_DataBase.item_database.ETC_Ins[item_ID].ETC_Name == "Magazine")
                    {
                        if(Player_main.player_main.Is_Equipping_Gun_Magazine == false)
                        {
                            Player_main.player_main.Set_Equipping_Magazine(true);
                        }
                    }
                    else if(Item_DataBase.item_database.ETC_Ins[item_ID].ETC_Name == "Fertilizer"
                        || Item_DataBase.item_database.ETC_Ins[item_ID].ETC_Name == "Compost")
                    {
                        // 농사 시간 단축
                    }
                    break;  // 이 외에는 직접적으로 사용하는 아이템 없음
                case Type.Tool:
                    for(int i = 0; i < Item_DataBase.item_database.Tool_Ins[item_ID].Usingtype.Length; i++)
                    {
                        if (Item_DataBase.item_database.Tool_Ins[item_ID].Usingtype[i] == Using_Type.Water)
                        {
                            Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(Item_DataBase.item_database.Tool_Ins[item_ID].Water / 100);
                        }
                    }
                    
                    break;
                case Type.Container:

                    break;
                case Type.Electronics:

                    break;
                case Type.Furniture:
                    // 맵에서 상호작용
                    break;
                case Type.Farming:
                    // 맵에서 상호작용
                    break;
            }
        }
        
    }



}
