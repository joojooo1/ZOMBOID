using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UI_State : MonoBehaviour, IPointerClickHandler
{
    public GameObject UI_window;
    public Sprite[] UI_window_Image;
    public UnityEngine.UI.Image Image;

    public Sprite[] gender_Image;
    public UnityEngine.UI.Image player_gender_Image;

    public Sprite[] player_damage_SpriteArray;
    public Sprite[] player_damage_Back_SpriteArray;

    [SerializeField] GameObject icon_prefab;
    [SerializeField] GameObject[] icon_position;

    public GameObject TreatmentBar;

    public List<UI_State_detailwindow> Damagelist = new List<UI_State_detailwindow>();
    public body_point Current_body_position = body_point.None;
    public int Current_Damage_index = -1;

    public UnityEngine.UI.Text job_text;
    public UnityEngine.UI.Image job_image;

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
                temp.SetImage(player_damage_SpriteArray[(int)damagetype], position, damagetype, i);
                UI_DamageImage.UI_Damage_Pre.Damage_Ins(position, Player_main.player_main.playerState.Player_body_point[(int)position].Get_DamageCount());
                Damagelist.Add(temp);
                break;
            }
        }

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

    public void Choice_Damage(body_point position, int index)  // 상태창의 상처프리팹 위에 마우스 대면 호출됨
    {
        Current_body_position = position;
        Current_Damage_index = index;
    }

    public void Use_Medical_item(Medical_Type type, int item_ID)
    {
        for (int k = 0; k < Damagelist.Count; k++)
        {
            if (Damagelist[k].position_Damage_Num == Current_Damage_index && Damagelist[k].body_position == Current_body_position)
            {
                if(type == Medical_Type.Bandage)
                {
                    Damagelist[k].Using_Bandage(item_ID);
                    break;
                }
                else
                {
                    Damagelist[k].Using_Medical_item(item_ID);
                    break;
                }

            }
        }
    }

    public void Set_Job(string _job_name, string _job_name_kr, Sprite _job_image)
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            job_text.text = _job_name_kr;
        }
        else
        {
            job_text.text = _job_name;
        }

        job_image.sprite = _job_image;
    }

    public void Reset_Job()
    {
        job_text.text = "";
        job_image.sprite = null;

    }
}

