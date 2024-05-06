/*****************************************************************************
// File Name : ObjectHoverEffect.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Controls what happens to the items when the mouse hovers over them
*****************************************************************************/
using UnityEngine;
public class ObjectHoverEffect : MonoBehaviour
{
    /// <summary>
    /// Enlarges the GameObject by 1.5 when the mouse enters.
    /// </summary>
    private void OnMouseEnter()
    {
        if (gameObject.transform.localScale.magnitude < 2f)
        {
            gameObject.transform.localScale *= 1.5f;
            Debug.Log("Used MouseEnter");
        }
    }
    /// <summary>
    /// Shrinks the GameObject by 1.5 when the mouse exits.
    /// </summary>
    private void OnMouseExit()
    {
        if (gameObject.transform.localScale.magnitude > 1.5f)
        {
            gameObject.transform.localScale /= 1.5f;
            Debug.Log("Used MouseExit");
        }
    }
}
