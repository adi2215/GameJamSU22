using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHave : MonoBehaviour
{
    public Data have;
    void Start()
    {
        if (have.claw)
            gameObject.SetActive(true);

        if (have.morg)
            gameObject.SetActive(true);
    }
}
