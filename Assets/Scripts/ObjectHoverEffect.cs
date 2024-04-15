/*****************************************************************************
// File Name : ObjectHoverEffect.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : same as text hover effect, except its for shop items
*****************************************************************************/
using UnityEngine;
public class ObjectHoverEffect : MonoBehaviour
{
    /// <summary>
    /// enlarges gameobject by 1.5 when mouse enters
    /// </summary>
    private void OnMouseEnter()
    {
        if (gameObject.transform.localScale.magnitude < 2f)
        {
            gameObject.transform.localScale *= 1.5f;
            Debug.Log("used MouseEnter");
        }
    }
    /// <summary>
    /// shrinks it by 1.5 when the mouse leaves
    /// </summary>
    private void OnMouseExit()
    {
        if (gameObject.transform.localScale.magnitude > 1.5f)
        {
            gameObject.transform.localScale /= 1.5f;
            Debug.Log("used MouseExit");
        }
    }
}
