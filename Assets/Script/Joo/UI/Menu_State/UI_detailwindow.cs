using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_detailwindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TreatmentBar;
    [SerializeField] UnityEngine.UI.Image icon_Image;

    public void SetImage(Sprite image)
    {
        icon_Image.sprite = image;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TreatmentBar.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TreatmentBar.SetActive(false);
    }
}
