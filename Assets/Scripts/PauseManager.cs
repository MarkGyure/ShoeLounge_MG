/*****************************************************************************
// File Name : PauseManager.cs 
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles how pausing the game works
*****************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    private InputAction pauseAction;
    private bool isPaused = false;
    [SerializeField] private GameObject pauseScreen;
    /// <summary>
    /// creates a new input action for pause button and enables the listener
    /// </summary>
    private void OnEnable()
    {
        pauseAction = new InputAction(binding: "<Keyboard>/escape");
        pauseAction.performed += ctx => TogglePause();
        pauseAction.Enable();
    }
    /// <summary>
    /// disables the input action when the script is disabled or destroyed
    /// </summary>
    private void OnDisable()
    {
        pauseAction.Disable();
    }
    /// <summary>
    /// if the game is paused, unpause it, if its not paused, pause it
    /// </summary>
    private void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    /// <summary>
    /// sets the time scale of the game to 0 so nothing happens and logs it for debugging. also sets the pause screen
    /// to active
    /// </summary>
    private void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Game Paused");
        pauseScreen.SetActive(true);
    }
    /// <summary>
    /// sets the time scale back to normal (1.0) and logs that its resumed. also removes the pause screen
    /// </summary>
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Game Resumed");
        pauseScreen.SetActive(false);

    }
}
