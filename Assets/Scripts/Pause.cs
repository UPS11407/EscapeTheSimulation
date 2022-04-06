using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public GameObject _pauseMenu;

    private bool _pause;

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
        GameObject.Find("Player").GetComponent<Pistol>().enabled = false;
        GameObject.Find("pistol").GetComponent<GunPivot>().enabled = false;

        _pause = true;

        Time.timeScale = 0f;

        _pauseMenu.SetActive(true);
    }

    public void UnPause()
    {
        _pause = false;

        _pauseMenu.SetActive(false);

        Time.timeScale = 1.0f;

        GameObject.Find("Player").GetComponent<Pistol>().enabled = true;
        GameObject.Find("pistol").GetComponent<GunPivot>().enabled = true;
    }
}
