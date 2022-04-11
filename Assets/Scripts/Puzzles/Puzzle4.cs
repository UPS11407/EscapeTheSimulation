using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//I only made this file to motivate myself to actually make something...
public class Puzzle4 : MonoBehaviour
{
    public GameObject _wall;

    public Sprite _pushed;
    public Sprite _unPushed;

    public int[] _layers;

    private bool _barrel;

    private void ChangeSprite(Sprite _sprite)
    {
        GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _layers[0])
        {
            _wall.SetActive(false);
            _barrel = true;
            ChangeSprite(_pushed);
        }

        if(collision.gameObject.layer == _layers[1])
        {
            _wall.SetActive(false);
            ChangeSprite(_pushed);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layers[0])
        {
            _wall.SetActive(false);
            _barrel = true;
            ChangeSprite(_pushed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layers[0])
        {
            _wall.SetActive(true);
            _barrel = false;
            ChangeSprite(_unPushed);
        }

        if (collision.gameObject.layer == _layers[1] && !_barrel)
        {
            _wall.SetActive(true);
            ChangeSprite(_unPushed);
        }
    }
}
