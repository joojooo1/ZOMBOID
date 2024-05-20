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
                // 레이캐스트를 쏴서 zombieLayer를 가진 오브젝트를 찾음
                RaycastHit[] hits = Physics.RaycastAll(transform.position, forwardDirection, searchDistance, characterLayer);
                List<RaycastHit> zomHits = new List<RaycastHit>();

                foreach (RaycastHit hit in hits)
                {
                    // 레이에 맞은 오브젝트의 태그가 "zom"인 경우에만 리스트에 추가
                    if (hit.collider.CompareTag("zom"))
                    {
                        zomHits.Add(hit);
                    }
                }

                // 리스트를 배열로 변환하여 저장
                hits = zomHits.ToArray();
                // 레이캐스트 결과를 거리에 따라 정렬
                System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

                // 최대 3명의 좀비에 대해 처리
                for (int i = 0; i < Mathf.Min(Inventory_Player_Shown.InvPS.NowWeapon.W_Multi_Hit, hits.Length); i++)
                {
                    // 레이에 맞은 오브젝트 가져오기
                    GameObject hitObject = hits[i].collider.gameObject;
                    Debug.Log(hitObject);

                    // 가져온 오브젝트에서 ZombieHp 스크립트 가져오기
                    zombieHp zomHp = hitObject.GetComponent<zombieHp>();

                    // ZombieHp 스크립트가 있다면 GetDamage 함수 호출
                    if (zomHp != null)
                    {

                        Debug.Log("레이에 좀비 걸림 데미지 전송");
                        //zomHp.GetDamage(hitaudio, audioobject.GetComponent<player_rot>().playerpos.GetComponent<player_movement>().player_Main.Calculate_damage_to_Zombie());  // 또는 다른 처리를 수행
                    }
                }
                Debug.DrawRay(transform.position, forwardDirection * searchDistance, Color.red);
                Debug.Log("소리 전송");
            }
        }
    }
    public float searchDistance = 10f;
    public LayerMask characterLayer;
    public int maxZombiesDetected = 30;
    public float raycastAngle = 45f;
    public int raycastCount = 10;

    private float detectedZombies;
    public float damagePerAttack = 100;//test용 데미지 AttackZombies()에 main에서 데미지 계산식 적용후 공격 적용해야할것
    public void AttackZombies()
    {
        Vector3 forwardDirection = transform.forward;

        // 레이캐스트를 쏴서 zombieLayer를 가진 오브젝트를 찾음
        RaycastHit[] hits = Physics.RaycastAll(transform.position, forwardDirection, searchDistance, characterLayer);
        List<RaycastHit> zomHits = new List<RaycastHit>();

        foreach (RaycastHit hit in hits)
        {
            // 레이에 맞은 오브젝트의 태그가 "zom"인 경우에만 리스트에 추가
            if (hit.collider.CompareTag("zom"))
            {
                zomHits.Add(hit);
            }
        }

        // 리스트를 배열로 변환하여 저장
        hits = zomHits.ToArray();
        // 레이캐스트 결과를 거리에 따라 정렬
        System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

        // 최대 3명의 좀비에 대해 처리
        for (int i = 0; i < Mathf.Min(maxZombiesDetected, hits.Length); i++)
        {
            // 레이에 맞은 오브젝트 가져오기
            GameObject hitObject = hits[i].collider.gameObject;
            Debug.Log(hitObject);

            // 가져온 오브젝트에서 ZombieHp 스크립트 가져오기
            zombieHp zomHp = hitObject.GetComponent<zombieHp>();

            // ZombieHp 스크립트가 있다면 GetDamage 함수 호출
            if (zomHp != null)
            {
                Debug.Log("레이에 좀비 걸림 데미지 전송");
                //zomHp.GetDamage(gameObject, damagePerAttack);  // 또는 다른 처리를 수행
            }
        }
        Debug.DrawRay(transform.position, forwardDirection * searchDistance, Color.red);
    }
    public void atkset()
    {
        atk = false;
    }
}
