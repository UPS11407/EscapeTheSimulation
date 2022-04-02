using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//energy flow puzzle script
//idk where to start
public class Puzzle5 : MonoBehaviour
{
    public Sprite _active;
    public Sprite _inActive;

    private Sprite _current;

    public void ChangeImage()
    {
        _current = GetComponent<Image>().sprite;

        if(_active == _current)
        {
            GetComponent<Image>().sprite = _inActive;
        }
        else if(_inActive == _current)
        {
            GetComponent<Image>().sprite = _active;
        }
    }

    public void ResetImage()
    {
        GetComponent<Image>().sprite = _inActive;
    }
}
