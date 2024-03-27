using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moodle_Prefab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Moodles_private_code type;
    int step;
    int index;
    [SerializeField] UnityEngine.UI.Image Back;
    [SerializeField] UnityEngine.UI.Image Icon;

    Animator anim;

    private void OnEnable()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void SetMoodle(Moodles_private_code Moodletype, int Moodlestep, Sprite Back_Image, Sprite Moodle_Image)
    {
        if(step != 0 && step != Moodlestep)
        {
            anim.SetTrigger("move");
        }


        type = Moodletype;
        step = Moodlestep;
        Back.sprite = Back_Image;
        Icon.sprite = Moodle_Image;

    }

    public void SetIndex(int MoodleNum)
    {
        index = MoodleNum;
    }

    public int GetIndex() { return  index; }

    public Moodles_private_code GetMoodleType() { return  type; }

    public void Get_Moodle_string(Moodles_private_code type)
    {
        string current_state = "";

        switch(type)
        {
            case Moodles_private_code.Hungry:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Hungry.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Hungry.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Stuffed:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Stuffed.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Stuffed.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Thirsty:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Thirsty.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Thirsty.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Panic:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Panic.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Panic.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Bored:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Bored.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Bored.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Stressed:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Stressed.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Stressed.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Unhappy:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Unhappy.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Unhappy.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Drunk:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Drunk.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Drunk.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Heavy_Load:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Heavy_Load.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Heavy_Load.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Endurance:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Endurance.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Endurance.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Tired:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Tired.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Tired.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Hyperthermia_Hot:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Hyperthermia_Cold:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Cold.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Cold.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Windchill:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Windchill.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Windchill.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Wet:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Wet.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Wet.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Injured:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Injured.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Injured.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Pain:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Pain.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Pain.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Bleeding:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Bleeding.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Bleeding.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Has_a_Cold:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Has_a_Cold.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Has_a_Cold.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Sick:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Sick.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Sick.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Dead:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Dead.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Dead.Get_current_detail_state_to_string();
                break;
            case Moodles_private_code.Zombie:
                Moodle_State.text = Player_main.player_main.playerMoodles.Moodle_Zombie.Get_current_state_to_string();
                Moodle_Detail.text = Player_main.player_main.playerMoodles.Moodle_Zombie.Get_current_detail_state_to_string();
                break;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    public int GetStep() { return step; }


    // 세부정보 창 ( 마우스 올렸을때만 활성화 )

    public GameObject Moodle_InfoWindow;
    public UnityEngine.UI.Text Moodle_State;
    public UnityEngine.UI.Text Moodle_Detail;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Moodle_InfoWindow.SetActive(true);
        Get_Moodle_string(type);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Moodle_InfoWindow.SetActive(false);
    }
}
