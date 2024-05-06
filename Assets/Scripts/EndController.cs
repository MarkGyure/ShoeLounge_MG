/*****************************************************************************
// File Name : EndController.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : Checks the tutorial and tells the other class that it is the tutorial
*****************************************************************************/
using TMPro;
using UnityEngine;
public class EndController : MonoBehaviour
{
    [SerializeField] private TMP_Text playerText;
    [SerializeField] private TMP_Text JaceText;
    [SerializeField] private TMP_Text SofiaText;
    [SerializeField] private TMP_Text LaurrieText;
    [SerializeField] private TMP_Text MaurianneText;
    [SerializeField] private TMP_Text EndText;
    [SerializeField] private ScoreData scoreData;
    [SerializeField] private GameObject WinNote;
    /// <summary>
    /// called before first frame and sets all the text equal to the current scores of the "players" and handles the 
    /// text deciding if the player wins or not
    /// </summary>
    void Start()
    {
        playerText.text = "You: " + scoreData.playerScore;
        JaceText.text = "Jace: " + scoreData.jaceScore;
        SofiaText.text = "Sofia: " + scoreData.sophieScore;
        LaurrieText.text = "Laurrie: " + scoreData.laurieScore;
        MaurianneText.text = "Marianne: " + scoreData.marianneScore;
        if (scoreData.playerScore > scoreData.jaceScore && scoreData.playerScore > scoreData.sophieScore && 
            scoreData.playerScore > scoreData.laurieScore && scoreData.playerScore > scoreData.marianneScore)
        {
            EndText.text = "You Win!";
            WinNote.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            EndText.text = "You Lose.";
        }
    }
}