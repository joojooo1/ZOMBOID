using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player_animation : MonoBehaviour
{
    public GameObject aktob;
    public GameObject audioobject;
    public Animator animator;
    public bool atk = false;
    public float test_weapon_type = 0;
    public AudioClip Clip;
    player_rot audio;
    public AudioClip walkClip;
    public GameObject playernav;
    player_atk _Atk;

    public bool Player; // 0513 JY
    //public string Last_ANI_NAME;
    //public bool Last_ANI_BOOL;
    public List<String> Last_Name_Anime;
    public List<bool> Last_Bool_Anime;
    public List<float> Last_Float_Anime;

    // Start is called before the first frame update
    void Start()
    {
        _Atk = aktob.GetComponent<player_atk>();
        audio = audioobject.GetComponent<player_rot>();
        animator = GetComponent<Animator>();
        Last_Name_Anime = new List<string>();
        Last_Bool_Anime = new List<bool>();
        Last_Float_Anime = new List<float>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Player) // 0513 JY
        {
            float verticalInput = Input.GetAxisRaw("Vertical");
            verticalInput = Mathf.Clamp(verticalInput, -1f, 1f);
            float HorizontalInput = Input.GetAxisRaw("Horizontal");
            HorizontalInput = Mathf.Clamp(HorizontalInput, -1f, 1f);
            if (playernav.GetComponent<player_movement>().uI_Main.Playing)
            {
                if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        animatorsetBool("run", true);

                    }
                    else
                    {
                        animatorsetBool("walk", true);

                    }
                }
                else
                {
                    animatorsetBool("run", false);
                    animatorsetBool("walk", false);
                }
                if (Input.GetMouseButton(1))
                {

                    animatorsetBool("run", false);
                    animatorsetBool("Strife", true);
                    Vector3 input = (audioobject.transform.localRotation * new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0));
                    input.Normalize();
                    playernav.GetComponent<player_movement>().player_Main.Is_Aiming = true;
                    animatorsetFloat("x", input.x);
                    animatorsetFloat("z", -input.z);
                    if (Input.GetMouseButton(0) && !atk)
                    {
                        atk = true;
                        animatersetTrigger("ATK");

                    }

                }
                else
                {
                    playernav.GetComponent<player_movement>().player_Main.Is_Aiming = false;
                    animatorsetBool("Strife", false);
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (test_weapon_type < 4)
                    {
                        test_weapon_type++;
                    }
                    else
                        test_weapon_type = 0;
                    animatorsetFloat("weapon_type", test_weapon_type);
                }
                if (playernav.GetComponent<player_movement>().aser)
                {
                    animatorsetBool("walk", true);
                }
            }
        }
    }


    public void aktEnd()
    {
        atk = false;
        _Atk.atkset();

    }
    //0516 JY
    public void Getting_Anime_Set_For_Server(string Name, bool set, float floatt, int setting)
    {
        switch (setting)
        {
            case 1: // N B
                if (Last_Name_Anime.Count == 0) // �ʱ� ������ ����
                {
                    Last_Name_Anime.Add(Name);
                    Last_Bool_Anime.Add(set);
                    Last_Float_Anime.Add(404);

                    int Tof3 = 0;
                    if (set == true)
                    {
                        Tof3 = 1;
                    }
                    else
                    {
                        Tof3 = 0;
                    }
                    CMainGame.current.Player_Animation_Send(Name, Tof3, 404, setting);
                    return;
                }

                for (int ListCount = 0; ListCount < Last_Name_Anime.Count; ListCount++)
                {
                    if (Last_Name_Anime[ListCount] == Name)
                    {
                        if (Last_Bool_Anime[ListCount] != set)
                        {
                            Last_Bool_Anime[ListCount] = set;
                            int Tof2 = 0;
                            if (set == true)
                            {
                                Tof2 = 1;
                            }
                            else
                            {
                                Tof2 = 0;
                            }
                            CMainGame.current.Player_Animation_Send(Name, Tof2, 404, setting); // �Ұ� �ٸ����� ����
                            return;
                        }
                        else
                        {
                            //���� ������ ���������ʰ� ����
                            return;
                        }
                    }
                    else
                    {
                        //�ݺ�
                    }
                }
                // �������� ������� for���� �����Ƿ� �߰�����
                Last_Name_Anime.Add(Name);
                Last_Bool_Anime.Add(set);
                Last_Float_Anime.Add(404);

                int Tof = 0;
                if (set == true)
                {
                    Tof = 1;
                }
                else
                {
                    Tof = 0;
                }
                CMainGame.current.Player_Animation_Send(Name, Tof, 404, setting);
                return;

                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    public void animatorsetBool(string ANIMA_NAME, bool set)
    {
        animator.SetBool(ANIMA_NAME, set);
        if (Player)
        {
            Getting_Anime_Set_For_Server(ANIMA_NAME, set, 404, 1);
        }
    }
    public void animatersetTrigger(string ANIMA_NAME)
    {
        //setting 2 JY
        animator.SetTrigger(ANIMA_NAME);
    }
    public void animatorsetFloat(string ANIMA_NAME, float set)
    {
        //setting 3 JY
        animator.SetFloat(ANIMA_NAME, set);
    }
    void walkaudio()
    {
        audio.audioclip(walkClip, 0.5f);
    }
    public void animatorsetting(int A, float setting)
    {
        animator.SetLayerWeight(A, setting);

    }
    void Medical_body_pos()
    {
        Medical_body_pos_set(playernav.GetComponent<player_movement>().uI_Main.ui_player_state.Current_body_position);
    }
    void end()
    {


    }
    void Medical_body_pos_set(body_point body)
    {
        int _item_3d = 0;
        switch (body)
        {
            case body_point.Left_hand:
                _item_3d = 13;
                break;
            case body_point.Right_hand:
                _item_3d = 14;
                break;
            case body_point.Left_lowerarm:
                _item_3d = 5;
                break;
            case body_point.Right_lowerarm:
                _item_3d = 7;
                break;
            case body_point.Left_upperarm:
                _item_3d = 4;
                break;
            case body_point.Right_upperarm:
                _item_3d = 6;
                break;
            case body_point.Chest:
                _item_3d = 2;
                break;
            case body_point.Abdomen:
                _item_3d = 3;
                break;
            case body_point.Head:
                _item_3d = 0;
                break;
            case body_point.Neck:
                _item_3d = 1;
                break;
            case body_point.Groin:
                _item_3d = 8;
                break;
            case body_point.Left_upperleg:
                _item_3d = 9;
                break;
            case body_point.Right_upperleg:
                _item_3d = 11;
                break;
            case body_point.Left_lowerleg:
                _item_3d = 10;
                break;
            case body_point.Right_lowerleg:
                _item_3d = 12;
                break;
            case body_point.Left_foot:
                _item_3d = 15;
                break;
            case body_point.Right_foot:
                _item_3d = 16;
                break;
            default:
                break;
        }
    }

}
