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
            FacePlayer();
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
