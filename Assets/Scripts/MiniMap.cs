using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            transform.localScale = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //GetComponent<Image>().color = new Color(255,255,255,1f);
            transform.localScale = new Vector3(7, 7, 7);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            //GetComponent<Image>().color = new Color(255,255,255,0);
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
