using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string _sceneName;

    public void loadNewScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadSceneAsync()
    {
        SceneManager.LoadSceneAsync(_sceneName);
    }
}
