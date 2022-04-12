using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public float _damageVal;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject, 0.01f);
	}
}
