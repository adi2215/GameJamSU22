using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Data : ScriptableObject
{
    public int currentHealh;

    public int maxHealth = 10;

    public int Money = 10;


    public bool claw = false;

    public bool morg = false;

    public bool trigger1 = false;

    public bool trigger2 = false;

    public Vector3 pos;

    public Vector3 posCamera;

    public bool StarEnd = false;

    public int Potion1 = 0;
    public int Potion2 = 0;
    public int Potion3 = 0;
    public int Progress = 0;
}
