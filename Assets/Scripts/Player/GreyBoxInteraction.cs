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
            _button = other.gameObject;
            isButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            _button = null;
            isButton = false;
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            _isnotloaded = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && isButton && !_isnotloaded)
        {
            if(_button.TryGetComponent(out Puzzle puzzleComp) != true)
            {
                if(_button.TryGetComponent(out Puzzle3 puzzle3Comp) != true)
                {
                    if(_button.TryGetComponent(out TutorialButton TutButton) == true)
                    {
                        _button.GetComponent<TutorialButton>().DestroyWall();
                    }
                }
                else
                {
                    var puzzle3 = _button.GetComponent<Puzzle3>();
                    puzzle3.setButton(puzzle3.val);
                    puzzle3.checkButtons();
                }
            }
            else
            {
                var puzzle = _button.GetComponent<Puzzle>();
                puzzle.RunPuzzle();
                _isnotloaded = false;
            }

            if(_button.TryGetComponent(out ButtonTeleport _teleport) != true)
            {
                Destroy(_button);
            }
        }
    }
}
