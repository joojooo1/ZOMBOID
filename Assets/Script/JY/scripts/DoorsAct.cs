using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorsAct : MonoBehaviour
{
    // Start is called before the first frame update
    // collider, shadow, 2dcollider 모두 문이 소유
    //문을 틀 자식으로, 문은 가려지지않음 창문도 동일
    //player 에서 2d trigger enter 로 상호작용 활성화 창문 동일

    public Sprite Door_Closed;
    public Sprite Door_Opened;
    bool Opened = false;
    
    SpriteRenderer This_Sprite;
    BoxCollider This_Block;
    ShadowCaster2D This_Shadow;
    float Timer = 0;
    public bool Entered;

    void Start()
    {
        This_Sprite = GetComponent<SpriteRenderer>();
        This_Block = GetComponentInChildren<BoxCollider>();
        This_Shadow = GetComponent<ShadowCaster2D>();
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
                This_Sprite.sprite = Door_Opened;
                This_Block.enabled = false;
                This_Shadow.enabled = false;
                Opened = true;

                GetComponentInChildren<PolygonCollider2D>().transform.localScale = new Vector3(-1, 1, 1);

                Timer++;
            }
            else
            {
                This_Sprite.sprite = Door_Closed;
                This_Block.enabled = true;
                This_Shadow.enabled = true;
                Opened = false;

                GetComponentInChildren<PolygonCollider2D>().transform.localScale = new Vector3(1, 1, 1);

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
