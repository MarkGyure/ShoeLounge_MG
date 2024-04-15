/*****************************************************************************
// File Name : TextHoverEffect.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Handles the text hover effect
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TextHoverEffect : MonoBehaviour
{
    [SerializeField] private GameObject fakeButton;
    /// <summary>
    /// 
    /// </summary>
    private void OnMouseOver()
    {
        if (fakeButton.gameObject.transform.localScale.magnitude < 2f)
        {
            fakeButton.gameObject.transform.localScale *= 1.5f;
            Debug.Log("used MouseOver");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void OnMouseEnter()
    {
        if (fakeButton.gameObject.transform.localScale.magnitude < 2f)
        {
            fakeButton.gameObject.transform.localScale *= 1.5f;
            Debug.Log("used MouseEnter");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void OnMouseExit()
    {
        if (fakeButton.gameObject.transform.localScale.magnitude > 1.5f)
        {
            fakeButton.gameObject.transform.localScale /= 1.5f;
            Debug.Log("used MouseExit");
        }
    }
}

