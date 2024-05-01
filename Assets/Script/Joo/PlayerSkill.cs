using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.UIElements;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine.Rendering;
using System.Security.Principal;
using System.Threading;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerSkill : MonoBehaviour
{
    public static PlayerSkill playerSkill;

    // ��ü �ɷ�
    public PlayerPassiveSkill_Level Fitness_Level;  // ü��       /* 24.02.16 test */
    public PlayerPassiveSkill_Level Strength_Level;  // �ٷ�       /* 24.02.16 test */

    // ���� �ɷ�
    public PlayerSurvivalSkill_Level Hunting_Level;  // ���  // ��������
    public PlayerSurvivalSkill_Level Fishing_Level;  // ����
    public PlayerSurvivalSkill_Level Foraging_Level;  // ä��
    public PlayerSurvivalSkill_Level Riding_Level;  // �¸�

    // � �ɷ�
    public PlayerGeneralSkill_Level Sprinting_Level;  // �ɼ��� �޸���                                                    /* 24.02.16 test */
    public PlayerGeneralSkill_Level Lightfooted_Level;  // ������ �߰��� (�÷��̾��� �߼Ҹ��� �󸶳� �ָ��� �鸮����)        /* 24.02.16 test */
    public PlayerGeneralSkill_Level Nimble_Level;  // ���ؽ� �߰���                                                       /* 24.02.16 test */
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
    // public PlayerCraftingSkill_Level Tailoring_Level;  // ��ܼ�
    // float Metalworking = 0f;  // �ݼӿ���
    // float Mechanics = 0f;  // ��������

    private void Awake()
    {
        playerSkill = this;

        Fitness_Level = new PlayerPassiveSkill_Level(5.0f, "Fitness", "ü��");
        Strength_Level = new PlayerPassiveSkill_Level(5.0f, "Strength", "�ٷ�");

        Hunting_Level = new PlayerSurvivalSkill_Level(0f, "Hunting", "���");  // �C ���� ����, ����: ȹ�淮 
        Fishing_Level = new PlayerSurvivalSkill_Level(0f, "Fishing", "����");  // ����: ȹ�淮, ���� Ȯ��  ���ô�� ���� ����
        Foraging_Level = new PlayerSurvivalSkill_Level(0f, "Foraging", "ä��");  // ��Ŭ������ ä��(����), ����: ȹ�淮�� ����
        Riding_Level = new PlayerSurvivalSkill_Level(0f, "Riding", "�¸�");  // ������ ���� Ż���ִ���, �ӵ�   ( �ļ��� )

        Sprinting_Level = new PlayerGeneralSkill_Level(0f, "Sprinting", "�ɼ��� �޸���");
        Lightfooted_Level = new PlayerGeneralSkill_Level(0f, "Lightfooted", "������ �߰���");
        Nimble_Level = new PlayerGeneralSkill_Level(0f, "Nimble", "���ؽ� �߰���");
        Sneaking_Level = new PlayerGeneralSkill_Level(0f, "Sneaking", "������ ������");

        Axe_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.Axe, "Axe", "����");
        LongBlunt_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.LongBlunt, "LongBlunt", "�� �б�");
        ShortBlunt_Level = new  (0f, Weapon_type.ShortBlunt, "ShortBlunt", "ª�� �б�");
        LongBlade_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.LongBlade, "LongBlade", "���");
        ShortBlade_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.ShortBlade, "ShortBlade", "�ܰ�");
        Spear_Level = new PlayerWeaponSkill_Level(0f, Weapon_type.Spear, "Spear", "â");
        // ����: ������ ����

        Maintenance_Level = new PlayerMaintenanceSkill_Level(0f, "Maintenance", "���ǰ���");

        Aiming_Level = new PlayerGunSkill_Level(0f, Weapon_type.Gun, "Aiming", "����");
        Reloading_Level = new PlayerGunSkill_Level(0f, Weapon_type.Gun, "Reloading", "������");

        Carpentry_Level = new PlayerCraftingSkill_Level(0f, "Carpentry", "���");  // ����, ��Ÿ��, ��  // ����: �������� ����
        Cooking_Level = new PlayerCraftingSkill_Level(0f, "Cooking", "�丮");  // ������  // ����: �丮�� ȿ�� ����
        Farming_Level = new PlayerCraftingSkill_Level(0f, "Farming", "���");  // ����: ��Ȯ�� ����, �ൿ�ӵ� ����
        FirstAid_Level = new PlayerCraftingSkill_Level(0f, "FirstAid", "�Ƿ�");  // �Ƿᵵ�� ����  // ����: ġ��ӵ�
        Electrical_Level = new PlayerCraftingSkill_Level(0f, "Electrical", "�������");   // ����: �ڵ��� ����, ���ذ����� ������ǰ ���� ����   ( �ļ��� )

        // �Ϲ�, ����, �Ƿᵵ��
        // �丮
        // ����
    }

}
