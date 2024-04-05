using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture_BreakAble : MonoBehaviour
{
    public bool TowardUP=false;
    public bool Can_Enter_Animation=false;
    public bool IsLarge=false;
    public bool IsMain=false;
    public List<GameObject> Parts;
    public Transform PointMainBody;

    public void Setting_First(bool tof1, bool tof2, bool tof3, bool tof4)
    {
        TowardUP = tof1;
        Can_Enter_Animation = tof2;
        IsLarge = tof3;
        IsMain = tof4;
    }
   

}
