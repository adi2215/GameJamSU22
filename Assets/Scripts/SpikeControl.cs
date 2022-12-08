using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControl : MonoBehaviour
{
    public Vector3 Center;
    public float decay = 0;
    public float rise = 0;
    void Awake()
    {
        rise = 0.3f;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.localScale = new Vector3(15, 0, 15);
    }

    void Update()
    {
        if (rise > 0)
        {
            decay = 0;
            transform.localScale += new Vector3(0, 100f * Time.deltaTime * (Mathf.Cos(Mathf.PI * (0.3f - rise) / 0.3f) + 0.5f), 0);
            rise -= Time.deltaTime;
        } else if(decay > 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            transform.localScale -= new Vector3(0, 100f * Time.deltaTime * (-Mathf.Cos(Mathf.PI * (0.3f - decay) / 0.3f) + 0.5f), 0);
            if (transform.localScale.y < 0)
            {
                Destroy(gameObject);
            }
            decay -= Time.deltaTime;
        } else
        {
            transform.localScale = new Vector3(15, 15, 15);
            transform.position += (Center - transform.position) * (Time.deltaTime * 0.2f);
            if (Vector3.Distance(transform.position, Center) < 2)
            {
                decay = 1f;
            }
        }
    }
}
