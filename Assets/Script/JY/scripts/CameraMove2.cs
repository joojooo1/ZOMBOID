using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject Player;
    float smoothSpeed = 0.125f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(Player.transform.position.x,Player.transform.position.y/*-3.4f*/,Player.transform.position.z-2f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // º¸°£

        transform.position = smoothedPosition;
    }
}
