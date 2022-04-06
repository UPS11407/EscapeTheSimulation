using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DmgUp : MonoBehaviour
{
    [SerializeField] private float _buff;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 0)
        {
            collision.gameObject.GetComponent<Pistol>()._buff += _buff;
            Destroy(gameObject);
        }
    }
}
