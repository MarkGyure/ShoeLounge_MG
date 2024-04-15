/*****************************************************************************
// File Name : ObjectSceneChange.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : changes scene from the load button
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObjectSceneChange : MonoBehaviour
{
    /// <summary>
    /// goes to the next scene on the build index
    /// </summary>
    private void OnMouseUp()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
