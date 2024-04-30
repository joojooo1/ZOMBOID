using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public float fuel = 0;
    public float fuel_max = 0;

    public float searchRadius = 15f; // �˻� �ݰ�
    public int bulb = 0;
    public int appliances = 0;
    public int turret = 0;
    List<GameObject> el = new List<GameObject>();
    Vector3 currentPosition;
    void Start()
    {
        // ���� ������Ʈ�� ��ġ
        currentPosition = transform.position;
        bulb = 0;
        appliances = 0;
        turret = 0;
        find_obj();
        StartCoroutine(Consumption());
    }
    public void generator_on()
    {
        find_obj();
        StartCoroutine(Consumption());
    }
    public void generator_off()
    {
        el = null;
        StopCoroutine(Consumption());
    }
    void find_obj()
    {
        Debug.Log("ASdasdas");
        electricity_test[] foundObjects = GameObject.FindObjectsOfType<electricity_test>(); //������ǰ ��ũ��Ʈ ����� ����

        // �˻��� ��� ������Ʈ�� ��ȸ�ϸ� ó��
        foreach (electricity_test obj in foundObjects)
        {
            // �ڽ��� �����ϰ� �˻��ϱ� ���� �ǳʶ�
            if (obj == this)
                continue;

            // ������Ʈ���� �Ÿ� ���
            float distance = Vector3.Distance(currentPosition, obj.transform.position);

            // �Ÿ��� �˻� �ݰ� ���� �ִ� ���
            if (distance <= searchRadius)
            {
                if (obj.TEST)
                {
                    el.Add(obj.gameObject);
                    Debug.Log(obj.gameObject.name);
                    Get_obj_type(obj.gameObject.tag);
                }

            }
        }
    }
    void Get_obj_type(string type)
    {
        switch (type)
        {
            case "bulb":
                bulb++;
                break;
            case "appliances":
                appliances++;
                break;
            case "turret":
                turret++;
                break;
        }
    }
    void out_obj_type(string type)
    {
        switch (type)
        {
            case "bulb":
                bulb--;
                break;
            case "appliances":
                appliances--;
                break;
            case "turret":
                turret--;
                break;
        }
    }
    IEnumerator Consumption()
    {
        while (true)
        {
            yield return new WaitForSeconds(48f);
            float cost = (bulb * 0.05f) + (appliances * 0.13f) + (turret * 0.3f);
            if (fuel > cost)
            {
                fuel -= cost;
            }
            else
            {
                outelectricity();
            }
        }
    }

    // ���� ������Ʈ�� ���ŵǾ��� �� ȣ��Ǵ� �Լ� (��: Ư�� �̺�Ʈ �߻� ��)
    public void OnObjectRemoved(GameObject obj)
    {
        currentPosition = transform.position;
        float distance = Vector3.Distance(currentPosition, obj.transform.position);

        // �Ÿ��� �˻� �ݰ� ���� �ִ� ���
        if (distance <= searchRadius)
        {
            if (obj.GetComponent<electricity_test>().TEST)
            {
                el.Add(obj);
                Get_obj_type(obj.gameObject.tag);
            }
            else
            {
                el.Remove(obj);
                out_obj_type(obj.gameObject.tag);
            }
        }
    }
    void outelectricity()
    {
        foreach (GameObject obj in el)
        {
            // GameObject�� ������ �ִ� ElScript ������Ʈ ��������
            electricity_test elScript = obj.GetComponent<electricity_test>();

            // ElScript�� �ִٸ� bool ���� ����
            if (elScript != null)
            {
                elScript.TEST = false; // ������ bool �� ����
            }
        }
        bulb = 0;
        appliances = 0;
        turret = 0;
        fuel = 0;
    }
    public void charge(GameObject oil_obj,float fuelcharge)
    {
        fuel += fuelcharge;
        if (fuel > fuel_max)
        {
            float oil = fuel - fuel_max;
            oil_obj.GetComponent<Item_Electronics>().Capacity = (int)oil;
        }
        else
            oil_obj.GetComponent<Item_Electronics>().Capacity = oil_obj.GetComponent<Item_Electronics>().Capacity - (int)fuelcharge;
    }
}
