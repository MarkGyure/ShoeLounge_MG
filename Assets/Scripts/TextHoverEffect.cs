/*****************************************************************************
// File Name : TextHoverEffect.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Handles the text hover effect
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
public class TextHoverEffect : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isHovering = false;
    private float hoverScaleFactor = 1.5f;
    private void Start()
    {
        originalScale = transform.localScale;
    }
    private void Update()
    {
        if (Mouse.current != null)
        {
            // Cast a ray from the mouse cursor into the scene
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            // Check if the ray intersects with this object
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Mouse is hovering over this object
                isHovering = true;
            }
            else
            {
                // Mouse is not hovering over this object
                isHovering = false;
            }
        }
        // Scale the object accordingly
        if (isHovering)
        {
            // Enlarge the object when hovering
            transform.localScale = originalScale * hoverScaleFactor;
        }
        else
        {
            // Shrink the object back to its original size
            transform.localScale = originalScale;
        }
    }
}