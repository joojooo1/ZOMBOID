using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieHp : MonoBehaviour
{
    string zomType;
    float curret_zombie_hp;
    public float curret_speed;
    public float easy_max_hp = 50;
    public float normal_max_hp = 70;
    public float hard_max_hp = 100;
    public float easy_speed = 7;
    public float normal_speed = 10;
    public float hard_speed = 13;
    public bool zom_crawl;
    public GameObject zom_target;
    zombie_movement _Movement;
    // Start is called before the first frame update
    void Awake()
    {
        int zomType_probability = Random.Range(0, 10);
        if (zomType_probability > 6)
        {
            zomType = "normal";
            if (zomType_probability > 9)
            {
                zomType = "hard";
            }
        }
        else
            zomType = "easy";
        zomType = "hard";
        zom_stet();
        Debug.Log(zomType);
        _Movement = gameObject.GetComponent<zombie_movement>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(GameObject player,float Damage)
    {
        curret_zombie_hp -= Damage;
        _Movement.zom_down(player);
        if (curret_zombie_hp <= 0)
        {
            _Movement.live = false;
        }
    }
    public void zombie_atk(GameObject player)
    {
        //플레이어 데미지 보내기 bool로 성공보내기
    }

    void zom_stet()
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
    public void zom_data(GameObject zombie_target,bool zombie_crawl)
    {
        zom_target = zombie_target;
        zom_crawl = zombie_crawl;
    }
}
