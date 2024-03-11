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
    zombieHp zomHp;
    Player_main _main;
    public float Playermovement_speed = 7;
    public float Playerturnspeed = 10;
    Animator animator;
    float dis = 1;
    Weapon_type weapon;
    public GameObject zombie;
    bool atking = false;

    public bool injury = false;
    public LayerMask zombieLayer;
    public float rayLength = 100f;
    public float maxDetectionDistance = 15f;
    public int maxTargets = 3;
    public float attackRange = 15F;
    public string curretposture;


    float weapon_test = 0;
    enum PlayerAnimType
    {
        None,
        Atk,
        Push,
        Reading,
        Digging,
        Watering,
        Drink,
        Eat,
        Woodcut,
        Woodsaw,
        Sleep,
        Smoking,
        ZombieHit,
        Die,
        Fishing,
        ChangeWeapon,
        Reload
    }

    enum PlayerAnimPosture
    {
        Idle,
        Strife,
        Squat,
        Prone
    }
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _main = gameObject.GetComponent<Player_main>();
        animator = GetComponent<Animator>();
        animator.SetFloat("weapon_type", weapon_test);
        curretposture = "idle";
    }
    Vector3 inputpos;
    Vector3 movement;
    // Update is called once per frame
    void FixedUpdate()
    {
        inputpos = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), 0f, UnityEngine.Input.GetAxisRaw("Vertical"));
        navMeshAgent.Move(inputpos * navMeshAgent.speed * Time.deltaTime);
        Vector3 mousePos = UnityEngine.Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
        Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        if (UnityEngine.Input.GetMouseButton(1))
        {
            if (curretposture != "Strife")
            {
                curretpostruecange();
            }
            movement = inputpos.normalized * Time.deltaTime * (Playermovement_speed - 2);
            
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                Vector3 directionToTarget = hit.point - transform.position;
                directionToTarget.y = 0;
                if (directionToTarget != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
                    toRotation.eulerAngles = new Vector3(0, toRotation.eulerAngles.y, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Playerturnspeed);
                    inputpos= (transform.rotation * inputpos);

                }
            }
            animator.SetFloat("x", inputpos.x);
            animator.SetFloat("z", inputpos.z);
            if (UnityEngine.Input.GetMouseButton(0) && !atking)
            {
                Debug.Log("마우스 입력 받음");
                atking = true;
                animator.SetTrigger("ATK");
                
            }
        }
        else if (UnityEngine.Input.GetMouseButtonUp(1))
        {
            curretpostruecange();
        }
        else
        {
            movement = inputpos.normalized * Time.deltaTime * Playermovement_speed;
            if (movement.magnitude > 0.01f)
            {
                // 이동 방향으로 회전 각도 계산
                Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

                // Quaternion.Lerp를 사용하여 부드럽게 회전 적용
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Playerturnspeed);
            }

        }
        Vector3 pos = transform.position;
        pos += movement;
        if(transform.position != pos)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        //navMeshAgent.Move(pos * navMeshAgent.speed * Time.deltaTime);
        if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
        {
            weapon_test++;
            animator.SetFloat("weapon_type", weapon_test);
            if(weapon_test > 3)
            {
                weapon_test = -1;
            }
            Debug.Log(weapon_test);
        }
        
    }
    void curretpostruecange()
    {
        switch (curretposture)
        {
            case "idle":
                PlayAnimation(PlayerAnimPosture.Strife);
                curretposture = "Strife";
                break;
            case "Strife":
                PlayAnimation(PlayerAnimPosture.Idle);
                curretposture = "idle";
                break;
            default: break;
        }
    }
    void gunatk()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,dis))
        {
            GameObject zom = hit.collider.gameObject;
            if(zom.tag == "zombie")
            {
                Debug.Log("좀비 맞음");
                zomHp = zom.GetComponent<zombieHp>();
                zombie_movement _movement = zom.GetComponent<zombie_movement>();
                zomHp.GetDamage(gameObject, 10);
                _movement.zom_down(gameObject);
            }
        }
    }
    float multiplhits = 3;
    void AttackZombies()
    {
        float count = 0;
        // 오브젝트의 정면 방향
        Vector3 forwardDirection = transform.forward;

        // 레이캐스트를 쏴서 zombieLayer를 가진 오브젝트를 찾음
        
        RaycastHit[] hits = Physics.RaycastAll(transform.position, forwardDirection, attackRange);
        
        // 레이캐스트 결과를 거리에 따라 정렬
        System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

        // 최대 3명의 좀비에 대해 처리
        for (int i = 0; i < hits.Length; i++)
        {
            // 레이에 맞은 오브젝트 가져오기
            GameObject hitObject = hits[i].collider.gameObject;
            
            // 가져온 오브젝트에서 ZombieHp 스크립트 가져오기
            zombieHp zomHp = hitObject.GetComponent<zombieHp>();

            // ZombieHp 스크립트가 있다면 GetDamage 함수 호출
            if (zomHp != null&& count <= multiplhits)
            {
                count++;
                Debug.Log("레이에 좀비 걸림 데미지 전송");
                zomHp.GetDamage(gameObject, 10F);  // 또는 다른 처리를 수행
            }
        }
    }
    void weapon_atk()
    {
        switch (weapon)
        {
            case Weapon_type.Gun:
                {
                    dis += 10;
                    gunatk();
                }
                break;
            default:
                {
                    Debug.Log("총아님");
                    AttackZombies();
                }
                break;
        }
    }
    void atkEnd()
    {
        atking = false;
    }


    //애니메이션 서버 호환 버전(24.03.04)
    PlayerAnimType animType = PlayerAnimType.None; //현재 애니메이션 타입1
    PlayerAnimPosture posture = PlayerAnimPosture.Idle; //현재 애니메이션 타입2
    //애니메이션타입1 입력및 서버전송준비
    private void PlayAnimation(PlayerAnimType newState)
    {
        animType = newState;
        SendAnimationStateToServer(newState);
        Player_anim_02();
        
    }
    //애니메이션타입2 입력및 서버전송준비
    private void PlayAnimation(PlayerAnimPosture newState)
    {
        posture = newState;
        SendAnimationStateToServer(newState);
        Player_anim_01();
    }
    private void SendAnimationStateToServer<T>(T state)
    {
        // 여기에서는 서버로 데이터를 전송하는 코드를 가정합니다.
    }
    private void GetAnimationStatefromServer<T>(T state)
    {
        // 받은 데이터의 타입이 PlayerAnimType인지 확인
        if (state is PlayerAnimType)
        {
            // 형변환을 통해 PlayerAnimType으로 변환하고 animType에 저장
            animType = (PlayerAnimType)(object)state;

            // 애니메이션 실행 함수 호출
            Player_anim_01();
        }
        // 받은 데이터의 타입이 PlayerAnimPosture인지 확인
        else if (state is PlayerAnimPosture)
        {
            // 형변환을 통해 PlayerAnimPosture로 변환하고 posture에 저장
            posture = (PlayerAnimPosture)(object)state;

            // 애니메이션 실행 함수 호출
            Player_anim_02();
        }
    }
    //애니메이션 타입1 값별 애니메이션 호출
    void Player_anim_01()
    {
        switch (posture)
        {
            case PlayerAnimPosture.Idle:
                animator.SetBool("Strife", false);
                animator.SetBool("squat", false);
                animator.SetBool("prone", false);
                break;
            case PlayerAnimPosture.Strife:
                animator.SetBool("Strife", true);
                animator.SetBool("squat", false);
                animator.SetBool("prone", false);
                break;
            case PlayerAnimPosture.Squat:
                animator.SetBool("Strife", false);
                animator.SetBool("squat", true);
                animator.SetBool("prone", false);
                break;
            case PlayerAnimPosture.Prone:
                animator.SetBool("Strife", false);
                animator.SetBool("squat", false);
                animator.SetBool("prone", true);
                break;
        }

        
    }
    //애니메이션 타입2 값별 애니메이션 호출
    void Player_anim_02()
    {
        switch (animType)
        {
            case PlayerAnimType.Atk:
                animator.SetTrigger("ATK");
                break;
            case PlayerAnimType.Push:
                animator.SetTrigger("Push");
                break;
            case PlayerAnimType.Reading:
                animator.SetTrigger("Reading");
                break;
            case PlayerAnimType.Digging:
                animator.SetTrigger("Digging");
                break;
            case PlayerAnimType.Watering:
                animator.SetTrigger("watering");
                break;
            case PlayerAnimType.Drink:
                animator.SetTrigger("drink");
                break;
            case PlayerAnimType.Eat:
                animator.SetTrigger("eat");
                break;
            case PlayerAnimType.Woodcut:
                animator.SetBool("woodcut", true);
                break;
            case PlayerAnimType.Woodsaw:
                animator.SetBool("woodsaw", true);
                break;
            case PlayerAnimType.Sleep:
                animator.SetBool("sleep", true);
                break;
            case PlayerAnimType.Smoking:
                animator.SetTrigger("smoking");
                break;
            case PlayerAnimType.ZombieHit:
                animator.SetTrigger("zombie_hit");
                break;
            case PlayerAnimType.Die:
                animator.SetTrigger("die");
                break;
            case PlayerAnimType.Fishing:
                animator.SetBool("Fishing", true);
                break;
            case PlayerAnimType.ChangeWeapon:
                animator.SetTrigger("change_weapon");
                break;
            case PlayerAnimType.Reload:
                animator.SetBool("reload", true);
                break;
            default:
                animator.SetBool("woodcut", false);
                animator.SetBool("woodsaw", false);
                animator.SetBool("sleep", false);
                animator.SetBool("Fishing", false);
                animator.SetBool("reload", false);
                break;
        }
    }
}
