using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Literature : ScriptableObject
{
    public Book_Type LiteratureType;
    public Skill_Type LiteratureSkillType;
    public Location_Type Location;
    public int Literature_ID;

    public int Width_block;
    public int Height_block;
    public int Nesting_Depth;

    public string LiteratureName;
    public string LiteratureName_Kr;
    public float LiteratureWeight;
    public Sprite Literature_Image;

    public int Literature_Level;
    public int Literature_Page;
    // 게임시간 10분에 5페이지 ( 실제시간 25초에 5페이지 )
    /*
        skillbook level 1:  220 page  1100초 ( 18분20초 )
        skillbook level 2:  260 page  1300초 ( 21분40초 )
        skillbook level 3:  300 page  1500초 ( 25분 )
        skillbook level 4:  340 page  1700초 ( 28분20초 )
        skillbook level 5:  380 page  1900초 ( 31분40초 )
     */
    public int Literature_Multiplier;

    public float L_Unhappiness;
    public float L_Stress;
    public float L_Boredom;


}


/*  Magazine
   
  - Fishing
    1. Angler USA Magazine Vol. 1 : 낚시대
    2. Angler USA Magazine Vol. 2 : 어망, 낚시줄

   - Electrical
    1. Electronics Magazine Vol. 1 : 원격조작장비
    2. Electronics Magazine Vol. 2 : 타이머
    3. Electronics Magazine Vol. 3 : 동작감지센서
    4. Electronics Magazine Vol. 4 : 원격폭발트리거
    5. Engineer Magazine Vol. 1 : 소음발생기
    6. Engineer Magazine Vol. 2 : 연막탄
    7. Guerilla Radio Vol. 1 : 라디오
    8. Guerilla Radio Vol. 2 : 무전기
    9. Guerilla Radio Vol. 3 : 햄 라디오
    10. How to Use Generators : 발전기
    11. Laines Auto Manual - Standard Models : 일반 차량을 정비할 수 있게 됨
    12. Laines Auto Manual - Commercial Models : 대형/상업용 차량을 정비할 수 있게 됨
    13. Laines Auto Manual - Performance Models : 스포츠카를 정비할 수 있게 됨
    14. The Metalwork Magazine Vol. 1 : 금속 벽, 금속 지붕
    15. The Metalwork Magazine Vol. 2 : 금속 컨테이너
    16. The Metalwork Magazine Vol. 3 : 금속 펜스
    17. The Metalwork Magazine Vol. 4 : 금속 판, 소형 금속 판

   - Cooking
    1. Good Cooking Magazine Vol. 1 : 케이크, 파이 반죽
    2. Good Cooking Magazine Vol. 2 : 빵반죽

   - Farming
    1. The Farming Magazine : 곰팡이 제거제, 파리 제거제

   - Foraging
    1. The Herbalist : 허브, 베리, 버섯을 구분할 수 있게 됨 ( 독이 든 음식이 별도로 구별되어 보임 )

 */