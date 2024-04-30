using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_State_Skill_anim : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnSpeed(int step)
    {
        switch (step)
        {
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
