/*****************************************************************************
// File Name : TutorialCheck.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Checks the tutorial and tells the other class that it is the tutorial
*****************************************************************************/
using UnityEngine;
public class TutorialCheck : MonoBehaviour
{
    [SerializeField] private TimerCountdown timerCountdown;
    /// <summary>
    /// runs the timerCountdowns SetTutorial method
    /// </summary>
    void Start()
    {
        timerCountdown.SetTutorial();
    }
}
