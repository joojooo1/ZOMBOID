using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float speed = 5;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        //anim.SetFloat("x", input.x);
        //anim.SetFloat("y", input.y);

        Vector3 pos = transform.position;
        pos += input * Time.deltaTime * speed;


        transform.position = pos;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall")&&other.transform.position.y<2)
        {
            if (other.transform.IsChildOf(transform))
                transform.position += new Vector3(0f, 1f, 0f);
            other.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") && other.transform.position.y >= 2)
        {
            if (other.transform.IsChildOf(transform))
                transform.position += new Vector3(0f, 1f, 0f);
            other.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        }
    }
}
