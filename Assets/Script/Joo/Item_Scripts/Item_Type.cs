using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Medical_Type
{
    Bandage = 0,
    Disinfectant = 1,
    Herb = 2,
    Medical_equipment = 3,
    Pharmaceutical = 4
}

public enum AMMO_Type
{
    Round_223 = 0,
    Round_308 = 1,
    Special_Round_38 = 2,
    Magnum_Round_44 = 3,
    Auto_Round_45 = 4,
    Round_556mm = 5,
    Round_9mm = 6,
    Shotgun_Shells = 7,
    None = 8
}

public enum Magazine_Type
{
    M9_Magazine = 0,
    M1911_Auto_Magazine = 1,
    D_E_Magazine = 2,
    MSR700_Magazine = 3,
    MSR788_Magazine = 4,
    M16_Magazine = 5,
    M14_Magazine = 6,
    None = 7
}

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
    etc = 9,
    Cooking = 10
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

public enum Location_Type
{
    None = 0,
    Container = 1,
    Refrigeration = 2,
    freezer = 3,
    Fishing = 4,
    bookshelf = 5
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
    Tailoring = 9,
    None = 10
}

public enum Weapon_Using_Type
{
    Attack = 0,
    Logging = 1,
    Shovel = 2,
    Fishing = 3,
    Cooking = 4,
    Destroy = 5,
    Farming = 6,
    Ingredients = 7

}

public enum Electronic_Type
{
    PowerSources = 0,

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
    Tool = 7
}