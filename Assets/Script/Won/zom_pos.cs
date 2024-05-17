using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;

public class zom_pos : MonoBehaviour
{
    public NavMeshAgent nav;
    public GameObject target;
    public Vector3 AUDIOPOS;
    public zom_targetpos zom_Targetpos;
    public GameObject zombody;
    public GameObject targetpos;
    public bool re = false;
    public bool audioposget = false;
    public float zomspeed;
    public GameObject[] respawn;

    public int ZOM_SN=0;
    // Start is called before the first frame update
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        zom_Targetpos = zombody.GetComponent<zom_targetpos>();

    }
    private void Start()
    {
        zomspeed = zombody.GetComponent<zombieHp>().curret_speed;
        zommovespeed(zomspeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (target != null) 
        {
            audioposget = false;

            nav.SetDestination(new Vector3(target.transform.position.x,target.transform.position.y,0));
            
        }
        
        if(nav.remainingDistance <= nav.stoppingDistance +0.1f && audioposget)
        {
            audioposget = false;
            //zom_Targetpos.idlepos();
        }
        
    }
    public void zomldiepos(Vector3 pos)
    {
        Vector3 direction = (pos - nav.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        nav.SetDestination(pos);
    }
   
    public void zommovespeed(float zomspeed)
    {
        nav.speed = zomspeed;
        Debug.Log("이동 재설정" + nav.speed);
    }
    void zomseverrot(Quaternion lookRotation)
    {

    }
    public void Audioposget(Vector3 pos)
    {
        audioposget = true;
        nav.SetDestination(new Vector3(pos.x, pos.y, 0));
    }
    
    public void zomon(GameObject player)
    {
        targetpos.SetActive(true);
        //zom_Targetpos.StartCoroutine("find");
    }
    public void zomoff(GameObject player)
    {
        //zom_Targetpos.StopCoroutine("find");
        targetpos.SetActive(false);
    }
    public void zomatkend()
    {
        nav.speed = zomspeed;
        Debug.Log("이속 정상화");
    }
    public void get_zom_spawn_pos(Vector3 pos)
    {
        zom_Targetpos.idle_pos_set(pos);
    }
    public void respawn_set()
    {
        nav.enabled = false;
        int I = Random.Range(0, respawn.Length);
        Debug.Log("리스폰 위치로"+ I);
        targetpos.SetActive(false);
        transform.position = respawn[I].transform.position;
        restart();
    }
    void restart()
    {
        nav.enabled = true;
        zom_Targetpos.tasd();
        zom_Targetpos.live = true;
        zombody.GetComponent<BoxCollider>().enabled = true;
        asd();
        Debug.Log("좀비 활동 시작");
    }
    public void asd()
    {
        zombody.GetComponent<zombieHp>().Restart();
        zombody.GetComponent<zom_targetpos>().Restart();
        Restart();
    }
    void Restart()
    {
        nav = GetComponent<NavMeshAgent>();
        zom_Targetpos = zombody.GetComponent<zom_targetpos>();
        Debug.Log("좀비 이동속도 조절" + zomspeed);
        target = null;
        audioposget = false;
        zommovespeed(zomspeed);
    }
}
