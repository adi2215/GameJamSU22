using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public Data db;
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void Restart()
    {
        db.currentHealh = db.maxHealth;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
