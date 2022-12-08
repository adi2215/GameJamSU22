using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Data : ScriptableObject
{
    public int currentHealh;

    public int maxHealth = 10;

    public int Money = 10;

    public int Potion1 = 0;
    public int Potion2 = 0;
    public int Potion3 = 0;
}
