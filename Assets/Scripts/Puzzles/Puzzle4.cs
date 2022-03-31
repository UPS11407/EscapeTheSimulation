using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//I only made this file to motivate myself to actually make something...
public class Puzzle4 : MonoBehaviour
{
    public GameObject _wall;

    public int[] _layers;

    private bool _open;
    private bool _barrel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _layers[0])
        {
            _wall.SetActive(false);
            _open = true;
            _barrel = true;
        }

        if(collision.gameObject.layer == _layers[1])
        {
            _wall.SetActive(false);
            _open = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layers[0])
        {
            _wall.SetActive(false);
            _barrel = true;
            _open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layers[0])
        {
            _wall.SetActive(true);
            _barrel = false;
            _open = false;
        }

        if (collision.gameObject.layer == _layers[1] && !_barrel)
        {
            _wall.SetActive(true);
            _open = false;
        }
    }
}
