using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : EnemyBase
{
	public bool _grenade;

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
				if (CanShoot() && PlayerActive()){
					if (!_grenade)
					{
						Shoot();
					}
					else
					{
						ShootGrenade();
					}
				}
			else
				{
					ChargePlayer();
				}
			}
		}
	}
}
