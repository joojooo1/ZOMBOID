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

       
    }
    Vector3 rayDirection;
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
    public bool fnidplayertarget = false;
    public void findtarget(GameObject target)
    {
        if (target.tag == "Player")
        {

        }
        zompos.target = target;
    }
    int count = 0;
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
                        fnidplayertarget = true;
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

                count = 0;
                player = null;
                zompos.target = null;
                idlepos();
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
            yield return new WaitForSeconds(2F);
        }
    }
    public void idlepos()
    {
        if (!zompos.audioposget)
        {

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
