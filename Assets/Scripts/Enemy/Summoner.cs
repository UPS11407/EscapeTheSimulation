using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : EnemyBase
{
    public GameObject summonEnemyType;
    public float summonRate;
    public float maxSummons;
    
    float summonDelay = 0;
    public bool canSummon()
    {
        if (summonEnemyType != null)
        {
            if (summonDelay < Time.realtimeSinceStartup)
            {
                summonDelay = Time.realtimeSinceStartup + summonRate;
                return true;
            }
            else
            {
                return false;
            }
        } else
        {
            return false;
        }
    }

    private void Summon()
    {
        if (canSummon() && transform.childCount < maxSummons)
        {
            Instantiate(summonEnemyType, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z), transform.rotation, transform);

            
        }
    }

    private void Update()
    {
        EnemyUpdate();
        Summon();

        if (GetAlertStatus())
        {
            FleePlayer();
        }
        
    }
}
