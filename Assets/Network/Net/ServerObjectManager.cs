using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ServerObjectManager : MonoBehaviour
{
    public static ServerObjectManager current;
    private void Awake()
    {
        if (current == null)
            current = this;
        else
            Debug.LogError("Not single ServerObjectManager");
    }

    public enum OBJECT_TYPE : byte
    {
        PLAYER = 0,
        ZOMBIEA,
        ZOMBIEB,
        ZOMBIEC,
    }
    [SerializeField]
    GameObject[] objectPrefab; //0 플레이어, 1 좀비A

    public void ClearNull()
    {
        for (int i = 0; i < ObjectArray.Count;)
        {
            if (ObjectArray[i] == null)
                ObjectArray.RemoveAt(i);
            else
                ++i;
        }
    }
    List<NetObject> ObjectArray = new List<NetObject>();
    public NetObject FindObject(int playerindex)
    {
        ClearNull();
        for (int i=0; i < ObjectArray.Count; ++i)
        {
            if (ObjectArray[i].player_index == playerindex)
            {
                return ObjectArray[i];
            }
        }
        return null;
    }
    public void RemoveAtObject(NetObject obj)
    {
        ObjectArray.Remove(obj);
    }

    public void DestroyObject(int playerindex)
    {
        NetObject obj = FindObject(playerindex);
        if (obj != null)
        {
            Destroy(obj.gameObject);
        }
        ClearNull();
    }
    public void MoveObject(int playeridex, Vector3 pos, float angle, OBJECT_TYPE Objecttype)
    {
        NetObject FindNetobj = FindObject(playeridex);
        if(FindNetobj == null)
        {
            GameObject obj = Instantiate(objectPrefab[(byte)Objecttype]);
            FindNetobj = obj.GetComponent<NetObject>();
            FindNetobj.CreateOjbect(playeridex, Objecttype);
            ObjectArray.Add(FindNetobj);
            obj.name = "Net_" + playeridex;

            obj.transform.position = pos;

            if (Objecttype == OBJECT_TYPE.PLAYER)
                CMainGame.current.PlayerName_REQ(playeridex);


        }
        FindNetobj.SetTarget(pos, Quaternion.Euler(0, angle, 0));
        //FindNetobj.transform.position = pos;
        //FindNetobj.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
    //서버 오브젝트 매니저
    public void PlayerShoot(int playeridex, float angle)
    {
        NetObject FindNetobj = FindObject(playeridex);
        FindNetobj.SetTargetRotation(Quaternion.Euler(0, angle, 0));

        PayerShooting shoot = FindNetobj.GetComponentInChildren<PayerShooting>();
        if (shoot != null)
            shoot.Shoot();
    }
    public void ENEMY_TARGET(int enemyIndex, int TargetIndex)
    {
        NetObject enemy = FindObject(enemyIndex);
        if (enemy != null)
        {
            NetObject FindNetobj = FindObject(TargetIndex);
            enemy.SetTarget(FindNetobj);
        }
    }

    public void PlayerHealth(int playeridex, float hp)
    {
        NetObject FindNetobj = FindObject(playeridex);
        if (FindNetobj == null)
            return;

        EnemyHealth enemyhealth = FindNetobj.GetComponent<EnemyHealth>();
        if (enemyhealth != null)
        {
            enemyhealth.ServerTakedamage(hp);
        }

        PlayerHealth health = FindNetobj.GetComponent<PlayerHealth>();
        if (health != null)
            health.ServerTakedamage(hp);
    }
}
