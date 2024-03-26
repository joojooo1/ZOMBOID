using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Moodle : MonoBehaviour
{
    public static UI_Moodle ui_moodle;
    public Sprite[] Background_Good;
    public Sprite[] Background_Bad;
    public Sprite[] Moodletype;

    [SerializeField] GameObject MoodlePrefab;
    [SerializeField] Transform MoodleWindow;

    List<Moodle_Prefab> currentMoodle = new List<Moodle_Prefab>();

    private void Awake()
    {
        ui_moodle = this;
    }

    public void Moodle_Ins(Moodles_private_code Moodlecode, int Moodlestep)
    {
        int current_indexnumber;

        if (currentMoodle.Count > 0)
        {
            for (int i = 0; i < currentMoodle.Count; i++)
            {
                if (currentMoodle[i].GetMoodleType() == Moodlecode)  // 이미 해당 무들 활성화 되어있는 경우
                {
                    current_indexnumber = i;

                    if (currentMoodle[i].GetStep() != Moodlestep)
                    {
                        if (Moodlestep == 0)
                        {
                            Destroy(currentMoodle[i].gameObject);
                            currentMoodle.Remove(currentMoodle[i]);
                        }
                        else
                        {
                            SetMoodleicon(Moodlecode, Moodlestep, currentMoodle[i], current_indexnumber);
                        }
                    }

                    break;
                }
                else if (i == (currentMoodle.Count - 1))  // 해당 무들이 활성화되지 않은 경우
                {
                    if (Moodlestep != 0)
                    {
                        GameObject tempObj = null;
                        tempObj = Instantiate(MoodlePrefab, MoodleWindow);
                        Moodle_Prefab slot = tempObj.GetComponentInChildren<Moodle_Prefab>();
                        current_indexnumber = currentMoodle.Count;
                        SetMoodleicon(Moodlecode, Moodlestep, slot, current_indexnumber);
                        currentMoodle.Add(slot);
                    }
                }
            }
        }
        else
        {
            if(Moodlestep != 0)
            {
                GameObject tempObj = null;
                tempObj = Instantiate(MoodlePrefab, MoodleWindow);
                Moodle_Prefab slot = tempObj.GetComponentInChildren<Moodle_Prefab>();
                current_indexnumber = 0;
                SetMoodleicon(Moodlecode, Moodlestep, slot, current_indexnumber);
                currentMoodle.Add(slot);
            }
            
        }



        for(int i = 0; i < currentMoodle.Count; i++)
        {
            currentMoodle[i].SetIndex(i);
        }

    }

    public void SetMoodleicon(Moodles_private_code Moodlecode, int Moodlestep, Moodle_Prefab slot, int index)
    {
        switch (Moodlecode)
        {
            case Moodles_private_code.Hungry:
            case Moodles_private_code.Thirsty:
            case Moodles_private_code.Panic:
            case Moodles_private_code.Bored:
            case Moodles_private_code.Stressed:
            case Moodles_private_code.Unhappy:
            case Moodles_private_code.Drunk:
            case Moodles_private_code.Heavy_Load:
            case Moodles_private_code.Endurance:
            case Moodles_private_code.Tired:
            case Moodles_private_code.Hyperthermia_Hot:
            case Moodles_private_code.Hyperthermia_Cold:
            case Moodles_private_code.Windchill:
            case Moodles_private_code.Wet:
            case Moodles_private_code.Injured:
            case Moodles_private_code.Pain:
            case Moodles_private_code.Bleeding:
            case Moodles_private_code.Has_a_Cold:
            case Moodles_private_code.Sick:
            case Moodles_private_code.Dead:
            case Moodles_private_code.Zombie:
                slot.SetMoodle(Moodlecode, Moodlestep, Background_Bad[Moodlestep-1], Moodletype[(int)Moodlecode]);
                break;
            case Moodles_private_code.Stuffed:
                slot.SetMoodle(Moodlecode, Moodlestep, Background_Good[Moodlestep-1], Moodletype[(int)Moodlecode]);
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }



}
