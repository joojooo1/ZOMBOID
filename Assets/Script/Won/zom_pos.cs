using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;

public class zom_pos : MonoBehaviour
{
    NavMeshAgent nav;
    public GameObject target;
    zom_targetpos zom_Targetpos;
    public GameObject targetpos;
    Vector3 Tarpos;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        zom_Targetpos = targetpos.GetComponent<zom_targetpos>();
        //nav.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null) 
        {
            nav.SetDestination(new Vector3(target.transform.position.x,target.transform.position.y,0));
        }
    }
    public void zomldiepos(Vector3 pos)
    {
        
        Tarpos = pos;
        Vector3 direction = (pos - nav.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        nav.transform.rotation = Quaternion.RotateTowards(nav.transform.rotation, lookRotation, 0);
        nav.SetDestination(new Vector3(pos.x,pos.y,0));
    }
   
    public void zommovespeed(float zomspeed)
    {
        nav.speed = zomspeed;
    }
    void zomseverrot(Quaternion lookRotation)
    {

    }
}
