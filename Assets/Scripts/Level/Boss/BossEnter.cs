using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnter : MonoBehaviour
{
    public bool inBossRoom = false;
    public GameObject healthBar;
    public GameObject bossDoor;

    private void Start()
    {
       healthBar.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !inBossRoom)
        {
            inBossRoom = true;
            healthBar.SetActive(true);
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(0.1f);
        bossDoor.GetComponent<BossDoor>().enabled = false;
        bossDoor.SetActive(true);
    }
}
