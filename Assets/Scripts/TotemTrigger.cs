using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TotemTrigger: MonoBehaviour
{
    public LetGo contextOn;
    public LetGo contextOff;
    public bool playerInRange;

    public Data StarTrig;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && StarTrig.StarEnd)
        {
            SceneManager.LoadScene("End");
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            contextOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            contextOff.Raise();
            playerInRange = false;
        }
            
    }
}
