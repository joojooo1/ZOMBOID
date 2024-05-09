using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory_Library : MonoBehaviour
{
    public static Inventory_Library IL;
    //�������� ���������� ȣ��Ʈ�� ����

    bool Is_Host = false;
    public List<short[,,]> Inventory_DB;

    short[,,] packageExample_8x6 =
    {
        {
            {0,8,0,0,0,0},
            {0,0,0,0,0,0},
            {1,0,0,0,0,0},
            {0,0,0,0,0,0},
            {1,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        },
        {
            {0,16,0,0,0,0},
            {0,0,0,0,0,0},
            {9,0,0,0,0,0},
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
        },
        { // count -1
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

    short[,,] packageExample_8x10 =
    {
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {1,0,1,0,0,8,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {1,0,0,0,0,0,0,0,0,0},
            {0,0,8,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {9,0,18,0,0,4,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,16,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,3,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0}
        }
    };

    short[,,] packageExample_2x4 =
    {
        {
            {0,0},
            {0,0},
            {0,0},
            {0,0}
        },
        {
            {0,0},
            {0,0},
            {0,0},
            {0,0}
        },
        {
            {0,0},
            {0,0},
            {0,0},
            {0,0}
        },
        {
            {0,0},
            {0,0},
            {0,0},
            {0,0}
        },
        {
            {0,0},
            {0,0},
            {0,0},
            {0,0}
        }
    };

    short[,,] packageExample_4x3 =
    {
        {
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},

        },
        {
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},
        },
        {
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},
        },
        {
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},
        },
        {
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},
        }
    };

    short[,,] packageExample_4x4 =
   {
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        }
    };

    public short[,,] packageExample_8x14 =
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
        }
    };
    private void Awake()
    {
        IL = this;
        Inventory_DB = new List<short[,,]>();
        Inventory_DB.Add(packageExample_2x4);

        Inventory_DB.Add(packageExample_8x6);

        Inventory_DB.Add(packageExample_8x10);

        Inventory_DB.Add(packageExample_4x4);

        Inventory_DB.Add(packageExample_4x3);

        short[,,] copy = new short[5, 8, 14];
        Inventory_DB.Add(copy);
        Debug.Log("Furniture Sample Num = " + Inventory_DB.Count);

    }
    private void Start()
    {
        //for(int i = 0; i < 38; i++)
        //{
        //    short[,,] dumy= new short[1, 1, 1];
        //    Inventory_DB.Add(dumy);
        //}

    }
    public void Setting_ThisPlayer_Host()
    {
        Is_Host = true;
    }
    public bool Getting_IsThisPlayer_Host()
    {
        return Is_Host;
    }

    public short Adding_New_Package(short[,,] Packages)
    {
        //db�� ��Ű�� �߰� ������ȣ ��ȯ
        Inventory_DB.Add(Packages);
        short Order = (short)Inventory_DB.Count;
        return Order;
    }
    public short Adding_New_Ground8x14_Package()
    {
        //db�� ��Ű�� �߰� ������ȣ ��ȯ
        short[,,] copy = new short[5, 8, 14];

        // Array.Copy�� ����Ͽ� ���� ���� ����
        for (int d = 0; d < 5; d++)
        {
            Array.Copy(packageExample_8x14, d * 8 * 14, copy, d * 8 * 14, 8 * 14);
        }
        Inventory_DB.Add(copy);
        short Order = (short)Inventory_DB.Count;
        return Order;
    }
    public short[,,] Getting_Package(short Order)
    {
        short[,,] Exist_Package = new short[1, 1, 1];
        Exist_Package = Inventory_DB[Order];
        return Exist_Package;
    }
    public void Resetting_Package(short Order, short[,,] Changed_Packages)
    {
        Inventory_DB[Order] = Changed_Packages;

    }
    public short Getting_Package_Num(short Order)
    {
        short Package_Num = Order;
        return Package_Num;
    }

    public void Spawn_Items(short Order)
    {
        int Spawn_Maximum_Amount = 8;
        int Type_Maximun_Border = 8;

        short[,,] sample = Getting_Package(Order);
        int Array_Heigt_Item_Width = sample.GetLength(1);
        int Array_Width_Item_Height = sample.GetLength(2);

        //UnityEngine.Random.InitState(33);

        int TotalNum = UnityEngine.Random.Range(0, Spawn_Maximum_Amount);

        short[,,] SummonCollector = new short[5, Spawn_Maximum_Amount, 1];
        for (int SummonCount = 0; SummonCount < TotalNum; SummonCount++)
        {
            int Type = (short)UnityEngine.Random.Range(0, Type_Maximun_Border);//type
            Type = 1;
            SummonCollector[0, SummonCount, 0] = (short)Type;
            int ID = 0;
            switch (Type)
            {
                case 0:
                    ID = UnityEngine.Random.Range(0, Item_DataBase.item_database.food_Ins.Count - 1);//ID
                    SummonCollector[1, SummonCount, 0] = (short)ID;
                    break;
                case 1:
                    ID = UnityEngine.Random.Range(0, Item_DataBase.item_database.food_Ins.Count - 1);//ID
                    SummonCollector[1, SummonCount, 0] = (short)ID;
                    break;
                case 2:
                    ID = UnityEngine.Random.Range(0, Item_DataBase.item_database.food_Ins.Count - 1);//ID
                    SummonCollector[1, SummonCount, 0] = (short)ID;
                    break;
                case 3:
                    ID = UnityEngine.Random.Range(0, Item_DataBase.item_database.food_Ins.Count - 1);//ID
                    SummonCollector[1, SummonCount, 0] = (short)ID;
                    break;
                case 4:
                    ID = UnityEngine.Random.Range(0, Item_DataBase.item_database.food_Ins.Count - 1);//ID
                    SummonCollector[1, SummonCount, 0] = (short)ID;
                    break;
                case 5:
                    ID = UnityEngine.Random.Range(0, Item_DataBase.item_database.food_Ins.Count - 1);//ID
                    SummonCollector[1, SummonCount, 0] = (short)ID;
                    break;
                case 6:
                    ID = UnityEngine.Random.Range(0, Item_DataBase.item_database.food_Ins.Count - 1);//ID
                    SummonCollector[1, SummonCount, 0] = (short)ID;
                    break;
                case 7:
                    ID = UnityEngine.Random.Range(0, Item_DataBase.item_database.food_Ins.Count - 1);//ID
                    SummonCollector[1, SummonCount, 0] = (short)ID;
                    break;
                case 8:
                    ID = UnityEngine.Random.Range(0, Item_DataBase.item_database.Container_Ins.Count - 1);
                    SummonCollector[1, SummonCount, 0] = (short)ID;
                    if (ID < 8)
                    {
                        //����Ư������
                    }
                    break;
            }
        }


        int[] SizeSortedArray = new int[Spawn_Maximum_Amount];
        for (int TurnAround = 0; TurnAround < SummonCollector.GetLength(1); TurnAround++)
        {
            int I_Width = Item_DataBase.item_database.Requesting_Original_Width(SummonCollector[0, TurnAround, 0], SummonCollector[1, TurnAround, 0]);
            int I_Heigt = Item_DataBase.item_database.Requesting_Original_Height(SummonCollector[0, TurnAround, 0], SummonCollector[1, TurnAround, 0]);
            int Total_Size = (I_Width * I_Heigt) * 100;
            Total_Size += TurnAround;

            SizeSortedArray[TurnAround] = Total_Size;
        }
        Array.Sort(SizeSortedArray); // �ܼ� ũ��� ����    1~10���ڸ��� SC ���� ex)0~8    1���� �����迭
        for (int i = 0; i < SizeSortedArray.Length; i++)
        {
            if (SizeSortedArray[i] < 100)
            {
                SizeSortedArray[i] = 0;
            }
        }
        //���ø�
        short[,,] SampleS =
        {
            { { 1 },{ 1 },{ 1 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 } },
            { { 80 },{ 9 },{ 45 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 } },
            { { 0 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 } },
            { { 0 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 } },
            { { 0 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 },{ 0 } }
        };
        int[] SampleSS =
        {
            200,201,402,0,0,0,0,0
        };
        SummonCollector = SampleS;
        SizeSortedArray = SampleSS;

        for (int Count = 0; Count < SizeSortedArray.Length; Count++)
        {
            bool Find_Empty_Location = true; //while ���� ��ĭ�� ã��������

            while (Find_Empty_Location)
            {
                if (SizeSortedArray[Count] == 0)
                {
                    //Debug.Log("EmptySSA");
                    break;
                }
                else if (Item_DataBase.item_database.Requesting_Original_Width(SummonCollector[0, SizeSortedArray[Count] % 100, 0], SummonCollector[1, SizeSortedArray[Count] % 100, 0]) > Array_Heigt_Item_Width)
                {
                    Find_Empty_Location = false;
                    break;
                    // ������ ���� �迭 ����
                }
                else if (Item_DataBase.item_database.Requesting_Original_Height(SummonCollector[0, SizeSortedArray[Count] % 100, 0], SummonCollector[1, SizeSortedArray[Count] % 100, 0]) > Array_Width_Item_Height)
                {
                    Find_Empty_Location = false;
                    break;
                    // ������ ���� �迭 ����
                }
                else
                {

                    for (int Item_y_Count = 0; Item_y_Count < Array_Width_Item_Height; Item_y_Count++) // ������ ���� �迭 ����
                    {
                        for (int Item_x_Count = 0; Item_x_Count < Array_Heigt_Item_Width; Item_x_Count++) // ������ ���� �迭 ����
                        {
                            if (sample[0, Item_x_Count, Item_y_Count] == 0)
                            {
                                if (Item_DataBase.item_database.Requesting_Original_Width(SummonCollector[0, SizeSortedArray[Count] % 100, 0], SummonCollector[1, SizeSortedArray[Count] % 100, 0]) == 1 && Item_DataBase.item_database.Requesting_Original_Height(SummonCollector[0, SizeSortedArray[Count] % 100, 0], SummonCollector[1, SizeSortedArray[Count] % 100, 0]) == 1)
                                {
                                    // 101
                                    for (int Depth = 0; Depth < 5; Depth++)
                                    {
                                        sample[Depth, Item_x_Count, Item_y_Count] = SummonCollector[Depth, SizeSortedArray[Count] % 100, 0];
                                    }
                                    //Debug.Log("Sapwn 11 Complete");

                                    goto Exitloop;
                                }
                                else// ũ�⸦ ����
                                {
                                    for (int Depth = 0; Depth < 5; Depth++)
                                    {
                                        sample[Depth, Item_x_Count, Item_y_Count] = SummonCollector[Depth, SizeSortedArray[Count] % 100, 0];
                                    }

                                    int I_Width = Item_DataBase.item_database.Requesting_Original_Width(SummonCollector[0, SizeSortedArray[Count] % 100, 0], SummonCollector[1, SizeSortedArray[Count] % 100, 0]);
                                    //������ ���� �迭 ����
                                    int I_Height = Item_DataBase.item_database.Requesting_Original_Height(SummonCollector[0, SizeSortedArray[Count] % 100, 0], SummonCollector[1, SizeSortedArray[Count] % 100, 0]);
                                    //������ ���� �迭 ����

                                    if (I_Width > 1)
                                    {
                                        for (int Item_Width = 1; Item_Width < I_Width; Item_Width++) // ������ ���� �迭 ����
                                        {
                                            for (int Item_Height = 0; Item_Height < I_Height; Item_Height++) // ������ ���� �迭 ����
                                            {
                                                sample[0, Item_x_Count + Item_Width, Item_y_Count + Item_Height] = 99; // �ӽ�

                                            }
                                        }
                                    }
                                    if (I_Height > 1)
                                    {
                                        for (int Item_Height = 1; Item_Height < I_Height; Item_Height++) // ������ ���� �迭 ����
                                        {
                                            for (int Item_Width = 0; Item_Width < I_Width; Item_Width++) // ������ ���� �迭 ����
                                            {
                                                sample[0, Item_x_Count + Item_Width, Item_y_Count + Item_Height] = 99; // �ӽ�
                                            }
                                        }
                                    }
                                    //Debug.Log("Spawn Not11 Complete");
                                    goto Exitloop;
                                }
                            }
                        }
                    }
                }
                break;
            }
        Exitloop:;

        
        }

        //99 ����
        for (int Clear_Y = 0; Clear_Y < Array_Heigt_Item_Width; Clear_Y++)
        {
            for (int Clear_X = 0; Clear_X < Array_Width_Item_Height; Clear_X++)
            {
                if (sample[0, Clear_Y, Clear_X] == 99)
                {
                    sample[0, Clear_Y, Clear_X] = 0;
                }
            }
        }
    }

}
