using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class zombie_movement : MonoBehaviour
{
    public float speed; //���� �̵��ӵ�
    private Transform zombieTransform;
    public GameObject player; //�÷��̾� 
    private float targetTime = 0f;//�÷��̾� �����ϴ� �ð�
    public float durationTime = 5f;//�÷��̾� �������� �ʰ��� �����ϴ� �ð�
    public float detectionRange = 10f;//�÷��̾� ��������
    public float rotationSpeed = 10f;//���� ȸ�� �ӵ�
    public float detectionRadius = 5f;//���������� ������
    public int rayCount = 18; // �������� ��� Ray�� ����
    public LayerMask playerLayer; //�÷��̾� ���̾�
    private Animator animator;
    private Vector3 lastPosition; // �����̵��ִϸ��̼� ���� ��ǥ
    private Vector3 targetPosition;// ���� idle ��ȸ�� ���� ��ǥ
    public bool isMoving = false; // ���� idle ��ȸ���ΰ�
    const float moveInterval = 5f; // ���� idle ��ȸ�� ���� ��ǥ �缳�� �ð� 
    bool zombie_crawl = false;//���� �Ѿ��������� (hp����)
    GameObject atk_player;//���񿡼� ������ �÷��̾�
    float atk_distance = 1f; //���� ���ݽõ� ����
    zombieHp zomhp;//������ ���� ��ũ��Ʈ
    public bool atking = false;//���� �������ΰ�
    public bool live = true;//������ ��������
    float dieday= 0f;//���� ��¥
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
        if (crawl_spawn <= 1)//��ũ��Ʈ ���۽� ���� �� �����̴°� ���� �����̴°� �Ǵ�
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
            if (player != null)//�÷��̾� Ž���� �ൿ
            {
                StopCoroutine(zomidlemove());//���� idle����
                navMeshAgent.SetDestination(player.transform.position);
                /*targetTime += Time.deltaTime;
                if (targetTime > durationTime)//�÷��̾ Ž�� ������ ������� �����ð��� �Ѿ�����
                {
                    player = null;
                    targetTime = 0f;
                    StartCoroutine(RandomMoveCoroutine());//���� idle����
                }*/
            }
           if (!atking && !ing)
           {
                findplayer();//���� �÷��̾� ��Ž��
           }
        }
        else
        {/*
            dieday = ���� ��¥;
            if(dieday+30 < ���� ��¥)
            {
                Destroy(gameObject);
            }*/
        }
    }
    void findplayer() //�ֺ� �÷��̾� Ž��  ccccc
    {
        float angleStep = 360f / rayCount;
        for (float angle = 0; angle < 360; angle += angleStep)
        {
            Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * zombieTransform.right;
            RaycastHit hit;
            float dis = detectionRadius;
            if(angle < 45 || angle > 315)//Ž�������� ���� �����϶� Ȯ��
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
    IEnumerator zomidlemove()//���� ���� ��ǥ ��ȸ�ϱ�cccccc
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
        // ��ǥ ��ġ�� �����ϸ� �̵� ���� ����
        animator.SetBool("walk", false);
        isMoving = false;
        StartCoroutine(RandomMoveCoroutine());
    }
    IEnumerator zommove()//�÷��̾�on ���� �̵�cccccc
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
    IEnumerator RandomMoveCoroutine()// ��� �ð� �Ŀ� ������ ��ǥ ��ġ ����xxxxxx
    {
        yield return new WaitForSeconds(moveInterval);
        if(player == null)
        {
            animator.SetBool("run", false);
            SetRandomTargetPosition();
            isMoving = true;
        }
    }
    void SetRandomTargetPosition()// ������ ��ǥ ��ġ ����cccccc
    {
        float randomX = Random.Range(-3F, 3f) + transform.position.x;
        float randomY = Random.Range(-3f, 3f) + transform.position.y;
        targetPosition = new Vector3(randomX, randomY, transform.position.z);
        navMeshAgent.SetDestination(targetPosition);
        StartCoroutine(zomidlemove());
    }

    void zom_up()//���� �Ͼ Ȯ��zzzzzzz
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
            Debug.Log("�Ͼ��");
        }
    }
    public void zom_down(GameObject player)//���� �Ѿ�����
    {
        atk_player = player;
        /*int zom_down_percentage = Random.Range(0, 10);
        if (zom_down_percentage > 1)
        {
            zombie_crawl = true;
            if (atk_player != null)//�÷��̾ �����ؼ� �Ѿ�������
            {
                Vector3 relativePosition = atk_player.transform.position - transform.position;
                Vector3 forwardVector = transform.forward;
                float dotProduct = Vector3.Dot(relativePosition.normalized, forwardVector);
                if (dotProduct > 0)//���� �տ� �������÷��̾ �ִ� ���
                {
                    animator.SetBool("down", true);
                }
                else //���� �ڿ� ������ �÷��̾ �ִ� ���
                {
                    zombie_crawl = true;
                    animator.SetBool("backdown", true);
                }
            }
            else//���� ������ �Ѿ�������
            {
                zombie_crawl = true;
                animator.SetBool("backdown", true);
            }
            zom_situation();
        }*/
        // else
        // {
        Debug.Log("����");
            animator.SetTrigger("hit");
        //}
            
    }//zzzzz
    void zom_atk_anim()//���� ���ݽ��� �ִϸ��̼�cccccc
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
    void zom_atk_try()//������ ���� ��������(���� �������� �Ǵܽ� ������� �Ÿ��� 1�����̸� ������ �����Ѵ�.)zzzzzz
    {
        float player_atk = Vector3.Distance(player.transform.position, zombieTransform.position);
        if(player_atk <= atk_distance)
        {
            //zomhp.zombie_atk(player);
        }
    }
    void zom_atk_end()//������ �ٽ� �����ϱ����� �۾�zzzzzzz
    {
        zom_speed_curret();
        animator.SetBool("playeratk", false);
        atking = false;
    }

    void zom_situation()//������ ���� ����
    {
        zomhp.zom_data(player, zombie_crawl);
    }
    void zom_anim_speed()//������ �̵��ӵ��� ���� �ִϸ��̼� �ӵ� ����zzzzzzzz
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
    void zom_up_off()//���� �Ͼ�� �̵��ӵ� ����zzzzzzzz
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
