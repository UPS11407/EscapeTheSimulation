using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthUp : MonoBehaviour
{
    [SerializeField] private float _healthUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 0)
        {
            collision.gameObject.GetComponent<PlayerHealth>()._health += _healthUp;
            Destroy(gameObject);
        }
    }
}
