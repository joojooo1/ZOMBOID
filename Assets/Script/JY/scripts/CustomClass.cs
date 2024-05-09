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

    public int Building_Type_Value = 100; // ����

    public int Wall_Sprite_Num = 100; //�� sprite
    public int Ground_Sprite_Num = 100; // �ٴ� sprite
    public int Floor_Value = 0; // ��
    public int Change_Create = 0; // ���� or ����

    public int Furniture_ActingType_Value = 100;

    public int Furniture_Direction_Value = 100; // 0 ���, 1����, 2���(�Ұ�),3 ���Ͽ�(�Ұ�) 

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

    public Sprite DummySpr; // ���� sprite



    private float X_Length;
    private float Y_Length;

    /*
     ���� ���̾� �и� or ���̷��̾�
     Ÿ�Ժ� prefeb ���� ����
     Ÿ�� �ڽ����� ����(?)
     Ư��Ÿ��(��,â��,������,ü�µ��) ǥ��
     ���Ÿ�� ǥ��
     �����Ÿ�� ǥ��
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

    //�ش罺ũ��Ʈ �߰��۾����� �±׺з��۾�
    //���ܵ� �±� ��,â,����
    public void Furniture_Type_Fitting_Setting(GameObject Instans)
    {
        //�������� �⺻������ �ı����� ��ũ��Ʈ ����
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
        //������ ���� ���Ϻ�
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
                    GameObject FirstC = Instans.GetComponentInParent<MapLoader>().Tiles[Y * MultY + X + 1].gameObject; // ����ġ�� ù�ڽ��� ���� �θ�Ÿ��

                    GameObject InstansChildren1 = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//����
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingOrder = FirstC.GetComponent<SpriteRenderer>().sortingOrder+2; //���̾� ����
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                    InstansChildren1.transform.position = new Vector3(FirstC.transform.position.x, FirstC.transform.position.y + 0.99f, FirstC.transform.position.z);
                    InstansChildren1.transform.SetParent(FirstC.transform);
                    InstansChildren1.transform.localPosition = Vector3.zero;
                    InstansChildren1.transform.localPosition += new Vector3(0f, 0.99f, 0f);

                    InstansChildren1.tag = Instans.tag; // �Ļ��� ��õ �±� ����
                    InstansChildren1.GetComponent<Furniture_BreakAble>().PointMainBody = Instans.transform; // �Ļ��� ��õ ���� ����

                    Instans.GetComponent<Furniture_BreakAble>().Parts.Add(InstansChildren1);//��õ�� �Ļ� ���� �߰�

                    InstansChildren1.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num+1];// �Ļ� �̹��� ����
                }
                else if (Furniture_Size_4)
                {

                }



                //Instans = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
                //Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder;
                //Instans.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y + 0.99f, Hit.transform.position.z);
                //Instans.transform.localPosition = Vector3.zero;
                //Instans.transform.localPosition += new Vector3((0 + 0.63f), (0.99f - 0.315f), 0f); // ��ġ���� ��
                //Instans.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];

                break;
            case 1:
                if (Furniture_Size_1)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(false, true, false, true);//����
                }
                else if (Furniture_Size_2)
                {
                    Instans.GetComponent<Furniture_BreakAble>().Setting_First(false, true, false, true);

                    int Y = Instans.GetComponentInParent<TileItsInfo>().Y_line;
                    int X = Instans.GetComponentInParent<TileItsInfo>().Counts;
                    int MultY = Instans.GetComponentInParent<MapLoader>().LengthofX;
                    GameObject FirstC = Instans.GetComponentInParent<MapLoader>().Tiles[(Y-1) * MultY+X].gameObject; // ����ġ�� ù�ڽ��� ���� �θ�Ÿ��

                    GameObject InstansChildren1 = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//����
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingOrder = FirstC.GetComponent<SpriteRenderer>().sortingOrder + 2; //���̾� ����
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                    InstansChildren1.transform.position = new Vector3(FirstC.transform.position.x, FirstC.transform.position.y + 0.99f, FirstC.transform.position.z);
                    InstansChildren1.transform.SetParent(FirstC.transform);
                    InstansChildren1.transform.localPosition = Vector3.zero;
                    InstansChildren1.transform.localPosition += new Vector3(0f, 0.99f, 0f);

                    InstansChildren1.tag = Instans.tag; // �Ļ��� ��õ �±� ����
                    InstansChildren1.GetComponent<Furniture_BreakAble>().PointMainBody = Instans.transform; // �Ļ��� ��õ ���� ����

                    Instans.GetComponent<Furniture_BreakAble>().Parts.Add(InstansChildren1);//��õ�� �Ļ� ���� �߰�

                    InstansChildren1.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 1];// �Ļ� �̹��� ����
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
                    GameObject FirstC = Instans.GetComponentInParent<MapLoader>().Tiles[Y * MultY + X + 1].gameObject; // ����ġ�� ù�ڽ��� ���� �θ�Ÿ��

                    GameObject InstansChildren1 = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//����
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingOrder = FirstC.GetComponent<SpriteRenderer>().sortingOrder + 2; //���̾� ����
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                    InstansChildren1.transform.position = new Vector3(FirstC.transform.position.x, FirstC.transform.position.y + 0.99f, FirstC.transform.position.z);
                    InstansChildren1.transform.SetParent(FirstC.transform);
                    InstansChildren1.transform.localPosition = Vector3.zero;
                    InstansChildren1.transform.localPosition += new Vector3(0f, 0.99f, 0f);

                    InstansChildren1.tag = Instans.tag; // �Ļ��� ��õ �±� ����
                    InstansChildren1.GetComponent<Furniture_BreakAble>().PointMainBody = Instans.transform; // �Ļ��� ��õ ���� ����

                    Instans.GetComponent<Furniture_BreakAble>().Parts.Add(InstansChildren1);//��õ�� �Ļ� ���� �߰�

                    InstansChildren1.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 1];// �Ļ� �̹��� ����
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
                    GameObject FirstC = Instans.GetComponentInParent<MapLoader>().Tiles[(Y - 1) * MultY + X].gameObject; // ����ġ�� ù�ڽ��� ���� �θ�Ÿ��

                    GameObject InstansChildren1 = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//����
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingOrder = FirstC.GetComponent<SpriteRenderer>().sortingOrder + 2; //���̾� ����
                    InstansChildren1.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                    InstansChildren1.transform.position = new Vector3(FirstC.transform.position.x, FirstC.transform.position.y + 0.99f, FirstC.transform.position.z);
                    InstansChildren1.transform.SetParent(FirstC.transform);
                    InstansChildren1.transform.localPosition = Vector3.zero;
                    InstansChildren1.transform.localPosition += new Vector3(0f, 0.99f, 0f);

                    InstansChildren1.tag = Instans.tag; // �Ļ��� ��õ �±� ����
                    InstansChildren1.GetComponent<Furniture_BreakAble>().PointMainBody = Instans.transform; // �Ļ��� ��õ ���� ����

                    Instans.GetComponent<Furniture_BreakAble>().Parts.Add(InstansChildren1);//��õ�� �Ļ� ���� �߰�

                    InstansChildren1.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 1];// �Ļ� �̹��� ����
                }
                else if (Furniture_Size_4)
                {

                }
                break;
        }
    }

    private void Update()
    {
        //ī�޶� Ray

        if (Input.GetMouseButtonDown(0)) // 0�� ���� ��ư�� �ǹ�
        {
            // ���콺�� ���� ��ġ�� Ray�� �߻��Ͽ� �浹�� ����
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
                        //Debug.Log(HitObject.name + "��Ŭ�� ���������� Ÿ���� �߰�");
                        objectFound = true;
                        GameObject Hit = HitObject.GetComponentInParent<TileItsInfo>().transform.gameObject;
                        //Debug.Log(Hit + "Is Parent");
                        if (Change_Create == 0 && !(HitObject.CompareTag("stair"))) // 1�� ����
                        {
                            if (Building_Type_Value == 0) // ����_Ÿ��
                            {
                                HitObject.GetComponentInParent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                            }
                        }
                        if (Change_Create == 1 && !(HitObject.CompareTag("stair"))) // ����
                        {
                            /*0*/
                            /*1~11*/
                            GameObject Instans = Instantiate(Prefebs[Building_Type_Value], new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));//�ʱ� ����

                            Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder; //���̾� ����
                            Instans.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y + 0.99f, Hit.transform.position.z); // ��ġ�̵�
                            Instans.transform.SetParent(Hit.transform); // �ڽ�����
                            Instans.transform.localPosition = Vector3.zero; // ��ġ �ʱ�ȭ
                            Instans.transform.localPosition += new Vector3(0f, 0.99f, 0f); // ��ġ���� ��

                            Instans.GetComponent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                            ShadowCaster2D shadowCaster = Instans.GetComponent<ShadowCaster2D>();


                            switch (Floor_Value) //2�� ���з�
                            {
                                case 1:

                                    if (shadowCaster != null)
                                    {
                                        /*// �׸��ڰ� ǥ�õ� ���̾ ����
                                        foreach (int layer in shadowCaster.m_ApplyToSortingLayers)
                                        {
                                            Debug.Log(layer);
                                        }
                                        shadowCaster.m_ApplyToSortingLayers = new int[] { 0, Tile1f }; // ���� ���̾� ��ȣ
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
                                        Debug.LogError("ShadowCaster2D ������Ʈ�� ã�� �� �����ϴ�.");
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
                                        case 4: //��������
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            break;
                                        case 5: //��������
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            break;
                                        case 6: // â
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
                                        case 8: // �� ����
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<DoorsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<DoorsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 9: // �� ����
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<DoorsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<DoorsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 10: // �� ����

                                            break;
                                        case 11: // �� ����

                                            break;
                                        case 12: // ������ �ϴ��� �����ٴ� ���� Ȥ�� ���ϴ��� ������
                                            Furniture_Type_Fitting_Setting(Instans); //���ΰ�ü ���� action ��ũ��Ʈ, �±� �ް� ����
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            Furniture_Direction_Size(Hit, Instans);//���ΰ�ü ������������ �ڽĻ����� ����
                                            break;
                                        case 13: // ������ �ϴ��� Ȥ�� ���ϴ��� ������
                                            Furniture_Type_Fitting_Setting(Instans);
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;

                                            break;
                                        case 14: // ���Ϸ� ���ϴ� �潺
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            //0429 �׽��� ==============================================================================
                                            int Y = Hit.GetComponent<TileItsInfo>().Y_line;
                                            int X = Hit.GetComponent<TileItsInfo>().Counts;
                                            int LengthOfX_Limit = MapLoader.ML.LengthofX;
                                            OffMeshLink OML = Instans.AddComponent<OffMeshLink>();
                                            OML.startTransform = MapLoader.ML.Tiles[(Y - 1) * LengthOfX_Limit + X].transform;
                                            OML.endTransform = MapLoader.ML.Tiles[(Y) * LengthOfX_Limit + X].transform;
                                            //0429 �׽��� ==============================================================================
                                            break;
                                        case 15: // ���Ϸ� ���ϴ� �潺
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 16: // Ÿ�� ����
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Tile";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            Instans.transform.localPosition = Vector3.zero;
                                            Instans.transform.localPosition += new Vector3(0f, 0.97f, 0f); // ��ġ���� ��
                                            break;
                                        case 17: // ���Ϸ� ���ϴ� �潺
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                    }

                                    break;
                                case 2:
                                    if (shadowCaster != null)
                                    {
                                        /*
                                        // �׸��ڰ� ǥ�õ� ���̾ ����
                                        foreach (int layer in shadowCaster.m_ApplyToSortingLayers)
                                        {
                                            Debug.Log(layer);
                                        }
                                        shadowCaster.m_ApplyToSortingLayers = new int[] { 0, -Tile2f }; // ���� ���̾� ��ȣ
                                        foreach (int layer in shadowCaster.m_ApplyToSortingLayers)
                                        {
                                            Debug.Log(layer);
                                        }
                                        */
                                    }
                                    else
                                    {
                                        Debug.LogError("ShadowCaster2D ������Ʈ�� ã�� �� �����ϴ�.");
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
                                        case 4: //��������
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            break;
                                        case 5: //��������
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            break;
                                        case 6: // â
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
                                        case 8: // �� ����
                                            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level2_Wall";
                                            Instans.GetComponent<DoorsAct>().Door_Closed = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                                            Instans.GetComponent<DoorsAct>().Door_Opened = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num + 2];
                                            Instans.layer = 6;
                                            Instans.GetComponent<SpriteRenderer>().sortingOrder += 2;
                                            break;
                                        case 9: // �� ����
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

                            //if (Floor_Value == 1) // 1��
                            //{
                            //    switch (Building_Type_Value)
                            //    {
                            //        case 0:
                            //            break;
                            //        case 1://����_��_����
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
                            //        case 3://����_��_���� �ڳ�
                            //            Instans.GetComponent<SpriteRenderer>().sprite = Wall_Sprite_Arr[Wall_Sprite_Num];
                            //            Instans.GetComponent<SpriteRenderer>().sortingLayerName = "Level1_Wall";
                            //            Instans.GetComponent<SpriteRenderer>().sortingOrder = Hit.GetComponent<SpriteRenderer>().sortingOrder;
                            //            Instans.transform.SetParent(Hit.transform);
                            //            Instans.transform.localPosition = Vector3.zero;
                            //            Instans.transform.localPosition += new Vector3(0f, 0.99f, 0f);
                            //            break;
                            //        case 4://����_â��_����
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
                            //        case 6://����_��_����
                            //            break;
                            //        case 7:
                            //            break;
                            //        case 8://����_����_��_����
                            //            break;
                            //        case 9:
                            //            break;
                            //        case 10://����_����_����
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
                    // ���̿� �ƹ��͵� �浹���� �ʾ����Ƿ� �ݺ����� ����.
                    Debug.Log("nothing");
                    break;
                }
            }
            // Ray�� � collider�� �浹�ߴ��� Ȯ��
            if (Physics.Raycast(ray, out hitInfo))
            {
                // �浹�� ������Ʈ���� ���ϴ� �Լ� ȣ��
                //Debug.Log(hitInfo.collider.transform.gameObject);
                //hitInfo.collider.gameObject.GetComponent<TileChange>().Click2();
                //Map.GetComponent<CustomClass>().Creatimg(hitInfo.collider.gameObject);
                GameObject HitObject = hitInfo.collider.transform.gameObject;
                GameObject Hit = HitObject.transform.parent.gameObject;
                /*���� �켱��ġ*/
                /* / Building_Type_Value /0 Ÿ�� / 1 �� / 3 �ڳ� / 4 â�� / 6 �� / 8 �� ���� / 10 ���� */
                
            }
        }


    }


}



