using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieHp : MonoBehaviour
{
    string zomType;//������ ����
    public float curret_zombie_hp;//���� ������ ü��
    public float curret_speed;//���� ������ �̵��ӵ�
    public float easy_max_hp = 50;//���� ������ �ִ� ü��
    public float normal_max_hp = 70;//���� ������ �ִ� ü��
    public float hard_max_hp = 100;//���� ������ �ִ� ü��
    public float easy_speed = 1;//���� ������ �̵� �ӵ�
    public float normal_speed = 1;//���� ������ �̵� �ӵ�
    public float hard_speed = 1;//���� ������ �̵� �ӵ�
    public bool zom_crawl;//���� �Ѿ��� �ִ°�
    public GameObject zom_target;//���� �߰��ϴ� ��ǥ
    zombie_movement _Movement;
    // Start is called before the first frame update
    void Awake()
    {
        int zomType_probability = Random.Range(0, 10);
        if (zomType_probability > 6)//������ ���� ����
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

    public void GetDamage(GameObject player,float Damage)//���� �޴� ������
    {
        Debug.Log("������ ����");
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
        //�÷��̾� ������ ������ bool�� ����������
    }

    void zom_stet()//������ ���Կ� ���� ���ݰ���
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
    public void zom_data(GameObject zombie_target,bool zombie_crawl)//������ ���� ����(������ �����ϱ� ����)
    {
        zom_target = zombie_target;
        zom_crawl = zombie_crawl;
    }
}
