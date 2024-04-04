using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class zom_targetpos : MonoBehaviour
{
    GameObject player;
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
            Debug.Log("�÷��̾� Ÿ�� �Ҹ��� ã��Ϸ�");
        }
        zompos.target = target;
    }
    void findplayer() //�ֺ� �÷��̾� Ž��  ccccc
    {
        Debug.Log("�÷��̾� Ž��");
        float angleStep = 360f / rayCount;
        for (float angle = 0; angle < 360; angle += angleStep)
        {
            Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * zompos.transform.right;
            RaycastHit hit;
            float dis = detectionRadius;
            if (angle < 45 || angle > 315)//Ž�������� ���� �����϶� Ȯ��
            {
                dis += 5;
            }
            if (Physics.Raycast(transform.position, rayDirection, out hit, dis, playerLayer))
            {
                if (!hit.collider.CompareTag("Player"))
                {
                    // Ư�� �±׸� ���� ������Ʈ�� �����ϰ��� �� �� ������ �۾�
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
            Debug.Log("���� ��ǥ ����");
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
