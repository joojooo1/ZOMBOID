using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ServerObjectManager;

public class NetObject : MonoBehaviour
{


    [SerializeField]
    UnityEngine.UI.Text PlayerName;
    public void SetName(string name)
    {
        PlayerName.text = name;
    }

    bool IsPlayer = false;
    public bool GetIsPlayer()
    {
        return IsPlayer;
    }
    public int player_index;

    private Vector3 targetPosition;

    ServerObjectManager.OBJECT_TYPE objecttype;
    public void CreateOjbect(int playerindex, ServerObjectManager.OBJECT_TYPE _objecttype)
    {
        //UnityEngine.Screen.SetResolution(800, 600, false);
        objecttype = _objecttype;
        player_index = playerindex;
        if (CMainGame.current.playerSN == player_index)
        {
            IsPlayer = true;
            foreach(GameObject obj in ServerObjectManager.current.TwoDirectionalCameras)
            {
                obj.GetComponent<CameraRay>().Player = this.gameObject;
                obj.GetComponent<CameraRay>().Player_Exist = true;
            }
            CameraMove2.ThreeDirectionalCamera.Player = this.gameObject;
            CameraMove2.ThreeDirectionalCamera.Player_Exist = true;
            Map_InterActionTrigger_ByCamera.InterActionRay.Player = this.gameObject;
            Map_InterActionTrigger_ByCamera.InterActionRay.Player_Exiest = true;

            //PlayerHealth Health = GetComponent<PlayerHealth>();
            //if (Health != null)
            //    Health.SetPlayer();
        }
        else //내꺼 아닐때
        {

            //this.gameObject.layer = LayerMask.NameToLayer("HIT");
        }
    }

    //Animator anim;

    Vector3 spawnpos;
    private void Start()
    {
        //spawnpos = transform.position;
        //anim = GetComponent<Animator>();
        //if (anim == null)
        //    anim = GetComponentInChildren<Animator>();
    }

    float timer = 0f; Vector3 prePos; Quaternion preAngle;
    private void Update()
    {
        if (IsPlayer)
        {
            timer += Time.deltaTime;
            if (transform.position != prePos ||
               transform.rotation != preAngle)
            {
                if (timer >= 0.2f)
                {
                    PosSend();
                    timer = 0f;
                }
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, targetPosition);

            // 거리가 일정 값 이상인 경우에만 이동 처리
            if (distance > 0.1f)
            {
                // 이동 방향과 거리에 맞는 이동량 계산
                Vector3 direction = (targetPosition - transform.position).normalized;
                float step = 3.5f * Time.deltaTime;

                // 이동
                transform.position += direction * step;
            }
            else
            {
                // 목표 위치에 도달했을 때 정확한 위치로 설정
                transform.position = targetPosition;
            }
        }
        //    else //플레이어 다른애들
        //    {
        //        switch(objecttype)
        //        {
        //            case OBJECT_TYPE.PLAYER:
        //                {
        //                    transform.position = Vector3.Slerp(transform.position, netpos, Time.deltaTime * 4f);
        //                    transform.rotation = Quaternion.Slerp(transform.rotation, netrot, Time.deltaTime * 10f);

        //                    if (Vector3.Distance(transform.position, netpos) > 1f)
        //                        anim.SetBool("IsMove", true);
        //                    else
        //                        anim.SetBool("IsMove", false);
        //                }
        //                break;
        //            default: //몬스터
        //                {
        //                    //EnemyMovement move = GetComponent<EnemyMovement>();
        //                    //if (move != null)
        //                    //{
        //                    //    float dist = 0;
        //                    //    if (TargetObject != null)
        //                    //    {
        //                    //        dist  = move.SetDest(TargetObject.transform.position);
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        dist  = move.SetDest(spawnpos);
        //                    //    }

        //                    //    if (dist > 1f)
        //                    //        anim.SetBool("IsMove", true);
        //                    //    else
        //                    //        anim.SetBool("IsMove", false);

        //                    //}
        //                }
        //                break;
        //        }
        //    }
        //    prePos = transform.position;
        //    preAngle = transform.rotation;
        //}


        //public NetObject TargetObject { get; private set; }
        //public void SetTarget(NetObject _TargetObject)
        //{
        //    TargetObject = _TargetObject;
        //}

        //Vector3 netpos;
        //Quaternion netrot;
        //public void SetTarget(Vector3 pos, Quaternion rot)
        //{
        //    netpos = pos;
        //    netrot = rot;
        //}
        //public void SetTargetRotation(Quaternion rot)
        //{
        //    netrot = rot;
        //  //  transform.rotation = rot;
        //}


    }

    void PosSend()
    {
        CMainGame.current.PLAYER_MOVING_REQ(gameObject.transform.position, gameObject.transform.rotation.eulerAngles.y);
    }

    public void ReceivePosition(Vector3 newPosition)
    {
        targetPosition = newPosition;
    }

}
