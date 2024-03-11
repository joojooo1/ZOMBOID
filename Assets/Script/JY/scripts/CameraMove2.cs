using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y-3.4f,Player.transform.position.z-2f);
    }
}
