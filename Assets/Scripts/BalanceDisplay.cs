/*****************************************************************************
// File Name : BalanceDisplay.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : shoes the balance that updates between scenes
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceDisplay : MonoBehaviour
{
    private BalanceController balanceController;
    public TextMeshProUGUI balanceText;
    /// <summary>
    /// updates before first frame and find balanceController and updates the text after doing a check to make sure
    /// everything is ok with it
    /// </summary>
    void Start()
    {
        // Find the BalanceController instance in the scene
        balanceController = FindObjectOfType<BalanceController>();
        if (balanceController == null)
        {
            Debug.LogError("BalanceController not found in the scene.");
            return;
        }
        UpdateBalanceText();
    }
    /// <summary>
    /// called every frame and just updates balance text constantly
    /// </summary>
    void Update()
    {
        // Update the balance text continuously
        UpdateBalanceText();
    }
    /// <summary>
    /// checks to make sure balanceController and text arent missing and then sents the text to the balance
    /// </summary>
    private void UpdateBalanceText()
    {
        if (balanceController != null && balanceText != null)
        {
            balanceText.text = "Balance: " + balanceController.Balance.ToString("0");
        }
    }
}


