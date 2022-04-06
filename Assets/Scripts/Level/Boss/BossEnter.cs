using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnter : MonoBehaviour
{
    public bool inBossRoom = false;
    public GameObject healthBar;
    private void Start()
    {
       healthBar.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            inBossRoom = true;
            healthBar.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Destroy(this.gameObject);

            if (healthBar == null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
