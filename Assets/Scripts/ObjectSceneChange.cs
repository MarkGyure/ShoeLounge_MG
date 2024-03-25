/*****************************************************************************
// File Name : ObjectSceneChange.cs
// Author : Mark Gyure
// Creation Date : 3/24/2024
//
// Brief Description : changes scene from the load button
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObjectSceneChange : MonoBehaviour
{
    public string SceneName;
    private void OnMouseUp()
    {
        SceneManager.LoadScene(SceneName);
    }
}
