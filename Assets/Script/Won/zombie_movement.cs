using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class zombie_movement : MonoBehaviour
{
    public float speed = 10f; //���� �̵��ӵ�
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
    bool zombie_crawl = false;//���� �Ѿ���������
    GameObject atk_player;//���񿡼� ������ �÷��̾�
    float atk_distance = 1f; //���� ���ݽõ� ����
    zombieHp zomhp;//������ ���� ��ũ��Ʈ
    bool atking = false;//���� �������ΰ�

    void Start()
    {
        int crawl_spawn = Random.Range(0, 10);
        zomhp = gameObject.GetComponent<zombieHp>();
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        zombieTransform = transform;
        StartCoroutine(RandomMoveCoroutine());
        if (crawl_spawn <= 10)//��ũ��Ʈ ���۽� ���� �� �����̴°� ���� �����̴°� �Ǵ�
        {
            Debug.Log(crawl_spawn);
            zombie_crawl = true;
            animator.SetBool("crawl_walk", zombie_crawl);
        }
    }

    void FixedUpdate()
    {

        if (player != null)//�÷��̾� Ž���� �ൿ
        {
            StopCoroutine(zomidlemove());//���� idle����

            targetTime += Time.deltaTime;
            if (targetTime > durationTime)//�÷��̾ Ž�� ������ ������� �����ð��� �Ѿ�����
            {
                player = null;
                targetTime = 0f;
                StartCoroutine(RandomMoveCoroutine());//���� idle����
            }
        }
        else if(player == null)
        {
            findplayer();//���� �÷��̾� ��Ž��
            StopCoroutine(zommove());//�÷��̾� ���� ����
        }
        animatorwalk();//���� �����̴� �ִϸ��̼����� �̵�
    }
    void findplayer() //�ֺ� �÷��̾� Ž��
    {
        float angleStep = 360f / rayCount;
        for (float angle = 0; angle < 360; angle += angleStep)
        {
            Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * zombieTransform.forward;
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
    IEnumerator zomidlemove()//���� ���� ��ǥ ��ȸ�ϱ�
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
        // ��ǥ ��ġ�� �����ϸ� �̵� ���� ����
        isMoving = false;
        StartCoroutine(RandomMoveCoroutine());
    }
    IEnumerator zommove()//�÷��̾�on ���� �̵�
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
                Debug.Log("���� ���ݽõ�");
                if(!atking)
                 zom_atk_anim();
                yield break;
            }
            yield return null;
        }
        
    }
    void animatorwalk()//�÷��̾�on/off ������ �ִϸ��̼�
    {
        Vector3 movementDirection = (transform.position - lastPosition).normalized;
        if (movementDirection.magnitude > 0.1f)//���� ��ǥ����� �ִϸ��̼� ������ ���⼳��
        {
            if (player != null)//�÷��̾�on
            {
                animator.SetBool("run", true);
                
            }
            else//�÷��̾�off
            {
                
                animator.SetBool("walk", true);
                 
            }
        }
        else//���� idle�ϋ�
        {
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
        }
        // ���� ��ġ�� ������ ��ġ�� ������Ʈ
        lastPosition = transform.position;
    }
    IEnumerator RandomMoveCoroutine()// ��� �ð� �Ŀ� ������ ��ǥ ��ġ ����
    {
        yield return new WaitForSeconds(moveInterval);
        if(player == null)
        {
            SetRandomTargetPosition();
            isMoving = true;
        }
    }
    void SetRandomTargetPosition()// ������ ��ǥ ��ġ ����
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
            Debug.Log("�Ͼ��");
        }
    }
    void zom_down()//���� �Ѿ�����
    {
        int zom_down_percentage = Random.Range(0, 10);
        if (zom_down_percentage > 1)
        {
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

        }
    }
    public void zombie_hit(GameObject player)//���� ���ݹ����� ���
    {
        atk_player = player;
        animator.SetBool("hit", true);
    }
    void zom_atk_anim()//���� ���ݽ��� �ִϸ��̼�
    {
        Debug.Log("����");
        atking = true;
        animator.SetBool("crawl_walk", false);
        animator.SetBool("run", false);
        animator.SetBool("walk", false);
        animator.SetBool("playeratk", true);
    }
    void zom_atk_try()//������ ���� ��������(���� �������� �Ǵܽ� ������� �Ÿ��� 1�����̸� ������ �����Ѵ�.)
    {
        animator.SetBool("playeratk", false);
        float player_atk = Vector3.Distance(player.transform.position, zombieTransform.position);
        if(player_atk <= atk_distance)
        {
            Debug.Log("������� ����");
            //zomhp.zombie_atk(player);
        }
    }
    void zom_atk_end()//������ �ٽ� �����ϱ����� �۾�
    {
        atking = false;
        findplayer();
    }
}
