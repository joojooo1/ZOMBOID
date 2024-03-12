using UnityEngine;
using System.Linq;
using UnityEngine.Rendering.Universal;

public class CustomClass : MonoBehaviour
{
    public Vector3 Target_Location;

    public bool boolVar = true;
    public bool bool2 = true;

    public int Building_Type_Value = 100; // 형태

    public int Wall_Sprite_Num = 100; //벽 sprite
    public int Ground_Sprite_Num = 100; // 바닥 sprite
    public int Floor_Value = 0; // 층
    public int Change_Create = 0; // 변경 or 생성

    public float floatVar = 0.1f;

    public Sprite[] Wall_Sprite_Arr;  //0
    public Sprite[] Ground_Sprite_Arr;  //1
    public Sprite[] Roof_Sprite_Arr; //2
    public Sprite[] Window_Sprite_Arr; //3
    public Sprite[] Door_Sprite_Arr; //4


    public Sprite[] ChangeAble_Sprite_Arr;
    public int ChangeAble_Sprite_Package=0;
    public int ChangeAble_Sprite_Num=0;
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

    private int Tile1f= -264142255;
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

    private void Update()
    {
        //카메라 Ray

        if (!bool2)
        {
            Sample();
        }

        if (Input.GetMouseButtonDown(0)) // 0은 왼쪽 버튼을 의미
        {
            // 마우스의 현재 위치로 Ray를 발사하여 충돌을 감지
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // Ray가 어떤 collider와 충돌했는지 확인
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 충돌한 오브젝트에서 원하는 함수 호출
                Debug.Log(hitInfo.collider.transform.gameObject);
                //hitInfo.collider.gameObject.GetComponent<TileChange>().Click2();
                //Map.GetComponent<CustomClass>().Creatimg(hitInfo.collider.gameObject);
                GameObject HitObject = hitInfo.collider.transform.gameObject;
                GameObject Hit = HitObject.transform.parent.gameObject;
                /*좌측 우선배치*/
                /* / Building_Type_Value /0 타일 / 1 벽 / 3 코너 / 4 창문 / 6 문 / 8 벽 데코 / 10 가구 */
                if (Change_Create == 0&&!(HitObject.CompareTag("stair"))) // 변경
                {
                    if (Building_Type_Value == 0) // 변경_타일
                    {
                        HitObject.GetComponentInParent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                    }
                }
                if (Change_Create == 1&&!(HitObject.CompareTag("stair"))) // 생성
                {
                    /*0*/
                    /*1~11*/
                    GameObject Instans = Instantiate(Prefebs[Building_Type_Value],new Vector3(0f,0f,0f), Quaternion.Euler(0f, 0f, 0f));
                    
                    Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder;
                    Instans.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y + 0.99f, Hit.transform.position.z);
                    Instans.transform.SetParent(Hit.transform);
                    Instans.transform.localPosition = Vector3.zero;
                    Instans.transform.localPosition += new Vector3(0f, 0.99f, 0f);

                    Instans.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                    ShadowCaster2D shadowCaster = Instans.GetComponent<ShadowCaster2D>();



                    
                    switch (Floor_Value)
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
        }

       
    }


}



