using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_inventory : MonoBehaviour, IPointerClickHandler
{
    // inventory_icon�� ��ȣ�ۿ�
    public static UI_inventory Inventory_UI_main;

    public GameObject UI_window;  // ������ �κ��丮
    public GameObject Storage_Object;
    public Sprite[] UI_window_Image;  // �κ��丮 ���� ��ư �̹���(On, Off)
    public UnityEngine.UI.Image Image;  // �κ��丮 ���� ��ư �̹���(�������)

    void Start()
    {
        Inventory_UI_main = this;
        if (Inventory_Player_Shown.InvPS.inven_open) { Image.sprite = UI_window_Image[1]; }
        else { Image.sprite = UI_window_Image[0]; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Inventory_Player_Shown.InvPS.inven_open)
        {
            Image.sprite = UI_window_Image[0];
            Inventory_Player_Shown.InvPS.SetAnim(false);
        }
        else
        {
            Inventory_Player_Shown.InvPS.SetAnim(true);
            Image.sprite = UI_window_Image[1];
        }
    }
}
