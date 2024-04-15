/*****************************************************************************
// File Name : ScoreData.cs
// Author : Mark Gyure
// Creation Date : 4/14/2024
//
// Brief Description : handles the score as a scriptable object for the player AND non players
*****************************************************************************/
using UnityEngine;
[CreateAssetMenu(fileName = "ScoreData", menuName = "Score Data", order = 1)]
public class ScoreData : ScriptableObject
{
    public int playerScore = 0;
    public int sophieScore = 0;
    public int jaceScore = 0;
    public int laurieScore = 0;
    public int marianneScore = 0;
    /// <summary>
    /// Sets all scores to 0
    /// </summary>
    public void ResetScores()
    {
        playerScore = 0;
        sophieScore = 0;
        jaceScore = 0;
        laurieScore = 0;
        marianneScore = 0;
    }
    /// <summary>
    /// manually add to players scores
    /// </summary>
    /// <param name="playerName"></param>
    /// <param name="scoreValue"></param>
    public void AddPlayerScore(string playerName, int scoreValue = 1)
    {
        switch (playerName.ToLower())
        {
            case "player":
                playerScore += scoreValue;
                break;
            case "sophie":
                sophieScore += scoreValue;
                break;
            case "jace":
                jaceScore += scoreValue;
                break;
            case "laurie":
                laurieScore += scoreValue;
                break;
            case "marianne":
                marianneScore += scoreValue;
                break;
            default:
                Debug.LogWarning("Invalid player name.");
                break;
        }
    }
    /// <summary>
    /// have access to the player scores
    /// </summary>
    /// <param name="playerName"></param>
    /// <returns></returns>
    public int GetPlayerScore(string playerName)
    {
        switch (playerName.ToLower())
        {
            case "player":
                return playerScore;
            case "sophie":
                return sophieScore;
            case "jace":
                return jaceScore;
            case "laurie":
                return laurieScore;
            case "marianne":
                return marianneScore;
            default:
                Debug.LogWarning("Invalid player name.");
                return 0;
        }
    }
}
