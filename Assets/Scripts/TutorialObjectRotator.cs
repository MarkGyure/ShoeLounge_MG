/*****************************************************************************
// File Name : TutorialObjectRotator.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Handles how the shoe is rotated using right click on the mouse
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
public class TutorialObjectRotator : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 dragOrigin;
    private InputAction mouseClickAction;
    /// <summary>
    /// enables mouse click action
    /// </summary>
    void OnEnable()
    {
        mouseClickAction.Enable();
    }
    /// <summary>
    /// disables mouse click action
    /// </summary>
    void OnDisable()
    {
        mouseClickAction.Disable();
    }
    /// <summary>
    /// creates mouse click actiom and the andds listeners for starting and canceling
    /// </summary>
    void Awake()
    {
        mouseClickAction = new InputAction(binding: "<Mouse>/rightButton");
        mouseClickAction.started += ctx => StartDrag();
        mouseClickAction.canceled += ctx => EndDrag();
    }
    /// <summary>
    /// sets "isDragging" to true and reads the value of the mouse position to set the rotation angle later
    /// </summary>
    void StartDrag()
    {
        isDragging = true;
        dragOrigin = Mouse.current.position.ReadValue();
    }
    /// <summary>
    /// turns isDragging to false
    /// </summary>
    void EndDrag()
    {
        isDragging = false;
    }
    /// <summary>
    /// Gets the value of the direction that is being dragged, and rotates the shoe accordingly
    /// </summary>
    void Update()
    {
        if (isDragging)
        {
            Vector2 currentMousePosition = Mouse.current.position.ReadValue();
            Vector2 difference = currentMousePosition - dragOrigin;
            float rotationX = difference.y * 0.5f;
            float rotationY = -difference.x * 0.5f;
            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);
            dragOrigin = currentMousePosition;
        }
    }
}
