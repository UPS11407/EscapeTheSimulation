using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public bool _isSolved = false;

    public void RunPuzzle()
    {
        SceneManager.LoadScene(_sceneName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneName));
    }
}
