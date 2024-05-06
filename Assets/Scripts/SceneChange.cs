/*****************************************************************************
// File Name : SceneChange.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
// Brief Description : handles Scene changes
*****************************************************************************/
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [SerializeField] private TMP_Text resetConfirm;
    [SerializeField] private ScoreData scoreData;
    /// <summary>
    /// loads scene in NextScene field
    /// </summary>
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    /// <summary>
    /// loads the menu screen only
    /// </summary>
    public void LoadMenuScreen()
    {
        SceneManager.LoadScene("MenuScreen");
    }
    /// <summary>
    /// this is everywhere and i literally dont remember what it does...
    /// </summary>
    public void ResetConfirmText()
    {
        resetConfirm.gameObject.SetActive(true);
    }
    /// <summary>
    /// calls to reset the scores
    /// </summary>
    public void ResetScores() 
    {
        scoreData.ResetScores();
    }
}
