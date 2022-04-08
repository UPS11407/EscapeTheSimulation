using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : EnemyBase
{
    public GameObject summonEnemyType;
    public float summonRate;
    public float maxSummons;

    public Transform _parent;
    
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
        if (canSummon() && _parent.childCount < maxSummons && PlayerActive())
        {
            var newEnemy = Instantiate(summonEnemyType, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation, _parent);
            newEnemy.transform.localScale = new Vector3(2f, 2f, 2f);        
        }
    }

    private void Update()
    {
        EnemyUpdate();
        Summon();

        if (GetAlertStatus())
        {
            FacePlayer();
            FleePlayer();
        }
        
    }
}
