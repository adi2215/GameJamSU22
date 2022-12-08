using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger2 : MonoBehaviour
{
    public Data boss;

    void Start()
    {
        if (boss.trigger2)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            boss.trigger2 = true;
            SceneManager.LoadScene("Boss2");
        }
    }
}
