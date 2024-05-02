using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_InterActionTrigger_ByCamera : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<TileItsInfo>() != null)
        {
            Inventory_Player_Shown.InvPS.Storage_Contact_Refresh((short)other.GetComponentInParent<TileItsInfo>().Storage_Order, 814, true);
            other.GetComponentInParent<TileItsInfo>().gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponentInParent<TileItsInfo>().gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
    private void Update()
    {
        //멀티수정필
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
    }
}
