using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_item_controller : MonoBehaviour
{
    public GameObject[] Hat;
    public GameObject[] Glasses;
    public GameObject[] Mask;
    public GameObject[] jacket;
    public GameObject[] T_shirt;
    public GameObject[] shirt;
    public GameObject[] underwear;
    public GameObject[] Vest;
    public GameObject Watch;
    public GameObject[] Gloves;
    public GameObject[] Shoes;
    public GameObject[] Bottoms;
    public GameObject[] protectiveGear;
    public GameObject Cargo_pocket;
    public GameObject MiniBag_forward;
    public GameObject MiniBag_back;
    public GameObject[] Back_back;
    public GameObject[] Backpack_weapon; // 배낭o 보조무기
    public GameObject[] Back_weapon; // 배낭x 보조무기
    public GameObject[] current_weapon; // 현재 착용무기
    public GameObject current_weapons_pos; //현재 착용무기 위치 관리 오브젝트
    public GameObject[] current_weapon_parent; //allgirls : 0 // milltary_all
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool Back_Pack_on = false;
    public void Sub_Weapon(int a , bool set)
    {
        for (int i = 0; i < Back_back.Length; i++)
        {
            if(Back_back[i].activeSelf)
            {
                Back_Pack_on = true;
                break;
            }
        }
        if (Back_Pack_on)
        {
            Backpack_weapon[a].SetActive(set);
        }
        else
        {
            Back_weapon[a].SetActive(set);
        }
    }
    bool Current_weapon_pos = false;
    public void Current_Weapon(int a , bool set)
    {
       
        if (current_weapon_parent[1].activeSelf)
        {
            Current_weapon_pos = true;
        }
        
        if (Current_weapon_pos)
        {
            current_weapons_pos.transform.SetParent(current_weapon_parent[1].transform);
        }
        else
        {
            current_weapons_pos.transform.SetParent(current_weapon_parent[0].transform);
        }
        
        current_weapon[a].SetActive(set);
    }
}
