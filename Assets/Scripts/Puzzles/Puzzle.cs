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

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    public void RunPuzzle()
    {
        SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
        Time.timeScale = 0;

        EventSystem eventSystem = GameObject.Find("EventSystemL1").GetComponent<EventSystem>();
        eventSystem.enabled = false;

        if (_player.GetComponent<WeaponSwap>().activeWeapon == 0)
        {
            _player.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        else if (_player.GetComponent<WeaponSwap>().activeWeapon == 1)
        {
            _player.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
    }

    public void SolvePuzzle()
    {
        if (_isSolved)
        {
            Time.timeScale = 1;
            if (_player.GetComponent<WeaponSwap>().activeWeapon == 0)
            {
                _player.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            }
            else if (_player.GetComponent<WeaponSwap>().activeWeapon == 1)
            {
                _player.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            }

			SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(_sceneName));

            Destroy(GameObject.Find(_wallName));
        }

        EventSystem eventSystem = GameObject.Find("EventSystemL1").GetComponent<EventSystem>();
        eventSystem.enabled = true;

        _isSolved = false;
    }
}
