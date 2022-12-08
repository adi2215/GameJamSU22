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

}
