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
				if (CanShoot()){

					try
					{
						if (player.GetComponentInChildren<Pistol>().enabled)
						{
							if (!_grenade)
							{
								Shoot();
							}
							else
							{
								ShootGrenade();
							}
						}
					}

					catch
					{
						if (player.GetComponentInChildren<Shotgun>().enabled)
						{
							if (!_grenade)
							{
								Shoot();
							}
							else
							{
								ShootGrenade();
							}
						}
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
