using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	Transform _camera;
	public Transform player;

	private void Start()
	{
		_camera = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
    {
        _camera.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
