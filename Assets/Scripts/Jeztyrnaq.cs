using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeztyrnaq : MonoBehaviour
{
    public GameObject Target;
    public GameObject Spike;
    public GameObject Shockwave;
    public int circles = 0;
    int health = 10;
    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        SummonSpikes();
    }
    void SummonSpikes()
    {
        if (circles == 2)
        {
            return;
        }
        circles += 1;
        float x = Target.transform.position.x;
        float y = Target.transform.position.y;
        for (int i = 0; i < 15; ++i)
        {
            float alpha = i * Mathf.PI * 2 / 15;
            GameObject obj = Instantiate(Spike, new Vector3(x + 5 * Mathf.Cos(alpha), y + 5 * Mathf.Sin(alpha), 0), Quaternion.identity, gameObject.transform);
            obj.SetActive(true);
            obj.GetComponent<SpikeControl>().Center = Target.transform.position;
        }
    }
    IEnumerator SummonShockwaves()
    {
        yield return new WaitForSeconds(3f);
        Vector3 pos = transform.position;
        Vector3 goal = Vector3.Normalize(Target.transform.position-pos)*2;
        for (int i = 0; i < 20; ++i)
        {
            pos += goal;
            GameObject obj = Instantiate(Shockwave, pos, Quaternion.identity);
            obj.SetActive(true);
            yield return new WaitForSeconds(0.07f);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(Time.realtimeSinceStartup);
        health -= 1;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        circles = 0;
        if (health == 0)
        {
            Destroy(gameObject);
        }
        var angle = Random.Range(0, 2 * Mathf.PI);
        var len = Random.Range(10, 15);
        transform.position = Target.transform.position + new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * len;
        
        
        Invoke(nameof(SummonSpikes), 1);
        StartCoroutine(SummonShockwaves());
    }
}
