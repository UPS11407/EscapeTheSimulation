using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 0)
        {
            collision.gameObject.GetComponent<PlayerHealth>()._health = collision.gameObject.GetComponent<PlayerHealth>()._maxHealth;
            Destroy(gameObject);
        }
    }
}
