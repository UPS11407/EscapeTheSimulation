using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public GameObject _pauseMenu;

    public AudioClip _pauseSound;

    private bool _pause;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }
    bool PlayerActive()
    {
        if (_player.GetComponent<WeaponSwap>().activeWeapon == 0)
        {
            if (_player.transform.GetChild(0).GetChild(0).gameObject.activeInHierarchy)
            {
                return true;
            }
        }
        else if (_player.GetComponent<WeaponSwap>().activeWeapon == 1)
        {
            if (_player.transform.GetChild(0).GetChild(1).gameObject.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pause && PlayerActive())
        {
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _pause && PlayerActive())
        {
            UnPause();
        }
    }

    private void PauseGame()
    {
        GetComponent<AudioSource>().clip = _pauseSound;
        GetComponent<AudioSource>().volume = 0.2f;
        GetComponent<AudioSource>().Play();

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
