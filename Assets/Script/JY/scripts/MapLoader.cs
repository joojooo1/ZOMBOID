using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public static MapLoader ML;

    [SerializeField]
    public GameObject Tile1;
    [SerializeField]
    public GameObject Tile2;
    [SerializeField]
    Transform GroundLevel;
    [SerializeField]
    Transform GroundLevel2;

    [SerializeField]
    public GameObject[] Tiles;

    List<GameObject> TilesList;

    [SerializeField]
    public Sprite[] Sprites;

    int NumberofHorizental=10;
    int NumberofVertical=10;

    public int ImageNum = 0;

    float RangeBetweenX = 0.63f;
    float RangeBetweenZ = 0.315f;

    public int LengthofX;
    public int LengthofY;

    bool LoadComplete=false;

    private void Awake()
    {
        ML = this;
    }
    //private void OnValidate()81
    //{
    //    List<Transform> round = new List<Transform>(GroundLevel.GetComponentsInChildren<Transform>());
    //    if (10 > round.Count) { StartGeneratingTiles(15, 15); }
    //    Debug.Log("onvalidate is executed. in MapLoader");
    //}
    private void Start()
    {
        LengthofX = 0;
        LengthofY = 0;
        ImageNum = 0;
        TilesList = new List<GameObject> { };
        //StartGeneratingTiles(10, 10);
        if (Tiles.Length == 0)
        {
            StartGeneratingTilesQuater(LengthofX, LengthofY, 0f);
            //StartGeneratingTilesQuater2(LengthofX, LengthofY, 1.95f);
        }
        Tiles=TilesList.ToArray();
        Debug.Log(Inventory_Library.IL.Inventory_DB.Count + "개의 인벤토리 총 생성됨");
        LoadComplete = true;
        //Debug.Log("MLCMP");
        Inventory_Library.IL.Spawn_Items(7);
        
    }

    public void Checking_Map_Load()
    {
        UI_Starting.US.Map_Setting_complete = LoadComplete;
    }

    //void StartGeneratingTiles(int LengthofX,int LengthofY,float yhight)//가로로 열단위 생성
    //{
    //    float[] LocationsX = new float[LengthofX];
    //    float[] LocationsY = new float[LengthofY];

    //    for (int o = 1; o < LengthofY+1;++o)
    //    {
    //        if (o % 2 > 0)//홀수
    //        {
    //            for (int i = 0; i < LengthofX/2; ++i)
    //            {
    //                GameObject inst = Instantiate(Tile1, new Vector3(GroundLevel.transform.position.x+RangeBetweenX * i*2, yhight, GroundLevel.transform.position.y+RangeBetweenZ * o), Quaternion.Euler(90f, 0f, 0f));
    //                inst.transform.SetParent(GroundLevel);
    //            }
    //        }
    //        else if (0 % 2 == 0)//짝수
    //        {
    //            for (int i = 0; i < LengthofX / 2; ++i)
    //            {
    //                GameObject inst = Instantiate(Tile1, new Vector3(GroundLevel.transform.position.x+RangeBetweenX + RangeBetweenX * i * 2, yhight, GroundLevel.transform.position.y+RangeBetweenZ * o), Quaternion.Euler(90f, 0f, 0f));
    //                inst.transform.SetParent(GroundLevel);
    //                inst.name = "Isometric Diamond";
    //            }
    //        }
    //    }
    //}


    void StartGeneratingTilesQuater(int LengthofX,int LengthofY,float yhight)
    {
        List<GameObject> obj = new List<GameObject>();
        for (int o = 0; o < LengthofY; ++o)
        {
            for (int i = 0; i < LengthofX; ++i)
            {
                GameObject inst = Instantiate(Tile1, new Vector3((GroundLevel.transform.position.x+(RangeBetweenX * i)-(RangeBetweenX*o)),(GroundLevel.transform.position.z+((RangeBetweenZ * i)+(RangeBetweenZ*o))), yhight), Quaternion.Euler(0f, 0f, 0f));
                inst.transform.SetParent(GroundLevel);
                inst.GetComponent<TileItsInfo>().Floor = 1;
                inst.GetComponent<TileItsInfo>().Y_line = o;
                inst.GetComponent<TileItsInfo>().Counts = i;
                inst.GetComponent<TileItsInfo>().Storage_Order = Inventory_Library.IL.Adding_New_Ground8x14_Package();
                obj.Add(inst);
                TilesList.Add(inst);
            }
        }
        foreach (GameObject tiles in obj)
        {
            tiles.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Tile";
            tiles.GetComponent<SpriteRenderer>().sortingOrder = (int)(32767-(tiles.transform.position.y * 100));
        }

    }
    void StartGeneratingTilesQuater2(int LengthofX, int LengthofY, float yhight)
    {
        List<GameObject> obj = new List<GameObject>();
        for (int o = 0; o < LengthofY; ++o)
        {
            for (int i = 0; i < LengthofX; ++i)
            {
                
                GameObject inst = Instantiate(Tile1, new Vector3((GroundLevel2.transform.position.x+(RangeBetweenX * i)) - (RangeBetweenX * o), (GroundLevel2.transform.position.z+((RangeBetweenZ * i) + (RangeBetweenZ * o))), (-1f*yhight)), Quaternion.Euler(0f, 0f, 0f));
                inst.transform.SetParent(GroundLevel2);
                inst.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f); // 2층 편의상 반투명
                inst.GetComponent<TileItsInfo>().Floor = 2;
                inst.GetComponent<TileItsInfo>().Y_line = o;
                inst.GetComponent<TileItsInfo>().Counts = i;
                obj.Add(inst);
                TilesList.Add(inst);
            }
        }
        foreach(GameObject tiles in obj)
        {
            tiles.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Tile";
            tiles.GetComponent<SpriteRenderer>().sortingOrder = (int)(32767-(tiles.transform.position.y * 100));
        }
    }

    //카메라 가려질 레이어 안에 넘겨서 층간 가려짐 표현
}
