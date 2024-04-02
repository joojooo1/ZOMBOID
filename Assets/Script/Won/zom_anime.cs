using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class zom_anime : MonoBehaviour
{
    public GameObject zomnav;
    Animator animator;
    NavMeshAgent nav;
    zom_pos zompos;
    zom_targetpos zomtarget;
    float turnspeed = 1000;
    public GameObject asd;
    private Quaternion initialLocalRotation;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        Transform parentTransform = transform.parent;
        nav = zomnav.GetComponent<NavMeshAgent>();
        zompos = zomnav.GetComponent<zom_pos>();
        zomtarget = asd.GetComponent<zom_targetpos>();
        if (nav == null)
        {
            nav = zomnav.GetComponent<NavMeshAgent>();
        }
        if (zompos == null)
        {
            zompos = zomnav.GetComponent <zom_pos>();
        }
        if(zomtarget == null)
        {
            zomtarget = asd.GetComponent<zom_targetpos>();
        }
        //transform.SetParent(zomnav.transform, false);
        
    }
    public GameObject z;
    // Update is called once per frame
    void Update()
    {

        transform.localRotation = zomnav.transform.rotation;


        if (nav.velocity != Vector3.zero)
        {
            

            if (zompos.target != null)
            {
                animatorsetBool("run", true);
            }
            else
                animatorsetBool("walk", true);
        }
        else 
        {
            animatorsetBool("run", false);
            animatorsetBool("walk", false);
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == zompos.target)
        {
            animatorsetBool("Playeratk",true);
        }
    }
    void idleposset()
    {
        zomtarget.idlepos();
    }
    void animatorsetBool(string ANIMA_NAME, bool set)
    {
        animator.SetBool(ANIMA_NAME, set);
    }
    void animatersetTrigger(string ANIMA_NAME)
    {
        animator.SetTrigger(ANIMA_NAME);
    }
    void animatorsetFloat(string ANIMA_NAME, float set)
    {
        animator.SetFloat(ANIMA_NAME, set);
    }
}
