/*****************************************************************************
// File Name : BalanceController.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Controls the balance
*****************************************************************************/
using UnityEngine;
public class BalanceController : MonoBehaviour
{
    // Static reference to the instance of BalanceController
    private static BalanceController instance;
    [SerializeField] private float balance = 900;
    // Key to store and retrieve balance value from PlayerPrefs
    private string balanceKey = "PlayerBalance";
    // Property to get the balance
    public float Balance
    {
        get { return balance; }
        set { balance = value; }
    }
    /// <summary>
    /// Sets balance to base debug value which is 900
    /// </summary>
    public void ResetBalance()
    {
        // Reset balance to its original value
        balance = 900f;
    }
    /// <summary>
    /// handles how data is loadedd inbetween scenes by setting the instance of the object to this, loading balance, 
    /// and then making sure this object is not destroyed when it is loaded so it keeps the data. if the object
    /// instance is there again it will destroy it so theres not another if you enter the scene multiple times
    /// </summary>
    void Awake()
    {
        // Singleton pattern to ensure only one instance of BalanceController exists
        if (instance == null)
        {
            // Set the instance to this object
            instance = this;
            // Load the balance value from PlayerPrefs
            LoadBalance();
            // Make sure this object persists across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists and it's not this instance, destroy this one
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    /// <summary>
    /// adds to the balance from other classes or here
    /// </summary>
    /// <param name="amount"></param>
    private void AddToBalance(float amount)
    {
        Balance += amount;
    }
    /// <summary>
    /// saves balance using playerPrefs
    /// </summary>
    public void SaveBalance()
    {
        PlayerPrefs.SetFloat(balanceKey, Balance);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// loads balance using playerPrefs only if HasKey has the balanceKey
    /// </summary>
    private void LoadBalance()
    {
        if (PlayerPrefs.HasKey(balanceKey))
        {
            Balance = PlayerPrefs.GetFloat(balanceKey);
        }
    }
    /// <summary>
    /// example method to buy something
    /// </summary>
    /// <param name="amount"></param>
    public void PerformTransaction(float amount)
    {
        // Example usage: adding to balance
        AddToBalance(amount);
    }
}