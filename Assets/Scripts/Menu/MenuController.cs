using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject _activeMenu;
    public AudioSource _backgroundAudio;

    public List<KeyCode> _increaseHoris;
    public List<KeyCode> _decreaseHoris;
    public List<KeyCode> _confirmButtons;

    private MenuDefinition _activeMenuDefinition;
    private int _activeButton = 0;

    public void Start()
    {
        //Update active menu definition at start
        UpdateActiveMenuDefinition();

    }

    public void Update()
    {
        MenuInput(_increaseHoris, _decreaseHoris);
    }

    private void MenuInput(List<KeyCode> increase, List<KeyCode> decrease)
    {
        int newActive = _activeButton;

        for(int i = 0; i < increase.Count; i++)
        {
            if (Input.GetKeyDown(increase[i]))
            {
                newActive = SwitchCurrentButton(1);
            }
        }

        for (int i = 0; i < decrease.Count; i++)
        {
            if (Input.GetKeyDown(decrease[i]))
            {
                newActive = SwitchCurrentButton(-1);
            }
        }

        for (int i = 0; i < _confirmButtons.Count; i++)
        {
            if (Input.GetKeyDown(_confirmButtons[i]))
            {
                ClickCurrentButton();
            }
        }

        _activeButton = newActive;
    }

    private int SwitchCurrentButton(int increment)
    {
        if (!_activeMenuDefinition.GetButtonDefinitions()[_activeButton].GetDisableControls())
        {
            int newActive = Utility.WrapAround(_activeMenuDefinition.GetButtonCount(), _activeButton, increment);

            _activeMenuDefinition.GetButtonDefinitions()[_activeButton].SwappedOff();
            _activeMenuDefinition.GetButtonDefinitions()[newActive].Swappedto();

            return newActive;

        }


        return _activeButton;

    }

    private void ClickCurrentButton()
    {
        if (!_activeMenuDefinition.GetButtonDefinitions()[_activeButton].GetDisableControls())
        {
            _activeMenuDefinition.GetButtonDefinitions()[_activeButton].Clickbutton();
        }
    }

    public void UpdateActiveMenuDefinition()
    {
        _activeMenuDefinition = _activeMenu.GetComponent<MenuDefinition>();

        if (_activeMenuDefinition._menuMusic != null )
        {
            _backgroundAudio.clip = _activeMenuDefinition._menuMusic;
            _backgroundAudio.Play();

        }
        else if (!_activeMenuDefinition._continuePervMusic)
        {
            _backgroundAudio.Stop();
        }
    }

    public void SetActiveMenu(GameObject activeMenu)
    {
        //set active menu
        _activeMenu = activeMenu;

        //Make sure to update definition
        UpdateActiveMenuDefinition();

    }
}
