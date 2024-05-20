using UnityEngine;
using System.Linq;
using UnityEngine.Rendering.Universal;
using UnityEngine.AI;

public class CustomClass : MonoBehaviour
{
    public Vector3 Target_Location;

    public Camera camera;

    public bool boolVar = true;
    public bool bool2 = true;

    public int Building_Type_Value = 100; // 형태

    public int Wall_Sprite_Num = 100; //벽 sprite
    public int Ground_Sprite_Num = 100; // 바닥 sprite
    public int Floor_Value = 0; // 층
    public int Change_Create = 0; // 변경 or 생성

    public int Furniture_ActingType_Value = 100;

    public int Furniture_Direction_Value = 100; // 0 우상, 1우하, 2우상역(불가),3 우하역(불가) 

    public float floatVar = 0.1f;

    public Sprite[] Wall_Sprite_Arr;  //0
    public Sprite[] Ground_Sprite_Arr;  //1
    public Sprite[] Roof_Sprite_Arr; //2
    public Sprite[] Window_Sprite_Arr; //3
    public Sprite[] Door_Sprite_Arr; //4
    public Sprite[] Furniture_Sprite_Arr;//5
    public Sprite[] Bedding_SP_Arr;//6
    public Sprite[] Sitting_SP_Arr;//7
    public Sprite[] Fence_Sprite_Arr;//8
    public Sprite[] Ground_Deco_Huge_Sprite_Arr;//9

    public bool Furniture_Size_1;
    public bool Furniture_Size_2;
    public bool Furniture_Size_4;

    public Sprite[] ChangeAble_Sprite_Arr;
    public int ChangeAble_Sprite_Package = 0;
    public int ChangeAble_Sprite_Num = 0;
    public GameObject[] Prefebs;


    public Vector2 scrollPosition = Vector2.zero;

    public Sprite DummySpr; // 더미 sprite



    private float X_Length;
    private float Y_Length;

    /*
     층별 레이어 분리 or 더미레이어
     타입별 prefeb 생성 설정
     타일 자식으로 지정(?)
     특성타일(문,창문,가연성,체력등등) 표현
     재배타일 표현
     저장소타일 표현
     */

    /* -264142255 = 1.tile  -1718577979 = 1.wall  1072855423 = 1.DW  
                     -555301847 = 2.tile  464287725 = 2.wall  1114963647 = 2.DW  -1290270517= 7 */

    private int Tile1f = -264142255;
    private int Wall1f = -1718577979;
    private int DW1f = 1072855423;
    private int Tile2f = -555301847;
    private int Wall2f = 464287725;
    private int DW2f = 1114963647;
    private int Seven1f = -1290270517;
    public void Creatimg(GameObject TargetTile)
    {
        Debug.Log(TargetTile.name + TargetTile.transform.position);
    }

    public void Sample()
    {
        Debug.Log("yureca");
    }

    //해당스크립트 추가작업이자 태그분류작업
    //제외된 태그 문,창,차량
    public void Furniture_Type_Fitting_Setting(GameObject Instans)
    {
        //프리펩이 기본적으로 파괴가능 스크립트 보유
        switch (Furniture_ActingType_Value)
        {
            case 0:
                //Instans.AddComponent<Water>();
                Instans.tag = "Water";
                break;
            case 1:
                //Instans.AddComponent<Heating>();
                Instans.tag = "Heating";
                break;
            case 2:
                //Instans.AddComponent<Storage>();
                Instans.tag = "Storage";
                break;
            case 3:
                //Instans.AddComponent<Electricity>();
                Instans.tag = "Electricity";
                break;
            case 4:
                //Instans.AddComponent<Bed>();
                Instans.tag = "Bed";
                break;
            case 5:
                //Instans.AddComponent<TrashCan>();
                Instans.tag = "TrashCan";
                break;
            case 6:
                //Instans.AddComponent<Refrigerator>();
                Instans.tag = "Refrigerator";
                break;
            case 7:
                //Instans.AddComponent<Sit>();
                Instans.tag = "Sit";
                break;
            case 8:
                //Instans.AddComponent<Farm>();
                Instans.tag = "Farm";
                break;
        }
        //this.gameObject.AddComponent<Item_DataBase>();
    }
    //public class Furniture_BreakAble 
    //{
    //    public bool TowardUP;
    //    public bool Can_Enter_Animation;
    //    public bool IsLarge;
    //    public bool IsMain;
    //    public List<GameObject> Parts;
    //    public Transform PointMainBody;

    //}
    public void Furniture_Direction_Size(GameObject Hit,GameObject Instans)
    {
        //우상우하 우상불 우하불
        switch (Furniture_Direction_Value)
        {
            case 0:
                if (Furniture_Size_1)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(true, true, false, true);
                }
                else if (Furniture_Size_2)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(true, true, true, true);

                    int Y = Instans.GetComponentInParent<TileItsInfo>().Y_line;
                    int X = Instans.GetComponentInParent<TileItsInfo>().Counts;
                    int MultY = Instans.GetComponentInParent<MapLoader>().LengthofX;
                    GameObject FirstC = Instans.GetComponentInParent<MapLoader>().Tiles[Y * MultY + X + 1].gameObject; // 현위치의 첫자식이 생길 부모타일

                    GameObject InstansChildren1 = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//생성
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingOrder = FirstC.GetComponent<SpriteRenderer>().sortingOrder+2; //레이어 복사
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                    InstansChildren1.transform.position = new Vector3(FirstC.transform.position.x, FirstC.transform.position.y + 0.99f, FirstC.transform.position.z);
                    InstansChildren1.transform.SetParent(FirstC.transform);
                    InstansChildren1.transform.localPosition = Vector3.zero;
                    InstansChildren1.transform.localPosition += new Vector3(0f, 0.99f, 0f);

                    InstansChildren1.tag = Instans.tag; // 파생에 원천 태그 복사
                    InstansChildren1.GetComponent<Furniture_BreakAble>().PointMainBody = Instans.transform; // 파생에 원천 정보 고정

                    Instans.GetComponent<Furniture_BreakAble>().Parts.Add(InstansChildren1);//원천에 파생 정보 추가

                    InstansChildren1.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num+1];// 파생 이미지 변경
                }
                else if (Furniture_Size_4)
                {

                }



                //Instans = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
                //Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder;
                //Instans.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y + 0.99f, Hit.transform.position.z);
                //Instans.transform.localPosition = Vector3.zero;
                //Instans.transform.localPosition += new Vector3((0 + 0.63f), (0.99f - 0.315f), 0f); // 위치고정 ★
                //Instans.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];

                break;
            case 1:
                if (Furniture_Size_1)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(false, true, false, true);//우하
                }
                else if (Furniture_Size_2)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(false, true, false, true);

                    int Y = Instans.GetComponentInParent<TileItsInfo>().Y_line;
                    int X = Instans.GetComponentInParent<TileItsInfo>().Counts;
                    int MultY = Instans.GetComponentInParent<MapLoader>().LengthofX;
                    GameObject FirstC = Instans.GetComponentInParent<MapLoader>().Tiles[(Y-1) * MultY+X].gameObject; // 현위치의 첫자식이 생길 부모타일

                    GameObject InstansChildren1 = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//생성
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingOrder = FirstC.GetComponent<SpriteRenderer>().sortingOrder + 2; //레이어 복사
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                    InstansChildren1.transform.position = new Vector3(FirstC.transform.position.x, FirstC.transform.position.y + 0.99f, FirstC.transform.position.z);
                    InstansChildren1.transform.SetParent(FirstC.transform);
                    InstansChildren1.transform.localPosition = Vector3.zero;
                    InstansChildren1.transform.localPosition += new Vector3(0f, 0.99f, 0f);

                    InstansChildren1.tag = Instans.tag; // 파생에 원천 태그 복사
                    InstansChildren1.GetComponent<Furniture_BreakAble>().PointMainBody = Instans.transform; // 파생에 원천 정보 고정

                    Instans.GetComponent<Furniture_BreakAble>().Parts.Add(InstansChildren1);//원천에 파생 정보 추가

                    InstansChildren1.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 1];// 파생 이미지 변경
                }
                else if (Furniture_Size_4)
                {

                }
                break;
            case 2:
                if (Furniture_Size_1)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(true, false, false, true);
                }
                else if (Furniture_Size_2)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(true, false, false, true);

                    int Y = Instans.GetComponentInParent<TileItsInfo>().Y_line;
                    int X = Instans.GetComponentInParent<TileItsInfo>().Counts;
                    int MultY = Instans.GetComponentInParent<MapLoader>().LengthofX;
                    GameObject FirstC = Instans.GetComponentInParent<MapLoader>().Tiles[Y * MultY + X + 1].gameObject; // 현위치의 첫자식이 생길 부모타일

                    GameObject InstansChildren1 = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//생성
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingOrder = FirstC.GetComponent<SpriteRenderer>().sortingOrder + 2; //레이어 복사
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                    InstansChildren1.transform.position = new Vector3(FirstC.transform.position.x, FirstC.transform.position.y + 0.99f, FirstC.transform.position.z);
                    InstansChildren1.transform.SetParent(FirstC.transform);
                    InstansChildren1.transform.localPosition = Vector3.zero;
                    InstansChildren1.transform.localPosition += new Vector3(0f, 0.99f, 0f);

                    InstansChildren1.tag = Instans.tag; // 파생에 원천 태그 복사
                    InstansChildren1.GetComponent<Furniture_BreakAble>().PointMainBody = Instans.transform; // 파생에 원천 정보 고정

                    Instans.GetComponent<Furniture_BreakAble>().Parts.Add(InstansChildren1);//원천에 파생 정보 추가

                    InstansChildren1.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 1];// 파생 이미지 변경
                }
                else if (Furniture_Size_4)
                {

                }
                break;
            case 3:
                if (Furniture_Size_1)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(false, false, false, true);
                }
                else if (Furniture_Size_2)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(false, false, false, true);

                    int Y = Instans.GetComponentInParent<TileItsInfo>().Y_line;
                    int X = Instans.GetComponentInParent<TileItsInfo>().Counts;
                    int MultY = Instans.GetComponentInParent<MapLoader>().LengthofX;
                    GameObject FirstC = Instans.GetComponentInParent<MapLoader>().Tiles[(Y - 1) * MultY + X].gameObject; // 현위치의 첫자식이 생길 부모타일

                    GameObject InstansChildren1 = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//생성
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingOrder = FirstC.GetComponent<SpriteRenderer>().sortingOrder + 2; //레이어 복사
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                    InstansChildren1.transform.position = new Vector3(FirstC.transform.position.x, FirstC.transform.position.y + 0.99f, FirstC.transform.position.z);
                    InstansChildren1.transform.SetParent(FirstC.transform);
                    InstansChildren1.transform.localPosition = Vector3.zero;
                    InstansChildren1.transform.localPosition += new Vector3(0f, 0.99f, 0f);

                    InstansChildren1.tag = Instans.tag; // 파생에 원천 태그 복사
                    InstansChildren1.GetComponent<Furniture_BreakAble>().PointMainBody = Instans.transform; // 파생에 원천 정보 고정

                    Instans.GetComponent<Furniture_BreakAble>().Parts.Add(InstansChildren1);//원천에 파생 정보 추가

                    InstansChildren1.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 1];// 파생 이미지 변경
                }
                else if (Furniture_Size_4)
                {

                }
                break;
        }
    }

    private void Update()
    {
        //카메라 Ray

        if (Input.GetMouseButtonDown(0)) // 0은 왼쪽 버튼을 의미
        {
            // 마우스의 현재 위치로 Ray를 발사하여 충돌을 감지
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool objectFound = false;
            while (!objectFound)
            {
                if (Physics.Raycast(ray, out hitInfo))
                {
                    Transform HitObject = hitInfo.transform;
                    //Debug.Log(HitObject.name);
                    if (HitObject.GetComponentInParent<TileItsInfo>()!=null)
                    {
                        //Debug.Log(HitObject.name + "좌클릭 정상적으로 타일을 발견");
                        objectFound = true;
                        GameObject Hit = HitObject.GetComponentInParent<TileItsInfo>().transform.gameObject;
                        //Debug.Log(Hit + "Is Parent");
                        if (Change_Create == 0 && !(HitObject.CompareTag("stair"))) // 1차 변경
                        {
                            if (Building_Type_Value == 0) // 변경_타일
                            {
                                HitObject.GetComponentInParent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                            }
                        }
                        if (Change_Create == 1 && !(HitObject.CompareTag("stair"))) // 생성
                        {
                            /*0*/
                            /*1~11*/
                            GameObject Instans = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//초기 생성

                            Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder; //레이어 복사
                            Instans.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y + 0.99f, Hit.transform.position.z); // 위치이동
                            Instans.transform.SetParent(Hit.transform); // 자식으로
                            Instans.transform.localPosition = Vector3.zero; // 위치 초기화
                            Instans.transform.localPosition += new Vector3(0f, 0.99f, 0f); // 위치고정 ★

                            Instans.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                            ShadowCaster2D shadowCaster = Instans.GetComponent<ShadowCaster2D>();


                            switch (Floor_Value) //2차 층분류
                            {
                                case 1:

                                    if (shadowCaster != null)
                                    {
                                        /*// 그림자가 표시될 레이어를 설정
                                        foreach (int layer in shadowCaster.m_ApplyToSortingLayers)
                                        {
                                            Debug.Log(layer);
                                        }
                                        shadowCaster.m_ApplyToSortingLayers = new int[] { 0, Tile1f }; // 예시 레이어 번호
                                        //shadowCaster.enabled = false;
                                        //shadowCaster.enabled = true;
                                        foreach (int layer in shadowCaster.m_ApplyToSortingLayers)
                                        {
                                            Debug.Log(layer);
                                        }
                                        */
                                    }
                                    else
                                    {
                                        Debug.LogError("ShadowCaster2D 컴포넌트를 찾을 수 없습니다.");
                                    }
                                    switch (Building_Type_Value) //notice 0~ tile
                                    {
                                        case 0:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Tile";
                                            break;
                                        case 1:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            break;
                                        case 2:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            break;
                                        case 3:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            break;
                                        case 4: //문프레임
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            break;
                                        case 5: //문프레임
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            break;
                                        case 6: // 창
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<WindowsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<WindowsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 7:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<WindowsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<WindowsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 8: // 문 좌측
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<DoorsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<DoorsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 9: // 문 우측
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<DoorsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<DoorsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 10: // 문 우측

                                            break;
                                        case 11: // 문 우측

                                            break;
                                        case 12: // 좌측이 하단인 벽에붙는 가구 혹은 좌하단이 메인인
                                            Furniture_Type_Fitting_Setting(Instans); //메인개체 들어가서 action 스크립트, 태그 받고 나옴
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            Furniture_Direction_Size(Hit, Instans);//메인개체 정보값지정후 자식생성후 나옴
                                            break;
                                        case 13: // 우측이 하단인 혹은 우하단이 메인인
                                            Furniture_Type_Fitting_Setting(Instans);
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;

                                            break;
                                        case 14: // 좌하로 향하는 펜스
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            //0429 테스팅 ==============================================================================
                                            int Y = Hit.GetComponent<TileItsInfo>().Y_line;
                                            int X = Hit.GetComponent<TileItsInfo>().Counts;
                                            int LengthOfX_Limit = MapLoader.ML.LengthofX;
                                            OffMeshLink OML = Instans.AddComponent<OffMeshLink>();
                                            OML.startTransform = MapLoader.ML.Tiles[(Y - 1) * LengthOfX_Limit + X].transform;
                                            OML.endTransform = MapLoader.ML.Tiles[(Y) * LengthOfX_Limit + X].transform;
                                            //0429 테스팅 ==============================================================================
                                            break;
                                        case 15: // 우하로 향하는 펜스
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 16: // 타일 데코
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Tile";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            Instans.transform.localPosition = Vector3.zero;
                                            Instans.transform.localPosition += new Vector3(0f, 0.97f, 0f); // 위치고정 ★
                                            break;
                                        case 17: // 우하로 향하는 펜스
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                    }

                                    break;
                                case 2:
                                    if (shadowCaster != null)
                                    {
                                        /*
                                        // 그림자가 표시될 레이어를 설정
                                        foreach (int layer in shadowCaster.m_ApplyToSortingLayers)
                                        {
                                            Debug.Log(layer);
                                        }
                                        shadowCaster.m_ApplyToSortingLayers = new int[] { 0, -Tile2f }; // 예시 레이어 번호
                                        foreach (int layer in shadowCaster.m_ApplyToSortingLayers)
                                        {
                                            Debug.Log(layer);
                                        }
                                        */
                                    }
                                    else
                                    {
                                        Debug.LogError("ShadowCaster2D 컴포넌트를 찾을 수 없습니다.");
                                    }
                                    switch (Building_Type_Value) //notice 0~ tile
                                    {
                                        case 0:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Tile";
                                            break;
                                        case 1:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            break;
                                        case 2:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            break;
                                        case 3:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            break;
                                        case 4: //문프레임
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            break;
                                        case 5: //문프레임
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            break;
                                        case 6: // 창
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            Instans.GetComponent<WindowsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<WindowsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 7:
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            Instans.GetComponent<WindowsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<WindowsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 8: // 문 좌측
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            Instans.GetComponent<DoorsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<DoorsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 9: // 문 우측
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            Instans.GetComponent<DoorsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<DoorsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                    }
                                    break;
                            }


                            //Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                            /*10*/

                            //if (Floor_Value == 1) // 1층
                            //{
                            //    switch (Building_Type_Value)
                            //    {
                            //        case 0:
                            //            break;
                            //        case 1://생성_벽_좌측
                            //            Instans.GetComponent<SpriteRenderer>().sprite = Wall_Sprite_Arr[Wall_Sprite_Num];
                            //            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                            //            Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder;
                            //            //Instans.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y+0.99f, Hit.transform.position.z);
                            //            Instans.transform.SetParent(Hit.transform);
                            //            Instans.transform.localPosition = Vector3.zero;
                            //            Instans.transform.localPosition += new Vector3(0f, 0.99f, 0f);
                            //            break;
                            //        case 2:
                            //            Instans.GetComponent<SpriteRenderer>().sprite = Wall_Sprite_Arr[Wall_Sprite_Num];
                            //            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                            //            Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder;
                            //            Instans.transform.SetParent(Hit.transform);
                            //            Instans.transform.localPosition = Vector3.zero;
                            //            Instans.transform.localPosition += new Vector3(0f, 0.99f, 0f);
                            //            break;
                            //        case 3://생성_벽_북측 코너
                            //            Instans.GetComponent<SpriteRenderer>().sprite = Wall_Sprite_Arr[Wall_Sprite_Num];
                            //            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                            //            Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder;
                            //            Instans.transform.SetParent(Hit.transform);
                            //            Instans.transform.localPosition = Vector3.zero;
                            //            Instans.transform.localPosition += new Vector3(0f, 0.99f, 0f);
                            //            break;
                            //        case 4://생성_창문_좌측
                            //            Instans.GetComponent<SpriteRenderer>().sprite = Wall_Sprite_Arr[Wall_Sprite_Num];
                            //            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                            //            Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder;
                            //            Instans.transform.SetParent(Hit.transform);
                            //            Instans.transform.localPosition = Vector3.zero;
                            //            Instans.transform.localPosition += new Vector3(0f, 0.99f, 0f);
                            //            break;
                            //        case 5:
                            //            Instans.GetComponent<SpriteRenderer>().sprite = Wall_Sprite_Arr[Wall_Sprite_Num];
                            //            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                            //            Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder;
                            //            Instans.transform.SetParent(Hit.transform);
                            //            Instans.transform.localPosition = Vector3.zero;
                            //            Instans.transform.localPosition += new Vector3(0f, 0.99f, 0f);
                            //            break;
                            //        case 6://생성_문_좌측
                            //            break;
                            //        case 7:
                            //            break;
                            //        case 8://생성_데코_벽_좌측
                            //            break;
                            //        case 9:
                            //            break;
                            //        case 10://생성_가구_좌측
                            //            break;
                            //        case 11:
                            //            break;



                            //    }
                            //}
                        }

                    }
                    else
                    {

                        ray = new Ray(hitInfo.point + ray.direction * 0.01f, ray.direction);
                    }
                }
                else
                {
                    // 레이에 아무것도 충돌하지 않았으므로 반복문을 종료.
                    Debug.Log("nothing");
                    break;
                }
            }
            // Ray가 어떤 collider와 충돌했는지 확인
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 충돌한 오브젝트에서 원하는 함수 호출
                //Debug.Log(hitInfo.collider.transform.gameObject);
                //hitInfo.collider.gameObject.GetComponent<TileChange>().Click2();
                //Map.GetComponent<CustomClass>().Creatimg(hitInfo.collider.gameObject);
                GameObject HitObject = hitInfo.collider.transform.gameObject;
                GameObject Hit = HitObject.transform.parent.gameObject;
                /*좌측 우선배치*/
                /* / Building_Type_Value /0 타일 / 1 벽 / 3 코너 / 4 창문 / 6 문 / 8 벽 데코 / 10 가구 */
                
            }
        }


    }


}



