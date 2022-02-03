using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1ButtonCombo : MonoBehaviour
{
    //[SerializeField] private GameObject _button1;

    //[SerializeField] private GameObject _button2;

    //[SerializeField] private GameObject _button3;

    //[SerializeField] private GameObject _button4;

    [SerializeField] private GameObject _finishButton;

    private bool _isclick1;

    private bool _isclick2;

    private bool _isclick3;

    private bool _isclick4;

    private void Update()
    {
        if (_isclick4)
        {
            _finishButton.GetComponent<Puzzle>()._isSolved = true;
        }
    }

    public void setButton(int button)
    {
        if (button == 1)
        {
            _isclick1 = true;
        }
        else if (button == 2 && _isclick1)
        {
            _isclick2 = true;
        }
        else if (button == 3 && _isclick2)
        {
            _isclick3 = true;
        }
        else if (button == 4 && _isclick3)
        {
            _isclick4 = true;
        }
        else
        {
            _isclick1 = false;
            _isclick2 = false;
            _isclick3 = false;
            _isclick4 = false;
        }
    }
}
