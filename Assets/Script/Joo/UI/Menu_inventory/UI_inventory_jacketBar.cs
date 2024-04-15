using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_inventory_jacketBar : MonoBehaviour, IPointerClickHandler
{
    public GameObject Bar;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Bar.activeSelf)
        {
            Bar.SetActive(false);
        }
        else
        {
            Bar.SetActive(true);
        }
    }
}
