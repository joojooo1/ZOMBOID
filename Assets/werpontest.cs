using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class werpontest : MonoBehaviour
{
    Collider collider;
    player_movement _Movement;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        _Movement = GetComponentInParent<player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            Debug.Log("근접무기 좀비공격함");
        }
    }
}
