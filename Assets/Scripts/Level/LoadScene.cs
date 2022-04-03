using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void loadNewScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadSceneAsync(string _sceneName)
    {
        SceneManager.LoadSceneAsync(_sceneName);
    }
}
