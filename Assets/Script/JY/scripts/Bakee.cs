using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using Unity.Mathematics;

public class Bakee : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface surface;

    float distance;
    float LengthofSurface = 12;
    public Transform player;

    private void Start()
    {
        TryBake();
        StartCoroutine(ExecuteEverySecond());
        //StartCoroutine("CheckDistance");
        //StartCoroutine("BK");
    }
    // Update is called once per frame
    void Update()
    {
        //TryBake();
    }

    IEnumerator CheckDistance()
    {
        while (true)
        {
            // yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(5f);
            distance = math.distancesq(transform.position, player.transform.position);
            if(distance > LengthofSurface)
            {
                transform.position = player.transform.position;
                TryBake();
            }
        }
    }
    IEnumerator BK()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            TryBake();
            Debug.Log("bk");    
        }
    }

    IEnumerator ExecuteEverySecond()
    {
        while (true)
        {
            // 1초 대기
            yield return new WaitForSeconds(1.0f);

            // 1초마다 실행할 코드
            TryBake();
        }
    }
    public void TryBake()
    {
        
        if (surface != null)
        {
            surface.BuildNavMesh();
            Debug.Log("NavMesh baked successfully!");
        }
        else
        {
            Debug.LogWarning("NavMeshSurface component is not found.");
        }
    }
}