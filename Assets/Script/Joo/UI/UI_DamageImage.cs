using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UI_DamageImage : MonoBehaviour
{
    public static UI_DamageImage UI_Damage_Pre;

    public Sprite[] Male_Image;
    public Sprite[] Female_Image;

    [SerializeField] GameObject Image_prefab;
    [SerializeField] Transform Pre_ins;

    private void OnEnable()
    {
        UI_Damage_Pre = this;
        //UI_main.ui_main.Set_UI_gender_Image();
    }

    List<UI_DamagePref> DamageImagelist = new List<UI_DamagePref>();

    public void Damage_Ins(body_point position, int totalCount)
    {
        GameObject tempObj = null;
        int point = 0;
        if (position == 0)
        {
            point = (int)position;
        }
        else
        {
            point = (int)position * 4;
        }
        

        tempObj = Instantiate(Image_prefab, Pre_ins);
        UI_DamagePref temp = tempObj.GetComponent<UI_DamagePref>();
        temp.body_Point = position;
        temp.startNum = point;
        temp.current_step = totalCount;
        if (UI_main.ui_main.Is_Female)
        {
            temp.Image.sprite = Female_Image[point + (totalCount - 1)];
        }
        else
        {
            temp.Image.sprite = Male_Image[point + (totalCount - 1)];
        }

        DamageImagelist.Add(temp);
    }

    public void Damage_Change(body_point position)
    {
        for (int k = 0; k < DamageImagelist.Count; k++)
        {
            if(DamageImagelist[k].body_Point == position)
            {
                if (Player_main.player_main.playerState.Player_body_point[(int)position].Get_DamageCount() == 0)
                {
                    Destroy(DamageImagelist[k].gameObject);
                    DamageImagelist.RemoveAt(k);
                }
                else
                {
                    if (Player_main.player_main.playerState.Player_body_point[(int)position].Get_Is_Bleeding() == false)
                        DamageImagelist[k].ChangeColor_recovery(position);
                    else
                        DamageImagelist[k].ChangeColor(position, Player_main.player_main.playerState.Player_body_point[(int)position].Get_DamageCount());

                }

            }

        }
    }

}
