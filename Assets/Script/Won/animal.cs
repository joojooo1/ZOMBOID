using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class animal : MonoBehaviour
{
    public LayerMask player;
    Animator animator;
    float hp;
    float fox_max_hp = 30;
    float rabbit_max_hp = 20;
    float deer_max_hp = 40;
    float speed;
    float rabbit_speed = 1;
    float deer_speed = 3;
    float fox_speed = 2;
    GameObject TARGET;
    Vector3 runpos;
    Vector3 walkpos;
    private NavMeshAgent navMeshAgent;
    bool isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animalspec();
        StartCoroutine("playerfind");
    }

    // Update is called once per frame
    void Update()
    {
        if (TARGET != null)
        {
            StopCoroutine("animalidle");
            StopCoroutine("playerfind");
            navMeshAgent.SetDestination(runpos);
            if(transform.position == runpos)
            {
                animator.SetBool("run", false);
                TARGET = null;
                StartCoroutine("playerfind");
            }
        }
        else if (TARGET == null && isMove != true)
        { 
            StartCoroutine("animalidle");
            
        }
        if (transform.position == walkpos)
        {

            isMove = false;
            animator.SetBool("walk", false);
        }
    }
    void animalspec()
    {
        switch (gameObject.name)
        {
            case "fox":
                hp = fox_max_hp;
                speed = fox_speed;
                navMeshAgent.speed = speed;
                break;
            case "rabbit":
                hp = rabbit_max_hp;
                speed = rabbit_speed;
                navMeshAgent.speed = speed;
                break;
            case "deer":
                hp = deer_max_hp;
                speed = deer_speed;
                navMeshAgent.speed = speed;
                break;
            default:
                hp = 30;
                speed = 2;
                navMeshAgent.speed = speed;
                break;
        }
    }
    IEnumerator animalidle()
    {
        while (!isMove) 
        {
            animator.SetBool("walk", false);
            yield return new WaitForSeconds(5f);
            SetRandomwalkpos();
        }
    }
    void SetRandomwalkpos()// 랜덤한 목표 위치 설정
    {

        StopCoroutine("animalidle");
        animator.SetBool("walk", true);
        isMove = true;
        float randomX = Random.Range(-3f, 3f) + transform.position.x;
        float randomY = Random.Range(-3f, 3f) + transform.position.y;
        walkpos = new Vector3(randomX, randomY, transform.position.z);
        navMeshAgent.SetDestination(walkpos);
    }
    IEnumerator playerfind()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            float closestDistance = Mathf.Infinity;
            GameObject closestObject = null;

            // 플레이어 레이어를 가진 모든 오브젝트를 찾기
            Collider[] playerObjects = Physics.OverlapSphere(transform.position, Mathf.Infinity, player);
            for(int i= 0; i>playerObjects.Length; i++)
            {
                Debug.Log(playerObjects[i].name);
            }

            // 가장 가까운 오브젝트 찾기
            foreach (var playerObject in playerObjects)
            {
                float distance = Vector3.Distance(transform.position, playerObject.transform.position);
                if (distance < closestDistance)
                {
                    Debug.Log(playerObject.name);
                    closestDistance = distance;
                    closestObject = playerObject.gameObject;
                    if (distance < 3)
                    {
                        animator.SetBool("walk", false);
                        animator.SetBool("run", true);
                        Vector3 fleeDirection = transform.position - closestObject.transform.position;
                        runpos = transform.position + fleeDirection;
                        TARGET = closestObject; 
                        break;
                    }
                }
            }

        }
    }
}
