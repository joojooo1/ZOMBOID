using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Library : MonoBehaviour
{
    public static Inventory_Library IL;
    //�������� ���������� ȣ��Ʈ�� ����

    public bool Is_Host;
    public List<short[,,]> Inventory_DB;

    private void Awake()
    {
        IL = this;
    }
    public short Adding_New_Package(short[,,] Packages)
    {
        short Order=0;


        return Order;
    }

    public short[,,] Getting_Package(short Order)
    {
        short[,,] Exist_Package = new short[1,1,1];

        Exist_Package = Inventory_DB[Order];
        return Exist_Package;
    }
    public short Getting_Package_Num(short Order)
    {
        short Package_Num = Order;
        return Package_Num;
    }
}
