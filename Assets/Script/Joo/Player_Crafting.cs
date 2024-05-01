using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Recipe
{
    public bool Is_Craftng;

    public Type Recipe_type;
    public int Recipe_ID;

    public Type Crafting_item_type;
    public int Crafting_item_ID;
    public List<Recipe_Ingredients> Recipe_Ingredients_list = new List<Recipe_Ingredients>();

    public Recipe(Type _Recipe_type, int _Recipe_ID, Type _Crafting_item_type, int _Crafting_item_ID)
    {
        Recipe_type = _Recipe_type;
        Recipe_ID = _Recipe_ID;
        Crafting_item_type = _Crafting_item_type;
        Crafting_item_ID = _Crafting_item_ID;
        Is_Craftng = false;
    }

    public void Add_Recipe_Ingredients(Type _DB_type, int _DB_ID, int value)
    {
        Recipe_Ingredients recipe_Ingredients = new Recipe_Ingredients(_DB_type, _DB_ID, value);
        Recipe_Ingredients_list.Add(recipe_Ingredients);
    }
}

public class Recipe_Ingredients
{
    public Type Recipe_Ingredients_DB_type;
    public int Recipe_Ingredients_DB_ID;
    public int Recipe_value;  // 필요한 개수

    public Recipe_Ingredients(Type _DB_type, int _DB_ID, int value)
    {
        Recipe_Ingredients_DB_type = _DB_type;
        Recipe_Ingredients_DB_ID = _DB_ID;
        Recipe_value = value;
    }
}

public class Player_Crafting : MonoBehaviour
{
    //12. Good Cooking Magazine Vol. 1 : 케이크 반죽, 파이 반죽, 초콜릿칩쿠키 반죽, 초콜릿쿠키 반죽, 오트밀쿠키 반죽, 쇼트브레드쿠키 반죽, 설탕쿠키 반죽 만들기
    public Recipe Recipe_Make_Cake_Batter;
    public Recipe Recipe_Make_Pie_Dough;
    //13. Good Cooking Magazine Vol. 2 :  빵, 피자, 바게트, 비스킷 만들기
    public Recipe Recipe_Make_Bread; // dough
    //14. Electronics Magazine Vol. 1 :  리모콘 v1, v2, v3 만들기 ( -> 리모콘 만들기 하나로 통일 )
    public Recipe Recipe_Make_Remote_Controller;
    //15. Electronics Magazine Vol. 2 :  타이머 만들기, 다른 물건에 타이머 달기
    public Recipe Recipe_Make_Timer;
    public Recipe Recipe_Add_Timer;
    //16. Electronics Magazine Vol. 3 :  모션센서 v1, v2, v3 만들기 ( -> 모션센서 만들기 하나로 통일 )
    public Recipe Recipe_Add_Motion_Sensor;
    //17. Electronics Magazine Vol. 4 :  원격 트리거 만들기, 다른 물건에 원격 트리거 달기
    public Recipe Recipe_Make_Remote_Trigger;
    public Recipe Recipe_Add_Crafted_Trigger;
    //18. Engineer Magazine Vol. 1 :  소음 발생기 만들기
    public Recipe Recipe_Make_Noise_Maker;
    //19. Engineer Magazine Vol. 2 :  연막탄 만들기
    public Recipe Recipe_Make_Smoke_Bomb;
    //20. The Farming Magazine :  살충제 스프레이, 곰팡이 스프레이 만들기
    public Recipe Recipe_Make_Mildew_Cure;
    public Recipe Recipe_Make_Flies_Cure;
    //21. Angler USA Magazine Vol. 1 :  낚시대 만들기, 낚시대 고치기
    public Recipe Recipe_Make_Fishing_Rod;
    public Recipe Recipe_Fix_Fishing_Rod;
    //22. Angler USA Magazine Vol. 2 :  낚시 그물 만들기, 고장난 낚시 그물에서 와이어 떼내기
    public Recipe Recipe_Make_Fishing_Net;
    public Recipe Recipe_Get_Wire_Back;
    //23. The Herbalist :  독이 있는 열매, 버섯 식별 가능
    public Recipe Recipe_Can_identifty_poisonous_berries_and_mushrooms_and_forage_medicinal_plants;
    //24. How to Use Generators :  발전기 사용법
    public Recipe Recipe_Teaches_the_player_how_to_connect_generators_to_buildings;
    //25. The Hunter Magazine Vol. 1 :  스네어 트랩 만들기  // skip
    public Recipe Recipe_Make_Snare_Trap;
    //26. The Hunter Magazine Vol. 2 :  함정상자 만들기, 스틱 트랩 만들기  // skip
    public Recipe Recipe_Make_Trap_Box;
    public Recipe Recipe_Make_Stick_Trap;
    //27. The Hunter Magazine Vol. 3 :  케이지트랩 만들기  // skip
    public Recipe Recipe_Make_Cage_Trap;
    //28. Laines Auto Manual - Commercial Models :  표준 차량 유형 유지관리 가능
    public Recipe Recipe_Can_perform_maintenance_on_heavy_duty_vehicle_types;
    //29. Laines Auto Manual - Performance Models :  대형 차량 유형 유지관리 가능
    public Recipe Recipe_Can_perform_maintenance_on_sport_vehicle_types;
    //30. Laines Auto Manual - Standard Models :  스포츠 차량 유형 유지관리 가능
    public Recipe Recipe_Can_perform_maintenance_on_standard_vehicle_types;
    //31. The Metalwork Magazine Vol. 1 :  금속벽 만들기, 금속지붕 만들기
    public Recipe Recipe_Make_Metal_Walls;
    public Recipe Recipe_Make_Metal_Roof;
    //32. The Metalwork Magazine Vol. 2 :  금속컨테이너 만들기
    public Recipe Recipe_Make_Metal_Containers;
    //33. The Metalwork Magazine Vol. 3 :  금속울타리 만들기
    public Recipe Recipe_Make_Metal_Fences;
    //34. The Metalwork Magazine Vol. 4 :  금속판 만들기, 소형금속판 만들기
    public Recipe Recipe_Make_Metal_Sheet;
    public Recipe Recipe_Make_Small_Metal_Sheet;
    //35. Guerilla Radio Vol. 1 :  임시 라디오 제작
    public Recipe Recipe_Craft_Makeshift_Radio;
    //36. Guerilla Radio Vol. 2 :  임시 무전기 제작
    public Recipe Recipe_Craft_Makeshift_Walkie_Talkie;
    //37. Guerilla Radio Vol. 3 :  임시 햄 라디오 제작
    public Recipe Recipe_Craft_Makeshift_Ham_Radio;
    private void Awake()
    {
        // Cooking
        Recipe_Make_Cake_Batter = new Recipe(Type.literature, 12, Type.food, 0);
        Recipe_Make_Pie_Dough = new Recipe(Type.literature, 12, Type.food, 0);
        Recipe_Make_Bread = new Recipe(Type.literature, 13, Type.food, 0);

        // Electronics
        Recipe_Make_Remote_Controller = new Recipe(Type.literature, 14, Type.tool, 0);
        Recipe_Make_Timer = new Recipe(Type.literature, 15, Type.tool, 0);
        Recipe_Add_Timer = new Recipe(Type.literature, 15, Type.tool, 0);
        Recipe_Add_Motion_Sensor = new Recipe(Type.literature, 16, Type.tool, 0);
        Recipe_Make_Remote_Trigger = new Recipe(Type.literature, 17, Type.tool, 0);
        Recipe_Add_Crafted_Trigger = new Recipe(Type.literature, 17, Type.tool, 0);

        Recipe_Make_Noise_Maker = new Recipe(Type.literature, 18, Type.tool, 0);
        Recipe_Make_Smoke_Bomb = new Recipe(Type.literature, 19, Type.tool, 0);

        Recipe_Teaches_the_player_how_to_connect_generators_to_buildings = new Recipe(Type.literature, 24, Type.tool, 0);

        Recipe_Can_perform_maintenance_on_heavy_duty_vehicle_types = new Recipe(Type.literature, 28, Type.Normal, 0);
        Recipe_Can_perform_maintenance_on_sport_vehicle_types = new Recipe(Type.literature, 29, Type.Normal, 0);
        Recipe_Can_perform_maintenance_on_standard_vehicle_types = new Recipe(Type.literature, 30, Type.Normal, 0);

        Recipe_Make_Metal_Walls = new Recipe(Type.literature, 31, Type.Normal, 0);
        Recipe_Make_Metal_Roof = new Recipe(Type.literature, 31, Type.Normal, 0);
        Recipe_Make_Metal_Containers = new Recipe(Type.literature, 32, Type.tool, 0);
        Recipe_Make_Metal_Fences = new Recipe(Type.literature, 33, Type.Normal, 0);
        Recipe_Make_Metal_Sheet = new Recipe(Type.literature, 34, Type.Normal, 0);
        Recipe_Make_Small_Metal_Sheet = new Recipe(Type.literature, 34, Type.Normal, 0);

        Recipe_Craft_Makeshift_Radio = new Recipe(Type.literature, 35, Type.Normal, 0);
        Recipe_Craft_Makeshift_Walkie_Talkie = new Recipe(Type.literature, 36, Type.Normal, 0);
        Recipe_Craft_Makeshift_Ham_Radio = new Recipe(Type.literature, 37, Type.Normal, 0);

        // Farming
        Recipe_Make_Mildew_Cure = new Recipe(Type.literature, 20, Type.Normal, 0);
        Recipe_Make_Flies_Cure = new Recipe(Type.literature, 20, Type.Normal, 0);

        // Fishing
        Recipe_Make_Fishing_Rod = new Recipe(Type.literature, 21, Type.weapon, 0);
        Recipe_Fix_Fishing_Rod = new Recipe(Type.literature, 21, Type.Normal, 0);
        Recipe_Make_Fishing_Net = new Recipe(Type.literature, 22, Type.weapon, 0);
        Recipe_Get_Wire_Back = new Recipe(Type.literature, 22, Type.Normal, 0);

        // Foraging
        Recipe_Can_identifty_poisonous_berries_and_mushrooms_and_forage_medicinal_plants = new Recipe(Type.literature, 23, Type.Normal, 0);

        Recipe_Make_Snare_Trap = new Recipe(Type.literature, 25, Type.weapon, 0);
        Recipe_Make_Trap_Box = new Recipe(Type.literature, 26, Type.weapon, 0);
        Recipe_Make_Stick_Trap = new Recipe(Type.literature, 26, Type.weapon, 0);
        Recipe_Make_Cage_Trap = new Recipe(Type.literature, 27, Type.weapon, 0);

    }










}
