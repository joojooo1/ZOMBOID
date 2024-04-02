using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class zom_targetpos : MonoBehaviour
{
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

    void findPlayer(GameObject target) 
    {
        zompos.target = target;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !zompos.target)
        {
            findPlayer(other.gameObject);
        }
    }
    public void idlepos()
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
