using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_inventory_Equip : MonoBehaviour
{
    public static UI_inventory_Equip inven_Equip_Window;

    Animator Anim;
    public bool inven_Equip_open;
    public bool Pin_fixed;

    private void Awake()
    {
        inven_Equip_Window = this;
        Anim = GetComponent<Animator>();
        inven_Equip_open = false;
    }

    public void SetAnim(bool open)
    {
        inven_Equip_open = open;
        Anim.SetBool("Open", inven_Equip_open);
    }
}
