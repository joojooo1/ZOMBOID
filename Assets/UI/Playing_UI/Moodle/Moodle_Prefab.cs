using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moodle_Prefab : MonoBehaviour
{
    Moodles_private_code type;
    int step;
    int index;
    [SerializeField] UnityEngine.UI.Image Back;
    [SerializeField] UnityEngine.UI.Image Icon;

    Animator anim;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
    }

    public void SetMoodle(Moodles_private_code Moodletype, int Moodlestep, Sprite Back_Image, Sprite Moodle_Image)
    {
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

    public int GetStep() { return step; }

    public void SetAnim()
    {
        anim.SetTrigger("Change");
    }
}
