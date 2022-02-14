using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    [SerializeField] private GameObject _controller;

    private bool _button1;
    private bool _button2;
    private bool _button3;

    private bool _isActive = true;

    public int val;

    [SerializeField] private GameObject _wall;


    public void setButton(int button)
    {
        var puzzleComp = _controller.GetComponent<Puzzle3>();
        if (button == 1){
            puzzleComp._button1 = true;
        }
        if(button == 2)
        {
            puzzleComp._button2 = true;
        }
        if (button == 3)
        {
            puzzleComp._button3 = true;
        }
    }

    public void checkButtons()
    {
        var puzzleComp = _controller.GetComponent<Puzzle3>();
        puzzleComp.SolvePuzzle();
        Destroy(this.gameObject);
    }

    public void SolvePuzzle()
    {
        if (_button1 && _button2 && _button3 && _isActive)
        {
            Destroy(_wall);
            _isActive = false;
        }
    }
}