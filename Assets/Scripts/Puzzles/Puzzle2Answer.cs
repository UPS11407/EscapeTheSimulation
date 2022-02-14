using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2Answer : MonoBehaviour
{
    [SerializeField] private Text _input;

    [SerializeField] private Image _image;

    public void OnClickButton()
    {
        if(_input.text == "34")
        {
            GetComponent<Puzzle>()._isSolved = true;
            GetComponent<Puzzle>().SolvePuzzle();
        }
        else
        {
            _image.color = Color.red;
        }
    }
}
