using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player_animation : MonoBehaviour
{
    public GameObject rot;
    public GameObject audioobject;
    Animator animator;
    bool atk = false;
    public float test_weapon_type = 0;
    public AudioClip Clip;
    player_rot audio;
    public AudioClip walkClip;
    // Start is called before the first frame update
    void Start()
    {
        audio = audioobject.GetComponent<player_rot>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float verticalInput = Input.GetAxisRaw("Vertical");
        verticalInput = Mathf.Clamp(verticalInput, -1f, 1f);
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        HorizontalInput = Mathf.Clamp(HorizontalInput, -1f, 1f);
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
            Vector3 input = (rot.transform.localRotation * new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0));
            input.Normalize();

            animatorsetFloat("x", input.x);
            animatorsetFloat("z", -input.z);
            if (Input.GetMouseButton(0) && !atk)
            {
                atk = true;
                animatersetTrigger("ATK");
                audio.audioclip(Clip,1);
                Debug.Log("�Ҹ� ����");
            }
        }
        else
        {
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
    }


    public void aktEnd()
    {
        atk = false;
    }

    void animatorsetBool(string ANIMA_NAME,bool set)
    {
        animator.SetBool (ANIMA_NAME, set);
    }
    void animatersetTrigger(string ANIMA_NAME)
    {
        animator.SetTrigger(ANIMA_NAME);
    }
    void animatorsetFloat(string ANIMA_NAME, float set)
    {
        animator.SetFloat(ANIMA_NAME, set);
    }
    void walkaudio()
    {
        audio.audioclip(walkClip, 0.5f);
    }
}
