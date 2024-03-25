/*****************************************************************************
// File Name : DirtController.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : handles dirt counting and spawning
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    public static DirtController Instance { get; private set; }
    private CleanController cleanController;
    /// <summary>
    /// called before first frame and does a debug check for cleanController
    /// </summary>
    private void Start()
    {
        cleanController = GameObject.FindObjectOfType<CleanController>();
        if (cleanController == null)
        {
            Debug.LogWarning("CleanController not found.");
        }
    }
    /// <summary>
    /// destroys dirt and adds to the dirt count in clean controller
    /// </summary>
    private void OnMouseDown()
    {
        if (cleanController != null)
        {
            cleanController.DirtCount++;
        }
        Destroy(gameObject);
    }
}
