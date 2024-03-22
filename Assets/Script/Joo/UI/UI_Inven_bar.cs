using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;


public class UI_Inven_bar : MonoBehaviour
{
    [SerializeField]
    GameObject inven;


    private void Start()
    {
        //inven.SetActive(true);
    }
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            inven.SetActive(true);
        }
        else
        {
            inven.SetActive(false);
        }
    }


}
