/*****************************************************************************
// File Name : ObjectRotator.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : Handles hoe the shoe is rotated using right click on the mouse
*****************************************************************************/
using UnityEngine;
public class ObjectRotator : MonoBehaviour
{
    private Vector3 dragOrigin;
    private bool isDragging = false;
    [SerializeField] private TimerCountdown timerCountdown;
    /// <summary>
    /// checks to see if the right mouse is held down and dragging(not using new input system yet but oopsies)
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && timerCountdown.timesUp1 == false && timerCountdown.allDone1 == false)
        {
            isDragging = true;
            dragOrigin = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1) && timerCountdown.timesUp1 == false)
        {
            isDragging = false;
        }
        if (isDragging && timerCountdown.timesUp1 == false)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 difference = currentMousePosition - dragOrigin;
            float rotationX = difference.y * 0.5f;
            float rotationY = -difference.x * 0.5f;
            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);
            dragOrigin = currentMousePosition;
        }
    }
}
