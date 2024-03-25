/*****************************************************************************
// File Name : ObjectHoverEffect.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : same as text hover effect, except its for shop items
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectHoverEffect : MonoBehaviour
{
    private void OnMouseEnter()
    {
        if (gameObject.transform.localScale.magnitude < 2f)
        {
            gameObject.transform.localScale *= 1.5f;
            Debug.Log("used MouseEnter");
        }
    }
    private void OnMouseExit()
    {
        if (gameObject.transform.localScale.magnitude > 1.5f)
        {
            gameObject.transform.localScale /= 1.5f;
            Debug.Log("used MouseExit");
        }
    }
}
