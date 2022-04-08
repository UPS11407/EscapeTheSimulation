using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public int _damageVal;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//Debug.Log(_damageVal);

		Destroy(gameObject, 0.01f);
	}
}
