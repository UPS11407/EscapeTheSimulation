using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//energy flow puzzle script
//idk where to start
public class Puzzle5 : MonoBehaviour
{
    public string _door;

    private Image _image;

    public Image[] _red;
    public Image[] _blue;
    public Image[] _green;
    public Image[] _yellow;

    private bool _redCheck = false;
    private bool _blueCheck = false;
    private bool _greenCheck = false;
    private bool _yellowCheck = false;

    private int _redVal;
    private int _blueVal;
    private int _greenVal;
    private int _yellowVal;

    private GameObject _player;

    private void Start()
    {
        _image = GetComponent<Image>();
        _player = GameObject.Find("Player");
    }

    private void SolvePuzzle()
    {
        EventSystem eventSystem = GameObject.Find("EventSystemL1").GetComponent<EventSystem>();
        eventSystem.enabled = true;
        Time.timeScale = 1.0f;

        if (_player.GetComponent<WeaponSwap>().activeWeapon == 0)
        {
            _player.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        else if (_player.GetComponent<WeaponSwap>().activeWeapon == 1)
        {
            _player.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }

        Destroy(GameObject.Find(_door));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Puzzle5"));
    }

    public void CycleColor()
    {
        Color _current = _image.color;

        if(_current == Color.red)
        {
            _image.color = Color.blue;
        }
        else if(_current == Color.blue)
        {
            _image.color = Color.green;
        }
        else if(_current == Color.green)
        {
            _image.color = Color.yellow;
        }
        else
        {
            _image.color = Color.red;
        }
    }

    public void checkButtons()
    {
        _redVal = 0;
        _blueVal = 0;
        _greenVal = 0;
        _yellowVal = 0;

        RedCheck();
        BlueCheck();
        GreenCheck();
        YellowCheck();

        if(_redCheck && _blueCheck && _greenCheck && _yellowCheck)
        {
            SolvePuzzle();
        }
    }

    private void RedCheck()
    {
        foreach (Image Img in _red)
        {
            if (Img.color == Color.red)
            {
                _redVal++;
            }
        }

        if (_redVal == 7)
        {
            _redCheck = true;
        }
    }

    private void BlueCheck()
    {
        foreach (Image Img in _blue)
        {
            if (Img.color == Color.blue)
            {
                _blueVal++;
            }
        }

        if (_blueVal == 7)
        {
            _blueCheck = true;
        }
    }

    private void GreenCheck()
    {
        foreach (Image Img in _green)
        {
            if (Img.color == Color.green)
            {
                _greenVal++;
            }
        }

        if (_greenVal == 7)
        {
            _greenCheck = true;
        }
    }

    private void YellowCheck()
    {
        foreach (Image Img in _yellow)
        {
            if (Img.color == Color.yellow)
            {
                _yellowVal++;
            }
        }

        if (_yellowVal == 7)
        {
            _yellowCheck = true;
        }
    }
}
