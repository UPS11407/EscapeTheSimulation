using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Tooltip("Speed of object (float)")]
    [SerializeField] private float _speed;

    [Tooltip("Delay between movement commands (float)")]
    [SerializeField] private float _delay;

    private Rigidbody2D _rigid;

    private float timetonext = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove())
        {
            //Debug.Log("test1");
            Move();
        }
    }

    private void Move()
    {
        Vector2 direction = new Vector2((float)Random.Range(-1f, 1f), (float)Random.Range(-1f, 1f));
        //Debug.Log(direction);

        _rigid.velocity = direction * _speed;
    }

    private bool canMove()
    {
        if(Time.realtimeSinceStartup > timetonext)
        {
            timetonext = Time.realtimeSinceStartup + _delay;
            return true;
        }
        else
        {
            return false;
        }
    }
}
