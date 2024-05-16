using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    public static CameraMove2 ThreeDirectionalCamera;

    // Start is called before the first frame update

    [SerializeField]
    public GameObject Player;

    public bool Player_Exist;

    float smoothSpeed = 0.125f;
    private void Awake()
    {
        ThreeDirectionalCamera = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player_Exist)
        {
            Vector3 desiredPosition = new Vector3(Player.transform.position.x, Player.transform.position.y/*-3.4f*/, Player.transform.position.z - 2f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // º¸°£

            transform.position = smoothedPosition;
        }
    }
}
