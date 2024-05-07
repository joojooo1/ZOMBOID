using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Playing_job
{
    public string Job_name;
    public string Job_name_kr;
    public string Explanation_for_Characteristic;
    public string Explanation_for_Characteristic_kr;
    public int index;
    public Sprite image;
}

public class UI_State : MonoBehaviour, IPointerClickHandler
{
    public UI_State_Skill ui_state_skill;

    public GameObject UI_window;
    public Sprite[] UI_window_Image;
    public UnityEngine.UI.Image Image;

    public Sprite[] gender_Image;
    public UnityEngine.UI.Image player_gender_Image;

    public Sprite[] player_damage_SpriteArray;

    [SerializeField] GameObject icon_prefab;
    [SerializeField] GameObject[] icon_position;

    public GameObject TreatmentBar;

    public List<UI_State_detailwindow> Damagelist = new List<UI_State_detailwindow>();

    public Playing_job playing_job = new Playing_job();

    private void Start()
    {
        if (UI_window.activeSelf) { Image.sprite = UI_window_Image[1]; }
        else { Image.sprite = UI_window_Image[0]; }

        if (UI_main.ui_main.Is_Female) { player_gender_Image.sprite = gender_Image[1]; }
        else { player_gender_Image.sprite = gender_Image[0]; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UI_window.activeSelf)
        {
            UI_window.SetActive(false);
            Image.sprite = UI_window_Image[0];
        }
        else
        {
            UI_window.SetActive(true);
            Image.sprite = UI_window_Image[1];
            UI_window.transform.SetAsLastSibling();
        }
    }

    public void icon_Ins(Damage_Pattern damagetype, body_point position)
    {
        for(int i = 0; i < icon_position.Length; i++)
        {
            if(i == (int)position)
            {
                if (icon_position[i].activeSelf == false)
                    icon_position[i].SetActive(true);
                else
                    break;
            }
        }

        GameObject tempObj = null;

        for(int i = 0; i < Player_main.player_main.playerState.Player_body_point[(int)position].Body_Damage_array.Length; i++)
        {
            if (Player_main.player_main.playerState.Player_body_point[(int)position].Body_Damage_array[i] == null)
            {
                tempObj = Instantiate(icon_prefab, icon_position[(int)position].transform);
                UI_State_detailwindow temp = tempObj.GetComponent<UI_State_detailwindow>();
                Player_main.player_main.playerState.Player_body_point[(int)position].Set_DamageArray(i, true, damagetype, position);
                temp.SetImage(player_damage_SpriteArray[(int)damagetype], position, damagetype);
                UI_DamageImage.UI_Damage_Pre.Damage_Ins(position, temp.position_Damage_Num);
                Damagelist.Add(temp);
                break;
            }
        }


        //if(Damagelist.Count == 1)
        //{
        //    UI_main.ui_main.UI_Damage.SetActive(true);
        //    UI_main.ui_main.Set_UIDamage();
        //}
    }

    public void icon_Destroy(body_point position, Damage_Pattern Attack_Pattern, int Damage_Num)
    {
        for(int k = 0; k < Damagelist.Count; k++)
        {
            if (Damagelist[k].position_Damage_Num == Damage_Num && Damagelist[k].body_position == position)
            {
                Player_main.player_main.playerState.Player_body_point[(int)position].Set_DamageArray(k, false, Attack_Pattern, position);

                int j = 0;
                for (int i = 0; i < Damagelist.Count; i++)
                {
                    if (Damagelist[i].body_position == position)
                    {
                        Damagelist[i].position_Damage_Num = j;
                        j++;
                    }
                }

                UI_DamageImage.UI_Damage_Pre.Damage_Change(position);
                Destroy(Damagelist[k].gameObject);
                Damagelist.RemoveAt(k);

                if (Damagelist.Count == 0)
                {
                    UI_main.ui_main.UI_Damage.SetActive(false);
                }
            }
        }


        for (int k = 0; k < Damagelist.Count; k++)
        {
            if (Damagelist[k].body_position == position)
                break;
            else
            {
                if(k == Damagelist.Count - 1)
                {
                    for (int i = 0; i < icon_position.Length; i++)
                    {
                        if (i == (int)position)
                        {
                            if (icon_position[i].activeSelf == true)
                                icon_position[i].SetActive(false);
                            else
                                break;
                        }
                    }
                }
            }
            
        }



    }
}

