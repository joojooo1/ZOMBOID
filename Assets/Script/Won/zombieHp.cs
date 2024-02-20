using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieHp : MonoBehaviour
{
    float curret_zombie_hp;
    public float zombie_max_hp = 100;
    zombie_movement _Movement;
    // Start is called before the first frame update
    void Start()
    {
        curret_zombie_hp = zombie_max_hp;
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
}
