using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn_Controller : MonoBehaviour
{
    Vector3 zom_spawn_pos;
    public GameObject[] zom_nav;
    // Start is called before the first frame update
    void Start()
    {
        zom_spawn_pos = transform.position;
        for (int i = 0; i < zom_nav.Length; i++)
        {
            zom_nav[i] = zom_nav[i];
            zom_nav[i].GetComponent<zom_pos>().get_zom_spawn_pos(zom_spawn_pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    void set_zom_spawn_pos()
    {
        for (int i = 0; i < zom_nav.Length; i++)
        {
            zom_nav[i] = zom_nav[i];
            zom_nav[i].GetComponent<zom_pos>().get_zom_spawn_pos(zom_spawn_pos);
        }
    }
}
