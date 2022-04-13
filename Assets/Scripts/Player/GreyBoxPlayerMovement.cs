using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreyBoxPlayerMovement : MonoBehaviour
{
    [Tooltip("Speed of player movement (float)")]
    public float _speed;

    private Rigidbody2D _rigid;
	public GameObject player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 movementDir = new Vector2(0f, 0f);
		byte inputs = 0;

        if (Input.GetKey(KeyCode.W))
        {
            movementDir += new Vector2(0f, 1f);
			inputs++;
            anim.SetBool("walkingUp", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("walkingDown", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementDir += new Vector2(0f, -1f);
			inputs++;
            anim.SetBool("walkingUp", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("walkingDown", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementDir += new Vector2(-1f, 0f);
			inputs++;
			player.transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("walkingUp", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("walkingDown", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementDir += new Vector2(1f, 0f);
			inputs++;
			player.transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("walkingUp", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("walkingDown", false);
        }

		if (inputs == 2)
		{
			_rigid.velocity = (movementDir * _speed)/1.5f;
            if (!GameObject.Find("Walking").GetComponent<AudioSource>().isPlaying)
            {
                GameObject.Find("Walking").GetComponent<AudioSource>().Play();
            }
        }
		else if(inputs == 1)
		{
			_rigid.velocity = movementDir * _speed;
            if (!GameObject.Find("Walking").GetComponent<AudioSource>().isPlaying)
            {
                GameObject.Find("Walking").GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            _rigid.velocity = movementDir * _speed;
            GameObject.Find("Walking").GetComponent<AudioSource>().Stop();
            anim.SetBool("walkingUp", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("walkingDown", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Powerup")
        {
            collision.gameObject.SetActive(false);
        }
    }
    
	public Vector3 GetPlayerPos()
	{
		return _rigid.position;
	}

}
