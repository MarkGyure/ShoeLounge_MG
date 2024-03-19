using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    private Vector3 dragOrigin;
    private bool isDragging = false;

    void Update()
    {
        // Check for mouse button down to start dragging
        if (Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            dragOrigin = Input.mousePosition;
        }

        // Check for mouse button release to stop dragging
        if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        // Rotate the object while dragging
        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 difference = currentMousePosition - dragOrigin;

            // Calculate rotation angles based on mouse movement
            float rotationX = difference.y * 0.5f;
            float rotationY = -difference.x * 0.5f;

            // Apply rotation to the object
            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);

            // Update drag origin for next frame
            dragOrigin = currentMousePosition;
        }
    }
}
