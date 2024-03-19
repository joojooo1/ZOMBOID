using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_s : MonoBehaviour
{

    //서버에서 최초접속자 호스트로 지정

    public bool Is_Host;
    public List<short[,,]> Inventory_Library;

    
    public short Adding_New_Package(short[,,] Packages)
    {
        short Order=0;


        return Order;
    }

    public short[,,] Getting_Package(short Order)
    {
        short[,,] Exist_Package = new short[1,1,1];

        Exist_Package = Inventory_Library[Order];
        return Exist_Package;
    }
}
