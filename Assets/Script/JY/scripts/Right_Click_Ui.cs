using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Right_Click_Ui : MonoBehaviour,IPointerExitHandler
{
    // Start is called before the first frame update
    public Camera camera;
    public Transform Selection_Box;
    public GameObject Selection_Prefebs;

    public void OnPointerExit(PointerEventData eventData)
    {
        Selection_Box.transform.localPosition = new Vector3(150f, 400f, 0);
    }

    public void Something_Selectec()
    {
        Selection_Box.transform.localPosition = new Vector3(150f, 400f, 0);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1)) //��Ŭ��
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            bool objectFound = false;
            while (!objectFound)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    if (objectHit.gameObject.layer == 0)
                    {
                        Debug.Log(objectHit.name + " is selected");
                        objectFound = true;
                        GameObject Hit = objectHit.GetComponentInParent<TileItsInfo>().transform.gameObject;
                        Debug.Log(Hit+"Is Parent");
                        Selection_Box.transform.position = new Vector3(Input.mousePosition.x+40, Input.mousePosition.y+10, 0);
                        foreach(Transform Childrens in Hit.GetComponentsInChildren<Transform>())
                        {
                            if (Childrens.gameObject.CompareTag("Sit"))
                            {
                                foreach(Transform SelectionChildren in Selection_Box.GetComponentsInChildren<Transform>())
                                {
                                    Text gannet = SelectionChildren.GetComponentInChildren<Text>();
                                    gannet.text = "�ɱ�";
                                }
                            }
                            if (Childrens.gameObject.CompareTag("Bed"))
                            {
                                foreach (Transform SelectionChildren in Selection_Box.GetComponentsInChildren<Transform>())
                                {
                                    Text gannet = SelectionChildren.GetComponentInChildren<Text>();
                                    gannet.text = "����";
                                }
                            }
                            if (Childrens.gameObject.CompareTag("Door")|| Childrens.gameObject.CompareTag("Window"))
                            {
                                foreach (Transform SelectionChildren in Selection_Box.GetComponentsInChildren<Transform>())
                                {
                                    Text gannet = SelectionChildren.GetComponentInChildren<Text>();
                                    gannet.text = "����/�ݱ�";
                                }
                            }
                            if (Childrens.gameObject.CompareTag("CanGetOver"))
                            {
                                foreach (Transform SelectionChildren in Selection_Box.GetComponentsInChildren<Transform>())
                                {
                                    Text gannet = SelectionChildren.GetComponentInChildren<Text>();
                                    gannet.text = "�ѱ�";
                                }
                            }
                        }

                    }
                    else
                    {
                        
                        ray = new Ray(hit.point + ray.direction * 0.01f, ray.direction);
                    }
                }
                else
                {
                    // ���̿� �ƹ��͵� �浹���� �ʾ����Ƿ� �ݺ����� ����.
                    break;
                }
            }
        }
    }
}
