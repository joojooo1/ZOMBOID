using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class zom_targetpos : MonoBehaviour
{
    GameObject player;
    public float detectionRadius = 5f;//인지범위의 반지름
    public float durationTime = 5f;//플레이어 인지범위 초과시 추적하는 시간
    public int rayCount = 18; // 원형으로 쏘는 Ray의 개수
    public LayerMask playerLayer; //플레이어 레이어
    public zom_pos zompos;
    public GameObject zomnav;
    public bool live = true;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        //Transform parentTransform = transform.parent;
        zom_pos zompos = zomnav.GetComponent<zom_pos>();

        if (zompos == null)
        {
            zompos = zomnav.GetComponent<zom_pos>();
        }

        StartCoroutine("find");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = zomnav.transform.position;
        if (!live)
        {
            //transform.position = zomnav.transform.position;
            collider.enabled = false;
        }
    }
    bool fnidplayertarget = false;
    public void findtarget(GameObject target) 
    {
        if (target.tag == "Player")
        {
            Debug.Log("플레이어 타겟 소리로 찾기완료");
        }
        zompos.target = target;
    }
    void findplayer() //주변 플레이어 탐색  ccccc
    {
        Debug.Log("플레이어 탐색");
        float angleStep = 360f / rayCount;
        for (float angle = 0; angle < 360; angle += angleStep)
        {
            Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * zompos.transform.right;
            RaycastHit hit;
            float dis = detectionRadius;
            if (angle < 45 || angle > 315)//탐지범위가 좀비 전면일때 확장
            {
                dis += 5;
            }
            if (Physics.Raycast(transform.position, rayDirection, out hit, dis, playerLayer))
            {
                if (!hit.collider.CompareTag("Player"))
                {
                    // 특정 태그를 가진 오브젝트를 무시하고자 할 때 실행할 작업
                    return;
                }
                if (hit.collider.gameObject.tag == "Player")
                {
                    if (!player)
                    {
                        player = hit.collider.gameObject;
                        findtarget(player);
                        fnidplayertarget = true;
                        break;
                    }
                }
                if (player = hit.collider.gameObject)
                {
                    fnidplayertarget = true;
                }
                else
                {
                    fnidplayertarget = false;
                }
            }
            
        }
    }
    IEnumerator find()
    {
        while (true)
        {
            if (fnidplayertarget)
            {
                findplayer();
            }
            else
            {
                player = null;
                findplayer();
                
            }
            yield return new WaitForSeconds(5);
        }
    }
    public void idlepos()
    {
        if (!zompos.audioposget)
        {
            Debug.Log("렌덤 좌표 설정");
            // 무작위 좌표 설정 (예시로 (0, 0, 0)에서 10 범위 내의 무작위 좌표 설정)
            Vector3 randomPoint = new Vector3(Random.Range(-3F, 3f) + transform.position.x, Random.Range(-3f, 3f) + transform.position.y, transform.position.z);

            // NavMeshHit 변수 생성
            NavMeshHit hit;

            // 무작위 좌표가 NavMesh 위에 있는지 확인
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                zompos.zomldiepos(randomPoint);
            }

        }
    }
}
