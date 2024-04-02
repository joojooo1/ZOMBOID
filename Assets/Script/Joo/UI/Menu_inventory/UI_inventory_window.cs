using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_inventory_window : MonoBehaviour
{

    public static UI_inventory_window inven_detail_Window;

    Animator Anim;
    public bool inven_detail_open;
    public bool Pin_fixed;

    private void Awake()
    {
        inven_detail_Window = this;
        Anim = GetComponent<Animator>();
        inven_detail_open = false;
    }

    public void SetAnim(bool open)
    {
        inven_detail_open = open;
        Anim.SetBool("Open", inven_detail_open);
    }

}
