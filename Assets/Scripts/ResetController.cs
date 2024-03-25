/*****************************************************************************
// File Name : ResetController.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Resets the shop for debugging
*****************************************************************************/
using UnityEngine;

public class ResetController : MonoBehaviour
{
    public ItemController[] items; 
    private BalanceController balanceController; 
    /// <summary>
    /// called before first frame and finds itemController and balanceController instance and then makes sure 
    /// balanceController is there and finds the instance from the string
    /// </summary>
    void Start()
    {
        items = FindObjectsOfType<ItemController>();
        balanceController = FindObjectOfType<BalanceController>();
        if (balanceController == null)
        {
            GameObject balanceControllerObject = new GameObject("BalanceController");
            balanceController = balanceControllerObject.AddComponent<BalanceController>();
        }
    }
    /// <summary>
    /// Resets the item no matter if its nested in another object or not
    /// </summary>
    public void ResetAll()
    {
        foreach (ItemController item in items)
        {
            item.ResetItem();
        }
        balanceController.ResetBalance();
        SaveItemStates();
        balanceController.SaveBalance(); 
    }
    /// <summary>
    /// saves item from the item class
    /// </summary>
    private void SaveItemStates()
    {
        foreach (ItemController item in items)
        {
            item.SaveItemState();
        }
    }
}