/*****************************************************************************
// File Name : ObjectSceneChange.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : changes scene from the load button
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnClick : MonoBehaviour
{
    private InputAction clickAction;

    private void Awake()
    {
        // Enable the default Mouse Left Click action
        clickAction = new InputAction(binding: "<Mouse>/leftButton");
        clickAction.Enable();

        // Register a callback for when the left mouse button is clicked
        clickAction.performed += OnClick;
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        // Check if the click was performed on this GameObject
        if (IsClickedOnThisGameObject())
        {
            // Load the next scene in the build
            LoadNextScene();
        }
    }

    private bool IsClickedOnThisGameObject()
    {
        // Get the current mouse position in screen coordinates
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Convert the screen coordinates to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

        // Perform a raycast to check if the mouse position overlaps with this GameObject's collider
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, worldMousePosition - Camera.main.transform.position, out hit))
        {
            // Check if the collider hit by the raycast is attached to this GameObject
            return hit.collider == GetComponent<Collider>();
        }

        return false;
    }

    private void LoadNextScene()
    {
        // Get the index of the current scene
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in the build
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void OnDisable()
    {
        // Disable the click action when this script is disabled or destroyed
        clickAction.Disable();
    }
}