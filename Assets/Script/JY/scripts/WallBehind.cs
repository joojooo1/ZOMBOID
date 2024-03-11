using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class WallBehind : MonoBehaviour
{
    SpriteRenderer spr;
    
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        /* 쉐도우 캐스터 레이어 지정번호 출력
        ShadowCaster2D shadowCaster = GetComponent<ShadowCaster2D>();
        foreach (int layer in shadowCaster.m_ApplyToSortingLayers)
        {
            Debug.Log(layer);
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("2Dcolsuc");
        if (collision.CompareTag("Player"))
        {
            this.gameObject.layer = 4;
            spr.color = new Color(1, 1, 1, 0.2f);
            //GetComponent<ShadowCaster2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("2DcolOut");
        this.gameObject.layer = 0;
        spr.color = new Color(1, 1, 1, 1);
        //GetComponent<ShadowCaster2D>().enabled = true;
    }
}
