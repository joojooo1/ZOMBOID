using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            {1,0,1,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {1,0,0,0,0,0,0,0,0,0},
            {0,0,8,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {9,0,18,0,0,0,0,0,0,0},
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
            {0,0,0,0,0,0,0,0,0,0},
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
    private void Awake()
    {
        IL = this;
        Inventory_DB = new List<short[,,]>();
        Inventory_DB.Add(packageExample_8x6);
        Debug.Log("invenlibrary adding example86" + Inventory_DB.Count);
        Inventory_DB.Add(packageExample_8x10);
        Debug.Log("LB 810 num = " + Inventory_DB.Count);
        Inventory_DB.Add(packageExample_2x4);
        Inventory_DB.Add(packageExample_4x3);
    }
    private void Start()
    {
        for(int i = 0; i < 38; i++)
        {
            short[,,] dumy= new short[1, 1, 1];
            Inventory_DB.Add(dumy);
        }
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
        short Order =(short)Inventory_DB.Count;
        return Order;
    }
    public short[,,] Getting_Package(short Order)
    {
        short[,,] Exist_Package = new short[1,1,1];
        Exist_Package = Inventory_DB[Order];
        return Exist_Package;
    }
    public void Resetting_Package(short Order,short[,,] Changed_Packages)
    {
        Inventory_DB[Order] = Changed_Packages;

    }
    public short Getting_Package_Num(short Order)
    {
        short Package_Num = Order;
        return Package_Num;
    }

    
}
