using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
//using static UnityEditor.PlayerSettings;

public class player_rot : MonoBehaviour
{
    Quaternion targetRotation;
    private AudioSource playerAudioSource;
    public LayerMask layerMask;
    public GameObject playerpos;
    // Start is called before the first frame update
    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    float rotationSpeed = 1000;
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (UnityEngine.Input.GetMouseButton(1))
        {
            Vector3 directionToTarget = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            directionToTarget.z = 0;
            Vector3 lookDirection = new Vector3(directionToTarget.x, directionToTarget.y, 0) - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0, -angle+90, 0f);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
            //gosever(targetRotation);
        }
        else if (horizontalInput != 0f || verticalInput != 0f)
        {
            // 입력값을 기준으로 회전 각도를 계산
            float targetAngle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            // 회전 각도 적용
            targetRotation = Quaternion.Euler(0, targetAngle, 0f);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
            //gosever(targetRotation);
        }
        if (playerpos.GetComponent<player_movement>().aser)
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerpos.GetComponent <NavMeshAgent>().velocity.normalized);
            Vector3 euler = targetRotation.eulerAngles;
            Debug.Log(euler.y+"ASd"+euler.x);
            if(euler.y < 180)
            {
                euler.y = euler.x + 90;
            }
            else
            { euler.y = euler.x-45; 
                if (euler.x < 50)
                {
                    euler.y = euler.x-180;
                    Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaa");
                }
                else if (euler.x < 90) 
                {
                    euler.y = euler.x + 90;
                } 
            }
            euler.x = 0f;
            euler.z = 0f;
            targetRotation = Quaternion.Euler(euler);
            transform.localRotation = targetRotation;
        }

        float currentVolume = playerAudioSource.volume;
        if (currentVolume > 0.5)
        {
            
            //test
            Collider[] colliders = Physics.OverlapSphere(transform.position, currentVolume*5, layerMask);
            foreach (Collider collider in colliders)
            {
                // 충돌체가 공통된 스크립트를 가지고 있는지 확인합니다.
                zom_pos zomtarget = collider.GetComponent<zom_pos>();
                if (zomtarget != null)
                {
                    zomtarget.Audioposget(transform.position);
                }
            }
        }
    }
    public void audioclip(AudioClip clip, float audiosound)
    {
        playerAudioSource.PlayOneShot(clip);
        playerAudioSource.volume = audiosound;
    }

    void gosever(Quaternion player_rot)
    {
        //서버로 회전값 전송 (서버스크립트).(플레이어 넘버).(player_rot);
    }
    void getseverrot(Quaternion player_rot)
    {
        //서버에서 받았을떄 회전값적용transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void getzomda(GameObject Zombie_Attack, string Zom_Type, bool IsBack, bool IsDown)
    {
        playerpos.GetComponent<player_movement>().player_Main.Calculate_HitForce(Zombie_Attack, Zom_Type, IsBack, IsDown);
    }
}
