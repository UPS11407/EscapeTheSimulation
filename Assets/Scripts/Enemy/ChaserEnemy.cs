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
            ChargePlayer();
        }
    }
}
