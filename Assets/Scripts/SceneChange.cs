using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string NextScene;
    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
