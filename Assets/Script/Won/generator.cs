using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public float fuel = 0;
    public float fuel_max = 0;

    public float searchRadius = 15f; // 검색 반경
    public int bulb = 0;
    public int appliances = 0;
    public int turret = 0;
    List<GameObject> el = new List<GameObject>();
    Vector3 currentPosition;
    void Start()
    {
        // 현재 오브젝트의 위치
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
        electricity_test[] foundObjects = GameObject.FindObjectsOfType<electricity_test>(); //전자제품 스크립트 생기면 연결

        // 검색된 모든 오브젝트를 순회하며 처리
        foreach (electricity_test obj in foundObjects)
        {
            // 자신은 제외하고 검색하기 위해 건너뜀
            if (obj == this)
                continue;

            // 오브젝트와의 거리 계산
            float distance = Vector3.Distance(currentPosition, obj.transform.position);

            // 거리가 검색 반경 내에 있는 경우
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

    // 기존 오브젝트가 제거되었을 때 호출되는 함수 (예: 특정 이벤트 발생 시)
    public void OnObjectRemoved(GameObject obj)
    {
        currentPosition = transform.position;
        float distance = Vector3.Distance(currentPosition, obj.transform.position);

        // 거리가 검색 반경 내에 있는 경우
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
            // GameObject가 가지고 있는 ElScript 컴포넌트 가져오기
            electricity_test elScript = obj.GetComponent<electricity_test>();

            // ElScript가 있다면 bool 값을 변경
            if (elScript != null)
            {
                elScript.TEST = false; // 변경할 bool 값 전달
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
