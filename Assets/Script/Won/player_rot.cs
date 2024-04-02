using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class player_rot : MonoBehaviour
{
    Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float rotationSpeed = 1000;
    // Update is called once per frame
    void Update()
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
            // �Է°��� �������� ȸ�� ������ ���
            float targetAngle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            // ȸ�� ���� ����
            targetRotation = Quaternion.Euler(0, targetAngle, 0f);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
            //gosever(targetRotation);
        }
    }

    void gosever(Quaternion player_rot)
    {
        //������ ȸ���� ���� (������ũ��Ʈ).(�÷��̾� �ѹ�).(player_rot);
    }
    void getseverrot(Quaternion player_rot)
    {
        //�������� �޾����� ȸ��������transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
