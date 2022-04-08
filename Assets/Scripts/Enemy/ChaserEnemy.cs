using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : EnemyBase
{
    private void Update()
    {
        EnemyUpdate();

        if (GetAlertStatus())
        {
            //rotates to face the player
            rotateToDirection(GetPlayer().transform.position);
            transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);
            ChargePlayer();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 8)
        {
            Debug.Log(collision.gameObject.GetComponent<PlayerBullet>()._damageVal);
            TakeDamage(collision.gameObject.GetComponent<PlayerBullet>()._damageVal);
        }
    }
}
