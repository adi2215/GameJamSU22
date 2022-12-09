using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Villager : MonoBehaviour
{
    public Data prog;

    public GameObject dialoguePanel;

    public TextMeshProUGUI dialogueText;

    public string[] diaoluge;

    private int index;

    public float wordSpeed;
    public bool playerInClose;

    public GameObject contButton;

    public LetGo contextOn;
    public LetGo contextOff;

    public int ret = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerInClose && ret <= 0)
        {
            ret++;
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == diaoluge[index])
        {
            contButton.SetActive(true);
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false);

        if (index < diaoluge.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in diaoluge[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            contextOn.Raise();
            prog.Progress = 1;
            playerInClose = true;
            zeroText();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            contextOff.Raise();
            playerInClose = false;
        }
    }
}
