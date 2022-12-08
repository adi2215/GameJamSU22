using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollowing : MonoBehaviour
{
    GameObject Target;
    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < 20) {
            transform.position += (Target.transform.position - transform.position) * (Time.deltaTime* 0.7f);
            if (Target.transform.position.x < transform.position.x)
            {
                transform.rotation = new Quaternion(0, -Mathf.PI, 0, 0);
            } else
            {
                transform.rotation = new Quaternion(0,  0, 0, 0);
            }
        }
    }
}
