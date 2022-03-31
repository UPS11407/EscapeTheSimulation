using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAM : MonoBehaviour
{
    [SerializeField] float speedIncrease;
    bool canUse = false;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canUse = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canUse = false;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && canUse == true) {

            player.GetComponent<GreyBoxPlayerMovement>()._speed += speedIncrease;
            Destroy(this.gameObject);
        }
    }

}
