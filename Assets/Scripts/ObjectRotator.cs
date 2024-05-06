/*****************************************************************************
// File Name : ObjectRotator.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Handles how the shoe is rotated using right click on the mouse
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRotator : MonoBehaviour
{
    private Vector2 dragOrigin;
    private bool isDragging = false;
    [SerializeField] private TimerCountdown timerCountdown;
    private InputAction rotateAction;

    void OnEnable()
    {
        // Enable the rotation action
        rotateAction.Enable();
    }

    void OnDisable()
    {
        // Disable the rotation action
        rotateAction.Disable();
    }

    void Awake()
    {
        // Create the rotation action
        rotateAction = new InputAction(binding: "<Mouse>/rightButton");

        // Add listener for the rotation action
        rotateAction.performed += ctx => StartDrag();
        rotateAction.canceled += ctx => EndDrag();
    }

    void StartDrag()
    {
        if (timerCountdown.timesUp1 || timerCountdown.allDone1)
            return;

        isDragging = true;
        dragOrigin = Mouse.current.position.ReadValue();
    }

    void EndDrag()
    {
        if (timerCountdown.timesUp1)
            return;

        isDragging = false;
    }

    void Update()
    {
        if (isDragging && !timerCountdown.timesUp1)
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
