using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moodle_Prefab : MonoBehaviour
{
    Moodles_private_code type;
    UnityEngine.UI.Image Back;
    UnityEngine.UI.Image Icon;

    public void SetMoodle(Moodles_private_code Moodletype, Sprite Back_Image, Sprite Moodle_Image)
    {
        type = Moodletype;
        Back.sprite = Back_Image;
        Icon.sprite = Moodle_Image;
    }




}
