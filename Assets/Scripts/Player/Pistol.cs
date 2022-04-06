using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
	[Tooltip("Speed of bullet (float)")]
	[SerializeField] float speed;

	[Tooltip("Interval between each shot")]
	[SerializeField] float shootDelay;

	[Tooltip("Bullet Prefab")]
	[SerializeField] GameObject bulletPrefab;

	public Transform bulletSpawn;

	public float _buff = 0.0f;

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
			var bullet = Instantiate(bulletPrefab, bulletSpawn.position + bulletDir * 0.75f, Quaternion.Euler(0, 0, 0));
			float angle = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg;
			bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector2 (bulletDir.x, bulletDir.y).normalized * speed;

			Destroy(bullet, 5);
		}

	}

}
