using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class player_atk : MonoBehaviour
{
    public AudioClip Clip;
    public GameObject audioobject;
    player_rot audio;
    public bool atk = false;
    // Start is called before the first frame update
    void Start()
    {   
        audio = audioobject.GetComponent<player_rot>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation= audioobject.transform.localRotation;
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0) && !atk)
            {
                atk = true;
                Vector3 forwardDirection = transform.forward;
                //searchDistance = Random.Range(Inventory_Player_Shown.Equipment[XLine].GetComponent<Item_Weapons>().W_Minimum_Range, Inventory_Player_Shown.Equipment[XLine].GetComponent<Item_Weapons>().W_Maximum_Range);
                AudioClip hitaudio;// = Equipment.audioClip;
                // ����ĳ��Ʈ�� ���� zombieLayer�� ���� ������Ʈ�� ã��
                RaycastHit[] hits = Physics.RaycastAll(transform.position, forwardDirection, searchDistance, characterLayer);
                List<RaycastHit> zomHits = new List<RaycastHit>();

                foreach (RaycastHit hit in hits)
                {
                    // ���̿� ���� ������Ʈ�� �±װ� "zom"�� ��쿡�� ����Ʈ�� �߰�
                    if (hit.collider.CompareTag("zom"))
                    {
                        zomHits.Add(hit);
                    }
                }

                // ����Ʈ�� �迭�� ��ȯ�Ͽ� ����
                hits = zomHits.ToArray();
                // ����ĳ��Ʈ ����� �Ÿ��� ���� ����
                System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

                // �ִ� 3���� ���� ���� ó��
                for (int i = 0; i < Mathf.Min(Inventory_Player_Shown.InvPS.NowWeapon.W_Multi_Hit, hits.Length); i++)
                {
                    // ���̿� ���� ������Ʈ ��������
                    GameObject hitObject = hits[i].collider.gameObject;
                    Debug.Log(hitObject);

                    // ������ ������Ʈ���� ZombieHp ��ũ��Ʈ ��������
                    zombieHp zomHp = hitObject.GetComponent<zombieHp>();

                    // ZombieHp ��ũ��Ʈ�� �ִٸ� GetDamage �Լ� ȣ��
                    if (zomHp != null)
                    {

                        Debug.Log("���̿� ���� �ɸ� ������ ����");
                        //zomHp.GetDamage(hitaudio, audioobject.GetComponent<player_rot>().playerpos.GetComponent<player_movement>().player_Main.Calculate_damage_to_Zombie());  // �Ǵ� �ٸ� ó���� ����
                    }
                }
                Debug.DrawRay(transform.position, forwardDirection * searchDistance, Color.red);
                Debug.Log("�Ҹ� ����");
            }
        }
    }
    public float searchDistance = 10f;
    public LayerMask characterLayer;
    public int maxZombiesDetected = 30;
    public float raycastAngle = 45f;
    public int raycastCount = 10;

    private float detectedZombies;
    public float damagePerAttack = 100;//test�� ������ AttackZombies()�� main���� ������ ���� ������ ���� �����ؾ��Ұ�
    public void AttackZombies()
    {
        Vector3 forwardDirection = transform.forward;

        // ����ĳ��Ʈ�� ���� zombieLayer�� ���� ������Ʈ�� ã��
        RaycastHit[] hits = Physics.RaycastAll(transform.position, forwardDirection, searchDistance, characterLayer);
        List<RaycastHit> zomHits = new List<RaycastHit>();

        foreach (RaycastHit hit in hits)
        {
            // ���̿� ���� ������Ʈ�� �±װ� "zom"�� ��쿡�� ����Ʈ�� �߰�
            if (hit.collider.CompareTag("zom"))
            {
                zomHits.Add(hit);
            }
        }

        // ����Ʈ�� �迭�� ��ȯ�Ͽ� ����
        hits = zomHits.ToArray();
        // ����ĳ��Ʈ ����� �Ÿ��� ���� ����
        System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

        // �ִ� 3���� ���� ���� ó��
        for (int i = 0; i < Mathf.Min(maxZombiesDetected, hits.Length); i++)
        {
            // ���̿� ���� ������Ʈ ��������
            GameObject hitObject = hits[i].collider.gameObject;
            Debug.Log(hitObject);

            // ������ ������Ʈ���� ZombieHp ��ũ��Ʈ ��������
            zombieHp zomHp = hitObject.GetComponent<zombieHp>();

            // ZombieHp ��ũ��Ʈ�� �ִٸ� GetDamage �Լ� ȣ��
            if (zomHp != null)
            {
                Debug.Log("���̿� ���� �ɸ� ������ ����");
                //zomHp.GetDamage(gameObject, damagePerAttack);  // �Ǵ� �ٸ� ó���� ����
            }
        }
        Debug.DrawRay(transform.position, forwardDirection * searchDistance, Color.red);
    }
    public void atkset()
    {
        atk = false;
    }
}
