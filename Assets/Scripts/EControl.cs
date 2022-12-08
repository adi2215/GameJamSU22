using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EControl : MonoBehaviour
{
    public Sprite[] states;
    private void Start()
    {
        SetState(3);
    }
    public void SetState(int x)
    {
        //Debug.Log("STATE NO: " + x.ToString() + "/" + states.Length.ToString());
        GetComponent<Image>().sprite = states[x];
        if (x == 3)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        } else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
