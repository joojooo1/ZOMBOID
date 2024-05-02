using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_State_Info : MonoBehaviour
{
    [SerializeField] Transform Characteristic_Playing_Info_Window;
    [SerializeField] GameObject Characteristic_Prefab_Info;

    public List<UI_Title_Characteristic_prefab> characteristics_On_Playing = new List<UI_Title_Characteristic_prefab>();
    public static UI_State_Info Instance;

    public UnityEngine.UI.Text player_job_text;

    private void OnEnable()
    {
        Instance = this;



        for (int i = 0; i < Player_Characteristic.current.characteristics_Player.Count;)
        {
            characteristics_On_Playing.Add(Player_Characteristic.current.characteristics_Player[i]);

            GameObject tempObj = null;
            tempObj = Instantiate(Characteristic_Prefab_Info, Characteristic_Playing_Info_Window);
            tempObj.GetComponent<UI_Title_Characteristic_prefab>().SetCharacteristic(characteristics_On_Playing[i].Prefab);
            tempObj.transform.SetSiblingIndex(0);
            i++;
        }


    }

    private void OnDisable()
    {
        foreach (Transform child in Characteristic_Playing_Info_Window)
        {
            Destroy(child.gameObject);
        }

        characteristics_On_Playing.Clear();
    }

    public GameObject Characteristic_info_Window;
    public UnityEngine.UI.Text Characteristic_name;

    public void Open_text(string _name, Transform position)
    {
        Characteristic_name.text = _name;
        Characteristic_info_Window.transform.position = position.position;
        Vector3 temp = new Vector3(40, -10, 0);
        Characteristic_info_Window.transform.position += temp;
        Characteristic_info_Window.SetActive(true);
    }

    public void Close_text()
    {
        Characteristic_info_Window.SetActive(false);
    }
}
