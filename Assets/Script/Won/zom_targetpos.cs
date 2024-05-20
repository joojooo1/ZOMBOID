using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class zom_targetpos : MonoBehaviour
{
    public GameObject player;
    public float detectionRadius = 5f;//인지범위의 반지름
    public float durationTime = 5f;//플레이어 인지범위 초과시 추적하는 시간
    public int rayCount = 18; // 원형으로 쏘는 Ray의 개수
    public LayerMask playerLayer; //플레이어 레이어
    zom_pos zompos;
    public GameObject zomnav;
    public bool live = true;
    public GameObject zombody;
    // Start is called before the first frame update
    
    void Awake()
    {
        gameObject.GetComponent<zombieHp>().enabled = true;
        //Transform parentTransform = transform.parent;
        zompos = zomnav.GetComponent<zom_pos>();

        if (zompos == null)
        {
            zompos = zomnav.GetComponent<zom_pos>();
        }
        Debug.Log("asd");
    }
    public void Restart()
    {
       zompos = zomnav.GetComponent<zom_pos>();

        if (zompos == null)
        {
            zompos = zomnav.GetComponent<zom_pos>();
        }
        tasd();
    }
    private void Start()
    {
        tasd();
        
    }
    Vector3 rayDirection;
    // Update is called once per frame
    void Update()
    {
        //transform.position = zomnav.transform.position;
        if (live)
        {
            transform.position = zomnav.transform.position;
            
        }
        if (zomnav.GetComponent<NavMeshAgent>().remainingDistance <= zomnav.GetComponent<NavMeshAgent>().stoppingDistance + 0.1f)
        {
            testset = true;
            
        }
        else
            testset = zompos.target;
        idle_pos_limit = asd.transform.position;
        if (!zombody.activeSelf)
        {
            zomnav.GetComponent<NavMeshAgent>().speed = zompos.zomspeed;
        }
    }
    public bool fnidplayertarget = false;
    public void findtarget(GameObject target)
    {
        if (target.tag == "Player")
        {

        }
        zompos.target = target;
    }
    public int count = 0;
    void findplayer() //주변 플레이어 탐색  ccccc
    {
        float angleStep = 360f / rayCount;
        for (float angle = 0; angle < 360; angle += angleStep)
        {
            
            rayDirection = Quaternion.Euler(0, 0, angle) * zompos.transform.forward;
            RaycastHit hit;
            float dis = detectionRadius;
            if (angle < 45 || angle > 315)//탐지범위가 좀비 전면일때 확장
            {
                dis += 5;
                for (float subAngle = angle - angleStep / 2; subAngle <= angle + angleStep / 2; subAngle += 3f)
                {
                    rayDirection = Quaternion.Euler(0, 0, subAngle) * zompos.transform.forward; // 더 촘촘하게 레이를 쏘기 위해 각도를 조절
                }
            }
            if (Physics.Raycast(transform.position, rayDirection, out hit, dis, playerLayer))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    if (!player)
                    {
                        count = 0;
                        player = hit.collider.gameObject;
                        findtarget(player);
                        //fnidplayertarget = true;
                        break;
                    }
                }
                
            }
        }
        
        if (player)
        {
            // 특정 태그를 가진 오브젝트를 무시하고자 할 때 실행할 작업
            count++;
            if (count > 20)
            {
                //fnidplayertarget = false;
                count = 0;
                zompos.target = null;
                idle_pos_set(transform.position);
                Debug.Log(transform.position);
                testset = true;
                player = null;
            }

        }
    }

    IEnumerator find()
    {
        while (true)
        {
            findplayer();
            yield return new WaitForSeconds(2F);
        }
    }
    public int test = 0;
    public bool testset = false;
    IEnumerator idlepos_set()
    {
        while (true)
        {
            if (testset)
            {
                test++;
                if (test > 2)
                {
                    idlepos();
                    test = 0;
                }
            }
            else if (zomnav.GetComponent<NavMeshAgent>().remainingDistance <= zomnav.GetComponent<NavMeshAgent>().stoppingDistance + 0.1f || player == null)
            {
                testset = true;
            }
            yield return new WaitForSeconds(3F);
        }
    }
    public void idlepos()
    {
        if (!zompos.audioposget&&idle_pos_limit != null)
        {
            Vector3 randomDirection = Random.insideUnitSphere.normalized;

            // 무작위한 이동 거리 설정
            float randomDistanceX = Random.Range(-limit_set, limit_set);
            float randomDistanceY = Random.Range(-limit_set, limit_set);

            // 무작위 좌표 설정 (예시로 (0, 0, 0)에서 10 범위 내의 무작위 좌표 설정)
            Vector3 randomPoint = new Vector3(randomDistanceX + idle_pos_limit.x, randomDistanceY + idle_pos_limit.y, transform.position.z);
            // 무작위 좌표가 NavMesh 위에 있는지 확인
            //Debug.Log(randomPoint);
            zompos.zomldiepos(randomPoint);
            //zompos.GetComponent<NavMeshAgent>().SetDestination(newPosition);

        }
    }
    public float limit_set = 10f;
    Vector3 idle_pos_limit;
    public void idle_pos_set(Vector3 pos)
    {
        idle_pos_limit = pos;
        idlepos();
    }
    public GameObject asd; 
    public void tasd()
    {
        idle_pos_limit = asd.transform.position;
        idle_pos_set(idle_pos_limit);
        fnidplayertarget = false;
        testset = false;
        player = null;
        StartCoroutine(idlepos_set());
        StartCoroutine(find());
    }
}
