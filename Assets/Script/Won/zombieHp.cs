using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieHp : MonoBehaviour
{
    string zomType;//좀비의 강함
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
    zombie_movement _Movement;
    // Start is called before the first frame update
    void Awake()
    {
        int zomType_probability = Random.Range(0, 10);
        if (zomType_probability > 6)//좀비의 강함 결정
        {
            zomType = "normal";
            if (zomType_probability > 9)
            {
                zomType = "hard";
            }
        }
        else
            zomType = "easy";
        zom_stet();
        _Movement = gameObject.GetComponent<zombie_movement>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(GameObject player,float Damage)//좀비가 받는 데미지
    {
        Debug.Log("데미지 들어옴");
        curret_zombie_hp -= Damage;
        _Movement.zom_down(player);
        if (curret_zombie_hp <= 0)
        {
            _Movement.zom_Die();
            _Movement.live = false;
        }
    }
    public void zombie_atk(GameObject player)
    {
        //플레이어 데미지 보내기 bool로 성공보내기
    }

    void zom_stet()//좀비의 강함에 따라 스텟결정
    {
        switch (zomType)
        {
            case "easy":
                curret_speed = easy_speed;
                curret_zombie_hp = easy_max_hp;
                break;
            case "normal":
                curret_speed = normal_speed;
                curret_zombie_hp = normal_max_hp;
                break;
            case "hard":
                curret_speed = hard_speed;
                curret_zombie_hp = hard_max_hp;
                break;
            default:
                curret_speed = easy_speed;
                curret_zombie_hp = easy_max_hp;
                break;
        }
    }
    public void zom_data(GameObject zombie_target,bool zombie_crawl)//좀비의 정보 저장(서버로 전송하기 위함)
    {
        zom_target = zombie_target;
        zom_crawl = zombie_crawl;
    }
}
