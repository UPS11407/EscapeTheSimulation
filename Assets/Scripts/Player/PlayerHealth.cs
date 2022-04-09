using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Max health value")]
    public float _health;

    private bool _dead;
    public float _maxHealth;

    [SerializeField] float _immuneTime;
    bool _isImmune = false;

    private void Start()
    {
        _maxHealth = _health;
    }

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
        if (!_isImmune)
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(Immunity());
            _health -= _damage;
        }
        
    }

    public float GetHealth()
    {
        return _health;
    }

    IEnumerator Immunity()
    {
        _isImmune = true;
        yield return new WaitForSeconds(_immuneTime);
        _isImmune = false;
    }
}
