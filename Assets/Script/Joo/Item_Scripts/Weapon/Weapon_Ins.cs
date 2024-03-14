using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Ins : MonoBehaviour
{
    [SerializeField]
    private List<Item_Weapons> Weapons_Ins;
    [SerializeField]
    private GameObject Weapons_Prefab;

    private void Start()
    {
        //Equipping_Weapon(Weapons_Ins[27]);   // test
    }


    public void Equipping_Weapon(Item_Weapons weapon)  // UI에서 장비 착용 시 호출
    {
        Weapon Current_Weapon = Instan(weapon);
        Current_Weapon.Weapon_Change(weapon);
        if(weapon.WeaponType == Weapon_type.Gun)
        {
            Set_AMMO_Capacity(weapon);
        }
        weapon.Nesting_Depth = 1;
        Player_main.player_main.Is_Equipping_Weapons = true;
    }

    public Weapon Instan(Item_Weapons weapon)
    {
        Weapon newWeapon = Instantiate(Weapons_Prefab).GetComponent<Weapon>();
        newWeapon.weaponData = weapon;
        return newWeapon;
    }

    public void Set_AMMO_Capacity(Item_Weapons weapon)
    {
        switch(weapon.Gun_Magazine)
        {
            case Magazine_Type.M9_Magazine:
                weapon.Gun_Max_Capacity = 15;
                break;
            case Magazine_Type.M1911_Auto_Magazine:
                weapon.Gun_Max_Capacity = 7;
                break;
            case Magazine_Type.D_E_Magazine:
                weapon.Gun_Max_Capacity = 8;
                break;
            case Magazine_Type.MSR700_Magazine:
                weapon.Gun_Max_Capacity = 3;
                break;
            case Magazine_Type.MSR788_Magazine:
                weapon.Gun_Max_Capacity = 3;
                break;
            case Magazine_Type.M16_Magazine:
                weapon.Gun_Max_Capacity = 30;
                break;
            case Magazine_Type.M14_Magazine:
                weapon.Gun_Max_Capacity = 20;
                break;
            case Magazine_Type.None:
                break;
        }
    }

}
