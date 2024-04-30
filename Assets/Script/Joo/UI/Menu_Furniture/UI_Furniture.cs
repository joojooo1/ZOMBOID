using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Furniture : MonoBehaviour, IPointerClickHandler
{
    public GameObject Furniture_window;    // 추후에 맵상 가구 등 설치하는 기능으로 수정
    public Sprite[] Furniture_Button_Image;
    public UnityEngine.UI.Image Furniture_Button_current;

    private void Start()
    {
        if (Furniture_window.activeSelf) { Furniture_Button_current.sprite = Furniture_Button_Image[1]; }
        else { Furniture_Button_current.sprite = Furniture_Button_Image[0]; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Furniture_window.activeSelf)
        {
            Furniture_window.SetActive(false);
            Furniture_Button_current.sprite = Furniture_Button_Image[0];
        }
        else
        {
            Furniture_window.SetActive(true);
            Furniture_Button_current.sprite = Furniture_Button_Image[1];
        }
    }

}
