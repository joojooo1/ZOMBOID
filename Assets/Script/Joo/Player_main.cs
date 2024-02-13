using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_main : MonoBehaviour
{
    PlayerInventory inven;
    PlayerSkill Skill;

    float fatigue; // ÇÇ·Îµµ


    // Start is called before the first frame update
    void Start()
    {
        inven.MaxWeightChange_forStrength(Skill.Fitness_Level.Get_P_Level());
    }

    float Playermovement_speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        Vector3 pos = transform.position;
        pos += input * Time.deltaTime * Playermovement_speed;

        transform.position = pos;
    }
}
