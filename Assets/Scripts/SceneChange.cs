/*****************************************************************************
// File Name : SceneChange.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : handles Scene changes
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string NextScene;
    /// <summary>
    /// loads scene in NextScene field
    /// </summary>
    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
