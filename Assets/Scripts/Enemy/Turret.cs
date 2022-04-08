using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : EnemyBase
{
    void Update()
    {
        EnemyUpdate();
        if (GetAlertStatus())
        {
            rotateToDirection(GetPlayer().transform.position);
            if (CanShoot() && PlayerActive())
            {
                Shoot();
            }
        }
    }
}
