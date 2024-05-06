/*****************************************************************************
// File Name : QuitController.cs 
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles how to quit the game by pressing the button
*****************************************************************************/
using UnityEngine;
public class QuitController : MonoBehaviour
{
    /// <summary>
    /// quits the application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
