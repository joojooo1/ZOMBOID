using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class zom_targetpos : MonoBehaviour
{
    public GameObject player;
    public float detectionRadius = 5f;//���������� ������
    public float durationTime = 5f;//�÷��̾� �������� �ʰ��� �����ϴ� �ð�
    public int rayCount = 18; // �������� ��� Ray�� ����
    public LayerMask playerLayer; //�÷��̾� ���̾�
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
    void findplayer() //�ֺ� �÷��̾� Ž��  ccccc
    {

        float angleStep = 360f / rayCount;
        for (float angle = 0; angle < 360; angle += angleStep)
        {
            rayDirection = Quaternion.Euler(0, 0, angle) * zompos.transform.forward;
            RaycastHit hit;
            float dis = detectionRadius;
            if (angle < 45 || angle > 315)//Ž�������� ���� �����϶� Ȯ��
            {
                dis += 5;
                for (float subAngle = angle - angleStep / 2; subAngle <= angle + angleStep / 2; subAngle += 3f)
                {
                    rayDirection = Quaternion.Euler(0, 0, subAngle) * zompos.transform.forward; // �� �����ϰ� ���̸� ��� ���� ������ ����

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
            // Ư�� �±׸� ���� ������Ʈ�� �����ϰ��� �� �� ������ �۾�
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

            // ������ ��ǥ ���� (���÷� (0, 0, 0)���� 10 ���� ���� ������ ��ǥ ����)
            Vector3 randomPoint = new Vector3(Random.Range(-3F, 3f) + transform.position.x, Random.Range(-3f, 3f) + transform.position.y, transform.position.z);

            // NavMeshHit ���� ����
            NavMeshHit hit;

            // ������ ��ǥ�� NavMesh ���� �ִ��� Ȯ��
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                zompos.zomldiepos(randomPoint);
            }

        }
    }
    
}
