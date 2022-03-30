using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    [SerializeField] private List<GameObject> _collectibles;

    [SerializeField] private GameObject _wall;

    private int val = 0;

    void Update()
    {
        checkForObjects();
    }

    void checkForObjects()
    {

        foreach(GameObject collectible in _collectibles)
        {
            if(collectible.activeInHierarchy == false)
            {
                val += 1;
            }

            if(val >= _collectibles.Count)
            {
                Destroy(_wall);
            }
        }
    }
}
