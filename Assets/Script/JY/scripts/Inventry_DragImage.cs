using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventry_DragImage : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Image;
    public GameObject Border;

    public void Change_Image(Sprite image, int Width, int Height, int Canvas_Wid, int Canvas_Hei)
    {
        Image.GetComponent<Image>().sprite = image;

        RectTransform canvasRectTransform = GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        canvasRectTransform.sizeDelta = new Vector2(Canvas_Wid, Canvas_Hei);

        canvasRectTransform.anchorMin = new Vector2(0f, 1f);
        canvasRectTransform.anchorMax = new Vector2(0f, 1f);
        //canvasRectTransform.localPosition = new Vector3(((Width - 1) * (Mathf.Round((Canvas_Wid / 2) * 10f) / 10f)), ((-1f) * (Height - 1) * (Mathf.Round((Canvas_Hei / 2) * 10f) / 10f)), 0f);
        canvasRectTransform.localPosition = Vector3.zero;

    }

    public void Change_Border_Color(bool TOF)
    {
        if (TOF)
        {
            Border.GetComponent<Image>().color = new Color(0, 1, 0, 1);
        }
        else
        {
            Border.GetComponent<Image>().color = new Color(1, 0, 0, 1);
        }
    }
}
