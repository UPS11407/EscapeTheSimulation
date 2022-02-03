using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreyBoxPlayerMovement : MonoBehaviour
{
    [Tooltip("Speed of player movement (float)")]
    [SerializeField] private float _speed;

    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 movementDir = new Vector2(0f, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            movementDir += new Vector2(0f, 1f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementDir += new Vector2(0f, -1f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementDir += new Vector2(-1f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementDir += new Vector2(1f, 0f);
        }

        _rigid.velocity = movementDir * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Powerup")
        {
            Destroy(collision.gameObject);
        }
    }
    
	public Vector3 GetPlayerPos()
	{
		return _rigid.position;
	}

}
