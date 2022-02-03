using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreyBoxInteraction : MonoBehaviour
{
    private bool isButton;

    public bool _isnotloaded = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            isButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            isButton = false;
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "Puzzle1")
        {
            _isnotloaded = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && isButton && _isnotloaded)
        {
            var puzzle = GameObject.Find("Button").gameObject.GetComponent<Puzzle>();
            puzzle.RunPuzzle();
            _isnotloaded = false;
        }
    }
}
