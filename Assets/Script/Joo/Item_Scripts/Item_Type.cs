using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Empty = 0,
    Farming = 1,
    food = 2,
    Normal = 3,   // 도구가 아닌 일반 아이템 == ETC ( 무기로 쓰이는 아이템 포함 ) // 소모품
    literature = 4,
    Tool = 5,  // 도구 ( 무기로 쓰이는 도구 포함 )
    clothing = 6,
    Container = 7,
    Electronics = 8,
    Medical = 9,
    Furniture = 10,
    weapon = 11
}

public enum Using_Type
{
    Attack = 0,
    General = 1,
    Repair = 2,  // 수리
    Fishing = 3,
    Cooking = 4,
    Destroy = 5,  // ?
    Farming = 6,
    Ingredients = 7,  // 재료
    Stationery = 8,  // 문구류
    Medical = 9,
    Carpentry = 10,
    Tool = 11,
    Container = 12  // 용기
}

public enum Medical_Type
{
    Bandage = 0,
    Disinfectant = 1,
    Herb = 2,
    Medical_equipment = 3,
    Pharmaceutical = 4
}

public enum Farming_Type
{
    Seed = 0,
    Plant = 1,

}

//public enum AMMO_Type
//{
//    Round_223 = 0,
//    Round_308 = 1,
//    Special_Round_38 = 2,
//    Magnum_Round_44 = 3,
//    Auto_Round_45 = 4,
//    Round_556mm = 5,
//    Round_9mm = 6,
//    Shotgun_Shells = 7,
//    None = 8
//}

//public enum Magazine_Type
//{
//    M9_Magazine = 0,
//    M1911_Auto_Magazine = 1,
//    D_E_Magazine = 2,
//    MSR700_Magazine = 3,
//    MSR788_Magazine = 4,
//    M16_Magazine = 5,
//    M14_Magazine = 6,
//    None = 7
//}

public enum Food_Type
{
    Canned_food = 0,  // 통조림 식품
    Spice = 1,  // 향신료
    Drink = 2, 
    Meat = 3,
    Fish = 4,
    Fruit = 5,
    Grain = 6,
    Sweet = 7,
    Vegetable = 8,
    Cooking = 9,
    Water = 10,
    Ingredients_food = 11
}

public enum Freshness_Level
{
    fresh = 0,
    stale = 1,
    rotten = 2
}

public enum Cooking_State
{
    uncooked = 0,
    cooked = 1,
    burned = 2
}


public enum Book_Type
{
    Map = 0,
    SkillBook = 1,
    Magazine = 2,
    Leisure = 3
}

public enum Skill_Type
{
    Hunting = 0,
    Fishing = 1,
    Foraging = 2,
    Riding = 3,
    Carpentry = 4,
    Cooking = 5,
    Farming = 6,
    FirstAid = 7,
    Electrical = 8,
    None = 9
}

public enum Electronic_usingType
{
    PowerSources = 0,  // 연료
    Container = 1,  // 연료 담는 용도
    Gas = 2,
    Light = 3,
    Charger = 4,
    Tool = 5
}

public enum PowerSources_Type  // 만들어내는 or 담는 연료의 타입
{
    None = 0,
    Electricity = 1,
    Gasoline = 2,
    Battery = 3,  // Battery로만 사용
    PropaneGas = 4,
    Fuel = 5  // Paper, wood, cotton
}

public enum Weapon_type
{
    Axe = 0,
    LongBlunt = 1,
    ShortBlunt = 2,
    LongBlade = 3,
    ShortBlade = 4,
    Spear = 5,
    Gun = 6,
    None = 7,
    Pistol = 8
}

public enum Container_Type
{
    Container = 0,
    Water_Container = 1,
    Furniture = 2,
    Car = 3
}

public enum CanBeEquipped_Bag
{
    None = 0,
    Back = 1,
    Front = 2,
    handle = 3
}

public enum Location_Type
{
    None = 0,
    Container = 1,  // 서랍 등
    Refrigeration = 2,
    Freezer = 3,
    Bookshelf = 4,
    Shelf = 5,
    Closet = 6,

}

public enum Area_Type
{
    Normal = 0,
    Police = 1,
    Fire = 2,
    Gas = 3,
    Prison = 4,
    Store = 5,
    Restaurant = 6,
    Bar = 7,
    Government = 8,
    School = 9,  // 사무실 포함
    Warehouse = 10,
    Hospital = 11,
    Military = 12,
    Fishing = 13,
    Logging = 14,
    Hunting = 15,
    Cooking = 16,
    Crafting = 17,
    Foraging = 18,
    wild = 19
}

public enum Bag_Type
{
    None = 0,     // 빈손 2 x 4
    FannyPack = 1,     // 허리가방 3 x 4
    Handheld = 2,     // 봉투 4 x 4
    Satchel = 3,     // 책가방 8 x 6
    DuffelBag = 4,     // 더플백 6 x 10
    HikingBag = 5,     // 여행용 가방 8 x 10
    MilitaryBackpack = 6     // 군용 배낭 8 x 12
}

public enum Clothing_Type
{
    Hat = 0,
    Glasses = 1,
    Mask = 2,
    Jacket = 3,
    Vest = 4,
    Watch = 5,
    Gloves = 6,
    Belt = 7,
    Shoes = 8,
    Bottoms = 9,
    protectiveGear = 10,
    subBottoms = 11,  // 정강이보호대
    miniBag = 12,
    Bag = 13,
    Shirt = 14,
    T_shirt = 15,
    Underwear = 16,
    None = 17
}
public enum animType
{
    GUN = 0,
    PISTOL = 1,
    ONE_HAND_SWING = 2,
    ONE_HAND_STING = 3,
    TWO_HAND_SWING = 4,
    TWO_HAND_STING = 5,
    IDLE = 6
}