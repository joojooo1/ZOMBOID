using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public static PlayerSkill playerSkill;

    // ��ü �ɷ�
    public PlayerPassiveSkill_Level Fitness_Level;  // ü��       /* 24.02.16 test */
    public PlayerPassiveSkill_Level Strength_Level;  // �ٷ�       /* 24.02.16 test */

    // ���� �ɷ�
    // ���
    // float Fishing = 0f;  // ����
    // float Trapping = 0f;  // ����
    // float Foraging = 0f;  // ä��
    // �¸�

    // � �ɷ�
    public PlayerGeneralSkill_Level Sprinting_Level;  // �ɼ��� �޸���                                                    /* 24.02.16 test */
    public PlayerGeneralSkill_Level Lightfooted_Level;  // ������ �߰��� (�÷��̾��� �߼Ҹ��� �󸶳� �ָ��� �鸮����)        /* 24.02.16 test */
    public PlayerGeneralSkill_Level Nimble_Level;  // ������ �߰���                                                       /* 24.02.16 test */
    public PlayerGeneralSkill_Level Sneaking_Level;  // ������ ������ (������ ������ �߼Ҹ� ũ��&���� �߰��� Ȯ��)                /* 24.02.16 test */

    // ���� �ɷ�
    public PlayerWeaponSkill_Level Axe_Level;  // ����
    public PlayerWeaponSkill_Level LongBlunt_Level;  // �� �б�
    public PlayerWeaponSkill_Level ShortBlunt_Level;  // ª�� �б�
    public PlayerWeaponSkill_Level LongBlade_Level;  // ���
    public PlayerWeaponSkill_Level ShortBlade_Level;  // �ܰ�
    public PlayerWeaponSkill_Level Spear_Level;  // â

    public PlayerMaintenanceSkill_Level Maintenance_Level;  // ���ǰ��� ( ���������� ������ �Ҹ����� ������ ��ħ )

    // �ѱ�
    public PlayerGunSkill_Level Aiming_Level;  // ����
    public PlayerGunSkill_Level Reloading_Level;  // ������

    // ���� �ɷ�
    public PlayerCraftingSkill_Level Carpentry_Level;  // ���
    public PlayerCraftingSkill_Level Cooking_Level;  // �丮
    public PlayerCraftingSkill_Level Farming_Level;  // ���
    public PlayerCraftingSkill_Level FirstAid_Level;  // �Ƿ�
    public PlayerCraftingSkill_Level Electrical_Level;  // �������
    // float Metalworking = 0f;  // �ݼӿ���
    // float Mechanics = 0f;  // ��������
    // float Tailoring = 0f;  // ��ܼ�

    private void Awake()
    {
        playerSkill = this;

        Fitness_Level = new PlayerPassiveSkill_Level(5.0f, "Fitness");
        Strength_Level = new PlayerPassiveSkill_Level(5.0f, "Strength");

        Sprinting_Level = new PlayerGeneralSkill_Level(0f, "Sprinting");
        Lightfooted_Level = new PlayerGeneralSkill_Level(0f, "Lightfooted");
        Nimble_Level = new PlayerGeneralSkill_Level(0f, "Nimble");
        Sneaking_Level = new PlayerGeneralSkill_Level(0f, "Sneaking");

        Axe_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.Axe);
        LongBlunt_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.LongBlunt);
        ShortBlunt_Level = new  (0f, Weapon_type.ShortBlunt);
        LongBlade_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.LongBlade);
        ShortBlade_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.ShortBlade);
        Spear_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.Spear);
        Maintenance_Level = new PlayerMaintenanceSkill_Level(0f);

        Aiming_Level = new PlayerGunSkill_Level(0f, Weapon_type.Gun, "Aiming");
        Reloading_Level = new PlayerGunSkill_Level(0f, Weapon_type.Gun, "Reloading");


        Carpentry_Level = new PlayerCraftingSkill_Level(0f, "Carpentry");
        Cooking_Level = new PlayerCraftingSkill_Level(0f, "Cooking");
        Farming_Level = new PlayerCraftingSkill_Level(0f, "Farming");
        FirstAid_Level = new PlayerCraftingSkill_Level(0f, "FirstAid");
        Electrical_Level = new PlayerCraftingSkill_Level(0f, "Electrical");


    }

}
