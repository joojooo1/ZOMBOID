using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Title_Characteristic_prefab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] UnityEngine.UI.Image image;
    public Characteristic Prefab = null;


    public void SetCharacteristic(Characteristic _Prefab)
    {
        Prefab = _Prefab;
        image.sprite = _Prefab.Sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            UI_Title_Characteristic_text.Characteristic_text.Open_text(Prefab.name_kr, Prefab.Explanation_for_Characteristic_kr, Prefab.Points);
        }
        else
        {
            UI_Title_Characteristic_text.Characteristic_text.Open_text(Prefab.name, Prefab.Explanation_for_Characteristic, Prefab.Points);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Title_Characteristic_text.Characteristic_text.Close_text();
    }

    float clickTime = 0;

    void OnMouseDoubleClick()
    {
        if(Prefab.Choice == false)  // characteristics_list -> characteristics_Player
        {
            Prefab.Choice = true;
            for(int i = 0; i < Player_Characteristic.current.characteristics_list.Count; i++)
            {
                if (Player_Characteristic.current.characteristics_list[i].Prefab.Characteristic_number == Prefab.Characteristic_number)
                {
                    UI_Title.ui_title.Set_TotalPoint_text(Prefab.Points);

                    GameObject tempObj = null;
                    Player_Characteristic.current.Set_Characteristic(Prefab.Characteristic_number, Prefab.Choice, tempObj);
                    Player_Characteristic.current.Remove_Selected_list(Prefab.Characteristic_number, false);

                    switch (Prefab.Characteristic_number)
                    {
                        case 0:
                            Player_Characteristic.current.Remove_Selected_list(21, false);
                            break;
                        case 21:
                            Player_Characteristic.current.Remove_Selected_list(0, false);
                            break;
                        case 3:
                            Player_Characteristic.current.Remove_Selected_list(24, false);
                            Player_Characteristic.current.Remove_Selected_list(44, false);
                            break;
                        case 24:
                            Player_Characteristic.current.Remove_Selected_list(3, false);
                            Player_Characteristic.current.Remove_Selected_list(44, false);
                            break;
                        case 44:
                            Player_Characteristic.current.Remove_Selected_list(3, false);
                            Player_Characteristic.current.Remove_Selected_list(24, false);
                            break;
                        case 4:
                            Player_Characteristic.current.Remove_Selected_list(32, false);
                            break;
                        case 32:
                            Player_Characteristic.current.Remove_Selected_list(4, false);
                            break;
                        case 5:
                            Player_Characteristic.current.Remove_Selected_list(26, false);
                            break;
                        case 26:
                            Player_Characteristic.current.Remove_Selected_list(5, false);
                            break;
                        case 6:
                            Player_Characteristic.current.Remove_Selected_list(33, false);
                            break;
                        case 33:
                            Player_Characteristic.current.Remove_Selected_list(6, false);
                            break;
                        case 7:
                            Player_Characteristic.current.Remove_Selected_list(29, false);
                            break;
                        case 29:
                            Player_Characteristic.current.Remove_Selected_list(7, false);
                            break;
                        case 8:
                            Player_Characteristic.current.Remove_Selected_list(22, false);
                            Player_Characteristic.current.Remove_Selected_list(28, false);
                            Player_Characteristic.current.Remove_Selected_list(30, false);
                            break;
                        case 18:
                            Player_Characteristic.current.Remove_Selected_list(22, false);
                            Player_Characteristic.current.Remove_Selected_list(28, false);
                            Player_Characteristic.current.Remove_Selected_list(30, false);
                            break;
                        case 22:
                            Player_Characteristic.current.Remove_Selected_list(8, false);
                            Player_Characteristic.current.Remove_Selected_list(18, false);
                            Player_Characteristic.current.Remove_Selected_list(28, false);
                            Player_Characteristic.current.Remove_Selected_list(30, false);
                            break;
                        case 28:
                            Player_Characteristic.current.Remove_Selected_list(8, false);
                            Player_Characteristic.current.Remove_Selected_list(18, false);
                            Player_Characteristic.current.Remove_Selected_list(22, false);
                            Player_Characteristic.current.Remove_Selected_list(30, false);
                            break;
                        case 30:
                            Player_Characteristic.current.Remove_Selected_list(8, false);
                            Player_Characteristic.current.Remove_Selected_list(18, false);
                            Player_Characteristic.current.Remove_Selected_list(22, false);
                            Player_Characteristic.current.Remove_Selected_list(28, false);
                            break;
                        case 9:
                            Player_Characteristic.current.Remove_Selected_list(23, false);
                            break;
                        case 23:
                            Player_Characteristic.current.Remove_Selected_list(9, false);
                            break;
                        case 11:
                            Player_Characteristic.current.Remove_Selected_list(38, false);
                            break;
                        case 38:
                            Player_Characteristic.current.Remove_Selected_list(11, false);
                            break;
                        case 12:
                            Player_Characteristic.current.Remove_Selected_list(25, false);
                            break;
                        case 25:
                            Player_Characteristic.current.Remove_Selected_list(12, false);
                            break;
                        case 13:
                            Player_Characteristic.current.Remove_Selected_list(39, false);
                            break;
                        case 39:
                            Player_Characteristic.current.Remove_Selected_list(13, false);
                            break;
                        case 14:
                            Player_Characteristic.current.Remove_Selected_list(31, false);
                            Player_Characteristic.current.Remove_Selected_list(51, false);
                            break;
                        case 31:
                            Player_Characteristic.current.Remove_Selected_list(14, false);
                            Player_Characteristic.current.Remove_Selected_list(51, false);
                            break;
                        case 51:
                            Player_Characteristic.current.Remove_Selected_list(14, false);
                            Player_Characteristic.current.Remove_Selected_list(31, false);
                            break;
                        case 16:
                            Player_Characteristic.current.Remove_Selected_list(40, false);
                            break;
                        case 40:
                            Player_Characteristic.current.Remove_Selected_list(16, false);
                            break;
                        case 17:
                            Player_Characteristic.current.Remove_Selected_list(45, false);
                            break;
                        case 45:
                            Player_Characteristic.current.Remove_Selected_list(17, false);
                            break;
                        case 46:
                            Player_Characteristic.current.Remove_Selected_list(37, false);
                            Player_Characteristic.current.Remove_Selected_list(43, false);
                            Player_Characteristic.current.Remove_Selected_list(48, false);
                            break;
                        case 37:
                            Player_Characteristic.current.Remove_Selected_list(46, false);
                            Player_Characteristic.current.Remove_Selected_list(43, false);
                            Player_Characteristic.current.Remove_Selected_list(48, false);
                            break;
                        case 43:
                            Player_Characteristic.current.Remove_Selected_list(46, false);
                            Player_Characteristic.current.Remove_Selected_list(37, false);
                            Player_Characteristic.current.Remove_Selected_list(48, false);
                            break;
                        case 48:
                            Player_Characteristic.current.Remove_Selected_list(46, false);
                            Player_Characteristic.current.Remove_Selected_list(37, false);
                            Player_Characteristic.current.Remove_Selected_list(43, false);
                            break;
                        case 50:
                            Player_Characteristic.current.Remove_Selected_list(42, false);
                            Player_Characteristic.current.Remove_Selected_list(15, false);
                            Player_Characteristic.current.Remove_Selected_list(20, false);
                            UI_Title.ui_title.Add_value_list("Strength", "근력", -4, 0, Player_Job.None, Characteristic_Value_type.Strength);
                            break;
                        case 42:
                            Player_Characteristic.current.Remove_Selected_list(50, false);
                            Player_Characteristic.current.Remove_Selected_list(15, false);
                            Player_Characteristic.current.Remove_Selected_list(20, false);
                            UI_Title.ui_title.Add_value_list("Strength", "근력", -3, 0, Player_Job.None, Characteristic_Value_type.Strength);
                            break;
                        case 15:
                            Player_Characteristic.current.Remove_Selected_list(50, false);
                            Player_Characteristic.current.Remove_Selected_list(42, false);
                            Player_Characteristic.current.Remove_Selected_list(20, false);
                            UI_Title.ui_title.Add_value_list("Strength", "근력", 1, 0, Player_Job.None, Characteristic_Value_type.Strength);
                            break;
                        case 20:
                            Player_Characteristic.current.Remove_Selected_list(50, false);
                            Player_Characteristic.current.Remove_Selected_list(42, false);
                            Player_Characteristic.current.Remove_Selected_list(15, false);
                            UI_Title.ui_title.Add_value_list("Strength", "근력", 4, 0, Player_Job.None, Characteristic_Value_type.Strength);
                            break;
                        case 47:
                            Player_Characteristic.current.Remove_Selected_list(36, false);
                            Player_Characteristic.current.Remove_Selected_list(10, false);
                            Player_Characteristic.current.Remove_Selected_list(19, false);
                            UI_Title.ui_title.Add_value_list("Fitness", "체력", -4, 0, Player_Job.None, Characteristic_Value_type.Fitness);
                            break;
                        case 36:
                            Player_Characteristic.current.Remove_Selected_list(47, false);
                            Player_Characteristic.current.Remove_Selected_list(10, false);
                            Player_Characteristic.current.Remove_Selected_list(19, false);
                            UI_Title.ui_title.Add_value_list("Fitness", "체력", -3, 0, Player_Job.None, Characteristic_Value_type.Fitness);
                            break;
                        case 10:
                            Player_Characteristic.current.Remove_Selected_list(47, false);
                            Player_Characteristic.current.Remove_Selected_list(36, false);
                            Player_Characteristic.current.Remove_Selected_list(19, false);
                            UI_Title.ui_title.Add_value_list("Fitness", "체력", 2, 0, Player_Job.None, Characteristic_Value_type.Fitness);
                            break;
                        case 19:
                            Player_Characteristic.current.Remove_Selected_list(47, false);
                            Player_Characteristic.current.Remove_Selected_list(36, false);
                            Player_Characteristic.current.Remove_Selected_list(10, false);
                            UI_Title.ui_title.Add_value_list("Fitness", "체력", 4, 0, Player_Job.None, Characteristic_Value_type.Fitness);
                            break;
                        default: break;
                    }

                }
            }
            
        }
        else  // characteristics_Player -> characteristics_list
        {
            Prefab.Choice = false;
            for (int i = 0; i < Player_Characteristic.current.characteristics_Player.Count; i++)
            {
                if (Player_Characteristic.current.characteristics_Player[i].Prefab.Characteristic_number == Prefab.Characteristic_number)
                {
                    UI_Title.ui_title.Set_TotalPoint_text(-Prefab.Points);

                    GameObject tempObj = null;
                    Player_Characteristic.current.Set_Characteristic(Prefab.Characteristic_number, Prefab.Choice, tempObj);
                    Player_Characteristic.current.Remove_Selected_list(Prefab.Characteristic_number, true);

                    GameObject Obj = null;
                    switch (Prefab.Characteristic_number)
                    {
                        case 0:
                            Player_Characteristic.current.Set_Characteristic(21, false, Obj);
                            break;
                        case 21:
                            Player_Characteristic.current.Set_Characteristic(0, false, Obj);
                            break;
                        case 3:
                            Player_Characteristic.current.Set_Characteristic(24, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(44, false, Obj);
                            break;
                        case 24:
                            Player_Characteristic.current.Set_Characteristic(3, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(44, false, Obj);
                            break;
                        case 44:
                            Player_Characteristic.current.Set_Characteristic(3, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(24, false, Obj);
                            break;
                        case 4:
                            Player_Characteristic.current.Set_Characteristic(32, false, Obj);
                            break;
                        case 32:
                            Player_Characteristic.current.Set_Characteristic(4, false, Obj);
                            break;
                        case 5:
                            Player_Characteristic.current.Set_Characteristic(26, false, Obj);
                            break;
                        case 26:
                            Player_Characteristic.current.Set_Characteristic(5, false, Obj);
                            break;
                        case 6:
                            Player_Characteristic.current.Set_Characteristic(33, false, Obj);
                            break;
                        case 33:
                            Player_Characteristic.current.Set_Characteristic(6, false, Obj);
                            break;
                        case 7:
                            Player_Characteristic.current.Set_Characteristic(29, false, Obj);
                            break;
                        case 29:
                            Player_Characteristic.current.Set_Characteristic(7, false, Obj);
                            break;
                        case 8:
                            Player_Characteristic.current.Set_Characteristic_in_list(22, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(28, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(30, false, Obj);
                            break;
                        case 18:
                            Player_Characteristic.current.Set_Characteristic_in_list(22, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(28, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(30, false, Obj);
                            break;
                        case 22:
                            Player_Characteristic.current.Set_Characteristic_in_list(8, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(18, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(28, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(30, false, Obj);
                            break;
                        case 28:
                            Player_Characteristic.current.Set_Characteristic_in_list(8, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(18, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(22, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(30, false, Obj);
                            break;
                        case 30:
                            Player_Characteristic.current.Set_Characteristic_in_list(8, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(18, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(22, false, Obj);
                            Player_Characteristic.current.Set_Characteristic_in_list(28, false, Obj);
                            break;
                        case 9:
                            Player_Characteristic.current.Set_Characteristic(23, false, Obj);
                            break;
                        case 23:
                            Player_Characteristic.current.Set_Characteristic(9, false, Obj);
                            break;
                        case 11:
                            Player_Characteristic.current.Set_Characteristic(38, false, Obj);
                            break;
                        case 38:
                            Player_Characteristic.current.Set_Characteristic(11, false, Obj);
                            break;
                        case 12:
                            Player_Characteristic.current.Set_Characteristic(25, false, Obj);
                            break;
                        case 25:
                            Player_Characteristic.current.Set_Characteristic(12, false, Obj);
                            break;
                        case 13:
                            Player_Characteristic.current.Set_Characteristic(39, false, Obj);
                            break;
                        case 39:
                            Player_Characteristic.current.Set_Characteristic(13, false, Obj);
                            break;
                        case 14:
                            Player_Characteristic.current.Set_Characteristic(31, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(51, false, Obj);
                            break;
                        case 31:
                            Player_Characteristic.current.Set_Characteristic(14, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(51, false, Obj);
                            break;
                        case 51:
                            Player_Characteristic.current.Set_Characteristic(14, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(31, false, Obj);
                            break;
                        case 16:
                            Player_Characteristic.current.Set_Characteristic(40, false, Obj);
                            break;
                        case 40:
                            Player_Characteristic.current.Set_Characteristic(16, false, Obj);
                            break;
                        case 17:
                            Player_Characteristic.current.Set_Characteristic(45, false, Obj);
                            break;
                        case 45:
                            Player_Characteristic.current.Set_Characteristic(17, false, Obj);
                            break;
                        case 46:
                            Player_Characteristic.current.Set_Characteristic(37, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(43, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(48, false, Obj);
                            break;
                        case 37:
                            Player_Characteristic.current.Set_Characteristic(46, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(43, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(48, false, Obj);
                            break;
                        case 43:
                            Player_Characteristic.current.Set_Characteristic(46, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(37, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(48, false, Obj);
                            break;
                        case 48:
                            Player_Characteristic.current.Set_Characteristic(46, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(37, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(43, false, Obj);
                            break;
                        case 50:
                            Player_Characteristic.current.Set_Characteristic(42, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(15, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(20, false, Obj);
                            UI_Title.ui_title.Add_value_list("Strength", "근력", 4, 0, Player_Job.None, Characteristic_Value_type.Strength);
                            break;
                        case 42:
                            Player_Characteristic.current.Set_Characteristic(50, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(15, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(20, false, Obj);
                            UI_Title.ui_title.Add_value_list("Strength", "근력", 3, 0, Player_Job.None, Characteristic_Value_type.Strength);
                            break;
                        case 15:
                            Player_Characteristic.current.Set_Characteristic(50, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(42, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(20, false, Obj);
                            UI_Title.ui_title.Add_value_list("Strength", "근력", -1, 0, Player_Job.None, Characteristic_Value_type.Strength);
                            break;
                        case 20:
                            Player_Characteristic.current.Set_Characteristic(50, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(42, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(15, false, Obj);
                            UI_Title.ui_title.Add_value_list("Strength", "근력", -4, 0, Player_Job.None, Characteristic_Value_type.Strength);
                            break;
                        case 47:
                            Player_Characteristic.current.Set_Characteristic(36, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(10, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(19, false, Obj);
                            UI_Title.ui_title.Add_value_list("Fitness", "체력", +4, 0, Player_Job.None, Characteristic_Value_type.Fitness);
                            break;
                        case 36:
                            Player_Characteristic.current.Set_Characteristic(47, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(10, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(19, false, Obj);
                            UI_Title.ui_title.Add_value_list("Fitness", "체력", +3, 0, Player_Job.None, Characteristic_Value_type.Fitness);
                            break;
                        case 10:
                            Player_Characteristic.current.Set_Characteristic(47, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(36, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(19, false, Obj);
                            UI_Title.ui_title.Add_value_list("Fitness", "체력", -2, 0, Player_Job.None, Characteristic_Value_type.Fitness);
                            break;
                        case 19:
                            Player_Characteristic.current.Set_Characteristic(47, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(36, false, Obj);
                            Player_Characteristic.current.Set_Characteristic(10, false, Obj);
                            UI_Title.ui_title.Add_value_list("Fitness", "체력", -4, 0, Player_Job.None, Characteristic_Value_type.Fitness);
                            break;
                        default: break;
                    }


                }
            }


        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((Time.time - clickTime) < 0.3f)
        {
            OnMouseDoubleClick();
            clickTime = -1;
        }
        else
        {
            clickTime = Time.time;
        }
    }

}



/*
 0 <-> 21
 3 <-> 24, 44
 4 <-> 32
 5 <-> 26
 6 <-> 33
 7 <-> 29
 8 <-> 22, 28, 30
 9 <-> 23
 11 <-> 38
 12 <-> 25
 13 <-> 39
 14 <-> 31, 51
 16 <-> 40
 17 <-> 45
 18 <-> 22, 28, 30




 */