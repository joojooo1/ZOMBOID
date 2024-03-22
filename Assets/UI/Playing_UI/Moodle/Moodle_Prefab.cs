using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moodle_Prefab : MonoBehaviour
{
    public Moodles_private_code type;
    public int index;
    UnityEngine.UI.Image Back;
    UnityEngine.UI.Image Icon;

    public void SetMoodle(Moodles_private_code Moodletype, int MoodleNum, Sprite Back_Image, Sprite Moodle_Image)
    {
        type = Moodletype;
        index = MoodleNum;
        Back.sprite = Back_Image;
        Icon.sprite = Moodle_Image;
    }




}
