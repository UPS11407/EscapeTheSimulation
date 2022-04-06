using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sys64 : EnemyBase
{
    [SerializeField] float dashStrength;
    

    float dashDelay;
    [SerializeField] float dashRate;

    private void Start()
    {
        GetComponent<Rigidbody2D>().drag = 5;
    }
    private void Update()
    {
        EnemyUpdate();
        if (GetAlertStatus())
        {
            FacePlayer();
            if (IsAtRange())
            {
                
                if (CanShoot() && player.GetComponent<GreyBoxShooting>().enabled)
                {
                    ShootGrenade();
                }
            }
            else
            {
                Dash();
            }
        }
    }
    
    bool CanDash()
    {
        if(dashDelay <= Time.realtimeSinceStartup)
        {
            Debug.Log("dash true");
            dashDelay = Time.realtimeSinceStartup + dashRate;
            return true;
        } 
        else
        {
            return false;
        }
    }
    public void Dash()
    {
        if (CanDash())
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.Normalize(player.transform.position - transform.position) * dashStrength, ForceMode2D.Impulse);
        }
    }
    
}
