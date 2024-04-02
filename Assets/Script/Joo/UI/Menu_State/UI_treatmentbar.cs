using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_treatmentbar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Treatment_detail;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Treatment_detail.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Treatment_detail.SetActive(false);
    }
}
