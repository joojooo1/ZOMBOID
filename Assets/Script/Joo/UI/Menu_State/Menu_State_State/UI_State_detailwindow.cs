using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class UI_State_detailwindow : MonoBehaviour, IPointerEnterHandler  //, IPointerExitHandler
{
    public body_point body_position;
    public Damage_Pattern _damagetype;
    public int position_Damage_Num = 0;
    public float _Bandage_Count = 0;
    public Transform Damage_icon_position;
    [SerializeField] UnityEngine.UI.Image icon_Image;

    public void SetImage(Sprite image, body_point position, Damage_Pattern damagetype)
    {
        icon_Image.sprite = image;
        body_position = position;
        _damagetype = damagetype;
        position_Damage_Num = Player_main.player_main.playerState.Player_body_point[(int)position].Get_DamageCount();
    }

    Vector3 pos = new Vector3(1f, -60f, 1);
    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_main.ui_main.ui_player_state.TreatmentBar.transform.position = Damage_icon_position.position + pos;
        UI_main.ui_main.ui_player_state.TreatmentBar.SetActive(true);
    }

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    if(UI_main.ui_main.ui_player_state.TreatmentBar.activeSelf == false)
    //        UI_main.ui_main.ui_player_state.TreatmentBar.SetActive(false);
    //}

}
