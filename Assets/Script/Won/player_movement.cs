using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.Services.Analytics.Internal;
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
    public GameObject[] playeraimeobject;
    public player_animation[] playeranime;
    Vector3 playerpos;
    Vector3 lastpos;
    string anima_name;
    public GameObject playerrot;


    private readonly float[] targetAngles = { -45f, 45f, 135f, -135f };
    // Start is called before the first frame update
    void Start()
    {
        for ( int i = 0; i<playeraimeobject.Length; i++)
        {
            playeranime[i] = playeraimeobject[i].GetComponent<player_animation>();
            Debug.Log(i);
        }
        Collider asd = GetComponent<Collider>();
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
        navMeshAgent.SetDestination(playerpos);
        if (!navMeshAgent.enabled)
        {
            if (UnityEngine.Input.GetAxisRaw("Horizontal") != 0 || UnityEngine.Input.GetAxisRaw("Vertical") != 0)
            {
                transform.position = new Vector3 (test.x-0.5f,test.y -1f,0);
                for (int i = 0; i < playeranime.Length; i++)
                {
                    if (playeraimeobject[i].activeSelf)
                    {
                        
                        playeranime[i].animatorsetBool(anima_name, false);

                        playeranime[i].animatorsetting(0.7f);
                    }
                }
                navMeshAgent.enabled = true;
            }
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.G))
        {
            for (int i = 0; i < playeranime.Length; i++)
            {
                if (!playeraimeobject[i].activeSelf)
                {

                    playeranime[i].animatorsetFloat("mobile_interaction", 1f);
                    playeranime[i].animatersetTrigger("don`t_move");
                }
            }
            float currentXRotation = playerrot.transform.rotation.eulerAngles.y;
            if (currentXRotation >= 180)
            {
                currentXRotation -= 360;
            }
            Debug.Log("playerrot" + currentXRotation);
            // 가장 가까운 목표 회전 각도 선택
            float closestAngle = targetAngles[0];
            float minDifference = Mathf.Abs(targetAngles[0] - currentXRotation);

            foreach (float angle in targetAngles)
            {
                float difference = Mathf.Abs(angle - currentXRotation);
                if (difference < minDifference)
                {
                    minDifference = difference;
                    closestAngle = angle;
                }
            }
            Debug.Log(closestAngle);
            low_fence(closestAngle);
        }

    }
    void playergoseverpos(Vector3 playergoseverpos)
    {
        //������ ��ǥ ����(������ũ��Ʈ).(�÷��̾� �ѹ�)(playergoseverpos);
    }
    void playergetseverpos(Vector3 playergetseverpos)
    {
        //�������� ��ǥ �޾� �̵� navMeshAgent.SetDestination(playergetseverpos);
    }
    OffMeshLink link;
    string animation_object;
    Furniture_BreakAble FB;
    Vector3 test;
    private void OnTriggerStay(Collider other)
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.F))
        {
            lastpos = transform.position;
            if (other.gameObject.transform.parent.GetComponent<Furniture_BreakAble>().Can_Enter_Animation)
            {
                FB = other.gameObject.transform.parent.GetComponent<Furniture_BreakAble>();
                animation_object = other.gameObject.transform.parent.tag;
                test = FB.transform.position;
                if (FB.PointMainBody)
                {
                    test = FB.PointMainBody.position;
                    FB = FB.PointMainBody.gameObject.transform.parent.GetComponent<Furniture_BreakAble>();
                    animation_object = FB.PointMainBody.gameObject.transform.parent.tag;
                }
                Debug.Log(animation_object);
                if(animation_object == "Bed")
                {
                    playobject_bed();
                }
                else if (animation_object == "Sit")
                {
                    playobject_sit();
                }
                
                navMeshAgent.enabled = false;
                Debug.Log(lastpos);
            }
            else
            {
                Debug.Log(FB.Can_Enter_Animation);
            }
        }
        
        if (other.gameObject.transform.parent.GetComponent<OffMeshLink>())
        {
            
            link = other.gameObject.transform.parent.GetComponent<OffMeshLink>();
        }
    }
    void playobject_bed()
    {
        for (int i = 0; i < playeranime.Length; i++)
        {
            if (playeraimeobject[i].activeSelf)
            {

                Debug.Log("시작");
                playeranime[i].animatersetTrigger("don`t_move");
                playeranime[i].animatorsetBool("sleep", true);
                playeranime[i].animatorsetting(0f);
                anima_name = "sleep";
            }

        }
        Debug.Log("애니메이션 가능");
        if (FB.TowardUP)
        {
            Debug.Log("회전값" + 50F);
            playerrot.transform.localRotation = Quaternion.Euler(0f, 50f, 0f);
            transform.position = new Vector3(test.x + 0.5f, test.y - 0.5f, 0);
            //sit 210 bad 50
        }
        else
        {
            Debug.Log("회전값" + -50F);
            playerrot.transform.localRotation = Quaternion.Euler(0f, -50f, 0f);
            transform.position = new Vector3(test.x + 0.3f, test.y - 0.55f, 0);//x+0.4y-0.3
                                                                               //sit 140 bad -50
        }
    }
    void playobject_sit()
    {
        for (int i = 0; i < playeranime.Length; i++)
        {
            if (playeraimeobject[i].activeSelf)
            {
                playeranime[i].animatorsetBool("sit", true);
                playeranime[i].animatorsetting(1f);
                anima_name = "sit";
            }

        }
        if (FB.TowardUP)
        {
            Debug.Log("회전값" + 50F);
            playerrot.transform.localRotation = Quaternion.Euler(0f, 140f, 0f);
            transform.position = new Vector3(test.x + 0.25f, test.y - 1.07f, 0);
            //sit 210 bad 50
        }
        else
        {
            Debug.Log(test);
            playerrot.transform.localRotation = Quaternion.Euler(0f, 220f, 0f);
            transform.position = new Vector3(test.x - 0.2f, test.y - 1.07f, 0);//x+0.4y-0.3
                                                                               //sit 140 bad -50
        }
    }
    public void OffMeshLinkasd()
    {
        for (int i = 0; i < playeraimeobject.Length; i++)
        {
            if (playeraimeobject[i].activeSelf)
            {
                navMeshAgent.enabled = false;
                transform.position = new Vector3(transform.position.x + low_fence_x, transform.position.y + low_fence_y, transform.position.z);
                break;
            }
        }
        for (int i = 0; i < playeraimeobject.Length; i++)
        {
            playeraimeobject[i].transform.localPosition = Vector3.zero;
            if (playeraimeobject[i].activeSelf)
            {
                playeranime[i].animatorsetFloat("mobile_interaction", 0);
            }
        }
        navMeshAgent.enabled = true;

    }
    float low_fence_x = 0.3f;
    float low_fence_y = 0.5f;
    void low_fence(float rot)
    {
        playerrot.transform.localRotation = Quaternion.Euler(0, rot, 0);
        switch (rot)
        {
            case -45:
                low_fence_x = -0.3f;
                low_fence_y = 0.5f;
                break;
            case 135:
                low_fence_x = 0.3f;
                low_fence_y = -0.5f;
                break;
            case 45:
                low_fence_x = 0.3f;
                low_fence_y = 0.5f;
                break;
            case -135:
                low_fence_x = -0.3f;
                low_fence_y = -0.5f;
                break;
        }
    }
}
