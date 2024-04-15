/*****************************************************************************
// File Name : GameCheck
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Starts every level off making sure its not the tutorial
*****************************************************************************/
using UnityEngine;
public class GameCheck : MonoBehaviour
{
    [SerializeField] private TimerCountdown timerCountdown;
    /// <summary>
    /// runs the timerCountdowns SetNoTutorial method
    /// </summary>
    void Start()
    {
        timerCountdown.SetNoTutorial();
    }
}
