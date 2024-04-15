using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class UI_State_detailwindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public body_point body_position;
    public int position_Damage_Num = 0;
    public GameObject TreatmentBar;
    [SerializeField] UnityEngine.UI.Image icon_Image;

    public void SetImage(Sprite image, body_point position)
    {
        icon_Image.sprite = image;
        body_position = position;
        position_Damage_Num = Player_main.player_main.playerState.Player_body_point[(int)position].Get_DamageCount();
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
