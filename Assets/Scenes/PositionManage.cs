using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManage : MonoBehaviour
{
    public GameObject pos;

    public GameObject posCam;

    public Data playpos;

    void Start()
    {
        pos.transform.position = playpos.pos;
        posCam.transform.position = playpos.posCamera;
    }

    void Update()
    {
        playpos.pos = pos.transform.position;
        playpos.posCamera = posCam.transform.position;
    }
}
