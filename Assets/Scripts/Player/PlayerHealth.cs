using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Max health value")]
    public float _health;

    private bool _dead;

    void Update()
    {
        CheckIfDead();

        if (_dead)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void CheckIfDead()
    {
        if(_health <= 0)
        {
            _dead = true;
        }
    }

    public void TakeDamage(float _damage)
    {
        _health -= _damage;
    }
}
