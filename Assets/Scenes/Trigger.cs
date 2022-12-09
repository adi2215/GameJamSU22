using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public Data boss;

    void Start()
    {
        if (boss.trigger1)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            boss.Progress = 2;
            boss.trigger1 = true;
            SceneManager.LoadScene("SampleScene 2");
        }
    }
}
