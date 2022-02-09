using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreyBoxInteraction : MonoBehaviour
{
    private bool isButton;

    public bool _isnotloaded = true;

    GameObject _button;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log(other.gameObject.name);
            _button = other.gameObject;
            isButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            _button = this.gameObject;
            isButton = false;
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Greybox")
        {
            _isnotloaded = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && isButton && !_isnotloaded)
        {
            var puzzle = _button.GetComponent<Puzzle>();
            puzzle.RunPuzzle();
            _isnotloaded = false;
        }
    }
}
