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
using static System.Collections.Specialized.BitVector32;
using static UnityEngine.GraphicsBuffer;

public class player_movement : MonoBehaviour
{
    public UI_main uI_Main;
    public Player_main player_Main;
    private NavMeshAgent navMeshAgent;
    public float Playermovement_speed = 7;
    public float Playerturnspeed = 10;
    public GameObject[] playeraimeobject;
    public player_animation[] playeranime;
    Vector3 playerpos;
    Vector3 lastpos;
    string anima_name;
    public GameObject playerrot;
    public bool low_Fen = false;
    private readonly float[] targetAngles = { -45f, 45f, 135f, -135f };

    public bool Player; // 0513 JY

    // Start is called before the first frame update
    void Start()
    {
        for ( int i = 0; i<playeraimeobject.Length; i++)
        {
            playeranime[i] = playeraimeobject[i].GetComponent<player_animation>();
            Debug.Log(i);
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        //_main = gameObject.GetComponent<Player_main>();
    }
    Vector3 Fence;
    Vector3 inputpos;
    public float test =0;
    bool run_set = false;
    bool Strife_set = false;
    private void Update()
    {
        if (Player) // 0513 JY
        {
            navMeshAgent.speed = player_Main.Get_Moving_Speed();
            if (!aser)
            {
                inputpos = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal") + (UnityEngine.Input.GetAxisRaw("Vertical") * 0.001f), UnityEngine.Input.GetAxisRaw("Vertical"), 0F);
                inputpos.Normalize();
                inputpos *= Time.fixedDeltaTime * (navMeshAgent.speed);
            }
            else
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
                {
                    Debug.Log("멈춤");
                    aser = false;
                    navMeshAgent.ResetPath();
                    for (int i = 0; i < playeranime.Length; i++)
                    {
                        if (playeraimeobject[i].activeSelf)
                        {
                            playeranime[i].animatersetTrigger(anim);
                        }
                    }
                }
            }
        
        }
        if (uI_Main.Playing)
        {

            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
                run_set = true;
                playeranimetion("Is_Running", run_set);
            }
            else if (UnityEngine.Input.GetMouseButton(1))
            {
                Strife_set = true;
                playeranimetion("Is_Aiming", Strife_set);
            }
            else
            {
                Strife_set = false;
                run_set = false;
                playeranimetion("Is_Running", run_set);
                playeranimetion("Is_Aiming", Strife_set);
            }
        }
    }
    }
    public bool aser = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player) // 0513 JY
        {

        if (uI_Main.Playing)
        {

            if (navMeshAgent.enabled && UnityEngine.Input.GetAxisRaw("Horizontal") != 0 || UnityEngine.Input.GetAxisRaw("Vertical") != 0)
            {
                if (aser)
                {
                    navMeshAgent.ResetPath();
                    aser = false;
                }
                navMeshAgent.Move(inputpos);
            }
            if (!navMeshAgent.enabled && !low_Fen)
            {
                if (UnityEngine.Input.GetAxisRaw("Horizontal") != 0 || UnityEngine.Input.GetAxisRaw("Vertical") != 0)
                {
                    //transform.position = new Vector3 (test.x-0.5f,test.y -1f,0);
                    for (int i = 0; i < playeranime.Length; i++)
                    {
                        if (playeraimeobject[i].activeSelf)
                        {

                            playeranime[i].animatorsetBool(anima_name, false);

                            playeranime[i].animatorsetting(1, 0.7f);
                        }
                    }
                    navMeshAgent.enabled = true;
                }
            }

            if (low_Fen)
            {

                transform.position = Vector3.Lerp(transform.position, Fence, Time.deltaTime * 3);
                if (Vector3.Distance(transform.position, Fence) < 0.1)
                {
                    low_Fen = false;
                    for (int i = 0; i < playeranime.Length; i++)
                    {
                        if (playeraimeobject[i].activeSelf)
                        {
                            playeranime[i].animatorsetting(1, 0.7f);

                        }

                    }
                    navMeshAgent.enabled = true;
                }
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.F11))
            {
                animepos(new Vector3(0, 0, 0), "smoking");
            }
        }
        }
    }
    public Vector3 playergoseverpos(Vector3 playergoseverpos)
    {
        playergoseverpos = this.transform.position;
        return playergoseverpos;
    }
    void playergetseverpos(Vector3 playergetseverpos)
    {
        //�������� ��ǥ �޾� �̵� navMeshAgent.SetDestination(playergetseverpos);
    }

    string animation_object;
    Furniture_BreakAble FB;
    Vector3 playerobject;
    private void OnTriggerStay(Collider other)
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.F))
        {
            lastpos = transform.position;
            if (other.gameObject.transform.parent.tag == "CanGetOver" && !low_Fen)
            {
                playobject_low_fence(other);

            }
            if (other.gameObject.transform.parent.tag == "Sit" || other.gameObject.transform.parent.tag == "Bed" || other.gameObject.transform.tag == "Sit" || other.gameObject.transform.tag == "Bed")
            {
                playerobject_sit_or_bed(other);
            }
            
        }
        
    }
    void playerobject_sit_or_bed(Collider other)
    {
        if (other.gameObject.transform.parent.GetComponent<Furniture_BreakAble>().Can_Enter_Animation)
        {
            FB = other.gameObject.transform.parent.GetComponent<Furniture_BreakAble>();
            animation_object = other.gameObject.transform.parent.tag;
            playerobject = FB.transform.position;
            if (FB.PointMainBody)
            {
                playerobject = FB.PointMainBody.position;
                FB = FB.PointMainBody.gameObject.transform.parent.GetComponent<Furniture_BreakAble>();
                animation_object = FB.PointMainBody.gameObject.transform.parent.tag;
            }
            Debug.Log(animation_object);
            if (animation_object == "Bed")
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
    }
    void playobject_low_fence(Collider other)
    {
        for (int i = 0; i < playeranime.Length; i++)
        {
            if (playeraimeobject[i].activeSelf)
            {

                playeranime[i].animatorsetting(1,0f);
                playeranime[i].animatersetTrigger("end");

            }

        }
        navMeshAgent.enabled = false;
        // 충돌한 방향 계산
        
        float currentXRotation = playerrot.transform.rotation.eulerAngles.y;
         if (currentXRotation >= 180)
         {
             currentXRotation -= 360;
         }
         // 가장 가까운 목표 회전 각도 선택
         float closestAngle = targetAngles[0];
         float minDifference = Mathf.Abs(targetAngles[0] - currentXRotation);
         foreach (float angle in targetAngles)
         {
             float difference = Mathf.Abs(angle - currentXRotation);
             if (difference <= minDifference)
             {
                 minDifference = difference;
                 closestAngle = angle;
             }
         }
        low_fence(closestAngle);
        Fence = new Vector3(transform.position.x + low_fence_x, transform.position.y + low_fence_y, transform.position.z);
        low_Fen = true;
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
                playeranime[i].animatorsetting(1, 0f);
                anima_name = "sleep";
            }

        }
        Debug.Log("애니메이션 가능");
        if (FB.TowardUP)
        {
            Debug.Log("회전값" + 50F);
            playerrot.transform.localRotation = Quaternion.Euler(0f, 50f, 0f);
            transform.position = new Vector3(playerobject.x + 0.5f, playerobject.y - 0.5f, 0);
            //sit 210 bad 50
        }
        else
        {
            Debug.Log("회전값" + -50F);
            playerrot.transform.localRotation = Quaternion.Euler(0f, -50f, 0f);
            transform.position = new Vector3(playerobject.x + 0.3f, playerobject.y - 0.55f, 0);//x+0.4y-0.3
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
                playeranime[i].animatorsetting(1, 1f);
                anima_name = "sit";
            }

        }
        if (FB.TowardUP)
        {
            Debug.Log("회전값" + 50F);
            playerrot.transform.localRotation = Quaternion.Euler(0f, 140f, 0f);
            transform.position = new Vector3(playerobject.x + 0.25f, playerobject.y - 1.07f, 0);
            //sit 210 bad 50
        }
        else
        {
            Debug.Log(playerobject);
            playerrot.transform.localRotation = Quaternion.Euler(0f, 220f, 0f);
            transform.position = new Vector3(playerobject.x - 0.2f, playerobject.y - 1.07f, 0);//x+0.4y-0.3
                                                                               //sit 140 bad -50
        }
    }
    
    float low_fence_x = 0.3f;
    float low_fence_y = 0.5f;
    void low_fence(float rot)
    {
        playerrot.transform.localRotation = Quaternion.Euler(0, rot, 0);
        switch (rot)
        {
            case -45:
                low_fence_x = -0.63f;
                low_fence_y = 0.315f;
                break;
            case 135:
                low_fence_x = 0.63f;
                low_fence_y = -0.315f;
                break;
            case 45:
                low_fence_x = 0.63f;
                low_fence_y = 0.315f;
                break;
            case -135:
                low_fence_x = -0.63f;
                low_fence_y = -0.315f;
                break;
        }
    }
    public void playeranimetion(string anim,bool action) 
    {
        switch (anim)
        {
            case "Is_Aiming":
                player_Main.Is_Aiming = action;
                break;
            case "Is_Running":
                player_Main.Is_Running = action;
                break;
            case "Is_Crouch":
                player_Main.Is_Crouch = action;
                break;
            case "Is_Crawl":
                player_Main.Is_Crawl = action;
                break;
        }
    }
    string anim;
    public void animepos(Vector3 pos, string animname)
    {
        anim = animname;
        aser = true;
        navMeshAgent.destination = pos;
        navMeshAgent.Move(navMeshAgent.destination);
    }
}
