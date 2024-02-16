using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Moodle_Hungry = new Moodles_state("Hungry", 0f, 0.15f, 0.25f, 0.45f, 0.7f);
        /*
         15% �̻�: -
         25% �̻�: ��ݴɷ� -1, ü�¹߻��� �ణ����, ġ���ӵ� -35%
         45% �̻�: ��ݴɷ� -2, ü�¹߻��� ����, ġ���ӵ� -60%
         70% �̻�: ��ݴɷ� -2, ü�¹߻��� ������
         */
        Moodle_Stuffed = new Moodles_state("Stuffed", 0f, 0.15f, 0.25f, 0.45f, 0.7f);
        /*
         15% �̻�: ġ���ӵ� �ణ���, �� ����
         25% �̻�: ġ���ӵ� ���, �� ����
         45% �̻�: ġ���ӵ� ���, �� ����, �Ļ� �Ұ���
         70% �̻�: ġ���ӵ� ���, �� ����, �Ļ� �Ұ���
         */
        Moodle_Thirsty = new Moodles_state("Thirsty", 0f, 0.13f, 0.25f, 0.7f, 0.85f);
        /*
         13% �̻�: -
         25% �̻�: ��ݴɷ� -1, ü�¹߻��� �ణ����
         70% �̻�: ��ݴɷ� -2, ü�¹߻��� ����
         85% �̻�: ��ݴɷ� -2, ü�¹߻��� ����, ü�� ������ ���� (�װų� �����ؼ��Ҷ�����)
         */
        Moodle_Panic = new Moodles_state("Panic", 0f, 0.3f, 0.5f, 0.8f, 0.9f);  // ���Ƿ� ����
        /*
          30% �̻�(�ణ�� �д�): ũ��Ƽ�� Ȯ�� -1.3%
          50% �̻�(��Ȳ): ũ��Ƽ�� Ȯ�� -2.6%, �������ⵥ���� -0.1,  ���� �ڼ����� �� ���� �Ͼ
          80% �̻�(���� �д�): ũ��Ƽ�� Ȯ�� -3.9%, �������ⵥ���� -0.2, �� ������ -0.4(Aiming_Level�� 6���� ����),  ���� �ڼ����� �� ���� �Ͼ
          90% �̻�(�ͽ�Ʈ�� �д�): ũ��Ƽ�� Ȯ�� -5.2%, �������ⵥ���� -0.3, �� ������ -0.6(Aiming_Level�� 6���� ����),  ���� �ڼ����� �� ���� �Ͼ, �þ� ������

          * ���� �������� 0.1 �̸����� ������������
         */
        Moodle_Bored = new Moodles_state("Bored", 0f, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% �̻�: -
         50% �̻�: ���� �����ӵ��� ����
         75% �̻�: ���� ������ �ӵ��� ����
         90% �̻�: ���� ���� �ӵ��� ����
         */
        Moodle_Stressed = new Moodles_state("Stressed", 0f, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% �̻�: -
         50% �̻�: ���� & ���Ÿ� ���� -0.1, ���� �����ӵ��� ����
         75% �̻�: ���� & ���Ÿ� ���� -0.2, ���� ������ �ӵ��� ����
         90% �̻�: ���� & ���Ÿ� ���� -0.3, ���� ���� �ӵ��� ����
         */
        Moodle_Unhappy = new Moodles_state("Unhappy", 0f, 0.2f, 0.45f, 0.6f, 0.8f);
        /*
         20% �̻�: �ð� ������ �ִ� �ൿ�ӵ� -7.4%
         45% �̻�: �ð� ������ �ִ� �ൿ�ӵ� -13.7%
         60% �̻�: �ð� ������ �ִ� �ൿ�ӵ� -19.6%
         80% �̻�: �ð� ������ �ִ� �ൿ�ӵ� -26.5%
         */
        Moodle_Drunk = new Moodles_state("Drunk", 0f, 0.1f, 0.3f, 0.5f, 0.7f);
        /*
         10% �̻�: �Ƿε� �ణ����, ü�¹߻��� �ణ����
         30% �̻�: �Ƿε� �ణ����, ü�¹߻��� �ణ����
         50% �̻�: �Ƿε� ����, ü�¹߻��� ����
         70% �̻�: �Ƿε� ����, ü�¹߻��� ����
         */
        Moodle_Heavy_Load = new Moodles_state("Heavy_Load", 0f, 1f, 1.25f, 1.5f, 1.75f);
        /*
         �� �δ� > 100% Weight: ���� ��Ÿ�� ������ �Ѿ��� Ȯ�� +13%, �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +13%, 
                                ũ��Ƽ�� Ȯ�� -5%, ���� �ӵ� -7%, ���� ��Ÿ���� ���� Ȯ�� -8%, 
                                �ȱ�/�޸���/�Ŀ���ũ �ӵ� -19%, ������ ȸ���� ����, ������ ��������� ���Ƴ� Ȯ�� -2%
         �� �δ� > 125% Weight: ���� ��Ÿ�� ������ �Ѿ��� Ȯ�� +26%, �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +26%, 
                                ũ��Ƽ�� Ȯ�� -10%, ���� �ӵ� -14%, ���� ��Ÿ���� ���� Ȯ�� -16%, 
                                �ȱ�/�޸���/�Ŀ���ũ �ӵ� -37%, ������ ȸ���� �ɰ��� ����, ������ ��������� ���Ƴ� Ȯ�� -4%
         �� �δ� > 150% Weight: ���� ��Ÿ�� ������ �Ѿ��� Ȯ�� +39%, �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +39%, 
                                ũ��Ƽ�� Ȯ�� -15%, ���� �ӵ� -21%, ���� ��Ÿ���� ���� Ȯ�� -24%, 
                                �ȱ�/�޸���/�Ŀ���ũ �ӵ� -56%, �޸��� ��Ȱ��ȭ(�Ŀ���ũ ����),
                                ������ ȸ�� ���� �� õõ�� ����, ü�� 75% �� ������ ����, 
                                ������ ��������� ���Ƴ� Ȯ�� -6%
         �� �δ� > 175% Weight: ���� ��Ÿ�� ������ �Ѿ��� Ȯ�� +52%, �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +52%, 
                                ũ��Ƽ�� Ȯ�� -20%, ���� �ӵ� -28%, ���� ��Ÿ���� ���� Ȯ�� -32%, 
                                �ȱ�/�޸���/�Ŀ���ũ �ӵ� -75%, �޸��� ��Ȱ��ȭ(�Ŀ���ũ ����),
                                ������ ȸ�� ���� �� ������ ������ ����, ü�� 75% �� ������ ����, 
                                ������ ��������� ���Ƴ� Ȯ�� -8%
         */
        Moodle_Endurance = new Moodles_state("Endurance", 0f, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% �̻�: ���������� -50%, ���ݼӵ� -7%, ���� ��Ÿ�� ������ �Ѿ��� Ȯ�� +10%,
                   �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +10%, ���� ��Ÿ���� ���� Ȯ�� -5%, �ȱ�/�޸���/�Ŀ���ũ �ӵ� -19%,
                   ������ ��������� ���Ƴ� Ȯ�� -2%
         50% �̻�: ���������� -80%, ���ݼӵ� -14%, ���� ��Ÿ�� ������ �Ѿ��� Ȯ�� +20%,
                   �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +20%, ���� ��Ÿ���� ���� Ȯ�� -10%, �ȱ�/�Ŀ���ũ �ӵ� -37%,
                   �޸��� ��Ȱ��ȭ, ������ ��������� ���Ƴ� Ȯ�� -4%
         75% �̻�: ���������� -90%, ���ݼӵ� -21%, ���� ��Ÿ�� ������ �Ѿ��� Ȯ�� +30%,
                   �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +30%, ���� ��Ÿ���� ���� Ȯ�� -15%, �ȱ� �ӵ� -56%,
                   �޸���/�Ŀ���ũ ��Ȱ��ȭ, ������ ��������� ���Ƴ� Ȯ�� -6%, � ��Ȱ��ȭ
         90% �̻�: ���������� -95%, ���ݼӵ� -28%, ���� ��Ÿ�� ������ �Ѿ��� Ȯ�� +40%,
                   �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +40%, ���� ��Ÿ���� ���� Ȯ�� -20%, �ȱ� �ӵ� -75%, ū ��ġ ���Ұ�
                   �޸���/�Ŀ���ũ ��Ȱ��ȭ, ������ ��������� ���Ƴ� Ȯ�� -8%, � ��Ȱ��ȭ
         */
        Moodle_Tired = new Moodles_state("Tired", 0f, 0.6f, 0.7f, 0.8f, 0.9f);
        /*
         60% �̻�: ���������� -50%, �þ� ������, ������ ȸ���� ũ�� ����
         70% �̻�: ���������� -80%, �þ� ������, �ν� �ݰ� ������, ������ ȸ���� �ɰ��ϰ� ����
         80% �̻�: ���������� -90%, �þ� ������, �ν� �ݰ� ������, ������ ȸ���� ������������ ����
         90% �̻�: ���������� -95%, �þ� ������, �ν� �ݰ� �ջ��, ������ ȸ���� �ߴ�
         */
        Moodle_Hyperthermia_Hot = new Moodles_state("Hyperthermia_Hot", 36f, 37.5f, 39f, 40f, 41f);
        /*
         37.5�� �̻�: ���� �ణ���� ����
         39�� �̻�: ���� ���� ����, �Ƿ� ���� ����, ���ݼӵ� -34%, �̵��ӵ� �ణ ����
         40�� �̻�: ���� ������ ����, �Ƿ� ������ ����, ���ݼӵ� -67%, �̵��ӵ� ������ ����
         41�� �̻�: ���� ������ ����, �Ƿ� ������ ����, ������ �ణ ����, ���ݼӵ� -90%, �̵��ӵ� ũ�� ����, ü�� õõ�� ����
         */
        Moodle_Hyperthermia_Cold = new Moodles_state("Hyperthermia_Cold", 36f, 36.5f, 35f, 30f, 25f);
        /*
         36.5�� ����: -
         35�� ����: ���ݼӵ� -34%, �ȱ�/�޸��� �ӵ� ������ ����
         30�� ����: ���ݼӵ� -67%, �ȱ�/�޸��� �ӵ� ũ�� ����
         25�� ����: ���ݼӵ� -90%, �ȱ�/�޸��� �ӵ� ���ϰ� ����, ü���� 1%�� �ɶ����� õõ�� ����
        */
        Moodle_Windchill = new Moodles_state("Windchill", 0f, 2f, 5f, 7f, 9f);  // ���Ƿ� ����
        /*
         2 �̻�: �������� 5~10�� ���� ����
         5 �̻�: �������� 10~15�� ���� ����
         7 �̻�: �������� 15~20�� ���� ����
         9 �̻�: �������� 20�� �̻� ���� ����
        */
        Moodle_Wet = new Moodles_state("Wet", 0f, 0.15f, 0.4f, 0.7f, 0.9f);
        /*
         15% �̻�: �ణ ��������
         40% �̻�: �ټ� ��������
         70% �̻�: ���� �� ����
         90% �̻�: ���� �ɸ� ���ɼ��� ����
        */
        Moodle_Injured = new Moodles_state("Injured", 0f, 0.8f, 0.6f, 0.4f, 0.25f);
        /*
         ü�� 80% �̸�: -
         ü�� 60% �̸�: ��ݴɷ� -1
         ü�� 40% �̸�: ��ݴɷ� -2
         ü�� 25% �̸�: ��ݴɷ� -3
        */
        Moodle_Pain = new Moodles_state("Pain", 0f, 0.8f, 0.6f, 0.4f, 0.25f);  // ���Ƿ� ���� (�λ�� ����)
        /*
         ü�� 80% �̸�: ���� ��Ÿ���� ������ �Ѿ��� Ȯ�� +5%, �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +5%
         ü�� 60% �̸�: ���� ��Ÿ���� ������ �Ѿ��� Ȯ�� +10%, �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +10%,
                       ���� ��Ȱ��ȭ, �λ������ ���� �̵�, ����������, ���ݼӵ� ���� ����
         ü�� 40% �̸�: ���� ��Ÿ���� ������ �Ѿ��� Ȯ�� +15%, �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +15%,
                       ���� ��Ȱ��ȭ, �λ������ ���� �̵�, ����������, ���ݼӵ� ������ ����
         ü�� 25% �̸�: ���� ��Ÿ���� ������ �Ѿ��� Ȯ�� +20%, �޸���/�Ŀ���ũ �� �Ѿ��� Ȯ�� +20%,
                       ���� ��Ȱ��ȭ, �λ������ ���� �̵�, ����������, ���ݼӵ� ũ�� ����, � ��Ȱ��ȭ
        */
        Moodle_Bleeding = new Moodles_state("Bleeding", 0f, 1f, 2f, 3f, 4f);
        /*
         ���� ��ó 1�� �̻�: �ð��� ������ ���� ü�� õõ�� �ս�
         ���� ��ó 2�� �̻�: �ð��� ������ ���� ü�� ������� �ս�, ��ݴɷ� -1
         ���� ��ó 3�� �̻�: �ð��� ������ ���� ü�� �ɰ��ϰ� �ս�, ��ݴɷ� -1
         ���� ��ó 4�� �̻�: ��� ġ������������ ����� �̸� �� ����, ��ݴɷ� -1
        */
        Moodle_Has_a_Cold = new Moodles_state("Has_a_Cold", 0f, 0.2f, 0.4f, 0.6f, 0.8f);
        /*
         20% �̻�: ��ä�⳪ ��ħ�� �� ���ɼ� ����
         40% �̻�: ��ä�⳪ ��ħ�� �� ���ɼ� ����
         60% �̻�: ��ä�⳪ ��ħ�� �� ���ɼ� ���Ƽ� ���� ���ϱ� �����
         60% �̻�: ��ä�⳪ ��ħ�� ��� �ؼ� �ܵ� ����or�ǳ��� �ƴϸ� ��� ���� �������
        */
        Moodle_Sick = new Moodles_state("Sick", 0f, 0.25f, 0.5f, 0.75f, 0.9f);
        /*
         25% �̻�: ü�¹߻��� �ణ ����, 
                   ����ȭor�ߵ��̸� ü�� õõ�� ����
         50% �̻�: ü�¹߻��� ������ ����, ��� �ɷ� -1, ���� ����or��ü�� ���� ��� ġ���ӵ� ������,
                   ����ȭor�ߵ��̸� ü�� ������ ����
         75% �̻�: ü�¹߻��� ���� ����, ��� �ɷ� -2, ���� ����or��ü�� ���� ��� ġ���ӵ� �ξ� ������,
                   ����ȭor�ߵ��̸� ü�� �ɰ��ϰ� ����
         90% �̻�: ü�¹߻��� ũ�� ����, ��� �ɷ� -3, ���� ����or��ü�� ���� ��� ü���� õõ�� ����,
                   ����ȭor�ߵ��̸� ü�� ġ�������� ����
        */
        Moodle_Dead = new Moodles_state("Dead", 100f, 0f, 0f, 0f, 0f);  // ü���� 0�̵Ǹ� �ٷ� ����
        /*
         �÷��̾ �������� �ʰ� ����� ���
         */
        Moodle_Zombie = new Moodles_state("Zombie", 100f, 0f, 0f, 0f, 0f);  // ���Ƿ� ���� (����: ü�� 0 && Dead�� �ƴ� ���)
        /*
         �÷��̾ �����ǰ� ����� ���.
         ��Ÿ �簡 ���� �ʰ� ���� ��ü�� ����� ��� ����� ��Ȱ
         */
        Moodle_Restricted_Movement = new Moodles_state("Restricted_Movement", 0f, 0f, 0f, 0f, 0f); // ���Ƿ� ���� (����: �Ź� ���� x || �ٸ��� �θ�� ��� || �� �δ� > 175% Weight ���)
        /*
         �ǹ�, �ٸ��λ�, ������, ���ſ� �� ����, �ӵ��� ������ ��ħ
         �޸���/�Ŀ���ŷ �� �� ����
         */
    }



    float Timer = 0.0f;
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 3.0f)
        {
            // 3�ʸ��� �Ƿε� +3.0f * �Ƿε� ���� ���� (���Ƿ� ����)
            Moodle_Tired.Set_Moodles_state();
            Timer = 0.0f;
        }
    }


}

public class Moodles_state
{
    string _Moodle_Name = "";
    state _Moodle_Number = 0;
    float _Moodle_current_state = 0f;
    float _First_state = 0f;
    float _Second_state = 0f;
    float _Third_state = 0f;
    float _Fourth_state = 0f;

    public Moodles_state(string Moodle_Name, float Moodle_current_state, float First_state, float Second_state, float Third_state, float Fourth_state)
    {
        _Moodle_Name = Moodle_Name;
        _Moodle_current_state = Moodle_current_state;
        _First_state = First_state;
        _Second_state = Second_state;
        _Third_state = Third_state;
        _Fourth_state = Fourth_state;
    }
    enum state
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
    public void Set_Moodles_state()
    {
        switch(_Moodle_Number)
        {
            case state.Hungry:
                break;
            case state.Stuffed:
                break;
            case state.Thirsty:
                break;
            case state.Panic:
                break;
            case state.Bored:
                break;
            case state.Stressed:
                break;
            case state.Unhappy:
                break;
            case state.Drunk:
                break;
            case state.Heavy_Load:
                break;
            case state.Endurance:
                break;
            case state.Tired:
                _Moodle_current_state += 3.0f * Player_main.player_main.playerSkill_ActivationProbability.Get_Fatigue_Generation_Rate();  // * �Ƿε� ���� ����
                //if()
                break;
            case state.Hyperthermia_Hot:
                break;
            case state.Hyperthermia_Cold:
                break;
            case state.Windchill:
                break;
            case state.Wet:
                break;
            case state.Injured:
                break;
            case state.Pain:
                break;
            case state.Bleeding:
                break;
            case state.Has_a_Cold:
                break;
            case state.Sick:
                break;
            case state.Dead:
                break;
            case state.Zombie:
                break;
            case state.Restricted_Movement:
                break;
            default:
                break;

        }
    }

    public float Get_Moodles_state()
    {
        return _Moodle_current_state;
    }


}

