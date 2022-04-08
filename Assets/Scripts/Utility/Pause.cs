using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public GameObject _pauseMenu;

    private bool _pause;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pause)
        {
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _pause)
        {
            UnPause();
        }
    }

    private void PauseGame()
    {
        if (_player.GetComponent<WeaponSwap>().activeWeapon == 0)
        {
            _player.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        else if (_player.GetComponent<WeaponSwap>().activeWeapon == 1)
        {
            _player.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }

        _pause = true;

        Time.timeScale = 0f;

        _pauseMenu.SetActive(true);
    }

    public void UnPause()
    {
        _pause = false;

        _pauseMenu.SetActive(false);

        Time.timeScale = 1.0f;

        if (_player.GetComponent<WeaponSwap>().activeWeapon == 0)
        {
            _player.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        else if (_player.GetComponent<WeaponSwap>().activeWeapon == 1)
        {
            _player.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }
    }
}
