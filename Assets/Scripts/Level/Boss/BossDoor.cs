using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    [SerializeField] private GameObject _collection;

    [SerializeField] private GameObject _wall;

    private bool _open = false;
    private int _val;

    void Update()
    {
        if (!_open)
        {
            checkForObjects();
        }
    }

    void checkForObjects()
    {
        _val = 0;
        for(int i = 0; i< _collection.transform.childCount; i++)
        {
            if(!_collection.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                _val++;
                //Debug.Log(_val);
            }
        }

        if(_val == _collection.transform.childCount)
        {
            _wall.SetActive(false);
            _open = true;
        }
    }
}
