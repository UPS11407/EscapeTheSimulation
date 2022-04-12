using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MenuType
{
    Horizontal,
    Vertical,
}
public class MenuDefinition : MonoBehaviour
{
    public MenuType _menuType = MenuType.Horizontal;
    public AudioClip _menuMusic;
    public bool _continuePervMusic = false;
    public List<GameObject> _menuButtonObject = new List<GameObject>();

    private List<ButtonDefinition> _menuButtonDefinitions = new List<ButtonDefinition>();
    private List<Button> _menuButtons = new List<Button>();
    private List<Animator> _menuAnimator = new List<Animator>();    

    public void Start()
    {
        //Searchges and grabs components
        for (int i = 0; i < _menuButtonObject.Count; i++)
        {
            _menuButtonDefinitions.Add(_menuButtonObject[i].GetComponent<ButtonDefinition>());
            _menuButtons.Add(_menuButtonObject[i].GetComponent<Button>());
        }
    }

    public MenuType GetMenuType()
    {

        return _menuType;
    }

    public int GetButtonCount()
    {
        return _menuButtonObject.Count;
    }

    public List<ButtonDefinition> GetButtonDefinitions()
    {
        return _menuButtonDefinitions;  
    }

    public List<Button> GetButtons()
    {
        return _menuButtons;
    }

    
}
