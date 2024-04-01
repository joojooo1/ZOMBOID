using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_detailwindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    body_point body_Point;
    int DamageCount;
    public GameObject TreatmentBar;
    [SerializeField] UnityEngine.UI.Image icon_Image;

    public void SetObject(Sprite image, body_point position)
    {
        icon_Image.sprite = image;
        body_Point = position;
        DamageCount++;
    }

    public void Damage_Destroy()
    {
        DamageCount--;
    }

    public int Damage_Count()
    {
        return DamageCount;
    }

    public body_point GetPosition()
    {
        return body_Point;
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
