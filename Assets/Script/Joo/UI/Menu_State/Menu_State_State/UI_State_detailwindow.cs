using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class UI_State_detailwindow : MonoBehaviour, IPointerEnterHandler
{
    public body_point body_position;
    public Damage_Pattern _damagetype;
    public int position_Damage_Num = 0;
    public Transform Damage_icon_position;
    [SerializeField] UnityEngine.UI.Image icon_Image;
    [SerializeField] UnityEngine.UI.Image icon_Background_Image;

    public void SetImage(Sprite image, body_point position, Damage_Pattern damagetype, int index)
    {
        icon_Image.sprite = image;
        body_position = position;
        _damagetype = damagetype;
        position_Damage_Num = index;

        switch (_damagetype)
        {
            case Damage_Pattern.Scratches:
            case Damage_Pattern.Glass:
            case Damage_Pattern.Abrasion:
                icon_Background_Image.sprite = UI_main.ui_main.ui_player_state.player_damage_Back_SpriteArray[0];
                break;
            case Damage_Pattern.Lacerations:
            case Damage_Pattern.Infection:
            case Damage_Pattern.bullet:
                icon_Background_Image.sprite = UI_main.ui_main.ui_player_state.player_damage_Back_SpriteArray[1];
                break;
            case Damage_Pattern.Bites:
            case Damage_Pattern.Fracture:
            case Damage_Pattern.Burn:
                icon_Background_Image.sprite = UI_main.ui_main.ui_player_state.player_damage_Back_SpriteArray[2];
                break;
        }
    }

    Vector3 pos = new Vector3(1f, -60f, 1);
    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_main.ui_main.ui_player_state.TreatmentBar.transform.position = Damage_icon_position.position + pos;
        UI_main.ui_main.ui_player_state.TreatmentBar.SetActive(true);
        UI_main.ui_main.ui_player_state.Choice_Damage(body_position, position_Damage_Num);
    }

    public void Using_Medical_item(int item_iD)
    {
        switch (Item_DataBase.item_database.medical_Ins[item_iD].MedicalType)
        {
            case Medical_Type.Disinfectant:
                Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].Set_Is_disinfection(Item_DataBase.item_database.medical_Ins[item_iD].Is_Disinfection);
                break;
            case Medical_Type.Herb:
                if(Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "Poultice")
                {
                    Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].item_recovery = Item_DataBase.item_database.medical_Ins[item_iD].Power;
                }
                else if(Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "BlackSage")
                {
                    Player_main.player_main.player_HP.Set_Player_HP_for_Heal(Item_DataBase.item_database.medical_Ins[item_iD].Power * 2);
                    Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].Set_Is_disinfection(true);
                }
                break;
            case Medical_Type.Pharmaceutical:
                if (Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "Antibiotics")
                {
                    Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].item_Antibiotics = Item_DataBase.item_database.medical_Ins[item_iD].Power;
                }
                else if(Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "Antidepressants")
                {
                    Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(-(Item_DataBase.item_database.medical_Ins[item_iD].Power * 10));
                }
                else if(Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "Beta Blockers")
                {
                    Player_main.player_main.playerMoodles.Moodle_Panic.Set_Moodles_state(-(Item_DataBase.item_database.medical_Ins[item_iD].Power * 15));
                }
                else if(Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "Cigarettes")
                {
                    Player_main.player_main.Is_Smoking = true;
                }
                else if (Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "Painkillers")
                {
                    Player_main.player_main.player_HP.Set_Player_HP_for_Heal(Item_DataBase.item_database.medical_Ins[item_iD].Power);
                }
                else if (Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "Sleeping Tablets")
                {
                    Player_main.player_main.ability_Sleeping = true;
                }
                else if (Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "Vitamins")
                {
                    Player_main.player_main.playerMoodles.Moodle_Tired.Set_Moodles_state(-Item_DataBase.item_database.medical_Ins[item_iD].Power);
                }
                break;
        }
    }

    public void Using_Bandage(int item_iD)
    {
        if (Item_DataBase.item_database.medical_Ins[item_iD].MedicalName == "Splint")
        {
            Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].Set_Is_Bandage(true, Item_DataBase.item_database.medical_Ins[item_iD].Power);
        }
        else
        {
            Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].Set_Is_Bandage(true, Item_DataBase.item_database.medical_Ins[item_iD].Power);
            Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].Set_Is_disinfection(Item_DataBase.item_database.medical_Ins[item_iD].Is_Disinfection);
            Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].Set_Is_Bandage_Dirty(Item_DataBase.item_database.medical_Ins[item_iD].Is_Clean);
        }

        Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].Change_Back_Image();
    }

    public void Remove_Bandage()
    {
        Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].Set_Is_Bandage(false, 0);
        Player_main.player_main.playerState.Player_body_point[(int)body_position].Body_Damage_array[position_Damage_Num].Set_Is_Bandage_Dirty(false);

        switch (_damagetype)
        {
            case Damage_Pattern.Scratches:
            case Damage_Pattern.Glass:
            case Damage_Pattern.Abrasion:
                icon_Background_Image.sprite = UI_main.ui_main.ui_player_state.player_damage_Back_SpriteArray[0];
                break;
            case Damage_Pattern.Lacerations:
            case Damage_Pattern.Infection:
            case Damage_Pattern.bullet:
                icon_Background_Image.sprite = UI_main.ui_main.ui_player_state.player_damage_Back_SpriteArray[1];
                break;
            case Damage_Pattern.Bites:
            case Damage_Pattern.Fracture:
            case Damage_Pattern.Burn:
                icon_Background_Image.sprite = UI_main.ui_main.ui_player_state.player_damage_Back_SpriteArray[2];
                break;
        }
    }

    public void Change_recovery_color(float value)
    {
        if(value < 0.33f)
        {
            icon_Background_Image.sprite = UI_main.ui_main.ui_player_state.player_damage_Back_SpriteArray[3];
        }
        else if(value > 0.33f &&  value < 0.66f)
        {
            icon_Background_Image.sprite = UI_main.ui_main.ui_player_state.player_damage_Back_SpriteArray[4];
        }
        else
        {
            icon_Background_Image.sprite = UI_main.ui_main.ui_player_state.player_damage_Back_SpriteArray[5];
        }
    }

}
