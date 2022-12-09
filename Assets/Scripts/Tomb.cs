using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb : MonoBehaviour
{
    public int capacity = 10;
    public bool active;
    GameObject Target;
    public GameObject Mob;
    float cool;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        //Mob = GameObject.FindGameObjectWithTag("Ghost");
    }

    // Update is called once per frame
    void Update()
    {
        cool -= Time.deltaTime;
        // if ()
        // {
        //     active = true;
        // }
        if (Vector3.Distance(transform.position, Target.transform.position) < 20)
        {
            if (cool < 0 && capacity > 0 && transform.childCount == 0)
            {
                capacity -= 1;
                var obj = Instantiate(Mob, transform.position, Quaternion.identity, transform);
                obj.SetActive(true);
                cool = 3f;
            }
        }
    }
}
