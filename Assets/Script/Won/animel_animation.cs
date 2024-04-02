using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animel_animation : MonoBehaviour
{
    public GameObject animelnav;
    NavMeshAgent nav;
    animal animal;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animal = animelnav.GetComponent<animal>();
        nav = animelnav.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = animelnav.transform.position;
        transform.localRotation = animelnav.transform.rotation;
        if (nav.velocity != Vector3.zero)
        {


            if (animal.TARGET != null)
            {
                animator.SetBool("run", true);
            }
            else
                animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<animel_animation>())
        {
            idleposset();
        }
    }*/
    void idleposset()
    {
        animal.SetRandomwalkpos();
    }
}
