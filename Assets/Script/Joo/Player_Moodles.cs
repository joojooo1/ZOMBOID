using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Moodles_private_code
{
    Hungry = 0,
    Stuffed = 1,
    Thirsty = 2,
    Panic = 3,
    Bored = 4,
    Stressed = 5,
    Unhappy = 6,
    Drunk = 7,
    Heavy_Load = 8,
    Endurance = 9,
    Tired = 10,
    Hyperthermia_Hot = 11,
    Hyperthermia_Cold = 12,
    Windchill = 13,
    Wet = 14,
    Injured = 15,
    Pain = 16,
    Bleeding = 17,
    Has_a_Cold = 18,
    Sick = 19,
    Dead = 20,
    Zombie = 21,
    Restricted_Movement = 22
}

public class Player_Moodles : MonoBehaviour
{
    public static Player_Moodles playerMoodles;

    public Moodles_state Moodle_Hungry; // �����
    public Moodles_state Moodle_Stuffed; // ��θ�
    public Moodles_state Moodle_Thirsty; // �񸶸�
    public Moodles_state Moodle_Panic; // ���� 
    public Moodles_state Moodle_Bored; // ������
    public Moodles_state Moodle_Stressed; // ��Ʈ����
    public Moodles_state Moodle_Unhappy; // ������
    public Moodles_state Moodle_Drunk; // ����
    public Moodles_state Moodle_Heavy_Load; // ���ſ�
    public Moodles_state Moodle_Endurance; // ��ħ
    public Moodles_state Moodle_Tired; // �ǰ���
    public Moodles_state Moodle_Hyperthermia_Hot; // ����
    public Moodles_state Moodle_Hyperthermia_Cold;  // �߿�
    public Moodles_state Moodle_Windchill; // �� �ٶ�
    public Moodles_state Moodle_Wet; // ����
    public Moodles_state Moodle_Injured; // �λ�
    public Moodles_state Moodle_Pain; // ����
    public Moodles_state Moodle_Bleeding; // ����
    public Moodles_state Moodle_Has_a_Cold; // ����
    public Moodles_state Moodle_Sick; // ����
    public Moodles_state Moodle_Dead;  // ���
    public Moodles_state Moodle_Zombie; // ����ȭ
    public Moodles_state Moodle_Restricted_Movement; // �������� �� �� ����

    private void Awake()
    {
        playerMoodles = this;

        Moodle_Hungry = new Moodles_state(Moodles_private_code.Hungry, 0.15f, 0.25f, 0.45f, 0.7f);
        /*
         15% �̻�: -
         25% �̻�: ��ݴɷ� -1, ü�¹߻��� �ణ����, ġ���ӵ� -35%
         45% �̻�: ��ݴɷ� -2, ü�¹߻��� ����, ġ���ӵ� -60%
         70% �̻�: ��ݴɷ� -2, ü�¹߻��� ������, ġ���ӵ� -60%
         */
        Moodle_Stuffed = new Moodles_state(Moodles_private_code.Stuffed, 0.15f, 0.25f, 0.45f, 0.7f);
        /*
         15% �̻�: ġ���ӵ� �ణ���, ��ݴɷ� +2
         25% �̻�: ġ���ӵ� ���, ��ݴɷ� +2
         45% �̻�: ġ���ӵ� ���, ��ݴɷ� +2, �Ļ� �Ұ���(Į�θ� ��ġ 1000 �̻��� ���)
         70% �̻�: ġ���ӵ� ���, ��ݴɷ� +2, �Ļ� �Ұ���(Į�θ� ��ġ 1000 �̻��� ���)
         */
        Moodle_Thirsty = new Moodles_state(Moodles_private_code.Thirsty, 0.13f, 0.25f, 0.7f, 0.85f);
        /*
         13% �̻�: -
         25% �̻�: ��ݴɷ� -1, ü�¹߻��� �ణ����
         70% �̻�: ��ݴɷ� -2, ü�¹߻��� ����
         85% �̻�: ��ݴɷ� -2, ü�¹߻��� ����, ü�� ������ ���� (�װų� �����ؼ��Ҷ�����)
         */
        Moodle_Panic = new Moodles_state(Moodles_private_code.Panic, 0.3f, 0.5f, 0.8f, 0.9f);  // ���Ƿ� ����
        /*
          30% �̻�(�ణ�� �д�): ũ��Ƽ�� Ȯ�� -1.3%
          50% �̻�(��Ȳ): ũ��Ƽ�� Ȯ�� -2.6%, �������ⵥ���� -0.1,  ���� �ڼ����� �� ���� �Ͼ
          80% �̻�(���� �д�): ũ��Ƽ�� Ȯ�� -3.9%, �������ⵥ���� -0.2, �� ������ -0.4(Aiming_Level�� 6���� ����),  ���� �ڼ����� �� ���� �Ͼ
          90% �̻�(�ͽ�Ʈ�� �д�): ũ��Ƽ�� Ȯ�� -5.2%, �������ⵥ���� -0.3, �� ������ -0.6(Aiming_Level�� 6���� ����),  ���� �ڼ����� �� ���� �Ͼ, �þ� ������

          * ���� �������� 0.1 �̸����� ������������
         */
        Moodle_Bored = new Moodles_state(Moodles_private_code.Bored, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% �̻�: -
         50% �̻�: ���� �����ӵ��� ����
         75% �̻�: ���� ������ �ӵ��� ����
         90% �̻�: ���� ���� �ӵ��� ����
         */
        Moodle_Stressed = new Moodles_state(Moodles_private_code.Stressed, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% �̻�: -
         50% �̻�: ���� & ���Ÿ� ���� -0.1, ���� �����ӵ��� ����
         75% �̻�: ���� & ���Ÿ� ���� -0.2, ���� ������ �ӵ��� ����
         90% �̻�: ���� & ���Ÿ� ���� -0.3, ���� ���� �ӵ��� ����
         */
        Moodle_Unhappy = new Moodles_state(Moodles_private_code.Unhappy, 0.2f, 0.45f, 0.6f, 0.8f);
        /*
         20% �̻�: �ð� ������ �ִ� �ൿ�ӵ� -7.4%
         45% �̻�: �ð� ������ �ִ� �ൿ�ӵ� -13.7%
         60% �̻�: �ð� ������ �ִ� �ൿ�ӵ� -19.6%
         80% �̻�: �ð� ������ �ִ� �ൿ�ӵ� -26.5%
         */
        Moodle_Drunk = new Moodles_state(Moodles_private_code.Drunk, 0.1f, 0.3f, 0.5f, 0.7f);
        /*
         10% �̻�: �Ƿε� �ణ����, ���� ���� �ӵ� ����, ���� ���� ���, ���� ����, ���� ����� ����
         30% �̻�: �Ƿε� �ణ����, ���� ���� �ӵ� ����, ���� ���� ���, ���� ����, ���� ����� ����
         50% �̻�: �Ƿε� ����, ���� ���� �ӵ� ����, ���� ���� ���, ���� ����, ���� ����� ����
         70% �̻�: �Ƿε� ����, ���� ���� �ӵ� ����, ���� ���� ���, ���� ����, ���� ����� ����
         */
        Moodle_Heavy_Load = new Moodles_state(Moodles_private_code.Heavy_Load, 1f, 1.25f, 1.5f, 1.75f);
        /*
         �� �δ� > 100% Weight: ���� ��Ÿ�� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +13%, 
                                ũ��Ƽ�� Ȯ�� -5%, ���� �ӵ� -7%, ���� ��Ÿ���� ���� Ȯ�� -8%, 
                                �̵��ӵ� -19%, ������ ȸ���� ����, ������ ��������� ���Ƴ� Ȯ�� -2%
         �� �δ� > 125% Weight: ���� ��Ÿ�� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +26%, 
                                ũ��Ƽ�� Ȯ�� -10%, ���� �ӵ� -14%, ���� ��Ÿ���� ���� Ȯ�� -16%, �������� �Ұ�,
                                �̵��ӵ� -37%, ������ ȸ���� �ɰ��� ����, ������ ��������� ���Ƴ� Ȯ�� -4%
         �� �δ� > 150% Weight: ���� ��Ÿ�� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +39%, 
                                ũ��Ƽ�� Ȯ�� -15%, ���� �ӵ� -21%, ���� ��Ÿ���� ���� Ȯ�� -24%, 
                                �̵��ӵ� -56%, �޸��� ��Ȱ��ȭ(�Ŀ���ũ ����),
                                ������ ȸ�� ���� �� õõ�� ����, ü�� 75% �� ������ ������ ����, 
                                ������ ��������� ���Ƴ� Ȯ�� -6%
         �� �δ� > 175% Weight: ���� ��Ÿ�� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +52%, 
                                ũ��Ƽ�� Ȯ�� -20%, ���� �ӵ� -28%, ���� ��Ÿ���� ���� Ȯ�� -32%, 
                                �̵��ӵ� -75%, �޸��� ��Ȱ��ȭ(�Ŀ���ũ ����),
                                ������ ȸ�� ���� �� ������ ������ ����, ü�� 75% �� ������ ����, �ȴ� ���¿��� ������ ����
                                ������ ��������� ���Ƴ� Ȯ�� -8%
         */
        Moodle_Endurance = new Moodles_state(Moodles_private_code.Endurance, 25f, 50f, 75f, 91f);
        /*
         75% ����: ���������� -50%, ���ݼӵ� -7%, ���� ��Ÿ�� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +10%,
                   ���� ��Ÿ���� ���� Ȯ�� -5%, �ȱ�/�޸���/�Ŀ���ũ �ӵ� -19%,
                   ������ ��������� ���Ƴ� Ȯ�� -2%
         50% ����: ���������� -80%, ���ݼӵ� -14%, ���� ��Ÿ�� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +20%,
                   ���� ��Ÿ���� ���� Ȯ�� -10%, �ȱ�/�Ŀ���ũ �ӵ� -37%,
                   �޸��� ��Ȱ��ȭ, ������ ��������� ���Ƴ� Ȯ�� -4%
         25% ����: ���������� -90%, ���ݼӵ� -21%, ���� ��Ÿ�� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +30%,
                   ���� ��Ÿ���� ���� Ȯ�� -15%, �ȱ� �ӵ� -56%,
                   �޸���/�Ŀ���ũ ��Ȱ��ȭ, ������ ��������� ���Ƴ� Ȯ�� -6%, � ��Ȱ��ȭ
         9% ����: ���������� -95%, ���ݼӵ� -28%, ���� ��Ÿ�� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +40%,
                   ���� ��Ÿ���� ���� Ȯ�� -20%, �ȱ� �ӵ� -75%, ū ��ġ ���Ұ�
                   �޸���/�Ŀ���ũ ��Ȱ��ȭ, ������ ��������� ���Ƴ� Ȯ�� -8%, � ��Ȱ��ȭ
         */
        Moodle_Tired = new Moodles_state(Moodles_private_code.Tired, 0.6f, 0.7f, 0.8f, 0.9f);
        /*
         60% �̻�: ���������� -50%, �þ� ������, ������ ȸ���� ũ�� ����
         70% �̻�: ���������� -80%, �þ� ������, �ν� �ݰ� ������, ������ ȸ���� �ɰ��ϰ� ����
         80% �̻�: ���������� -90%, �þ� ������, �ν� �ݰ� ������, ������ ȸ���� ������������ ����
         90% �̻�: ���������� -95%, �þ� ������, �ν� �ݰ� �ջ��, ������ ȸ���� �ߴ�
         */
        Moodle_Hyperthermia_Hot = new Moodles_state(Moodles_private_code.Hyperthermia_Hot, 37.5f, 39f, 40f, 41f);  // ����(36f)
        /*
         37.5�� �̻�: ���� �ణ���� ����
         39�� �̻�: ���� ���� ����, �Ƿ� ���� ����, ���ݼӵ� -34%, �̵��ӵ� �ణ ����
         40�� �̻�: ���� ������ ����, �Ƿ� ������ ����, ���ݼӵ� -67%, �̵��ӵ� ������ ����
         41�� �̻�: ���� ������ ����, �Ƿ� ������ ����, ������ �ణ ����, ���ݼӵ� -90%, �̵��ӵ� ũ�� ����, ü�� õõ�� ����
         */
        Moodle_Hyperthermia_Cold = new Moodles_state(Moodles_private_code.Hyperthermia_Cold, 36.5f, 35f, 30f, 25f);  // ����(36f)
        /*
         36.5�� ����: -
         35�� ����: ���ݼӵ� -34%, �ȱ�/�޸��� �ӵ� ������ ����
         30�� ����: ���ݼӵ� -67%, �ȱ�/�޸��� �ӵ� ũ�� ����
         25�� ����: ���ݼӵ� -90%, �ȱ�/�޸��� �ӵ� ���ϰ� ����, ü���� 1%�� �ɶ����� õõ�� ����
        */
        Moodle_Windchill = new Moodles_state(Moodles_private_code.Windchill, 2f, 5f, 7f, 9f);  // ���Ƿ� ����
        /*
         2 �̻�: �������� 5~10�� ���� ����
         5 �̻�: �������� 10~15�� ���� ����
         7 �̻�: �������� 15~20�� ���� ����
         9 �̻�: �������� 20�� �̻� ���� ����
        */
        Moodle_Wet = new Moodles_state(Moodles_private_code.Wet, 0.15f, 0.4f, 0.7f, 0.9f);
        /*
         15% �̻�: �ణ ��������
         40% �̻�: �ټ� ��������
         70% �̻�: ���� �� ����
         90% �̻�: ���� �ɸ� ���ɼ��� ����
        */
        Moodle_Injured = new Moodles_state(Moodles_private_code.Injured, 0.8f, 0.6f, 0.4f, 0.25f);
        /*
         ü�� 80% �̸�: -
         ü�� 60% �̸�: ��ݴɷ� -1
         ü�� 40% �̸�: ��ݴɷ� -2
         ü�� 25% �̸�: ��ݴɷ� -3
        */
        Moodle_Pain = new Moodles_state(Moodles_private_code.Pain, 0.8f, 0.6f, 0.4f, 0.25f);  // ���Ƿ� ���� (�λ�� ����)
        /*
         ü�� 80% �̸�: ���� ��Ÿ���� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +5%
         ü�� 60% �̸�: ���� ��Ÿ���� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +10%,
                       ���� ��Ȱ��ȭ, �λ������ ���� �̵�, ����������, ���ݼӵ� ���� ����
         ü�� 40% �̸�: ���� ��Ÿ���� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +15%,
                       ���� ��Ȱ��ȭ, �λ������ ���� �̵�, ����������, ���ݼӵ� ������ ����
         ü�� 25% �̸�: ���� ��Ÿ���� ������/�޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +20%,
                       ���� ��Ȱ��ȭ, �λ������ ���� �̵�, ����������, ���ݼӵ� ũ�� ����, � ��Ȱ��ȭ
        */
        Moodle_Bleeding = new Moodles_state(Moodles_private_code.Bleeding, 1f, 2f, 3f, 4f);
        /*
         ���� ��ó 1�� �̻�: �ð��� ������ ���� ü�� õõ�� �ս�
         ���� ��ó 2�� �̻�: �ð��� ������ ���� ü�� ������� �ս�, ��ݴɷ� -1
         ���� ��ó 3�� �̻�: �ð��� ������ ���� ü�� �ɰ��ϰ� �ս�, ��ݴɷ� -1
         ���� ��ó 4�� �̻�: ��� ġ������������ ����� �̸� �� ����, ��ݴɷ� -1
        */
        Moodle_Has_a_Cold = new Moodles_state(Moodles_private_code.Has_a_Cold, 0.2f, 0.4f, 0.6f, 0.8f);
        /*
         20% �̻�: ��ä�⳪ ��ħ�� �� ���ɼ� ����
         40% �̻�: ��ä�⳪ ��ħ�� �� ���ɼ� ����
         60% �̻�: ��ä�⳪ ��ħ�� �� ���ɼ� ���Ƽ� ���� ���ϱ� �����
         60% �̻�: ��ä�⳪ ��ħ�� ��� �ؼ� �ܵ� ����or�ǳ��� �ƴϸ� ��� ���� �������
        */
        Moodle_Sick = new Moodles_state(Moodles_private_code.Sick, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% �̻�: ü�¹߻��� �ణ ����, 
                   ����ȭor�ߵ��̸� ü�� õõ�� ����
         50% �̻�: ü�¹߻��� ������ ����, ��� �ɷ� -1, ���� ����or��ü����(20���̻�)�� ���� ��� ġ���ӵ� ������,
                   ����ȭor�ߵ��̸� ü�� ������ ���� & ��Ʈ���� ����
         75% �̻�: ü�¹߻��� ���� ����, ��� �ɷ� -1, ���� ����or��ü����(20���̻�)�� ���� ��� ġ���ӵ� �ξ� ������,
                   ����ȭor�ߵ��̸� ü�� �ɰ��ϰ� ���� & ��Ʈ���� ����
         90% �̻�: ü�¹߻��� ũ�� ����, ��� �ɷ� -2, ���� ����or��ü����(20���̻�)�� ���� ��� ü���� õõ�� ����,
                   ����ȭor�ߵ��̸� ü�� ġ�������� ���� & ��Ʈ���� ����
        */
        Moodle_Dead = new Moodles_state(Moodles_private_code.Dead, 0f, 0f, 0f, 0f);  // ü���� 0�̵Ǹ� �ٷ� ����
        /*
         �÷��̾ �������� �ʰ� ����� ���
         */
        Moodle_Zombie = new Moodles_state(Moodles_private_code.Zombie, 0f, 0f, 0f, 0f);  // ���Ƿ� ���� (����: ü�� 0 && Dead�� �ƴ� ���)
        /*
         �÷��̾ �����ǰ� ����� ���.
         ��Ÿ �簡 ���� �ʰ� ���� ��ü�� ����� ��� ����� ��Ȱ
         */
        Moodle_Restricted_Movement = new Moodles_state(Moodles_private_code.Restricted_Movement, 0f, 0f, 0f, 0f); // ���Ƿ� ���� (����: �Ź� ���� x || �ٸ��� �θ�� ��� || �� �δ� > 175% Weight ���)
        /*
         �ǹ�, �ٸ��λ�, ������, ���ſ� �� ����, �ӵ��� ������ ��ħ
         �޸���/�Ŀ���ŷ �� �� ����
         */
    }

    bool _Player_Setting_Language_to_Korean;
    public void Set_Player_Language(bool Language_type)
    {
        _Player_Setting_Language_to_Korean = Language_type;
    }

    public bool Get_Player_Language_Is_Korean()
    {
        return _Player_Setting_Language_to_Korean;
    }

}

public class Moodles_state
{
    public Moodles_private_code _Moodle_Code = new Moodles_private_code();
    string _Moodle_Name = "";
    float _Moodle_current_value = 0;  // �� ������ ���� ����
    int _Moodle_current_step = 0;

    // ������ ��ġ�� �ѱ�� �� ���·� �ٲ�
    float _First_state = 0;
    float _Second_state = 0;
    float _Third_state = 0;
    float _Fourth_state = 0;
    string _current_state_to_string = "";
    string _current_detail_state_to_string = "";

    public Moodles_state(Moodles_private_code Moodle_Code, float First_state, float Second_state, float Third_state, float Fourth_state)
    {
        _Moodle_Code = Moodle_Code;
        _Moodle_Name = _Moodle_Code.ToString();
        _First_state = First_state;
        _Second_state = Second_state;
        _Third_state = Third_state;
        _Fourth_state = Fourth_state;
    }

    public void Set_Moodles_state(float current_value)
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Hungry:  //  0.15f, 0.25f, 0.45f, 0.7f  // Player_main_Update
                _Moodle_current_value = current_value / 300;  // �ּ��ִ밪 Player_main ���� ����
                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if(Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������";
                        _current_detail_state_to_string = "���� �� ������ ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Peckish";
                        _current_detail_state_to_string = "Could do with a bite to eat.";
                    }
                    
                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�����";
                        _current_detail_state_to_string = "���̶� ������ �԰� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Hungry";
                        _current_detail_state_to_string = "Could eat a horse right now.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.35f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ſ� �����";
                        _current_detail_state_to_string = "�ٷ°� ġ���ɷ��� ũ�� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Very Hungry";
                        _current_detail_state_to_string = "Reduced strength and healing.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.6f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���ָ�";
                        _current_detail_state_to_string = "ü���� ���������� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Starving";
                        _current_detail_state_to_string = "Health now just falling away...";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Hungry, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.6f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.26 */
            case Moodles_private_code.Stuffed:  //  0.15f, 0.25f, 0.45f, 0.7f  // Player_main_Update
                _Moodle_current_value = (current_value / 300);  // �ּ��ִ밪 Player_main ���� ����
                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.ability_Eat = true;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ����";
                        _current_detail_state_to_string = "�Ű� ���̴� ������� �������.";
                    }
                    else
                    {
                        _current_state_to_string = "Satiated";
                        _current_detail_state_to_string = "Gnawing hunger entirely absent.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.ability_Eat = true;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������ ������";
                        _current_detail_state_to_string = "�谡 ��á��. ����� ���� �̷Ӱ� �� �̴ϴ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Well Fed";
                        _current_detail_state_to_string = "Tummy full. Goodness is making its way through your system.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.ability_Eat = true;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�谡 �����";
                        _current_detail_state_to_string = "������ �����ߴ�. ��� ü�°� �ٷ��� �����Ѵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Stuffed";
                        _current_detail_state_to_string = "Stomach contented. Health and strength aided.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.ability_Eat = false;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��Ӵ��� ���";
                        _current_detail_state_to_string = "�� �� �� �Դ� �� ������ ���߾�... �ٷ°� ġ���ɷ��� ��ð� ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Full to Bursting";
                        _current_detail_state_to_string = "Couldn't take another single, solitary bite.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Stuffed, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.ability_Eat = false;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.26 */
            case Moodles_private_code.Thirsty:  //  0.13f, 0.25f, 0.7f, 0.85f  // PlayerState_Update, Player_HP_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��¦ �񸶸�";
                        _current_detail_state_to_string = "���� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Slightly Thirsty";
                        _current_detail_state_to_string = "Dry Mouth.";
                    }

                    _Moodle_current_step = 1;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� �񸶸�";
                        _current_detail_state_to_string = "���� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Thirsty";
                        _current_detail_state_to_string = "Dehydrated.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Thirsty, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ����";
                        _current_detail_state_to_string = "������ ȥ���ϰ� ��������.";
                    }
                    else
                    {
                        _current_state_to_string = "Parched";
                        _current_detail_state_to_string = "Feeling faint and dizzy.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Thirsty, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�����ױ� ����";
                        _current_detail_state_to_string = "���� ã�� ���� ���ư�.";
                    }
                    else
                    {
                        _current_state_to_string = "Dying of Thirst";
                        _current_detail_state_to_string = "Desperate for water.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Thirsty, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.05 */
            case Moodles_private_code.Panic:  //  0.3f, 0.5f, 0.8f, 0.9f  // Player_main_Update  // Player_main_Calculate_HitForce
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _First_state && current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��¦ �����";
                        _current_detail_state_to_string = "��� ��ȣ���� �Ͻʽÿ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Slight Panic";
                        _current_detail_state_to_string = "Do your best to remain calm.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.013f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Second_state && current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�����";
                        _current_detail_state_to_string = "���߷��� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Panic";
                        _current_detail_state_to_string = "Accuracy reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.026f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Third_state && current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���ϰ� �����";
                        _current_detail_state_to_string = "���߷��� ũ�� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Strong Panic";
                        _current_detail_state_to_string = "Accuracy severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.039f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.2f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��Ȳ����";
                        _current_detail_state_to_string = "���߷��� �þ߰� �ɰ��ϰ� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Extreme Panic";
                        _current_detail_state_to_string = "Accuracy and vision severely reduced.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.052f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.3f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.06 */
            case Moodles_private_code.Bored:  //  0.25f, 0.5f, 0.75f, 0.9f  // ������ ���� �������� �ݿ��ϵ��� ���� ����
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if(_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ɽ���";
                        _current_detail_state_to_string = "�� ���̳� ��ſ� ���� ����� ���ʽÿ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Getting Bored";
                        _current_detail_state_to_string = "Occupy yourself, or seek entertainment.";
                    }

                    _Moodle_current_step = 1;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������";
                        _current_detail_state_to_string = "������� �ɸ� �� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Bored";
                        _current_detail_state_to_string = "In danger of becoming unhappy.";
                    }

                    _Moodle_current_step = 2;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ſ� ������";
                        _current_detail_state_to_string = "������� �ɸ� Ȯ���� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Very Bored";
                        _current_detail_state_to_string = "High chance of becoming unhappy.";
                    }

                    _Moodle_current_step = 3;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ؽ��� ������";
                        _current_detail_state_to_string = "��������� ���� ��.";
                    }
                    else
                    {
                        _current_state_to_string = "Extremely Bored";
                        _current_detail_state_to_string = "Very high chance of becoming unhappy.";
                    }

                    _Moodle_current_step = 4;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.06 */  // ������ ���� �������� �ݿ��ϵ��� ���� ����
            case Moodles_private_code.Stressed:  //  0.25f, 0.5f, 0.75f, 0.9f  // 
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �������� ������ 0 ����
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�Ҿ���";
                        _current_detail_state_to_string = "������ ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Anxious";
                        _current_detail_state_to_string = "On edge.";
                    }

                    _Moodle_current_step = 1;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �������� ������ 0 ����
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������";
                        _current_detail_state_to_string = "�Ű����.";
                    }
                    else
                    {
                        _current_state_to_string = "Agitated";
                        _current_detail_state_to_string = "Nervous and jumpy.";
                    }

                    _Moodle_current_step = 2;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �������� ������ 0.1 ����
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ��Ʈ����";
                        _current_detail_state_to_string = "�������� ���� �ҾȰ��� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Stressed";
                        _current_detail_state_to_string = "Sweaty palms. Gnawing fear.";
                    }

                    _Moodle_current_step = 3;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �������� ������ 0.2 ����
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�Ű����";
                        _current_detail_state_to_string = "���źп��� �Ͼ.";
                    }
                    else
                    {
                        _current_state_to_string = "Nervous Wreck";
                        _current_detail_state_to_string = "Terrified.";
                    }

                    _Moodle_current_step = 4;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �������� ������ 0.3 ����
                }
                break;     /* 24.03.07 */  // ���񿡰� �ѷ�����, ���� ��ó ġ�� ����, �ڴٰ� Ÿ�Ƿ� ���� ���, ���� ����  �϶� ȣ��   // �������� ����� ������ �ݿ�
            case Moodles_private_code.Unhappy:  //  0.2f, 0.45f, 0.6f, 0.8f  // 
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �ൿ�ӵ� 0.0% ����
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������";
                        _current_detail_state_to_string = "��� ��ȯ�� �Ҹ��� ���� ã���ʽÿ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Feeling a little sad";
                        _current_detail_state_to_string = "Find a way to raise your mood.";
                    }

                    _Moodle_current_step = 1;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �ൿ�ӵ� 7.4% ����
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��� ����";
                        _current_detail_state_to_string = "��еɸ��� �ൿ�̳� ������� ã���ʽÿ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Getting a tad weepy";
                        _current_detail_state_to_string = "Seek some excitement or human contact.";
                    }

                    _Moodle_current_step = 2;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �ൿ�ӵ� 13.7% ����
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�����";
                        _current_detail_state_to_string = "�����԰� ���Ŀ� �۽��̰� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Depressed";
                        _current_detail_state_to_string = "Ravaged by mourning and desperation.";
                    }

                    _Moodle_current_step = 3;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �ൿ�ӵ� 19.6% ����
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ؽ��� �����";
                        _current_detail_state_to_string = "���ǵ��Ǹ� �� ����� ã���ʽÿ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Severely Depressed";
                        _current_detail_state_to_string = "Find a way to forget reality.";
                    }

                    _Moodle_current_step = 4;
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    // �ൿ�ӵ� 26.5% ����
                }
                break;           // ��ü �ൿ�ӵ� �����ϵ��� ���� ����
            case Moodles_private_code.Drunk:  //  0.1f, 0.3f, 0.5f, 0.7f  // PlayerState_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Set_Driving_control(1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� �����";
                        _current_detail_state_to_string = "������� ���� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "A Bit Tipsy";
                        _current_detail_state_to_string = "Downed some booze.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Set_Driving_control(0.95f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ����";
                        _current_detail_state_to_string = "���� ������� �� �� ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Inebriated";
                        _current_detail_state_to_string = "Co-ordination slightly impaired.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Set_Driving_control(0.85f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ����";
                        _current_detail_state_to_string = "���� �����Ⱑ ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Plastered";
                        _current_detail_state_to_string = "Co-ordination impaired.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Set_Driving_control(0.7f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�̶�";
                        _current_detail_state_to_string = "����� ���ۿ� ������~ �� ������ �������! �����~�����...";
                    }
                    else
                    {
                        _current_state_to_string = "Utterly Shit-Faced";
                        _current_detail_state_to_string = "Iss you an' me 'gainst the wurld. I love you. I LOVE YOU.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Set_Driving_control(0.5f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.08 */
            case Moodles_private_code.Heavy_Load:  //  1f, 1.25f, 1.5f, 1.75f  // playerInventory_Weight_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ణ ���ſ�";
                        _current_detail_state_to_string = "���� ���ſ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Fairly Heavy Load";
                        _current_detail_state_to_string = "Carrying a little too much.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.07f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.19f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.13f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.08f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.02f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ���ſ�";
                        _current_detail_state_to_string = "�̵��ӵ��� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Heavy Load";
                        _current_detail_state_to_string = "Movement speed reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.14f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.10f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.37f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.26f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.16f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.04f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ſ� ���ſ�";
                        _current_detail_state_to_string = "�̵��ӵ��� ũ�� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Very Heavy Load";
                        _current_detail_state_to_string = "Movement speed highly reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.21f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.56f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.39f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.24f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.06f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�뷮�ʰ�";
                        _current_detail_state_to_string = "���� ��ĥ ������ ����. �������� ���ѵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Extremely Heavy Load";
                        _current_detail_state_to_string = "Can't take much more! Movement compromised.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.28f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.75f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.52f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.32f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.08f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    /*�ȴ� ���¿��� ������ ���� ( �̱��� ���� )*/
                }
                break;     /* 24.02.26 */
            case Moodles_private_code.Endurance:  //  25f, 50f, 75f, 91f  // PlayerState_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 100) { _Moodle_current_value = 100; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ణ ��ħ";
                        _current_detail_state_to_string = "���ݸ� ���ʽÿ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Moderate Exertion";
                        _current_detail_state_to_string = "Take a break.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0.5f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.07f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.19f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.1f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.02f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ��ħ";
                        _current_detail_state_to_string = "�޸��⵵ ����.";
                    }
                    else
                    {
                        _current_state_to_string = "High Exertion";
                        _current_detail_state_to_string = "Can barely jog.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0.8f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.14f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.37f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.1f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.04f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ſ� ��ħ";
                        _current_detail_state_to_string = "�ȴ� �͵� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Excessive Exertion";
                        _current_detail_state_to_string = "Can barely walk.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0.9f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.21f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.56f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.3f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.06f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��������";
                        _current_detail_state_to_string = "�����̱⵵ ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Exhausted";
                        _current_detail_state_to_string = "Can barely move.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forMoodle(0.95f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.28f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.75f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.4f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(_Moodle_Code, 0.08f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.23 */
            case Moodles_private_code.Tired:  //  0.6f, 0.7f, 0.8f, 0.9f  // PlayerState_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ǰ���";
                        _current_detail_state_to_string = "���� ���� ������ ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Drowsy";
                        _current_detail_state_to_string = "Could do with a lie-down.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.5f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����";
                        _current_detail_state_to_string = "���߷��� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Tired";
                        _current_detail_state_to_string = "Awareness reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.8f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ����";
                        _current_detail_state_to_string = "���߷��� ũ�� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Very Tired";
                        _current_detail_state_to_string = "Awareness severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.9f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������";
                        _current_detail_state_to_string = "�ʹ� �ǰ��ϰ�. ���� �� ����. ���ù����ϰ� �ǰ��ϴ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Ridiculously Tired";
                        _current_detail_state_to_string = "So tired. So desperately, inhumanly tired.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forMoodle(_Moodle_Code, _Moodle_current_step, 0.95f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    /*
                     �̱��� ����: �ٴڿ��� ���ڱ� ����, ���� ���� ���� �����ϰ� ���ڱ� ����
                     */
                }
                break;     /* 24.03.07 */
            case Moodles_private_code.Hyperthermia_Hot:  //  37.5f, 39f, 40f, 41f  // PlayerState_Update  // Player_HP_Update  // GameManeger_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ణ ����";
                        _current_detail_state_to_string = "�������� ������. ���� ���� ����. ������ ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Unpleasantly Hot";
                        _current_detail_state_to_string = "Consider taking off clothing. Thirst increased.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����ġ�� ����";
                        _current_detail_state_to_string = "���� ������ ���� ��. �޺��� ���� �����.";
                    }
                    else
                    {
                        _current_state_to_string = "Overheated";
                        _current_detail_state_to_string = "Thirsty. Sweaty. Over-exposed.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.34f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.01f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0.01f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����";
                        _current_detail_state_to_string = "�޽����� ���߷��� ������. ������ ã�� ������ ��.";
                    }
                    else
                    {
                        _current_state_to_string = "Sunstruck";
                        _current_detail_state_to_string = "Nauseous, unable to concentrate and desperate for liquids.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.67f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.03f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0.03f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���纴";
                        _current_detail_state_to_string = "���纴���� �ǽ��� ȥ����. �ɰ��� �����Ȳ.";
                    }
                    else
                    {
                        _current_state_to_string = "Hyperthermic";
                        _current_detail_state_to_string = "Delirious from heat stroke and exposure. Severely endangered.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.90f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.playerMoodles.Moodle_Wet.Set_Moodles_state(0.07f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */  // ��������, ������ ���� �߿�, ����ȭ, ���� �϶� ȣ��
            case Moodles_private_code.Hyperthermia_Cold:  //  36.5f, 35f, 30f, 25f  // PlayerState_Update  // Player_HP_Update  // GameManeger_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value > _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _First_state && _Moodle_current_value > _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ҽ���";
                        _current_detail_state_to_string = "���� �� �߿� �� ������...";
                    }
                    else
                    {
                        _current_state_to_string = "Chilly";
                        _current_detail_state_to_string = "It feels a bit nippy around here...";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Second_state && _Moodle_current_value > _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�߿�";
                        _current_detail_state_to_string = "�����ϰ� ���� ����� ã���ʽÿ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Cold";
                        _current_detail_state_to_string = "You need to find ways to keep warm.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.34f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.01f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.02f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Third_state && _Moodle_current_value > _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ſ� �߿�";
                        _current_detail_state_to_string = "���� ����ִ�. ��û���� �߿�.";
                    }
                    else
                    {
                        _current_state_to_string = "Freezing";
                        _current_detail_state_to_string = "Man alive. It is SO cold.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.67f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.03f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.17f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value < _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��ü����";
                        _current_detail_state_to_string = "���� ������ ������ ���������. ����״´�.";
                    }
                    else
                    {
                        _current_state_to_string = "Hypothermic";
                        _current_detail_state_to_string = "Body and mind obsessed by the cold.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forMoodle(_Moodle_Code, 0.90f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.47f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */  // �ʹ�����, ���ٶ� ���� Ȱ��ȭ �϶� ȣ��
            case Moodles_private_code.Windchill:  //  2f, 5f, 7f, 9f  // GameManager
                _Moodle_current_value = current_value;
                if (current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _First_state && current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������ �� �ٶ�";
                        _current_detail_state_to_string = "�������� 5-10�� ���� ������ ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Slight windchill";
                        _current_detail_state_to_string = "It's feeling 5 to 10 degrees colder than it actually is.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(-5.0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Second_state && current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������ �� �ٶ�";
                        _current_detail_state_to_string = "�������� 10-15�� ���� ������ ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Uncomfortable windchill";
                        _current_detail_state_to_string = "It's feeling 10 to 15 degrees colder than it actually is.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(-10.0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Third_state && current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�������� �� �ٶ�";
                        _current_detail_state_to_string = "�������� 15-20�� ���� ������ ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Freezing windchill";
                        _current_detail_state_to_string = "It's feeling 15 to 20 degrees colder than it actually is.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(-15.0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��û���� �߿� �ٶ�";
                        _current_detail_state_to_string = "�������� 20�� �Ѱ� ������ ������.";
                    }
                    else
                    {
                        _current_state_to_string = "Horrific windchill";
                        _current_detail_state_to_string = "It's feeling more than 20 degrees colder than it actually is.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerState.Set_Apparent_Temperature_forMoodle(-20.0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */
            case Moodles_private_code.Wet:  //  0.15f, 0.4f, 0.7f, 0.9f  
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������";
                        _current_detail_state_to_string = "�ణ �����ϴ�. ���ΰ�? ���ΰ�?";
                    }
                    else
                    {
                        _current_state_to_string = "Damp";
                        _current_detail_state_to_string = "Slightly damp. Rain, or sweat?";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����";
                        _current_detail_state_to_string = "�����ϴ�. ���� ���� ���� �ǰ�? �� ���� ���� �ǰ�?";
                    }
                    else
                    {
                        _current_state_to_string = "Wet";
                        _current_detail_state_to_string = "Sweatier, or even more rained on?";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ����";
                        _current_detail_state_to_string = "���⿡ �ɸ� �� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Soaking";
                        _current_detail_state_to_string = "Chance of catching a cold.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�컶 ����";
                        _current_detail_state_to_string = "���� ���⿡ �ɸ� �� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Drenched";
                        _current_detail_state_to_string = "High chance of catching a cold.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.playerState.Set_Probability_of_Catching_a_cold(_Moodle_Code, 0.2f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */  // ���� ��Ȳ�϶� ȣ��
            case Moodles_private_code.Injured:  //  0.8f, 0.6f, 0.4f, 0.25f  // Player_HP_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value > _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _First_state && _Moodle_current_value > _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���";
                        _current_detail_state_to_string = "������ġ�� �ʿ���.";
                    }
                    else
                    {
                        _current_state_to_string = "Discomfort";
                        _current_detail_state_to_string = "Something doesn't feel right...";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Second_state && _Moodle_current_value > _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�λ�";
                        _current_detail_state_to_string = "�ٷ°� �̵��ӵ��� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Injured";
                        _current_detail_state_to_string = "Strength and speed reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Third_state && _Moodle_current_value > _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ɰ��� �λ�";
                        _current_detail_state_to_string = "�ٷ°� �̵��ӵ��� ũ�� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Severe Injuries";
                        _current_detail_state_to_string = "Strength and speed severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "ġ������ �λ�";
                        _current_detail_state_to_string = "���� ����� ���� �� ����...";
                    }
                    else
                    {
                        _current_state_to_string = "Critical Injuries";
                        _current_detail_state_to_string = "Not going gently into that good night...";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Injured, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.22 */
            case Moodles_private_code.Pain:  //  0.8f, 0.6f, 0.4f, 0.25f  // Player_HP_Update
                _Moodle_current_value = current_value;
                if (_Moodle_current_value > _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.ability_Sleeping = true;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _First_state && _Moodle_current_value > _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ణ ����";
                        _current_detail_state_to_string = "�ణ�� ������ ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Minor Pain";
                        _current_detail_state_to_string = "Feeling slight pain.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.ability_Sleeping = true;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.05f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0.05f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Second_state && _Moodle_current_value > _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����";
                        _current_detail_state_to_string = "�̵��ӵ��� ���߷��� ���� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Pain";
                        _current_detail_state_to_string = "Speed and accuracy slightly reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.ability_Sleeping = false;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.1f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.1f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Third_state && _Moodle_current_value > _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ����";
                        _current_detail_state_to_string = "�̵��ӵ��� ���߷��� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Severe Pain";
                        _current_detail_state_to_string = "Speed and accuracy reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.ability_Sleeping = false;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.15f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0.15f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value <= _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�ص��� ����";
                        _current_detail_state_to_string = "�̵��ӵ��� ���߷��� ũ�� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Agony";
                        _current_detail_state_to_string = "Speed and accuracy severely reduced.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.ability_Sleeping = false;
                    Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.Set_Accuracy_forMoodle(_Moodle_Code, 0.2f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.27 */
            case Moodles_private_code.Bleeding:  //  1f, 2f, 3f, 4f  // Player_HP_Update  // PlayerState_Player_body_Location
                _Moodle_current_value = current_value;
                if (current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _First_state && current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����� ����";
                        _current_detail_state_to_string = "�ش밡 �ʿ��մϴ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Minor Bleeding";
                        _current_detail_state_to_string = "Bandage required.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Second_state && current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����";
                        _current_detail_state_to_string = "�ٷ°� �̵��ӵ��� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Bleeding";
                        _current_detail_state_to_string = "Strength and speed reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value >= _Third_state && current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� ����";
                        _current_detail_state_to_string = "�ٷ°� �̵��ӵ��� ũ�� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Severe Bleeding";
                        _current_detail_state_to_string = "Strength and speed severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��Ը� ���� �ս�";
                        _current_detail_state_to_string = "��� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Massive Blood Loss";
                        _current_detail_state_to_string = "Death imminent.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(Moodles_private_code.Bleeding, _Moodle_current_step);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.02.22 */
            case Moodles_private_code.Has_a_Cold:  //  0.2f, 0.4f, 0.6f, 0.8f  // PlayerState_Update  // Player_main_Update
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Is_Cold = false;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�๰�� ��";
                        _current_detail_state_to_string = "������ ��ä�⸦ ��.";
                    }
                    else
                    {
                        _current_state_to_string = "Runny Nose";
                        _current_detail_state_to_string = "Occasional sneezing.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Is_Cold = true;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������ ���ݵ� �๰";
                        _current_detail_state_to_string = "�ڲٸ� ��ä�⸦ ��.";
                    }
                    else
                    {
                        _current_state_to_string = "The Sniffles";
                        _current_detail_state_to_string = "Prone to sneezing.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Is_Cold = true;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����";
                        _current_detail_state_to_string = "��ħ�� ������ ��ä��. �̵��ӵ��� ġ���ɷ��� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "You Have A Cold";
                        _current_detail_state_to_string = "Sneezing and coughing. Speed and healing reduced.";
                    }
                   
                    _Moodle_current_step = 3;
                    Player_main.player_main.Is_Cold = true;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.2f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "������ ����";
                        _current_detail_state_to_string = "�̵��ӵ��� ġ���ɷ��� ũ�� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "You Have A Nasty Cold";
                        _current_detail_state_to_string = "Speed and healing now severely reduced.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Is_Cold = true;
                    Player_main.player_main.Set_Moving_Speed_forMoodle(_Moodle_Code, 0.6f);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.4f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.07 */
            case Moodles_private_code.Sick:  //  0.25f, 0.5f, 0.75f, 0.9f  //
                _Moodle_current_value += current_value;
                if (_Moodle_current_value > 1) { _Moodle_current_value = 1; }
                else if (_Moodle_current_value < 0) { _Moodle_current_value = 0; }

                if (_Moodle_current_value < _First_state)
                {
                    _current_state_to_string = "";
                    _current_detail_state_to_string = "";
                    _Moodle_current_step = 0;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _First_state && _Moodle_current_value < _Second_state)  // 1�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���� �� ����";
                        _current_detail_state_to_string = "����鼭 �ൿ�Ͻʽÿ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Queasy";
                        _current_detail_state_to_string = "Take things easy.";
                    }

                    _Moodle_current_step = 1;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.05f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Second_state && _Moodle_current_value < _Third_state)  // 2�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "�޽�����";
                        _current_detail_state_to_string = "�ٷ°� ġ���ɷ��� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Nauseous";
                        _current_detail_state_to_string = "Strength and healing reduced.";
                    }

                    _Moodle_current_step = 2;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.1f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value >= _Third_state && _Moodle_current_value < _Fourth_state)  // 3�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����";
                        _current_detail_state_to_string = "�ٷ°� ġ���ɷ��� ũ�� ���ϵ�.";
                    }
                    else
                    {
                        _current_state_to_string = "Sick";
                        _current_detail_state_to_string = "Strength and healing severely reduced.";
                    }

                    _Moodle_current_step = 3;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.3f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                else if (_Moodle_current_value > _Fourth_state)  // 4�ܰ�
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "��";
                        _current_detail_state_to_string = "������ ������ ���� Ŀ��.";
                    }
                    else
                    {
                        _current_state_to_string = "Fever";
                        _current_detail_state_to_string = "Increasing danger of death.";
                    }

                    _Moodle_current_step = 4;
                    Player_main.player_main.Inven_main.Inventory_Weight.Set_Add_Moodles_Point(_Moodle_Code, _Moodle_current_step);
                    Player_main.player_main.player_HP.Set_HP_Recovery_Speed_forMoodle(_Moodle_Code, 0.5f);
                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                }
                break;     /* 24.03.08 */  // ���� ���� or ���� �� ���� ����, ���� ���� �϶� ȣ��
            case Moodles_private_code.Dead:  // �񰨿� && ���  // Player_HP_Update
                if (current_value == _First_state && 
                    Player_main.player_main.playerState.Get_Is_Infection() == false)
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "���";
                        _current_detail_state_to_string = "�� ���̰� �� Ȯ���� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Deceased";
                        _current_detail_state_to_string = "High chance of becoming rat food.";
                    }

                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    /* �״� animation �ʿ��� */
                }
                break;     /* 24.03.08 */
            case Moodles_private_code.Zombie:  // ���� && ���  // Player_HP_Update
                if (current_value == _First_state &&
                    Player_main.player_main.playerState.Get_Is_Infection() == true)
                {
                    if (Player_Moodles.playerMoodles.Get_Player_Language_Is_Korean())
                    {
                        _current_state_to_string = "����ȭ";
                        _current_detail_state_to_string = "����� ���־� ����.";
                    }
                    else
                    {
                        _current_state_to_string = "Zombified";
                        _current_detail_state_to_string = "Sudden desire to eat people.";
                    }

                    UI_Moodle.ui_moodle.Moodle_Ins(_Moodle_Code, _Moodle_current_step);
                    /* ����ȭ�Ǵ� animation �ʿ��� */
                }
                break;     /* 24.03.08 */
            default:
                break;

        }

    }

    public string Get_current_state_to_string()
    {
        return _current_state_to_string;
    }

    public string Get_current_detail_state_to_string()
    {
        return _current_detail_state_to_string;
    }

    public float Get_Moodle_current_value()
    {
        return _Moodle_current_value;
    }

    public int Get_Moodle_current_step()
    {
        return _Moodle_current_step;
    }

}

