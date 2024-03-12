using UnityEngine;
using System.Linq;
using UnityEngine.Rendering.Universal;

public class CustomClass : MonoBehaviour
{
    public Vector3 Target_Location;

    public bool boolVar = true;
    public bool bool2 = true;

    public int Building_Type_Value = 100; // ����

    public int Wall_Sprite_Num = 100; //�� sprite
    public int Ground_Sprite_Num = 100; // �ٴ� sprite
    public int Floor_Value = 0; // ��
    public int Change_Create = 0; // ���� or ����

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
        //ī�޶� Ray

        if (!bool2)
        {
            Sample();
        }

        if (Input.GetMouseButtonDown(0)) // 0�� ���� ��ư�� �ǹ�
        {
            // ���콺�� ���� ��ġ�� Ray�� �߻��Ͽ� �浹�� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // Ray�� � collider�� �浹�ߴ��� Ȯ��
            if (Physics.Raycast(ray, out hitInfo))
            {
                // �浹�� ������Ʈ���� ���ϴ� �Լ� ȣ��
                Debug.Log(hitInfo.collider.transform.gameObject);
                //hitInfo.collider.gameObject.GetComponent<TileChange>().Click2();
                //Map.GetComponent<CustomClass>().Creatimg(hitInfo.collider.gameObject);
                GameObject HitObject = hitInfo.collider.transform.gameObject;
                GameObject Hit = HitObject.transform.parent.gameObject;
                /*���� �켱��ġ*/
                /* / Building_Type_Value /0 Ÿ�� / 1 �� / 3 �ڳ� / 4 â�� / 6 �� / 8 �� ���� / 10 ���� */
                if (Change_Create == 0&&!(HitObject.CompareTag("stair"))) // ����
                {
                    if (Building_Type_Value == 0) // ����_Ÿ��
                    {
                        HitObject.GetComponentInParent<SpriteRenderer>().sprite = ChangeAble_Sprite_Arr[ChangeAble_Sprite_Num];
                    }
                }
                if (Change_Create == 1&&!(HitObject.CompareTag("stair"))) // ����
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
        }

       
    }


}



