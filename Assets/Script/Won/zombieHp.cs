using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.XR;

public class zombieHp : MonoBehaviour
{
    public float curret_zombie_hp;//현재 좀비의 체력
    public float curret_speed;//현재 좀비의 이동속도
    public float easy_max_hp = 50;//약한 좀비의 최대 체력
    public float normal_max_hp = 70;//보통 좀비의 최대 체력
    public float hard_max_hp = 100;//강한 좀비의 최대 체력
    public float easy_speed = 1;//약한 좀비의 이동 속도
    public float normal_speed = 1;//보통 좀비의 이동 속도
    public float hard_speed = 1;//강한 좀비의 이동 속도
    public bool zom_crawl;//좀비가 넘어져 있는가
    public GameObject zom_target;//좀비가 추격하는 목표
    public zom_targetpos _Movement;
    public zom_anime anime;
    public GameObject zom_nav;
    public GameObject zom_body;
    // Start is called before the first frame update
    void Awake()
    {
        zom_stet();
        _Movement = GetComponent<zom_targetpos>();
        anime = zom_body.GetComponent<zom_anime>();
    }
    private void Start()
    {
    }
    public void Restart()
    {
        zom_stet();
        _Movement = GetComponent<zom_targetpos>();
        anime = zom_body.GetComponent<zom_anime>();
        zom_nav.GetComponent<zom_pos>().zomspeed = curret_speed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(GameObject player,float Damage)//좀비가 받는 데미지
    {
        curret_zombie_hp -= Damage;
        anime.animatersetTrigger("hit");
        Debug.Log("데미지 들어옴");
    }
    public void up_down()
    {
        Debug.Log("넘어지기 판단");
        float down = Random.Range(0, 10);
        if (curret_zombie_hp <= 0)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            down += 10;
        }
        if (down > 7)
        {
            anime.animatorsetBool("down",true);
        }
        
    }
    public void zombie_atk(GameObject player)
    {
        //플레이어 데미지 보내기 bool로 성공보내기
    }
    public enum ZombieType
    {
        Easy,
        Normal,
        Hard
    }
    public string zomTypetest;
    public ZombieType zomType;
    public void zom_stet()//좀비의 강함에 따라 스텟결정
    {
        Debug.Log("좀비 스텟 재설정");
        zom_target = null;
        int zomType_probability = Random.Range(0, 10);
        if (zomType_probability > 9)
            zomType = ZombieType.Hard;
        else if (zomType_probability > 6)
            zomType = ZombieType.Normal;
        else
            zomType = ZombieType.Easy;

        switch (zomType)
        {
            case ZombieType.Easy:
                curret_speed = easy_speed;
                curret_zombie_hp = easy_max_hp;
                zom_nav.GetComponent<zom_pos>().zomspeed = curret_speed;
                zomTypetest = "easy";
                break;
            case ZombieType.Normal:
                curret_speed = normal_speed;
                curret_zombie_hp = normal_max_hp;
                zom_nav.GetComponent<zom_pos>().zomspeed = curret_speed;
                zomTypetest = "normal";
                break;
            case ZombieType.Hard:
                curret_speed = hard_speed;
                curret_zombie_hp = hard_max_hp;
                zom_nav.GetComponent<zom_pos>().zomspeed = curret_speed;
                zomTypetest = "hard";
                break;
            default:
                curret_speed = easy_speed;
                curret_zombie_hp = easy_max_hp;
                zom_nav.GetComponent<zom_pos>().zomspeed = curret_speed;
                break;
        }
        //zom_nav.GetComponent<zom_pos>().zomatkend();
    }
    public void zom_data(GameObject zombie_target,bool zombie_crawl)//좀비의 정보 저장(서버로 전송하기 위함)
    {
        zom_target = zombie_target;
        zom_crawl = zombie_crawl;
    }
}
