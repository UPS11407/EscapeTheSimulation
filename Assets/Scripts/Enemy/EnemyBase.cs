using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    Rigidbody2D _rigibody;
    public float _maxHP = 1.0f;
    internal float _currentHP;

    //The player object
    public GameObject player;

    //enemy speed
    public float _movementSpeed;

    //Damage value
    public float _damageValue;

    //Has the player aggroed this enemy?
    public bool alertStatus = false;
    public float alertRange;

    [Tooltip("Only fill if ranged")]//bullet prefab
    public GameObject bulletPrefab;

    [Tooltip("Only fill if ranged")]//bullet speed
    public float bulletSpeed;

    [Tooltip("Only fill if ranged")]//rate of fire
    public float rateOfFire;
    float shotDelay = 0;

    //Max range before enemy starts moving
    public float maxRange;


    // Start is called before the first frame update
    void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        //give enemy max HP on spawn
        _currentHP = _maxHP;

        
    }

    public void EnemyUpdate()
    {
        alertEnemy();
        CheckIfDead();
    }

    //destroy enemy if dead
    public virtual void CheckIfDead()
    {
        if (_currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool IsAtRange()
    {
        if (GetPlayerDistance() < maxRange)
        {
            //Debug.Log("TRUE");
            return true;
        }
        else 
        {
            return false;
        }
    }

    ///<summary> Direction from enemy to player (not normalized) </summary>
    public Vector2 GetPlayerDirection()
    {
        return player.transform.position - transform.position;
    }

    ///<summary> distance from enemy to player </summary>
    public float GetPlayerDistance()
    {
        return GetPlayerDirection().magnitude;
    }

    ///<summary> rotate enemy to point </summary>
    public void rotateToDirection(Vector2 point)
    {
        gameObject.transform.right = player.transform.position - gameObject.transform.position;
    }

    ///<summary> Moves towards player </summary>
    public void ChargePlayer()
    {
        _rigibody.velocity = GetPlayerDirection().normalized * _movementSpeed;
    }

    //Reduce velocity to 0
    public void StopMovement()
    {
        _rigibody.velocity = Vector3.zero;
        _rigibody.angularVelocity = 0;
    }

    ///<summary> Moves away from player </summary>
    public void FleePlayer()
    {
        _rigibody.velocity = -GetPlayerDirection().normalized * _movementSpeed;
    }

    ///<summary> Sets alert status to true if the player is within range </summary>
    public void alertEnemy()
    {
        if (GetPlayerDistance() < alertRange)
        {
            alertStatus = true;
        }
    }

    //returns the alert status
    public bool GetAlertStatus()
    {
        return alertStatus;
    }
    public GameObject GetPlayer()
    {
        return player;
    }
    
    public bool CanShoot()
    {
        if (bulletPrefab != null)
        {
            if (shotDelay < Time.realtimeSinceStartup)
            {
                shotDelay = Time.realtimeSinceStartup + rateOfFire;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void Shoot()
    {
        //Debug.Log(transform.rotation);

        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0,0,90));
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        Destroy(bullet, 5);

    }

    public void TakeDamage(int _damage)
    {
        _currentHP -= _damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            TakeDamage(1);
        }
    }
}
