using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Player_State : MonoBehaviour
{
    public static UI_Player_State UI_P_state_sprite;

    public Sprite[] player_state_SpriteArray;

    private void Start()
    {
        UI_P_state_sprite = this;
    }
    private void Update()
    {
        
    }
}

/*
 [0] scratch
 [1] bandage
 [2] bandagedirty
 [3] bite
 [4] burn
 [5] fracture
 [6] stitches
 ------------------
 [7] infection
 [8] deepwound
 [9] glass
 [10] splint
 
 */