using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControl : MonoBehaviour
{
    public Vector3 Center;
    void Awake()
    {
        //Debug.Log("OK");
        //gameObject.SetActive(true);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Center) < 1)
        {
            Destroy(gameObject);
        }
        transform.position += (Center - transform.position) * (Time.deltaTime*0.2f);
    }
}
