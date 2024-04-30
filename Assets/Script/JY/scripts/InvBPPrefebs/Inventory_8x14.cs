using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory_8x14 : MonoBehaviour
{
    int X_Length = 8; // v
    int Y_Length = 14; // v
    int This_Size = 814;
    public short Storage_Order;
    public bool IsPlayers;
    public short[,,] Recent_Recieved_Package; // v

    public Transform Slot_Image;
    public Transform Slot_Weight;

    public GameObject SlotPrefeb; // v


    Item_Container ThisID;
    public InventorySlot[] Slots; // v

    short[,,] example =
    {
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        },
    };

    private void Start()
    {
        ThisID = Item_DataBase.item_database.Container_Ins[0];
        Slot_Image.gameObject.GetComponent<Image>().sprite = ThisID.Container_Image;
        Slot_Weight.gameObject.GetComponent<TextMeshProUGUI>().text = "..";
        //바닥예시 0429 지울것
        Generating_Slots_First(example,99);
    }

    

    //public void Ex_Add() // 서버 테스팅후 지울것
    //{
    //    Storage_Order=Inventory_Library.IL.Adding_New_Package(Recent_Recieved_Package);
    //    Debug.Log("Sample 86 has order = "+Storage_Order);
    //    Inventory_Player_Shown.InvPS.Player_Storages.Add(this.transform);
    //}

    public void Generating_Slots_First(short[,,] package,short Storage_Order_Set)
    {
        Storage_Order = Storage_Order_Set;
        int x = package.GetLength(1);
        int y = package.GetLength(2);
        int deep = package.GetLength(0);
        List<InventorySlot> SlotsDefine = new List<InventorySlot>();

        for (int amountofslots = 0; amountofslots < x * y; amountofslots++)
        {
            //prefeb 생성
            //0~7, 0~5
            GameObject prefeb = Instantiate(SlotPrefeb, new Vector3(0f, 0f, 0f), Quaternion.identity);
            prefeb.transform.SetParent(this.transform);
            prefeb.transform.localScale = Vector3.one;
            RectTransform canvasRectTransform = prefeb.GetComponentInChildren<Image>().gameObject.GetComponent<RectTransform>();
            canvasRectTransform.anchorMin = new Vector2(0f, 1f);
            canvasRectTransform.anchorMax = new Vector2(0f, 1f);
            canvasRectTransform.localPosition = Vector3.zero;
            canvasRectTransform.sizeDelta = Vector2.zero;

            if (amountofslots >= X_Length)
            {
                prefeb.GetComponent<InventorySlot>().Slot_Y = (short)(amountofslots / X_Length);
                prefeb.GetComponent<InventorySlot>().Slot_X = (short)(amountofslots % X_Length);
            }
            else
            {
                prefeb.GetComponent<InventorySlot>().Slot_X = (short)amountofslots;
                prefeb.GetComponent<InventorySlot>().Slot_Y = 0;
            }

            SlotsDefine.Add(prefeb.GetComponent<InventorySlot>());

        }
        Slots = SlotsDefine.ToArray();
        foreach (InventorySlot slots in Slots)
        {
            slots.Is_Changed = 1;
        }

        for (int YLine = 0; YLine < y; YLine++)
        {
            for (int XLine = 0; XLine < x; XLine++)
            {
                if (!(package[0, XLine, YLine] == 0))
                {
                    Debug.Log(XLine + "," + YLine + "is Exist");
                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().sprite = Item_DataBase.item_database.Requesting_Image(package[0, XLine, YLine], package[1, XLine, YLine]);
                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    short Size = Item_DataBase.item_database.Requesting_Size(package[0, XLine, YLine], package[1, XLine, YLine]);

                    // 0424, 0426 ===========================================================
                    Slots[YLine * X_Length + XLine].Item_Type = package[0, XLine, YLine];
                    Slots[YLine * X_Length + XLine].Item_ID = package[1, XLine, YLine];
                    Slots[YLine * X_Length + XLine].ParentTransform = this.transform;
                    Slots[YLine * X_Length + XLine].ParentSize = (short)This_Size;
                    Slots[YLine * X_Length + XLine].Size = Size;

                    Slots[YLine * X_Length + XLine].What_Main = null;
                    Slots[YLine * X_Length + XLine].IsMain = true;

                    //Slots[YLine * X_Length + XLine].Is_Changed--;
                    // 0424, 0426 ===========================================================
                    if (Size != 101) //11 아니면
                    {
                        int Width = Size / 100;
                        int Height = Size % 100;
                        int CanvasWidth = SlotSize_Req(Width);
                        int CanvasHeight = SlotSize_Req(Height);

                        RectTransform canvasRectTransform = Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<RectTransform>();

                        canvasRectTransform.sizeDelta = new Vector2(CanvasWidth, CanvasHeight);

                        canvasRectTransform.anchorMin = new Vector2(0f, 1f);
                        canvasRectTransform.anchorMax = new Vector2(0f, 1f);
                        canvasRectTransform.localPosition = new Vector3(((Mathf.Round((CanvasWidth / 2) * 10f) / 10f)), ((-1f)* (Mathf.Round((CanvasHeight / 2) * 10f) / 10f)), 0f);

                        
                        if (package[3, XLine, YLine] == 0) //정상
                        {
                            if (Width > 1)
                            {
                                for (int Length_Of_X = 1; Length_Of_X < Width; Length_Of_X++)//와이드는 상수 조건문 통과후 2부터
                                {
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].IsMain = false;
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].Is_Changed--;
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0);
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].Text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
                                    //추가 0424
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].ParentTransform = Slots[(YLine * X_Length + XLine) + Length_Of_X].What_Main.gameObject.GetComponent<InventorySlot>().ParentTransform;
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].ParentSize = Slots[(YLine * X_Length + XLine) + Length_Of_X].What_Main.gameObject.GetComponent<InventorySlot>().ParentSize;
                                    if (Height > 1)
                                    {
                                        for(int Length_Of_Y = 1; Length_Of_Y < Height; Length_Of_Y++)
                                        {
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].IsMain = false;
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].What_Main = Slots[YLine * X_Length + XLine].transform;
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].Is_Changed--;
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0);
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].Text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
                                            //추가 0424
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].ParentTransform = Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].What_Main.gameObject.GetComponent<InventorySlot>().ParentTransform;
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].ParentSize = Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].What_Main.gameObject.GetComponent<InventorySlot>().ParentSize;
                                        }
                                    }
                                }
                            }
                            if (Height > 1)
                            {
                                for (int Length_Of_Y = 1; Length_Of_Y < Height; Length_Of_Y++)
                                {
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].IsMain = false;
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Is_Changed--;
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0);
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
                                    //추가 0424
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].ParentTransform = Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].What_Main.gameObject.GetComponent<InventorySlot>().ParentTransform;
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].ParentSize = Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].What_Main.gameObject.GetComponent<InventorySlot>().ParentSize;
                                    if (Width > 1)
                                    {
                                        for (int Length_Of_X = 1; Length_Of_X < Height; Length_Of_X++)
                                        {
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].IsMain = false;
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].What_Main = Slots[YLine * X_Length + XLine].transform;
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Is_Changed--;
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0);
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
                                            //추가 0424
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].ParentTransform = Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].What_Main.gameObject.GetComponent<InventorySlot>().ParentTransform;
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].ParentSize = Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].What_Main.gameObject.GetComponent<InventorySlot>().ParentSize;
                                        }
                                    }
                                }
                            }
                        }
                        else if (package[3, XLine, YLine] == 1)//회전
                        {
                            if (Width > 1)
                            {
                                for (int Length_Of_Y = 1; Length_Of_Y < Height; Length_Of_Y++)//YY
                                {
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].IsMain = false;
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].Is_Changed--;
                                }
                            }
                            if (Height > 1)
                            {
                                for (int Length_Of_X = 1; Length_Of_X < Width; Length_Of_X++)//XX
                                {
                                    Slots[YLine * X_Length + XLine + Length_Of_X].IsMain = false;
                                    Slots[YLine * X_Length + XLine + Length_Of_X].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[YLine * X_Length + XLine + Length_Of_X].Is_Changed--;
                                }
                            }
                        }
                    }


                }
                else
                {
                    //short Size = Item_DataBase.item_database.Requesting_Size(package[0, XLine, YLine], package[1, XLine, YLine]);
                    if (!(Slots[YLine * X_Length + XLine].Is_Changed < 1)) // 변환되지않은
                    {
                        Slots[YLine * X_Length + XLine].IsMain = true;
                        int Width = 1;
                        int Height = 1;
                        int CanvasWidth = SlotSize_Req(Width);
                        int CanvasHeight = SlotSize_Req(Height);

                        RectTransform canvasRectTransform = Slots[YLine * X_Length + XLine].GetComponentInChildren<Image>().gameObject.GetComponent<RectTransform>();

                        canvasRectTransform.sizeDelta = new Vector2(CanvasWidth, CanvasHeight);

                        canvasRectTransform.anchorMin = new Vector2(0f, 1f);
                        canvasRectTransform.anchorMax = new Vector2(0f, 1f);
                        canvasRectTransform.localPosition = new Vector3(((Mathf.Round((CanvasWidth / 2) * 10f) / 10f)), ((-1f) * (Mathf.Round((CanvasHeight / 2) * 10f) / 10f)), 0f);

                        Slots[YLine * X_Length + XLine].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                        Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1);
                        Slots[YLine * X_Length + XLine].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                        Slots[YLine * X_Length + XLine].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                        Slots[YLine * X_Length + XLine].Text.GetComponent<Text>().color = new Color(1, 1, 1, 1);

                        Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().sprite = null;
                        Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                        Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
                        Slots[YLine * X_Length + XLine].Item_Type = 0;
                        Slots[YLine * X_Length + XLine].Item_ID = 0;

                        Slots[YLine * X_Length + XLine].ParentTransform = this.transform;
                        Slots[YLine * X_Length + XLine].ParentSize = (short)This_Size;
                        //short SizeOfItem = Item_DataBase.item_database.Requesting_Size(package[0, XLine, YLine], package[1, XLine, YLine]);
                        //Slots[YLine * X_Length + XLine].Size = SizeOfItem;
                        Slots[YLine * X_Length + XLine].Size = 0;
                    }
                }
            }
        }


        Recent_Recieved_Package = package;
    }
    public void Refreshing_Changed_Slots(short[,,] changedPackage)
    {
        int x = changedPackage.GetLength(1);
        int y = changedPackage.GetLength(2);
        int deep = changedPackage.GetLength(0);

        foreach (InventorySlot slots in Slots)
        {
            slots.Is_Changed = 1;
        }

        for (int YLine = 0; YLine < y; YLine++)
        {
            for (int XLine = 0; XLine < x; XLine++)
            {
                if (!(changedPackage[0, XLine, YLine] == 0))
                {

                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().sprite = Item_DataBase.item_database.Requesting_Image(changedPackage[0, XLine, YLine], changedPackage[1, XLine, YLine]);
                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

                    Slots[YLine * X_Length + XLine].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    Slots[YLine * X_Length + XLine].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                    Slots[YLine * X_Length + XLine].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                    short Size = Item_DataBase.item_database.Requesting_Size(changedPackage[0, XLine, YLine], changedPackage[1, XLine, YLine]);
                    if (Size != 101) //11 아니면
                    {
                        int Width = Size / 100;
                        int Height = Size % 100;
                        
                        int CanvasWidth = SlotSize_Req(Width);
                        int CanvasHeight = SlotSize_Req(Height);

                        RectTransform canvasRectTransform = Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<RectTransform>();

                        canvasRectTransform.sizeDelta = new Vector2(CanvasWidth, CanvasHeight);

                        canvasRectTransform.anchorMin = new Vector2(0f, 1f);
                        canvasRectTransform.anchorMax = new Vector2(0f, 1f);
                        canvasRectTransform.localPosition = new Vector3(((Mathf.Round((CanvasWidth / 2) * 10f) / 10f)), ((-1f)* (Mathf.Round((CanvasHeight / 2) * 10f) / 10f)), 0f);

                        if (changedPackage[3, XLine, YLine] == 0) //정상
                        {
                            if (Width > 1)
                            {
                                for (int Length_Of_X = 1; Length_Of_X < Width; Length_Of_X++)//와이드는 상수 조건문 통과후 2부터
                                {
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].IsMain = false;
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].Is_Changed--;
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0);
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                    Slots[(YLine * X_Length + XLine) + Length_Of_X].Text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
                                    if (Height > 1)
                                    {
                                        for (int Length_Of_Y = 1; Length_Of_Y < Height; Length_Of_Y++)
                                        {
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].IsMain = false;
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].What_Main = Slots[YLine * X_Length + XLine].transform;
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].Is_Changed--;
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0);
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                            Slots[(YLine + Length_Of_Y) * X_Length + XLine + Length_Of_X].Text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
                                        }
                                    }
                                }
                            }
                            if (Height > 1)
                            {
                                for (int Length_Of_Y = 1; Length_Of_Y < Height; Length_Of_Y++)
                                {
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].IsMain = false;
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Is_Changed--;
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0);
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                    Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
                                    if (Width > 1)
                                    {
                                        for (int Length_Of_X = 1; Length_Of_X < Width; Length_Of_X++)
                                        {
                                            Slots[((YLine + Length_Of_Y) * X_Length + XLine) + Length_Of_X].IsMain = false;
                                            Slots[((YLine + Length_Of_Y) * X_Length + XLine) + Length_Of_X].What_Main = Slots[YLine * X_Length + XLine].transform;
                                            Slots[((YLine + Length_Of_Y) * X_Length + XLine) + Length_Of_X].Is_Changed--;
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 0);
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                                            Slots[(YLine * X_Length + XLine) + (X_Length * Length_Of_Y)].Text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
                                        }
                                    }
                                }
                            }
                        }
                        else if (changedPackage[3, XLine, YLine] == 1)//회전
                        {
                            if (Width > 1)
                            {
                                for (int Length_Of_Y = 1; Length_Of_Y < Height; Length_Of_Y++)//YY
                                {
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].IsMain = false;
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].Is_Changed--;
                                }
                            }
                            if (Height > 1)
                            {
                                for (int Length_Of_X = 1; Length_Of_X < Width; Length_Of_X++)//XX
                                {
                                    Slots[YLine * X_Length + XLine + Length_Of_X].IsMain = false;
                                    Slots[YLine * X_Length + XLine + Length_Of_X].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[YLine * X_Length + XLine + Length_Of_X].Is_Changed--;
                                }
                            }
                        }
                    }

                    Slots[YLine * X_Length + XLine].Item_Type = changedPackage[0, XLine, YLine];
                    Slots[YLine * X_Length + XLine].Item_ID = changedPackage[1, XLine, YLine];
                    Slots[YLine * X_Length + XLine].ParentTransform = this.transform;
                    Slots[YLine * X_Length + XLine].ParentSize = (short)This_Size;
                    Slots[YLine * X_Length + XLine].Size = Size;

                    Slots[YLine * X_Length + XLine].What_Main = null;
                    Slots[YLine * X_Length + XLine].IsMain = true;

                    Slots[YLine * X_Length + XLine].Is_Changed--;
                }
                else
                {
                    //short Size = Item_DataBase.item_database.Requesting_Size(package[0, XLine, YLine], package[1, XLine, YLine]);
                    if (!(Slots[YLine * X_Length + XLine].Is_Changed < 1)) // 변환되지않은
                    {
                        Slots[YLine * X_Length + XLine].IsMain = true;
                        int Width = 1;
                        int Height = 1;
                        int CanvasWidth = SlotSize_Req(Width);
                        int CanvasHeight = SlotSize_Req(Height);

                        RectTransform canvasRectTransform = Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<RectTransform>();

                        canvasRectTransform.sizeDelta = new Vector2(CanvasWidth, CanvasHeight);

                        canvasRectTransform.anchorMin = new Vector2(0f, 1f);
                        canvasRectTransform.anchorMax = new Vector2(0f, 1f);
                        canvasRectTransform.localPosition = new Vector3(((Mathf.Round((CanvasWidth / 2) * 10f) / 10f)), ((-1f) * (Mathf.Round((CanvasHeight / 2) * 10f) / 10f)), 0f);

                        Slots[YLine * X_Length + XLine].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1);
                        Slots[YLine * X_Length + XLine].Putti.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                        Slots[YLine * X_Length + XLine].BorderLine.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                        Slots[YLine * X_Length + XLine].Text.GetComponent<Text>().color = new Color(1, 1, 1, 1);


                        Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().sprite = null;
                        Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                        Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
                        Slots[YLine * X_Length + XLine].Item_Type = 0;
                        Slots[YLine * X_Length + XLine].Item_ID = 0;

                        Slots[YLine * X_Length + XLine].ParentTransform = this.transform;
                        Slots[YLine * X_Length + XLine].ParentSize = (short)This_Size;
                        //short SizeOfItem = Item_DataBase.item_database.Requesting_Size(package[0, XLine, YLine], package[1, XLine, YLine]);
                        //Slots[YLine * X_Length + XLine].Size = SizeOfItem;
                        Slots[YLine * X_Length + XLine].Size = 0;
                    }
                }
            }
        }


        Recent_Recieved_Package = changedPackage;
    }

    private int SlotSize_Req(int num)
    {
        //0 , 19 , 37, 56
        //1,  2,  3, 4
        int Length = 0;

        switch (num)
        {
            case 0:
                Length = 18;
                break;
            case 1:
                Length = 18;
                break;
            case 2:
                Length = 36;
                break;
            case 3:
                Length = 56;
                break;
            case 4:
                Length = 75;
                break;
            case 5:
                Length = 93;
                break;
            case 6:
                Length = 112;
                break;
            case 7:
                Length = 130;
                break;
            case 8:
                Length = 130;
                break;
        }


        return Length;
    }
}
