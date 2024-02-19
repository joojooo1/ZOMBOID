using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class zombie_movement : MonoBehaviour
{
    public float speed = 10f; //좀비 이동속도
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
    bool zombie_crawl = false;//좀비가 넘어져있은지
    GameObject atk_player;//좀비에서 공격한 플레이어
    float atk_distance = 1f; //좀비 공격시도 범위
    zombieHp zomhp;//좀비의 상태 스크립트
    bool atking = false;//좀비가 공격중인가

    void Start()
    {
        int crawl_spawn = Random.Range(0, 10);
        zomhp = gameObject.GetComponent<zombieHp>();
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        zombieTransform = transform;
        StartCoroutine(RandomMoveCoroutine());
        if (crawl_spawn <= 10)//스크립트 시작시 좀비가 기어서 움직이는가 서서 움직이는가 판단
        {
            Debug.Log(crawl_spawn);
            zombie_crawl = true;
            animator.SetBool("crawl_walk", zombie_crawl);
        }
    }

    void FixedUpdate()
    {

        if (player != null)//플레이어 탐지후 행동
        {
            StopCoroutine(zomidlemove());//좀비 idle중지

            targetTime += Time.deltaTime;
            if (targetTime > durationTime)//플레이어가 탐지 범위를 벗어났을때 추적시간을 넘었을시
            {
                player = null;
                targetTime = 0f;
                StartCoroutine(RandomMoveCoroutine());//좀비 idle시작
            }
        }
        else if(player == null)
        {
            findplayer();//좀비가 플레이어 재탐색
            StopCoroutine(zommove());//플레이어 추적 중지
        }
        animatorwalk();//좀비가 움직이는 애니메이션으로 이동
    }
    void findplayer() //주변 플레이어 탐색
    {
        float angleStep = 360f / rayCount;
        for (float angle = 0; angle < 360; angle += angleStep)
        {
            Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * zombieTransform.forward;
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
                    targetTime = 0f;
                    player = hit.collider.gameObject;
                    StopCoroutine(zommove());
                    StopCoroutine(zomidlemove());
                    StartCoroutine(zommove());
                    break;
               }
               
            }
        }
    }
    IEnumerator zomidlemove()//좀비 렌덤 좌표 배회하기
    {
        while (transform.position != targetPosition && player == null)
        {
            Vector3 playerDirection = targetPosition - zombieTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            zombieTransform.rotation = Quaternion.Slerp(zombieTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if(zombie_crawl)
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            if (player != null)
            {
                isMoving = false;
                yield return null;
            }
            yield return null;
            
        }
        // 목표 위치에 도달하면 이동 상태 종료
        isMoving = false;
        StartCoroutine(RandomMoveCoroutine());
    }
    IEnumerator zommove()//플레이어on 좀비 이동
    {
        while (player)
        {
            Vector3 playerDirection = player.transform.position - zombieTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            zombieTransform.rotation = Quaternion.Slerp(zombieTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (zombie_crawl)
                zombieTransform.position = Vector3.MoveTowards(zombieTransform.position, player.transform.position, speed * Time.deltaTime/2);
            else
                zombieTransform.position = Vector3.MoveTowards(zombieTransform.position, player.transform.position, speed * Time.deltaTime);
            float player_atk = Vector3.Distance(player.transform.position , zombieTransform.position);
            if (player_atk <= atk_distance) 
            {
                Debug.Log("좀비 공격시도");
                if(!atking)
                 zom_atk_anim();
                yield break;
            }
            yield return null;
        }
        
    }
    void animatorwalk()//플레이어on/off 추적시 애니메이션
    {
        Vector3 movementDirection = (transform.position - lastPosition).normalized;
        if (movementDirection.magnitude > 0.1f)//좀비가 좌표변경시 애니메이션 결정및 방향설정
        {
            if (player != null)//플레이어on
            {
                animator.SetBool("run", true);
                
            }
            else//플레이어off
            {
                
                animator.SetBool("walk", true);
                 
            }
        }
        else//좀비 idle일떄
        {
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
        }
        // 현재 위치를 마지막 위치로 업데이트
        lastPosition = transform.position;
    }
    IEnumerator RandomMoveCoroutine()// 대기 시간 후에 랜덤한 목표 위치 설정
    {
        yield return new WaitForSeconds(moveInterval);
        if(player == null)
        {
            SetRandomTargetPosition();
            isMoving = true;
        }
    }
    void SetRandomTargetPosition()// 랜덤한 목표 위치 설정
    {
        float randomX = Random.Range(-10f, 10f) + transform.position.x;
        float randomZ = Random.Range(-10f, 10f) + transform.position.z;
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
        StartCoroutine(zomidlemove());
    }

    void zom_up()
    {
        if (Random.Range(0, 10) > 5)
        {
            animator.SetBool("up", true);
            Debug.Log("일어서다");
        }
    }
    void zom_down()//좀비가 넘어질때
    {
        int zom_down_percentage = Random.Range(0, 10);
        if (zom_down_percentage > 1)
        {
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

        }
    }
    public void zombie_hit(GameObject player)//좀비가 공격받을떄 모션
    {
        atk_player = player;
        animator.SetBool("hit", true);
    }
    void zom_atk_anim()//좀비가 공격시작 애니메이션
    {
        Debug.Log("공격");
        atking = true;
        animator.SetBool("crawl_walk", false);
        animator.SetBool("run", false);
        animator.SetBool("walk", false);
        animator.SetBool("playeratk", true);
    }
    void zom_atk_try()//좀비의 공격 성공여부(공격 성공여부 판단시 좀비와의 거리가 1이하이면 공격이 성공한다.)
    {
        animator.SetBool("playeratk", false);
        float player_atk = Vector3.Distance(player.transform.position, zombieTransform.position);
        if(player_atk <= atk_distance)
        {
            Debug.Log("좀비공격 성공");
            //zomhp.zombie_atk(player);
        }
    }
    void zom_atk_end()//좀비의 다시 공격하기위한 작업
    {
        atking = false;
        findplayer();
    }
}
