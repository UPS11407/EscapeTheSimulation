using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : EnemyBase
{
    
    // Update is called once per frame
    void Update()
    {
        EnemyUpdate();
        if (GetAlertStatus())
        {
            rotateToDirection(GetPlayer().transform.position);
            if (IsAtRange())
            {
                StopMovement();
                if (CanShoot())
                {
                    Shoot();
                }
            }
            else
            {
                ChargePlayer();
            }
        }
    }
}
