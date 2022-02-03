using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    [SerializeField] private GameObject _wall;

    public bool _isSolved = false;

    private string _scene;

    private void Start()
    {
        
    }

    private void Awake()
    {
        if (_scene == null)
        {
            _scene = _sceneName;
        }
    }


    public void RunPuzzle()
    {
        SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneName));
    }

    public void SolvePuzzle()
    {
        if (_isSolved)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Greybox"));

            Debug.Log(_scene);

            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Puzzle1"));


            Destroy(GameObject.Find("Puzzle1wall"));
        }

        _isSolved = false;
    }
}
