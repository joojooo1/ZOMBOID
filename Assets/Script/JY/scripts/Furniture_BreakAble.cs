using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture_BreakAble : MonoBehaviour
{
    bool TowardUP=false;
    bool Can_Enter_Animation=false;
    bool IsLarge=false;
    bool IsMain=false;
    public List<GameObject> Parts;
    public Transform PointMainBody;

    public void Setting_First(bool tof1, bool tof2, bool tof3, bool tof4)
    {
        TowardUP = tof1;
        Can_Enter_Animation = tof2;
        IsLarge = tof3;
        IsMain = tof4;
    }
    public bool Getting_IsUp()
    {
        bool Response= false;
        return Response;
    }
    public bool Getting_EnterAble()
    {
        bool Response = false;
        return Response;
    }
    public bool Getting_IsLarge()
    {
        bool Response = false;
        return Response;
    }
    public bool Getting_IsMain()
    {
        bool Response = false;
        return Response;
    }

}
