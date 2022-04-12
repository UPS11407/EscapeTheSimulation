using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTeleport : MonoBehaviour
{
    public Transform _point;

    private bool _touching = false;

    public GameObject _lastLevel;
    public GameObject _active;
    public AudioSource _levelOneAudio;
    public AudioSource _levelTwoAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 0)
        {
            _touching = true;
            //Debug.Log(_touching);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 0)
        {
            _touching = false;
            //Debug.Log(_touching);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _touching)
        {
            Teleport(GameObject.Find("Player"), _point);
            _levelOneAudio.Stop();
            _levelTwoAudio.Play();
        }
    }

    public void Teleport(GameObject _obj, Transform _location)
    {
        //Debug.Log("teleport?");
        _obj.transform.position = _location.position;
    }
}
