using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.AI.Navigation;

public class player_movement : MonoBehaviour
{
    public float Playermovement_speed = 1;
    public float Playerturnspeed = 10000;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }



    // Update is called once per frame
    //void Update()
    //{
    //    Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), (Input.GetAxisRaw("Vertical") / 2),0f);
    //    Vector3 mousePos = Input.mousePosition;
    //    mousePos.z = Camera.main.nearClipPlane;
    //    Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
    //    Vector3 movement;
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    //if (Input.GetMouseButton(0))
    //    //{
    //    //    movement = ((input.normalized * Time.deltaTime * (Playermovement_speed-2))/2);
    //    //    if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
    //    //    {
    //    //        Vector3 directionToTarget = hit.point - transform.position;
    //    //        directionToTarget.y = 0;
    //    //        if (directionToTarget != Vector3.zero)
    //    //        {
    //    //            Quaternion toRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
    //    //            toRotation.eulerAngles = new Vector3(0, toRotation.eulerAngles.y, 0);
    //    //            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Playerturnspeed);

    //    //        }
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    movement = input.normalized * Time.deltaTime * Playermovement_speed;
    //    //    if (movement != Vector3.zero)
    //    //    {
    //    //        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
    //    //        float currentAngle = transform.eulerAngles.y;
    //    //        float newAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
    //    //        transform.rotation = Quaternion.Euler(0f, newAngle, 0f);
    //    //    }
    //    //}
    //    Vector3 pos = transform.position;
    //    //pos += movement;

    //    pos += input;
    //    transform.position = pos;
    //}



    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), (Input.GetAxisRaw("Vertical") / 2), 0f);
        input.Normalize();
        // GetComponent<Rigidbody>().MovePosition(transform.position + input * Time.deltaTime * 3.5f);
        //transform.position += input * Time.deltaTime * 30f;
        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(transform.position + (input * Time.deltaTime * 3.5f));

        //transform.LookAt(transform.position + (input * Time.deltaTime * 3.5f));
    }

    
}
