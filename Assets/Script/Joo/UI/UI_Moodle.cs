using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Moodle : MonoBehaviour
{
    public Sprite[] Background_Good;
    public Sprite[] Background_Bad;
    public Sprite[] Moodletype;

    [SerializeField] GameObject MoodlePrefab;
    [SerializeField] Transform MoodleWindow;

    List<Moodle_Prefab> currentMoodle = new List<Moodle_Prefab>();

    Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    int a = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            a++;
            Moodle_Ins(Moodles_private_code.Hungry, a);
        }
    }


    public void Moodle_Ins(Moodles_private_code Moodlecode, int Moodlestep)
    {
        int Moodle_indexnumber;
        GameObject tempObj = null;

        if(currentMoodle != null)
        {
            for (int i = 0; i < currentMoodle.Count; i++)
            {
                if (currentMoodle[i].GetMoodleType() == Moodlecode)  // 이미 해당 무들 활성화 되어있는 경우
                {
                    Moodle_indexnumber = i;
                    if (currentMoodle[i].GetStep() == 1)
                    {
                        if (Moodlestep == 0)
                            Destroy(currentMoodle[i]);
                    }

                    break;
                }
                else if (i == (currentMoodle.Count - 1) && currentMoodle[i].GetMoodleType() != Moodlecode)  // 해당 무들이 활성화되지 않은 경우
                {
                    tempObj = Instantiate(MoodlePrefab, MoodleWindow);
                    Moodle_indexnumber = currentMoodle.Count;
                    SetMoodleicon(Moodlecode, Moodlestep, tempObj, Moodle_indexnumber);
                }
            }
        }
        else
        {
            tempObj = Instantiate(MoodlePrefab, MoodleWindow);
            Moodle_indexnumber = currentMoodle.Count;
            SetMoodleicon(Moodlecode, Moodlestep, tempObj, Moodle_indexnumber);
        }



        for(int i = 0; i < currentMoodle.Count; i++)
        {
            currentMoodle[i].SetIndex(i);
        }

    }

    public void SetMoodleicon(Moodles_private_code Moodlecode, int Moodlestep, GameObject tempObj, int index)
    {
        switch (Moodlecode)
        {
            case Moodles_private_code.Hungry:
                Moodle_Prefab slot = tempObj.GetComponent<Moodle_Prefab>();
                slot.SetMoodle(Moodles_private_code.Hungry, Moodlestep, Background_Bad[Moodlestep], Moodletype[(int)Moodles_private_code.Hungry]);
                currentMoodle.Add(slot);
                anim.SetTrigger("Change");
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
            default:
                Debug.Log("Error");
                break;
        }
    }



}
