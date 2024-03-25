/*****************************************************************************
// File Name : CleanController.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : handles the shoe cleaning
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CleanController : MonoBehaviour
{
    [SerializeField] private int dirtCount;
    [SerializeField] private TMP_Text winText;
    [SerializeField] private BalanceController balanceController; // Expose BalanceController as a serialized field
    private bool moneyGiven;
    /// <summary>
    /// called before first frame and disables winText
    /// </summary>
    private void Start()
    {
        moneyGiven = false;
        if (balanceController == null)
        {
            Debug.LogError("BalanceController is not assigned in the Inspector.");
        }

        winText.enabled = false;
    }
    public int DirtCount
    {
        get { return dirtCount; }
        set { dirtCount = value; }
    }
    /// <summary>
    /// makes sure the player "wins" aafter breaking 5 dirt
    /// </summary>
    private void Update()
    {
        if (dirtCount >= 5 && moneyGiven == false)
        {
            winText.enabled = true;
            balanceController.Balance += 5;
            balanceController.SaveBalance();
            Debug.Log("money given");
            moneyGiven=true;
        }
    }
}
