using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class zom_anime : MonoBehaviour
{
    public GameObject zomnav;
    public Animator animator;
    public NavMeshAgent nav;
    public zom_pos zompos;
    public zom_targetpos zomtarget;
    public GameObject asd;
    public bool fence= false;
    public zombieHp HP;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        Transform parentTransform = transform.parent;
        nav = zomnav.GetComponent<NavMeshAgent>();
        zompos = zomnav.GetComponent<zom_pos>();
        zomtarget = asd.GetComponent<zom_targetpos>();
        HP = parentTransform.GetComponent<zombieHp>();
        if (nav == null)
        {
            nav = zomnav.GetComponent<NavMeshAgent>();
        }
        if (zompos == null)
        {
            zompos = zomnav.GetComponent <zom_pos>();
        }
        if(zomtarget == null)
        {
            zomtarget = asd.GetComponent<zom_targetpos>();
        }
        //transform.SetParent(zomnav.transform, false);
        curretspeed = nav.speed;


    }
    public GameObject z;
    // Update is called once per frame
    void Update()
    {
        if (!nav.isOnOffMeshLink)
        {
            transform.localRotation = zomnav.transform.rotation;
        }
        else
        {
            animatorsetBool("backdown", true);
            fence = true;
            nav.speed = 0.5f;
        }


        if (nav.velocity != Vector3.zero)
        {
            

            if (zompos.target != null&&!fence)
            {
                animatorsetBool("run", true);
            }
            else
                animatorsetBool("walk", true);
        }
        else 
        {
            animatorsetBool("run", false);
            animatorsetBool("walk", false);
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == zompos.target && !atking)
        {
            animatorsetBool("Playeratk",true);
        }
    }
    void idleposset()
    {
        //zomtarget.idlepos();
    }
    public void animatorsetBool(string ANIMA_NAME, bool set)
    {
        animator.SetBool(ANIMA_NAME, set);
    }
    public void animatersetTrigger(string ANIMA_NAME)
    {
        animator.SetTrigger(ANIMA_NAME);
    }
    public void animatorsetFloat(string ANIMA_NAME, float set)
    {
        animator.SetFloat(ANIMA_NAME, set);
    }
    public float curretspeed;
    void fenceup()
    {
        if (fence)
        {
            animatorsetBool("up", true);
        }
    }
    void up_off()
    {
        live();
        if (!zomtarget.live)
        {
            Debug.Log("죽음");
            zompos.respawn_set();
        }
        SET();
    }
    public bool atking = false;
    void zom_atk_end()//좀비의 다시 공격하기위한 작업zzzzzzz
    {
        Debug.Log("공격완료");
        //zomnav.GetComponent<NavMeshAgent>().enabled = true;
        animator.SetBool("playeratk", false);
        zom_speed_set();
        atking = false;
    }
    void zom_atk_try()//좀비의 공격 성공여부(공격 성공여부 판단시 좀비와의 거리가 1이하이면 공격이 성공한다.)zzzzzz
    {
        Debug.Log("공격 시도중");
        zom_speed_zero();
        atking = true;
    }
    void zom_speed_set()
    {
        zomnav.GetComponent<zom_pos>().zomatkend();
    }
    void zom_speed_zero()
    {
        zomnav.GetComponent<NavMeshAgent>().speed = 0;
    }
    void live()
    {
        Debug.Log("생존 판단");
        if(HP.curret_zombie_hp <= 0)
        {
            zomtarget.live = false;
        }
        else
        {
            animatorsetBool("up", true);
        }
    }
    void downanime()
    {
        HP.up_down();
    }

    void SET()
    {
        fence = false;
        nav.speed = curretspeed;
        animatorsetBool("backdown", false);
        animatorsetBool("up", false);
    }
}
