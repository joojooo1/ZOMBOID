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
    public GameObject TARGET;
    Vector3 runpos;
    Vector3 walkpos;
    private NavMeshAgent navMeshAgent;
    bool isMove = false;
    public GameObject animel_ani;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = animel_ani.GetComponent<Animator>();//
        animalspec();//
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
            
        }
        else if (TARGET == null && isMove != true)
        { 
            StartCoroutine("animalidle");
            
        }
        if (transform.position == walkpos)
        {

            isMove = false;
        }
        if (transform.position == runpos)
        {
            Debug.Log("도망 완료");
            TARGET = null;
            StartCoroutine("playerfind");
        }
    }
    void animalspec()//
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
            yield return new WaitForSeconds(5f);
            SetRandomwalkpos();
        }
    }
    public void SetRandomwalkpos()// 랜덤한 목표 위치 설정
    {

        // 무작위 좌표 설정 (예시로 (0, 0, 0)에서 10 범위 내의 무작위 좌표 설정)
        Vector3 walkpos = new Vector3(Random.Range(-3F, 3f) + transform.position.x, Random.Range(-3f, 3f) + transform.position.y, transform.position.z);

        // NavMeshHit 변수 생성
        NavMeshHit hit;

        // 무작위 좌표가 NavMesh 위에 있는지 확인
        if (NavMesh.SamplePosition(walkpos, out hit, 10f, NavMesh.AllAreas))
        {
            StopCoroutine("animalidle");
            isMove = true;
            navMeshAgent.SetDestination(walkpos);
            Debug.Log("보냄");
        }
        
        
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
                   
                    closestDistance = distance;
                    closestObject = playerObject.gameObject;
                    if (distance < 3)
                    {

                        Vector3 fleeDirection = transform.position - closestObject.transform.position;
                        runpos = transform.position + fleeDirection;
                        TARGET = closestObject; 
                        break;
                    }
                }
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<animal>())
        {
            SetRandomwalkpos();
            Debug.Log("동물 충돌 좌표 재설치");
        }
    }
    
}
