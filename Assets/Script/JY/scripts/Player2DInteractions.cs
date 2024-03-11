using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DInteractions : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*6.NavIg 7.P Interaction 8.WallBehind*/
        if(collision.gameObject.layer == 8)
        {
            collision.transform.parent.gameObject.layer = 4;
            SpriteRenderer spr=collision.gameObject.GetComponentInParent<SpriteRenderer>();
            spr.color = new Color(1, 1, 1, 0.2f);
        }
        else if (collision.gameObject.layer == 7)
        {
            if (collision.transform.parent.gameObject.GetComponent<DoorsAct>())
            {
                collision.transform.parent.gameObject.GetComponent<DoorsAct>().Entered = true;
            }
            else if (collision.transform.parent.gameObject.GetComponent<WindowsAct>())
            {
                collision.transform.parent.gameObject.GetComponent<WindowsAct>().Entered = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.transform.parent.gameObject.layer = 0;
            SpriteRenderer spr = collision.gameObject.GetComponentInParent<SpriteRenderer>();
            spr.color = new Color(1, 1, 1, 1);
        }
        else if (collision.gameObject.layer == 7)
        {
            if (collision.transform.parent.gameObject.GetComponent<DoorsAct>())
            {
                collision.transform.parent.gameObject.GetComponent<DoorsAct>().Entered = false;
            }
            else if (collision.transform.parent.gameObject.GetComponent<WindowsAct>())
            {
                collision.transform.parent.gameObject.GetComponent<WindowsAct>().Entered = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

}
