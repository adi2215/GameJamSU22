using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InvetoryUpdate : MonoBehaviour
{
    public GameObject DeathScreen;
    public Data db;
    public GameObject moneyCount;
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        moneyCount.GetComponent<TextMeshProUGUI>().text = db.Money.ToString() + "$";
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = db.Potion1.ToString();
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = db.Potion2.ToString();
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = db.Potion3.ToString();
        if (db.currentHealh <= 0)
        {
            DeathScreen.SetActive(true);
        }
    }
}
