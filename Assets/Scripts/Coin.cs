using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Data db;
    public GameObject Target;
    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < 1)
        {
            transform.position += Vector3.Normalize(Target.transform.position - transform.position) * (Vector3.Distance(transform.position, Target.transform.position)/2) * 15f * Time.deltaTime;
        } else if (Vector3.Distance(transform.position, Target.transform.position) < 7)
        {
            transform.position += Vector3.Normalize(Target.transform.position - transform.position) * 15f * Time.deltaTime;
            //Debug.Log(Target.transform.position.ToString() + Vector3.Normalize(Target.transform.position - transform.position).ToString());
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            db.Money += 1;
            Destroy(gameObject);
        }
    }
}
