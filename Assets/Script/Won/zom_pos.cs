using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;

public class zom_pos : MonoBehaviour
{
    NavMeshAgent nav;
    public GameObject target;
    public Vector3 AUDIOPOS;
    zom_targetpos zom_Targetpos;
    public GameObject targetpos;
    Vector3 Tarpos;
    public bool audioposget = false;
    float ramdom;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        zom_Targetpos = targetpos.GetComponent<zom_targetpos>();
        //nav.updateRotation = false;
        ramdom = Random.Range(0, 3);
        Debug.Log(ramdom);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (target != null) 
        {
            audioposget = false;

            nav.SetDestination(new Vector3(target.transform.position.x,target.transform.position.y,0));
        }
        
        if(nav.remainingDistance <= nav.stoppingDistance +0.1f && audioposget)
        {
            audioposget = false;
            //zom_Targetpos.idlepos();
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
    public void Audioposget(Vector3 pos)
    {
        audioposget = true;
        nav.SetDestination(new Vector3(pos.x, pos.y, 0));
    }
}
