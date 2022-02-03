using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    [SerializeField] private string _wallName;

    public bool _isSolved = false;

    public void RunPuzzle()
    {
        SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
    }

    public void SolvePuzzle()
    {
        if (_isSolved)
        {
            //Debug.Log(_sceneName);

            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(_sceneName));

            Destroy(GameObject.Find(_wallName));
        }
        _isSolved = false;
    }
}
