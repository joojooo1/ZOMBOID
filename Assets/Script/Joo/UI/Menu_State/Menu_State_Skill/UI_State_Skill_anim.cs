using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_State_Skill_anim : MonoBehaviour
{
    Animator anim;
    public int index_anim;
    public int step;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
    }

    public void OnSpeed()
    {
        switch (step)
        {
            case 0:
                anim.SetFloat("MoveSpeed", 0f);
                break;
            case 1:
                anim.SetFloat("MoveSpeed", 0.2f);
                break;
            case 2:
                anim.SetFloat("MoveSpeed", 0.6f);
                break;
            case 3:
                anim.SetFloat("MoveSpeed", 1f);
                break;
        }
        
    }
}
