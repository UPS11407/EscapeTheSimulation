using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miniboss_Lvl1 : EnemyBase
{
    
    
    
    //Normal walking speed is multiplied with this multiplier during charge and divided while firing
    public float SpeedMulitplier = 2;

    private float originalSpeed;
    private float firingSpeed;
    private float chargeSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        chargeSpeed = _movementSpeed * SpeedMulitplier;
        firingSpeed = _movementSpeed / SpeedMulitplier;
        originalSpeed = _movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        EnemyUpdate();
        if (GetAlertStatus())
        {
            rotateToDirection(GetPlayer().transform.position);
            if (IsAtRange())
            {
                _movementSpeed = chargeSpeed;
                ChargePlayer();
                
            }
            else
            {
                _movementSpeed = firingSpeed;
                if (CanShoot())
                {
                    Shoot();
                }
                ChargePlayer();
            }
        }
    }
}
