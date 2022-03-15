using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : EnemyBase
{
    public GameObject summonEnemyType;
    public float summonRate;
    public float maxSummons;

    public GameObject parentGameObject;

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
    public override void CheckIfDead()
    {
        if (_currentHP <= 0)
        {
            Destroy(gameObject);
            if (parentGameObject != null)
            {
                Destroy(parentGameObject);
            }
        }
        
        
    }
    private void Summon()
    {
        if (canSummon() && parentGameObject.transform.childCount < maxSummons)
        {
            Instantiate(summonEnemyType, parentGameObject.transform.position, parentGameObject.transform.rotation, parentGameObject.transform);

            
        }
    }

    private void Update()
    {
        EnemyUpdate();
        if (GetAlertStatus())
        {
            Summon();
            rotateToDirection(GetPlayer().transform.position);
            if (CanShoot())
            {
                Shoot();
            }
        }
        
    }
}
