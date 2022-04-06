using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    [SerializeField] private string _wallName;

    public bool _isSolved = false;

    public void RunPuzzle()
    {
        SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
        Time.timeScale = 0;

        EventSystem eventSystem = GameObject.Find("EventSystemL1").GetComponent<EventSystem>();
        eventSystem.enabled = false;

        GameObject.Find("Player").GetComponent<Pistol>().enabled = false;
    }

    public void SolvePuzzle()
    {
        if (_isSolved)
        {
            Time.timeScale = 1;
            GameObject.Find("Player").GetComponent<Pistol>().enabled = true;

            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(_sceneName));

            Destroy(GameObject.Find(_wallName));
        }
        _isSolved = false;
    }
}
