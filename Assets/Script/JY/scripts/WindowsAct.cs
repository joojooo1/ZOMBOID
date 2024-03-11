using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsAct : MonoBehaviour
{
    // Start is called before the first frame update
    // 변경 sprite 보유, 그림자 없음, 투명화 없음

    public Sprite Door_Closed;
    public Sprite Door_Opened;
    bool Opened = false;

    SpriteRenderer This_Sprite;
    BoxCollider This_Block;
    float Timer=0;
    public bool Entered;
    
    void Start()
    {
        This_Sprite = GetComponent<SpriteRenderer>();
        This_Block = GetComponentInChildren<BoxCollider>();
        Entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        Door_Change();
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
    }

    void Door_Change()
    {
        if (Entered == true && Timer <= 0 && Input.GetKeyDown(KeyCode.E))
        {
            if (Opened == false)
            {
                Debug.Log("Opened");
                This_Sprite.sprite = Door_Opened;
                This_Block.enabled = false;
                Opened = true;
                Timer++;
            }
            else
            {
                Debug.Log("Closed");
                This_Sprite.sprite = Door_Closed;
                This_Block.enabled = true;
                Opened = false;
                Timer++;
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("2Dcolsuc");
    //    if (collision.CompareTag("Player"))
    //    {
    //        this.gameObject.layer = 4;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("2DcolOut");
    //    this.gameObject.layer = 0;
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (!(Timer == 0))
    //    {
    //        Timer -= Time.deltaTime;
    //    }
    //    Door_Change();
    //}
}
