using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    public GameObject _wall;

    public void DestroyWall()
    {
        Destroy(_wall);
        Destroy(this.gameObject);
    }
}
