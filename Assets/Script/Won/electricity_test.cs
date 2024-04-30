using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricity_test : MonoBehaviour
{
    public bool TEST = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            TEST = !TEST;
            generator[] foundObjects = GameObject.FindObjectsOfType<generator>();
            foreach (generator obj in foundObjects)
            {
                obj.OnObjectRemoved(this.gameObject);
            }
        }

    }
}
