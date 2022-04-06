using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
	[Tooltip("Speed of bullet (float)")]
	[SerializeField] float speed;

	[Tooltip("Interval between each shot")]
	[SerializeField] float shootDelay;

	[Tooltip("Bullet Prefab")]
	[SerializeField] GameObject bulletPrefab;

	public Transform bulletSpawn;

	public float _buff = 0.0f;

	public float _spreadAngle;

	Vector3 mousePos;

	public GameObject player;

	GreyBoxPlayerMovement _playerMovement;
	void Start()
	{
		_playerMovement = player.GetComponent<GreyBoxPlayerMovement>();
	}

	void Update()
	{
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetMouseButtonDown(button: 0))
		{
			Vector3 bulletDir = mousePos - _playerMovement.GetPlayerPos();
			bulletDir = bulletDir.normalized;
			float angle = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
			Debug.Log(angle);

			for (int i = 0; i < 7; i++)
			{
				var bullet = Instantiate(bulletPrefab, bulletSpawn.position + bulletDir * 0.75f, Quaternion.Euler(0, 0, angle - 60));

				bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * speed;
				Destroy(bullet, 5);
				angle -= _spreadAngle;
			}
			
		}

	}

}

