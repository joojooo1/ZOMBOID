using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Ending : MonoBehaviour
{
    public UnityEngine.UI.Text text0;
    public UnityEngine.UI.Text text1;
    private void OnEnable()
    {
        AudioManager.SoundManager.Player_Dead();
        text0.text = "당신은 " + GameManager.gameManager.Get_Elapsed_time() + "일동안 생존하였습니다.";
        text1.text = "당신은 생존하는 동안 " + GameManager.gameManager.Get_killed_count() + "마리의 좀비를 제거하였습니다.";
    }

    public GameObject Canvas_Ending;
    public GameObject Canvas_Title;
    public GameObject Canvas_Title_menu;
    public GameObject Canvas_Title_Name;
    public GameObject Canvas_Title_Char;
    public GameObject Canvas_Title_Starting_Window;
    public UnityEngine.UI.InputField InputField_title;
    public UnityEngine.UI.Dropdown dropdown_title;
    public GameObject Nextbutton_title_name;

    public void Set_Restart()
    {
        Player_Characteristic.current.ReStart_Characteristic();
        InputField_title.text = "";
        dropdown_title.value = 0;
        Nextbutton_title_name.SetActive(false);
        UI_Title.ui_title.On_Button(3);

        Canvas_Ending.SetActive(false);
        Canvas_Title.SetActive(true);
        Canvas_Title_menu.SetActive(true);
        Canvas_Title_Name.SetActive(false);
        Canvas_Title_Char.SetActive(false);
        Canvas_Title_Starting_Window.SetActive(false);
    }
}
