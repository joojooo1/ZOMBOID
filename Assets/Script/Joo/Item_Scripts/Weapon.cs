using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Weapon : MonoBehaviour
{
    public Item_Weapons WeaponData;
    public Item_Weapons weaponData { set {  WeaponData = value; } }

    public void Weapon_Change()
    {
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = WeaponData.ItemImage;
        Player_main.player_main.Set_Attack_Power_for_Equipping_Weapons(WeaponData);

    }

}
