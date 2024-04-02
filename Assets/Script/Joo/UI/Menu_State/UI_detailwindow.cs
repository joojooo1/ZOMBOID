using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_detailwindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public body_point body_position;
    public int position_Damage_Num;
    public GameObject TreatmentBar;
    [SerializeField] UnityEngine.UI.Image icon_Image;

    public void SetImage(Sprite image, body_point positon)
    {
        icon_Image.sprite = image;
        body_position = positon;
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
