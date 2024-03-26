using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player_animation : MonoBehaviour
{
    public GameObject rot;
    Animator animator;
    bool atk = false;
    public float test_weapon_type = 0;
    // Start is called before the first frame update
    void Start()
    {
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
                animator.SetBool("run", true);
            }
            else
            {
                animator.SetBool("walk", true);
            }
        }
        else
        {
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("run", false);
            animator.SetBool("Strife", true);
            Vector3 input = (rot.transform.localRotation * new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0));
            input.Normalize();
            Debug.Log(input);
            
            animator.SetFloat("x", input.x);
            animator.SetFloat("z", -input.z);
            if (Input.GetMouseButton(0) && !atk)
            {
                atk = true;
                animator.SetTrigger("ATK");
            }
        }
        else
        {
            animator.SetBool("Strife", false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (test_weapon_type < 4)
            {
                test_weapon_type++;
            }
            else
                test_weapon_type = 0;
            animator.SetFloat("weapon_type", test_weapon_type);
        }
    }


    public void aktEnd()
    {
        atk = false;
    }
}
