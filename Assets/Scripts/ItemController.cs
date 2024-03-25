/*****************************************************************************
// File Name : ItemController.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Controlls buying items and other properties
*****************************************************************************/
using System.Collections;
using UnityEngine;
public class ItemController : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private ParticleSystem particles;
    private BalanceController balanceController; 
    private bool isPurchased = false; 
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    /// <summary>
    /// called before first frame and sets original rotation and position to the transfroms pos and rot. then finds
    /// balanceController instance, loads the item state, and updates if it should be visable
    /// </summary>
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        balanceController = FindObjectOfType<BalanceController>();
        LoadItemState();
        UpdateItemVisibility();
    }
    /// <summary>
    /// when mouse is clicked on the item, it checks if the balance controller is there and then makes sure the player
    /// has enough money to buy the item, if they do the item is bought with a cool particle effect.
    /// </summary>
    private void OnMouseDown()
    {
        if (balanceController != null)
        {
            if (balanceController.Balance >= price)
            {
                balanceController.PerformTransaction(-price);
                isPurchased = true;
                SaveItemState();
                UpdateItemVisibility();
                StartCoroutine(EnableParticlesCoroutine());
            }
            else
            {
                Debug.Log("Not enough balance to purchase this item.");
            }
        }
        else
        {
            Debug.Log("BalanceController not found in the scene.");
        }
    }
    /// <summary>
    /// Resets item positon and rotation and makes it not purchased for debugging
    /// </summary>
    public void ResetItem()
    {
        ShowItem();
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        isPurchased = false;
    }
    /// <summary>
    /// shows the reset item
    /// </summary>
    private void ShowItem()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }
    /// <summary>
    /// hides the bought item
    /// </summary>
    private void HideItem()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
    /// <summary>
    /// handles particles for 1 second
    /// </summary>
    /// <returns></returns>
    IEnumerator EnableParticlesCoroutine()
    {
        particles.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        particles.gameObject.SetActive(false);
    }
    /// <summary>
    /// sets renderers and colliders to true or false if item is purchased or not
    /// </summary>
    private void UpdateItemVisibility()
    {
        if (isPurchased)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
        }
    }
    /// <summary>
    /// saves using playerPrefs (refer to youtube videos for understanding)
    /// </summary>
    public void SaveItemState()
    {
        PlayerPrefs.SetInt(gameObject.name + "_Purchased", isPurchased ? 1 : 0);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// load using playerPrefs (refer to youtube videos for understanding)
    /// </summary>
    private void LoadItemState()
    {
        if (PlayerPrefs.HasKey(gameObject.name + "_Purchased"))
        {
            isPurchased = PlayerPrefs.GetInt(gameObject.name + "_Purchased") == 1;
        }
    }
}