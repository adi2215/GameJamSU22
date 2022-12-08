using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour
{
    public TextMeshProUGUI moneyAmount;
    public Button[] buybutton;
    public Data moneyData;
    private int MoneyCheck;

    private void Start()
    {
        MoneyCheck = moneyData.Money;
        Debug.Log(MoneyCheck);
    }

    private void Update()
    {
        moneyAmount.text = moneyData.Money.ToString() + "$";
        MoneyCheck = moneyData.Money;

        if (MoneyCheck >= 3)
        {
            buybutton[0].interactable = true;
            buybutton[1].interactable = true;
            buybutton[2].interactable = true;
        }
        else
        {
            buybutton[0].interactable = false;
            buybutton[1].interactable = false;
            buybutton[2].interactable = false;
        }
    }

    public void buyBlue()
    {
        moneyData.Money -= 3;
        Debug.Log("Money");
    }

    public void buyGreen()
    {
        moneyData.Money -= 3;
    }

    public void buyPink()
    {
        moneyData.Money -= 3;
    }
}
