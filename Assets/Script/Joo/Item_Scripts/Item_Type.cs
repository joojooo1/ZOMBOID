using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Bandages_Type
{
    Adhesive_Bandages = 0,  // 접착 붕대 ( 출혈 멈춤, 치유 속도 높임 )
    Bandage = 1,  // 붕대 ( 출혈 멈춤, 치유 속도 높임 )
    Sterilized_Bandage = 2,  // 멸균 붕대 ( 출혈 멈춤, 치유 속도 높임, 감염확률 감소 )
    Dirty_Bandage = 3,  // 더러운 붕대 ( 출혈 멈춤, 감염확률 상승 )
    Ripped_Sheets = 4,  // 찢어진 천 ( 출혈 멈춤, 치유 속도 높임 )
    Sterilized_Rag = 5,  // 살균된 천 ( 출혈 멈춤, 치유 속도 높임, 감염확률 감소 )
    Dirty_Rag = 6,  // 더러운 천 ( 출혈 멈춤, 감염확률 상승 )
    Splint = 7  // 부목 ( 부러진 뼈 회복에 도움, 치료 소요시간 단축 )
}


public class Item_Type : MonoBehaviour
{
    
}
