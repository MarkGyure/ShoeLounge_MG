/*****************************************************************************
// File Name : TimerCountdown.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Deals with the timer countdown and the timer at the top of the screen
*****************************************************************************/
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TimerCountdown : MonoBehaviour
{
    [SerializeField] private float totalTime = 0;
    public float totalTime1 { get => totalTime; set => totalTime = value; }
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private bool timesUp = false;
    [SerializeField] private RectTransform loseBoard;
    [SerializeField] private Button doneButton;
    [SerializeField] private Button wrongLeaveButton;
    [SerializeField] private bool isTutorial = false;
    public bool timesUp1 { get => timesUp; set => timesUp = value; }
    [SerializeField] private ShoeCleaner shoeCleaner;
    private bool hasExecuted = false;
    [SerializeField] private bool allDone;
    public bool allDone1 { get => allDone; set => allDone = value; }
    /// <summary>
    /// sets isTutorial to true
    /// </summary>
    public void SetTutorial()
    {
        isTutorial = true;
    }
    /// <summary>
    /// sets isTutorial to false
    /// </summary>
    public void SetNoTutorial()
    {
        isTutorial = false;
    }
    /// <summary>
    /// runs once per frame and if total time is less that or equal to 60 adn hasExecuted is false it will set it to
    /// true and play a sound theoretically. then makes sure the timer isnt over yet and makes sure this isnt the
    /// tutorial and then subtracts time.deltatime from totalTime to insure proper timings. does math things that I
    /// honestly dont understand but it works!. Has a switch for all the 9-5 experience and if total tim gets low
    /// enough the player will lose the game and be forced to restart.
    /// </summary>
    void Update()
    {
        if (totalTime1 <= 60 && !hasExecuted)
        {
            hasExecuted = true;
            Debug.Log("playing sound");
        }
        if (totalTime > 0 && isTutorial == false)
        {
            totalTime -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(totalTime / 60);
            float seconds = Mathf.FloorToInt(totalTime % 60);
            int inGameHours = Mathf.FloorToInt(totalTime / 13);
            switch (inGameHours)
            {
                case 9:
                    timerText.text = "Time: 9:00 AM";
                    break;
                case 8:
                    timerText.text = "Time: 10:00 AM";
                    break;
                case 7:
                    timerText.text = "Time: 11:00 AM";
                    break;
                case 6:
                    timerText.text = "Time: 12:00 PM";
                    break;
                case 5:
                    timerText.text = "Time: 1:00 PM";
                    break;
                case 4:
                    timerText.text = "Time: 2:00 PM";
                    break;
                case 3:
                    timerText.text = "Time: 3:00 PM";
                    break;
                case 2:
                    timerText.text = "Time: 4:00 PM";
                    break;
                case 1:
                    timerText.text = "Time: 5:00 PM";
                    break;
            }
            if (totalTime < 1)
            {
                timerText.text = "Time's up";
                timesUp = true;
                loseBoard.gameObject.SetActive(true);
                doneButton.interactable = false;
                wrongLeaveButton.interactable = false;
                if (shoeCleaner.CleanedPixelCount >= 550000)
                {
                    Debug.Log("This was a perfect clean!");
                }
                else if (shoeCleaner.CleanedPixelCount >= 400000 && shoeCleaner.CleanedPixelCount < 550000)
                {
                    Debug.Log("This was a great clean!");
                }
                else if (shoeCleaner.CleanedPixelCount >= 270000 && shoeCleaner.CleanedPixelCount < 400000)
                {
                    Debug.Log("This was a decent clean!");
                }
                else if (shoeCleaner.CleanedPixelCount >= 100000 && shoeCleaner.CleanedPixelCount < 270000)
                {
                    Debug.Log("This was a bad clean!");
                }
                else if (shoeCleaner.CleanedPixelCount <= 100000)
                {
                    Debug.Log("This was a terrible clean!");
                }
            }
        }
    }
}
