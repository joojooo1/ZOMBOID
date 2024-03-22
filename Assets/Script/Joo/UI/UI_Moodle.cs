using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Moodle : MonoBehaviour
{
    [SerializeField] Sprite[] Background;
    [SerializeField] Sprite[] Moodletype;

    [SerializeField] GameObject MoodlePrefab;
    [SerializeField] Transform MoodleWindow;

    List<Moodle_Prefab> currentMoodle = new List<Moodle_Prefab>();

    public void Moodle_Ins(Moodles_private_code Moodlecode, int Moodlestep)
    {
        for(int i = 0; i<currentMoodle.Count; i++)
        {
            //if (currentMoodle[i].type == Moodlecode)
            {

            }
        }

        GameObject tempObj = null;
        tempObj = Instantiate(MoodlePrefab, MoodleWindow);
        switch (Moodlecode)
        {
            case Moodles_private_code.Hungry:
                tempObj = Instantiate(MoodlePrefab, MoodleWindow);
                Moodle_Prefab slot = tempObj.GetComponent<Moodle_Prefab>();

                break;
            case Moodles_private_code.Stuffed:
                break;
            case Moodles_private_code.Thirsty:
                break;
            case Moodles_private_code.Panic:
                break;
            case Moodles_private_code.Bored:
                break;
            case Moodles_private_code.Stressed:
                break;
            case Moodles_private_code.Unhappy:
                break;
            case Moodles_private_code.Drunk:
                break;
            case Moodles_private_code.Heavy_Load:
                break;
            case Moodles_private_code.Endurance:
                break;
            case Moodles_private_code.Tired:
                break;
            case Moodles_private_code.Hyperthermia_Hot:
                break;
            case Moodles_private_code.Hyperthermia_Cold:
                break;
            case Moodles_private_code.Windchill:
                break;
            case Moodles_private_code.Wet:
                break;
            case Moodles_private_code.Injured:
                break;
            case Moodles_private_code.Pain:
                break;
            case Moodles_private_code.Bleeding:
                break;
            case Moodles_private_code.Has_a_Cold:
                break;
            case Moodles_private_code.Sick:
                break;
            case Moodles_private_code.Dead:
                break;
            case Moodles_private_code.Zombie:
                break;
            case Moodles_private_code.Restricted_Movement:
                break;
        }

    }




}
