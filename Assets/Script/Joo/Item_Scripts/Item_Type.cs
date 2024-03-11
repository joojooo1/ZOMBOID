using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bandages_Type
{
    Adhesive_Bandages = 0,  // ���� �ش� ( ���� ����, ġ�� �ӵ� ���� )
    Bandage = 1,  // �ش� ( ���� ����, ġ�� �ӵ� ���� )
    Sterilized_Bandage = 2,  // ��� �ش� ( ���� ����, ġ�� �ӵ� ����, ����Ȯ�� ���� )
    Dirty_Bandage = 3,  // ������ �ش� ( ���� ����, ����Ȯ�� ��� )
    Ripped_Sheets = 4,  // ������ õ ( ���� ����, ġ�� �ӵ� ���� )
    Sterilized_Rag = 5,  // ��յ� õ ( ���� ����, ġ�� �ӵ� ����, ����Ȯ�� ���� )
    Dirty_Rag = 6,  // ������ õ ( ���� ����, ����Ȯ�� ��� )
    Splint = 7,  // �θ� ( �η��� �� ȸ���� ����, ġ�� �ҿ�ð� ���� )
    None = 8
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
    Canned_food = 0,  // ������ ��ǰ
    Spice = 1,  // ��ŷ�
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