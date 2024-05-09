using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_State_treatmentbar : MonoBehaviour, IPointerExitHandler  //, IPointerEnterHandler
{
    public GameObject Treatment_bar;

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    Treatment_detail.SetActive(true);
    //}

    public void OnPointerExit(PointerEventData eventData)
    {
        Treatment_bar.SetActive(false);
    }
}
