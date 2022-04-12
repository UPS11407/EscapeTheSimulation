using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonDefinition : MonoBehaviour
{
    public bool _selected = false;
    private Button _button;

    public AudioClip _swapToSFX;
    public AudioClip _confirmSFX;
    public float _confirmTime;

    private bool _disableControls = false;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
    }

    public void Swappedto()
    {
        _selected = true;

        //if there's SFX for swapping button, play it
        if (_swapToSFX != null)
        {
            AudioSource.PlayClipAtPoint(_swapToSFX, Vector3.zero);
        }
    }

    public void SwappedOff()
    {
        _selected = false;
    }

    public void Clickbutton()
    {
        if (!_disableControls)
        {
            _disableControls = true;

            if (_confirmSFX != null)
            {
                AudioSource.PlayClipAtPoint(_confirmSFX, Vector3.zero);
            }

            _button.onClick.Invoke();

            _disableControls = false;
        }
    }

    public bool GetDisableControls()
    {
        return _disableControls;
    }
}
