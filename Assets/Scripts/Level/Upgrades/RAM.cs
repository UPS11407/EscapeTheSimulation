using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM : MonoBehaviour
{
    [SerializeField] float speedIncrease;
    //bool canUse = false;
    //GameObject player;

    private void Start()
    {
        //player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 0)
        {
            collision.gameObject.GetComponent<GreyBoxPlayerMovement>()._speed += speedIncrease;
            Destroy(gameObject);
        }
    }
}
