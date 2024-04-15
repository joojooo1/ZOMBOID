using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Library : MonoBehaviour
{
    public static Inventory_Library IL;
    //�������� ���������� ȣ��Ʈ�� ����

    bool Is_Host = false;
    public List<short[,,]> Inventory_DB;

    private void Awake()
    {
        IL = this;
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
