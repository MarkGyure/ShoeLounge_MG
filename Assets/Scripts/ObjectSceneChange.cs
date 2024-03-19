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
    /*private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneName);
    }*/
}
