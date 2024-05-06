/*****************************************************************************
// File Name : FinishedController.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : controlls how the game is ended
*****************************************************************************/
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FinishedController : MonoBehaviour
{
    [SerializeField] private ShoeCleaner shoeCleaner;
    [SerializeField] private TimerCountdown timerCountdown;
    [SerializeField] private RectTransform scoreBoard;
    [SerializeField] AudioSource femalePerfect;
    [SerializeField] AudioSource femaleGreat;
    [SerializeField] AudioSource femaleBad;
    [SerializeField] AudioSource femaleTerrible;
    [SerializeField] AudioSource malePerfect;
    [SerializeField] AudioSource maleGreat;
    [SerializeField] AudioSource maleBad;
    [SerializeField] AudioSource maleTerrible;
    [SerializeField] AudioSource maleTooLong;
    [SerializeField] AudioSource maleLeaving;
    [SerializeField] AudioSource femaleTooLong;
    [SerializeField] AudioSource femaleLeaving;
    [SerializeField] TMP_Text jaceScore;
    [SerializeField] TMP_Text sophieScore;
    [SerializeField] TMP_Text laurieScore;
    [SerializeField] TMP_Text marianneScore;
    [SerializeField] private TMP_Text playerScore;
    [SerializeField] private ScoreData scoreData;
    [SerializeField] private Button doneButton;
    /// <summary>
    /// tells game that the round has ended, sets tutorial to true to stop timer, makes buttons not interactable anymore
    /// subtracts 1 screo from the player bc for some reason it gives them 1 for free when they press the done button.
    /// Actually looking at it right now it might be because of the line below and im REALLY stupid... ive been doing
    /// this for too long. Ill fix that later. sets the palyer text to show the score properly, gets random 1-20 
    /// numbers for the NPCs and updates their scores into the scriptable object and sets the text to that number.
    /// plays the corresponding sound to the player depending on how well they did.
    /// </summary>
    public void AllDone()
    {
        timerCountdown.allDone1 = true;
        timerCountdown.SetTutorial();
        doneButton.interactable = false;
        scoreData.AddPlayerScore("player", -1);
        // Add 1 point to the player's score
        scoreData.AddPlayerScore("player");
        // Update the TMP_Text object with the new player's score
        playerScore.text = "You: " + scoreData.GetPlayerScore("player").ToString();
        // Generate random scores for the fake players
        int jaceRandomScore = Random.Range(0, 21);
        int sophieRandomScore = Random.Range(0, 21);
        int laurieRandomScore = Random.Range(0, 21);
        int marianneRandomScore = Random.Range(0, 21);
        // Update the ScriptableObject scores for the fake players
        scoreData.AddPlayerScore("jace", jaceRandomScore);
        scoreData.AddPlayerScore("sophie", sophieRandomScore);
        scoreData.AddPlayerScore("laurie", laurieRandomScore);
        scoreData.AddPlayerScore("marianne", marianneRandomScore);
        // Update the TMP_Text objects with the new scores
        jaceScore.text = "Jace: " + scoreData.GetPlayerScore("jace").ToString();
        sophieScore.text = "Sofia: " + scoreData.GetPlayerScore("sophie").ToString();
        laurieScore.text = "Laurie: " + scoreData.GetPlayerScore("laurie").ToString();
        marianneScore.text = "Marianne: " + scoreData.GetPlayerScore("marianne").ToString();
        // Play audio based on the cleanedPixelCount
        if (shoeCleaner.CleanedPixelCount >= 550000)
        {
            malePerfect.Play();
        }
        else if (shoeCleaner.CleanedPixelCount >= 400000 && shoeCleaner.CleanedPixelCount < 550000)
        {
            malePerfect.Play();
        }
        else if (shoeCleaner.CleanedPixelCount >= 270000 && shoeCleaner.CleanedPixelCount < 400000)
        {
            maleGreat.Play();
        }
        else if (shoeCleaner.CleanedPixelCount >= 100000 && shoeCleaner.CleanedPixelCount < 270000)
        {
            maleBad.Play();
        }
        else if (shoeCleaner.CleanedPixelCount <= 100000)
        {
            maleTerrible.Play();
        }
        scoreBoard.gameObject.SetActive(true);
    }
    /// <summary>
    /// displays player score from scriptable object which may or may not be neccesarry.
    /// </summary>
    void Start()
    {
        playerScore.text = "You: " + scoreData.GetPlayerScore("player").ToString();
    }
}