using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int _health;

    void Update()
    {
		if (_health <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Bullet"))
		{
			Destroy(collision.gameObject);
			takeDamage(1);
		}
	}

	public void takeDamage(int damage)
	{

		_health -= damage;

	}
}
