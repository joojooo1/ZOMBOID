using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectInteraction : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;

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
            other.GetComponent<zom_pos>().zomon(player);
            //player.GetComponent<Player_main>().asd = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<zom_pos>())
        {
            //player.GetComponent<Player_main>().asd = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<zom_pos>())
        {
            other.GetComponent<zom_pos>().zomoff(player);
        }
    }
}
