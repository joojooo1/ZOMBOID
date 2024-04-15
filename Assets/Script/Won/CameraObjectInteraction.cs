using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectInteraction : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<zom_pos>())
        {
            other.GetComponent<zom_pos>().zomon();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<zom_pos>())
        {
            other.GetComponent<zom_pos>().zomoff();
        }
    }
}
