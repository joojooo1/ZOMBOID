
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField]
    GameObject Map;

    [SerializeField]
    public GameObject Player;

    public bool Player_Exist;

    public float smoothSpeed = 0.125f;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player_Exist)
        {
            //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            ////anim.SetFloat("x", input.x);
            ////anim.SetFloat("y", input.y);

            //Vector3 pos = transform.position;
            //pos += input * Time.deltaTime * speed;


            //transform.position = pos;
            Vector3 desiredPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
