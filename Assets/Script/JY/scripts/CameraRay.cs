using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField]
    GameObject Map;

    [SerializeField]
    GameObject Player;

    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        ////anim.SetFloat("x", input.x);
        ////anim.SetFloat("y", input.y);

        //Vector3 pos = transform.position;
        //pos += input * Time.deltaTime * speed;


        //transform.position = pos;
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y,-10f );
    }
}
