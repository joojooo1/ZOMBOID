
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_InterActionTrigger_ByCamera : MonoBehaviour
{
    public static Map_InterActionTrigger_ByCamera InterActionRay;

    public GameObject Player;
    public bool Player_Exiest;

    private void Awake()
    {
        InterActionRay = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<TileItsInfo>() != null)
        {
            Inventory_Player_Shown.InvPS.Storage_Contact_Refresh((short)other.GetComponentInParent<TileItsInfo>().Storage_Order, 8140, true);
            other.GetComponentInParent<TileItsInfo>().gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);
            GameObject Tile = other.GetComponentInParent<TileItsInfo>().gameObject;

            Inventory_Player_Shown.InvPS.Storage_Contract(Tile.transform, 0, false);//먼저 지우고

            Furniture_BreakAble breakableComponent = null;
            foreach (Transform child in other.GetComponentInParent<TileItsInfo>().gameObject.transform)
            {
                Furniture_BreakAble childBreakable = child.GetComponent<Furniture_BreakAble>();
                if (childBreakable != null)
                {
                    // Furniture_Breakable 컴포넌트를 가진 자식을 발견했습니다.
                    breakableComponent = childBreakable;
                    break;
                }
            }

            if (breakableComponent != null)
            {
                if (breakableComponent.gameObject.CompareTag("Storage"))
                {
                    Debug.Log("Storage Found");
                    // 작업 수행
                    Inventory_Player_Shown.InvPS.Storage_Contract(other.transform, (short)breakableComponent.StorageNum, true);
                }
            }
            else
            {
                Debug.Log("No Furniture_Breakable child found in the collided GameObject.");
            }
            //foreach (Transform kid in Tile.GetComponentsInChildren<Transform>()) 
            //{
            //    if (kid.gameObject.GetComponentInChildren<Furniture_BreakAble>() != null)
            //    {
            //        //다시 생성
            //        if (kid.gameObject.GetComponentInChildren<Furniture_BreakAble>().gameObject.CompareTag("Storage"))
            //        {
            //            Debug.Log("StorageFound");
            //            Inventory_Player_Shown.InvPS.Storage_Contract(Tile.transform, (short)kid.gameObject.GetComponentInChildren<Furniture_BreakAble>().StorageNum, true);
            //        }
            //    }

            //}
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<TileItsInfo>() != null)
        {
            other.GetComponentInParent<TileItsInfo>().gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
    private void Update()
    {
        if (Player_Exiest)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
        }
    }
}
