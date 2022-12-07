using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    int flag = 1;
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update() {
        if (transform.localScale.y > 1.15) {
            flag = 0;
        }
        if (transform.localScale.y < 1.0) {
            flag = 1;
        }
        if (flag == 1)
        {
            transform.localScale += new Vector3(0, 1, 0) * (Time.deltaTime/3);
        }else
        {
            transform.localScale -= new Vector3(0, 1, 0) * (Time.deltaTime/3);
        }
    }
}
