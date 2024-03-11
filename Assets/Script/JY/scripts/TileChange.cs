using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileChange : MonoBehaviour, IPointerClickHandler
{
    public GameObject Parent;
    public Camera MainCam;    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    //private void OnValidate()
    //{

    //    Debug.Log("OnValidate is executed.");
    //}

    void Update()
    {
    }

   public void OnPointerClick(PointerEventData eventData)
   {
        Debug.Log("aa");
        int IN = MapLoader.ML.ImageNum;
        GetComponent<SpriteRenderer>().sprite = MapLoader.ML.Sprites[IN];
   }

    public void Click2()
    {
        Debug.Log("aa");
        int IN = MapLoader.ML.ImageNum;
        GetComponent<SpriteRenderer>().sprite = MapLoader.ML.Sprites[IN];
    }
}
