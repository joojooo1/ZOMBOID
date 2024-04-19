using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_inventory_jacketBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Bar;
    float Timer = 0;
    bool Exit=false;

    private void Update()
    {
        if (Timer > 1)
        {
            Bar.transform.localPosition = new Vector3(-31.8235f,500,0);
            Exit = false;
        }
        if (Exit)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            Timer = 0;
        }
    }
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (Bar.activeSelf)
    //    {
    //        Bar.SetActive(false);
    //    }
    //    else
    //    {
    //        Bar.SetActive(true);
    //    }
    //}

    public void OnPointerEnter(PointerEventData eventData)
    {

        Bar.transform.localPosition = new Vector3(-31.8235f, 0, 0);
        Exit = false;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Exit = true;
    }
}
