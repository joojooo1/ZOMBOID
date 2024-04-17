using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_8x6 : MonoBehaviour
{
    int X_Length = 8; // v
    int Y_Length = 6; // v
    public short Storage_Order;
    public bool IsPlayers;
    public short[,,] Recent_Recieved_Package; // v

    public GameObject SlotPrefeb; // v


    Item_Container ThisID;
    public InventorySlot[] Slots; // v

    short[,,] packageExample1 =
    {
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {1,0,1,0,0,0},
            {0,0,0,0,0,0},
            {1,0,0,0,0,0},
            {0,0,8,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {9,0,18,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,16,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        },
        {
           {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        }
    };

    private void Start()
    {
        ThisID = Item_DataBase.item_database.Container_Ins[8];
        Generating_Slots_First(packageExample1);
        Ex_Add();
        Storage_Order = 38;
        IsPlayers = true;
    }

    public void Ex_Add() // 서버 테스팅후 지울것
    {
        Inventory_Library.IL.Inventory_DB.Add(Recent_Recieved_Package);
        Debug.Log(Inventory_Library.IL.Inventory_DB.Count);
    }

    public void Generating_Slots_First(short[,,] package)
    {
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
            prefeb.GetComponentInChildren<Canvas>().sortingOrder = 1;
            prefeb.transform.localScale = Vector3.one;
            RectTransform canvasRectTransform = prefeb.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
            canvasRectTransform.anchorMin = new Vector2(0f, 1f);
            canvasRectTransform.anchorMax = new Vector2(0f, 1f);
            canvasRectTransform.localPosition = Vector3.zero;
            canvasRectTransform.sizeDelta = Vector2.zero;

            if (amountofslots >= 8)
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

                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().sprite = Item_DataBase.item_database.Requesting_Image(package[0, XLine, YLine], package[1, XLine, YLine]);
                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    short Size = Item_DataBase.item_database.Requesting_Size(package[0, XLine, YLine], package[1, XLine, YLine]);
                    if (Size != 101) //11 아니면
                    {
                        int Width = Size / 100;
                        int Height = Size % 10;
                        int CanvasWidth = SlotSize_Req(Width);
                        int CanvasHeight = SlotSize_Req(Height);

                        RectTransform canvasRectTransform = Slots[YLine * X_Length + XLine].GetComponentInChildren<Canvas>().GetComponent<RectTransform>();

                        canvasRectTransform.sizeDelta = new Vector2(CanvasWidth, CanvasHeight);

                        canvasRectTransform.anchorMin = new Vector2(0f, 1f);
                        canvasRectTransform.anchorMax = new Vector2(0f, 1f);
                        canvasRectTransform.localPosition = new Vector3(((Width - 1) * (Mathf.Round((CanvasWidth / 2) * 10f) / 10f)), ((-1f) * (Height - 1) * (Mathf.Round((CanvasHeight / 2) * 10f) / 10f)), 0f);

                        if (package[3, XLine, YLine] == 0) //정상
                        {
                            if (Width > 1)
                            {
                                for (int Length_Of_X = 1; Length_Of_X < Width; Length_Of_X++)//와이드는 상수 조건문 통과후 2부터
                                {
                                    Slots[YLine * X_Length + XLine + Length_Of_X].IsMain = false;
                                    Slots[YLine * X_Length + XLine + Length_Of_X].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[YLine * X_Length + XLine + Length_Of_X].Is_Changed--;
                                }
                            }
                            if (Height > 1)
                            {
                                for (int Length_Of_Y = 1; Length_Of_Y < Height; Length_Of_Y++)
                                {
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].IsMain = false;
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].Is_Changed--;
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

                    Slots[YLine * X_Length + XLine].Item_Type = package[0, XLine, YLine];
                    Slots[YLine * X_Length + XLine].Item_ID = package[1, XLine, YLine];
                    Slots[YLine * X_Length + XLine].ParentTransform = this.transform;
                    Slots[YLine * X_Length + XLine].ParentSize = 86;
                    Slots[YLine * X_Length + XLine].Size = Size;

                    Slots[YLine * X_Length + XLine].What_Main = null;
                    Slots[YLine * X_Length + XLine].IsMain = true;

                    Slots[YLine * X_Length + XLine].Is_Changed--;
                }
                else
                {

                    if (!(Slots[YLine * X_Length + XLine].Is_Changed < 1)) // 이미 앞에서 변환된
                    {
                        Slots[YLine * X_Length + XLine].IsMain = true;
                    }

                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().sprite = null;
                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
                    Slots[YLine * X_Length + XLine].Item_Type = 0;
                    Slots[YLine * X_Length + XLine].Item_ID = 0;

                    Slots[YLine * X_Length + XLine].ParentTransform = this.transform;
                    Slots[YLine * X_Length + XLine].ParentSize = 86;
                    short SizeOfItem = Item_DataBase.item_database.Requesting_Size(package[0, XLine, YLine], package[1, XLine, YLine]);
                    Slots[YLine * X_Length + XLine].Size = SizeOfItem;
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
                    short Size = Item_DataBase.item_database.Requesting_Size(changedPackage[0, XLine, YLine], changedPackage[1, XLine, YLine]);
                    if (Size != 101) //11 아니면
                    {
                        int Width = Size / 100;
                        int Height = Size % 10;
                        int CanvasWidth = SlotSize_Req(Width);
                        int CanvasHeight = SlotSize_Req(Height);

                        RectTransform canvasRectTransform = Slots[YLine * X_Length + XLine].GetComponentInChildren<Canvas>().GetComponent<RectTransform>();

                        canvasRectTransform.sizeDelta = new Vector2(CanvasWidth, CanvasHeight);

                        canvasRectTransform.anchorMin = new Vector2(0f, 1f);
                        canvasRectTransform.anchorMax = new Vector2(0f, 1f);
                        canvasRectTransform.localPosition = new Vector3(((Width - 1) * (Mathf.Round((CanvasWidth / 2) * 10f) / 10f)), ((-1f) * (Height - 1) * (Mathf.Round((CanvasHeight / 2) * 10f) / 10f)), 0f);

                        if (changedPackage[3, XLine, YLine] == 0) //정상
                        {
                            if (Width > 1)
                            {
                                for (int Length_Of_X = 1; Length_Of_X < Width; Length_Of_X++)//와이드는 상수 조건문 통과후 2부터
                                {
                                    Slots[YLine * X_Length + XLine + Length_Of_X].IsMain = false;
                                    Slots[YLine * X_Length + XLine + Length_Of_X].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[YLine * X_Length + XLine + Length_Of_X].Is_Changed--;
                                }
                            }
                            if (Height > 1)
                            {
                                for (int Length_Of_Y = 1; Length_Of_Y < Height; Length_Of_Y++)
                                {
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].IsMain = false;
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].What_Main = Slots[YLine * X_Length + XLine].transform;
                                    Slots[YLine * X_Length + XLine + (X_Length * Length_Of_Y)].Is_Changed--;
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
                    Slots[YLine * X_Length + XLine].ParentSize = 86;
                    Slots[YLine * X_Length + XLine].Size = Size;

                    Slots[YLine * X_Length + XLine].What_Main = null;
                    Slots[YLine * X_Length + XLine].IsMain = true;

                    Slots[YLine * X_Length + XLine].Is_Changed--;
                }
                else
                {

                    if (!(Slots[YLine * X_Length + XLine].Is_Changed < 1)) // 이미 앞에서 변환된
                    {
                        Slots[YLine * X_Length + XLine].IsMain = true;
                    }
                    int Width = 1;
                    int Height = 1;
                    int CanvasWidth = 0;
                    int CanvasHeight = 0;

                    RectTransform canvasRectTransform = Slots[YLine * X_Length + XLine].GetComponentInChildren<Canvas>().GetComponent<RectTransform>();

                    canvasRectTransform.sizeDelta = new Vector2(CanvasWidth, CanvasHeight);

                    canvasRectTransform.anchorMin = new Vector2(0f, 1f);
                    canvasRectTransform.anchorMax = new Vector2(0f, 1f);
                    canvasRectTransform.localPosition = new Vector3(((Width - 1) * (Mathf.Round((CanvasWidth / 2) * 10f) / 10f)), ((-1f) * (Height - 1) * (Mathf.Round((CanvasHeight / 2) * 10f) / 10f)), 0f);


                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().sprite = null;
                    Slots[YLine * X_Length + XLine].Image.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    Slots[YLine * X_Length + XLine].BackgroundColor.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1f);
                    Slots[YLine * X_Length + XLine].Item_Type = 0;
                    Slots[YLine * X_Length + XLine].Item_ID = 0;

                    Slots[YLine * X_Length + XLine].ParentTransform = this.transform;
                    Slots[YLine * X_Length + XLine].ParentSize = 86;
                    short SizeOfItem = Item_DataBase.item_database.Requesting_Size(changedPackage[0, XLine, YLine], changedPackage[1, XLine, YLine]);
                    Slots[YLine * X_Length + XLine].Size = SizeOfItem;
                }
            }
        }


        Recent_Recieved_Package = changedPackage;
    }

    private int SlotSize_Req(int num)
    {
        //0 , 19 , 37
        //1,  2,  3
        int Length = 0;

        switch (num)
        {
            case 1:
                Length = 0;
                break;
            case 2:
                Length = 19;
                break;
            case 3:
                Length = 37;
                break;
        }


        return Length;
    }



    public void Adding_Item()
    {

    }
    public void Deleting_Item()
    {

    }
}
