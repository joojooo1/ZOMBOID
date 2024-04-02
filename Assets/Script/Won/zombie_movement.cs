using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class zombie_movement : MonoBehaviour
{
    public float speed; //좀비 이동속도
    private Transform zombieTransform;
    public GameObject player; //플레이어 
    private float targetTime = 0f;//플레이어 감지하는 시간
    public float durationTime = 5f;//플레이어 인지범위 초과시 추적하는 시간
    public float detectionRange = 10f;//플레이어 인지범위
    public float rotationSpeed = 10f;//좀비 회전 속도
    public float detectionRadius = 5f;//인지범위의 반지름
    public int rayCount = 18; // 원형으로 쏘는 Ray의 개수
    public LayerMask playerLayer; //플레이어 레이어
    private Animator animator;
    private Vector3 lastPosition; // 좀비이동애니메이션 관련 좌표
    private Vector3 targetPosition;// 좀비 idle 배회시 렌덤 좌표
    public bool isMoving = false; // 좀비가 idle 배회중인가
    const float moveInterval = 5f; // 좀비 idle 배회시 렌덤 좌표 재설정 시간 
    bool zombie_crawl = false;//좀비가 넘어져있은지 (hp전송)
    GameObject atk_player;//좀비에서 공격한 플레이어
    float atk_distance = 1f; //좀비 공격시도 범위
    zombieHp zomhp;//좀비의 상태 스크립트
    public bool atking = false;//좀비가 공격중인가
    public bool live = true;//좀비의 생존여부
    float dieday= 0f;//죽은 날짜
    public bool ing = false;
    NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        live = true;
        int crawl_spawn = Random.Range(0, 10);
        zomhp = gameObject.GetComponent<zombieHp>();
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        zombieTransform = transform;
        StartCoroutine(RandomMoveCoroutine());
        if (crawl_spawn <= 1)//스크립트 시작시 좀비가 기어서 움직이는가 서서 움직이는가 판단
        {
            Debug.Log(crawl_spawn);
            zombie_crawl = true;
            animator.SetBool("crawl_walk", zombie_crawl);
            zom_situation();
        }
        speed = zomhp.curret_speed;
        zom_anim_speed();
    }

    void Update()
    {
        //animatorwalk();
        if (live)
        {
            if (player != null)//플레이어 탐지후 행동
            {
                StopCoroutine(zomidlemove());//좀비 idle중지
                navMeshAgent.SetDestination(player.transform.position);
                /*targetTime += Time.deltaTime;
                if (targetTime > durationTime)//플레이어가 탐지 범위를 벗어났을때 추적시간을 넘었을시
                {
                    player = null;
                    targetTime = 0f;
                    StartCoroutine(RandomMoveCoroutine());//좀비 idle시작
                }*/
            }
           if (!atking && !ing)
           {
                findplayer();//좀비가 플레이어 재탐색
           }
        }
        else
        {/*
            dieday = 서버 날짜;
            if(dieday+30 < 서버 날짜)
            {
                Destroy(gameObject);
            }*/
        }
    }
    void findplayer() //주변 플레이어 탐색  ccccc
    {
        float angleStep = 360f / rayCount;
        for (float angle = 0; angle < 360; angle += angleStep)
        {
            Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * zombieTransform.right;
            RaycastHit hit;
            float dis = detectionRadius;
            if(angle < 45 || angle > 315)//탐지범위가 좀비 전면일때 확장
            {
                dis += 5;
            }
            if (Physics.Raycast(zombieTransform.position, rayDirection, out hit, dis, playerLayer))
            {
               if (hit.collider.gameObject.tag == "Player")
               {
                    zom_situation();
                    targetTime = 0f;
                    player = hit.collider.gameObject;
                    StopCoroutine(zommove());
                    StopCoroutine(zomidlemove());
                    StartCoroutine(zommove());
                    break;
               }
            }
            if (player)
            {
                StopCoroutine(zommove());
                StopCoroutine(zomidlemove());
                StartCoroutine(zommove());
                break;
            }
        }
    }
    IEnumerator zomidlemove()//좀비 렌덤 좌표 배회하기cccccc
    {
        while (transform.position != targetPosition && player == null)
        {

            animator.SetBool("walk", true);
            Vector3 playerDirection = targetPosition - zombieTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            zombieTransform.localRotation = Quaternion.Slerp(zombieTransform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
            if(zombie_crawl)
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            if (player != null)
            {
                animator.SetBool("walk", false);
                isMoving = false;
                yield break;
            }
            yield return null;
            
        }
        // 목표 위치에 도달하면 이동 상태 종료
        animator.SetBool("walk", false);
        isMoving = false;
        StartCoroutine(RandomMoveCoroutine());
    }
    IEnumerator zommove()//플레이어on 좀비 이동cccccc
    {
        while (player && !atking)
        {
            ing = true;
            animator.SetBool("run", true);
            navMeshAgent.SetDestination(player.transform.position);
            Vector3 playerDirection = player.transform.position - zombieTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection, Vector3.right);
            zombieTransform.localRotation = Quaternion.Slerp(zombieTransform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
            float player_atk = Vector3.Distance(player.transform.position , zombieTransform.position);
            if (player_atk <= atk_distance) 
            {
                if (!atking)
                {
                    ing = false;
                    animator.SetBool("run", false);
                    zom_atk_anim();

                    //StopCoroutine(zommove());
                    yield break;
                }
            }
            else if(player_atk >= 20)
            {
                ing = false;
               // player = null;
                StopCoroutine(zommove());
                yield break;
            }
            else
            {
                //if (zombie_crawl)

                //zombieTransform.position = Vector3.MoveTowards(zombieTransform.position, player.transform.position, (speed * Time.deltaTime) / 2);
                //else
                // zombieTransform.position = Vector3.MoveTowards(zombieTransform.position, player.transform.position, speed * Time.deltaTime);
                
            }
            yield return null;
        }
        
    }
    IEnumerator RandomMoveCoroutine()// 대기 시간 후에 랜덤한 목표 위치 설정xxxxxx
    {
        yield return new WaitForSeconds(moveInterval);
        if(player == null)
        {
            animator.SetBool("run", false);
            SetRandomTargetPosition();
            isMoving = true;
        }
    }
    void SetRandomTargetPosition()// 랜덤한 목표 위치 설정cccccc
    {
        float randomX = Random.Range(-3F, 3f) + transform.position.x;
        float randomY = Random.Range(-3f, 3f) + transform.position.y;
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
        navMeshAgent.SetDestination(targetPosition);
        StartCoroutine(zomidlemove());
    }

    void zom_up()//좀비가 일어날 확률zzzzzzz
    {
        if (Random.Range(0, 10) > 5)
        {
            speed = 0;
            zombie_crawl = false;
            animator.SetBool("crawl_walk", false);
            animator.SetBool("down", false);
            animator.SetBool("backdown", false);
            animator.SetBool("up", true);
            zom_situation();
            Debug.Log("일어서다");
        }
    }
    public void zom_down(GameObject player)//좀비가 넘어질때
    {
        atk_player = player;
        /*int zom_down_percentage = Random.Range(0, 10);
        if (zom_down_percentage > 1)
        {
            zombie_crawl = true;
            if (atk_player != null)//플레이어가 공격해서 넘어졌을떄
            {
                Vector3 relativePosition = atk_player.transform.position - transform.position;
                Vector3 forwardVector = transform.forward;
                float dotProduct = Vector3.Dot(relativePosition.normalized, forwardVector);
                if (dotProduct > 0)//좀비 앞에 공격한플레이어가 있는 경우
                {
                    animator.SetBool("down", true);
                }
                else //좀비 뒤에 공격한 플레이어가 있는 경우
                {
                    zombie_crawl = true;
                    animator.SetBool("backdown", true);
                }
            }
            else//좀비 스스로 넘어졌을떄
            {
                zombie_crawl = true;
                animator.SetBool("backdown", true);
            }
            zom_situation();
        }*/
        // else
        // {
        Debug.Log("맞음");
            animator.SetTrigger("hit");
        //}
            
    }//zzzzz
    void zom_atk_anim()//좀비가 공격시작 애니메이션cccccc
    {
        zom_speed_zero();
        animator.SetBool("run", false);
        if (!atking)
        {
            atking = true;
            animator.SetBool("playeratk", true);
        }
        StartCoroutine(zommove());
    }
    void zom_atk_try()//좀비의 공격 성공여부(공격 성공여부 판단시 좀비와의 거리가 1이하이면 공격이 성공한다.)zzzzzz
    {
        float player_atk = Vector3.Distance(player.transform.position, zombieTransform.position);
        if(player_atk <= atk_distance)
        {
            //zomhp.zombie_atk(player);
        }
    }
    void zom_atk_end()//좀비의 다시 공격하기위한 작업zzzzzzz
    {
        zom_speed_curret();
        animator.SetBool("playeratk", false);
        atking = false;
    }

    void zom_situation()//좀비의 정보 전송
    {
        zomhp.zom_data(player, zombie_crawl);
    }
    void zom_anim_speed()//좀비의 이동속도에 따라 애니메이션 속도 변경zzzzzzzz
    {
        switch (speed)
        {
            case 7:
                animator.SetFloat("Typespeed", 2f);
                navMeshAgent.speed = 2f;
                break;
            case 10:
                animator.SetFloat("Typespeed", 3f);
                navMeshAgent.speed = 2f;
                break;
            case 13:
                animator.SetFloat("Typespeed", 4f);
                navMeshAgent.speed = 2f;
                break;
            default:
                animator.SetFloat("Typespeed", 1f);
                navMeshAgent.speed = 2f;
                break;
        }
    }
    void zom_up_off()//좀비가 일어나뒤 이동속도 변경zzzzzzzz
    {
        speed = zomhp.curret_speed;
        animator.SetBool("up", false);
    }
    void zom_speed_zero()//zzzzzzzz
    {
        speed = 0;
    }
    void zom_speed_curret()///zzzzzz
    {
        speed = zomhp.curret_speed;
    }
    public void zom_Die()//zzzzzzzzzzzzz
    {
        Collider collider = gameObject.GetComponent<Collider>();
        collider.enabled = false;
        animator.SetBool("backdown", true);
        speed = 0;
    }
}
