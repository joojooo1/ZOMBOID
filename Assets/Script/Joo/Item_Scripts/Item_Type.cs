using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bandages_Type
{
    Adhesive_Bandages = 0,  // Á¢Âø ºØ´ë ( ÃâÇ÷ ¸ØÃã, Ä¡À¯ ¼Óµµ ³ôÀÓ )
    Bandage = 1,  // ºØ´ë ( ÃâÇ÷ ¸ØÃã, Ä¡À¯ ¼Óµµ ³ôÀÓ )
    Sterilized_Bandage = 2,  // ¸ê±Õ ºØ´ë ( ÃâÇ÷ ¸ØÃã, Ä¡À¯ ¼Óµµ ³ôÀÓ, °¨¿°È®·ü °¨¼Ò )
    Dirty_Bandage = 3,  // ´õ·¯¿î ºØ´ë ( ÃâÇ÷ ¸ØÃã, °¨¿°È®·ü »ó½Â )
    Ripped_Sheets = 4,  // Âõ¾îÁø Ãµ ( ÃâÇ÷ ¸ØÃã, Ä¡À¯ ¼Óµµ ³ôÀÓ )
    Sterilized_Rag = 5,  // »ì±ÕµÈ Ãµ ( ÃâÇ÷ ¸ØÃã, Ä¡À¯ ¼Óµµ ³ôÀÓ, °¨¿°È®·ü °¨¼Ò )
    Dirty_Rag = 6,  // ´õ·¯¿î Ãµ ( ÃâÇ÷ ¸ØÃã, °¨¿°È®·ü »ó½Â )
    Splint = 7,  // ºÎ¸ñ ( ºÎ·¯Áø »À È¸º¹¿¡ µµ¿ò, Ä¡·á ¼Ò¿ä½Ã°£ ´ÜÃà )
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
    Canned_food = 0,  // ÅëÁ¶¸² ½ÄÇ°
    Spice = 1,  // Çâ½Å·á
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