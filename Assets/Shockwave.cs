using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    float alpha;
    public float lifetime = 0.5f;
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
        transform.localScale = new Vector3(0.2f, 0.2f * Mathf.Sin(alpha), 0.2f);
        alpha += Mathf.PI/lifetime * Time.deltaTime;
    }
}
