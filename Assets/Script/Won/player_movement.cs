using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class player_movement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public float Playermovement_speed = 7;
    public float Playerturnspeed = 10;
    Vector3 playerpos;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //_main = gameObject.GetComponent<Player_main>();
    }
    Vector3 inputpos;
    // Update is called once per frame
    void FixedUpdate()
    {
        inputpos = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical")/2, 0f);
        inputpos.Normalize();
        playerpos = new Vector3(transform.position.x + (inputpos.x * Time.deltaTime * 3.5f), transform.position.y + (inputpos.y * Time.deltaTime * 3.5f), 0f);
        navMeshAgent.SetDestination
            (playerpos);
        
    }
    void playergoseverpos(Vector3 playergoseverpos)
    {
        //서버로 좌표 전송(서버스크립트).(플레이어 넘버)(playergoseverpos);
    }
    void playergetseverpos(Vector3 playergetseverpos)
    {
        //서버에서 좌표 받아 이동 navMeshAgent.SetDestination(playergetseverpos);
    }
}
