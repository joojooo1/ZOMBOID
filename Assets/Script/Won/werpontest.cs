using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class werpontest : MonoBehaviour
{
    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    Vector3 inputpos;
    // Update is called once per frame
    void Update()
    {
        inputpos = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"), 0F);
        inputpos.Normalize();

        if (nav.enabled)
        {
            Debug.Log(inputpos);
            nav.Move(inputpos * nav.speed * Time.deltaTime);
        }
    }
   
}
