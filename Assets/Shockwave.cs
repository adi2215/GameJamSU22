using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    float alpha;
    public float lifetime = 1;
    private void Awake()
    {
        //StartCoroutine(Oscilate);
        alpha = 0;
    }
    private void Update()
    {
        if (alpha > Mathf.PI)
        {
            Destroy(gameObject);
        }
        transform.localScale = new Vector3(0.4f, 0.4f * Mathf.Sin(alpha), 0.4f);
        alpha += Mathf.PI/lifetime * Time.deltaTime;
    }
}
