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
