using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DamagePref : MonoBehaviour
{
    public body_point body_Point;
    public int startNum;
    public int current_step;
    public UnityEngine.UI.Image Image;

    public void ChangeColor(body_point position, int totalCount)
    {
        current_step = totalCount;
        if(current_step > 3)
            current_step = 3;

        if (UI_main.ui_main.Is_Female)
        {
            Image.sprite = UI_DamageImage.UI_Damage_Pre.Female_Image[startNum + (current_step - 1)];
        }
        else
        {
            Image.sprite = UI_DamageImage.UI_Damage_Pre.Male_Image[startNum + (current_step - 1)];

        }

    }

    public void ChangeColor_recovery(body_point position)
    {
        if (UI_main.ui_main.Is_Female)
        {
            Image.sprite = UI_DamageImage.UI_Damage_Pre.Female_Image[startNum + 3];
        }
        else
        {
            Image.sprite = UI_DamageImage.UI_Damage_Pre.Male_Image[startNum + 3];

        }
    }


}
