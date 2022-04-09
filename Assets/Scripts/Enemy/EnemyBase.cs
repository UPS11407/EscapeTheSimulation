using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D))]
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

    [Tooltip("Only fill if grenade is used")] //grenade force strength
    public float _grenadeStrength = 1.0f;

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
            GameObject.Find("EnemyDeath").GetComponent<DeathSound>().PlaySound();
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

    public void FacePlayer()
    {
        if(player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    ///<summary> Moves towards player </summary>
    public void ChargePlayer()
    {
        _rigibody.velocity = GetPlayerDirection().normalized * _movementSpeed;
    }

    public bool PlayerActive()
    {
        if (player.GetComponent<WeaponSwap>().activeWeapon == 0)
        {
            if (player.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Pistol>().enabled)
            {
                return true;
            }
        }
        else if (player.GetComponent<WeaponSwap>().activeWeapon == 1)
        {
            if (player.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Shotgun>().enabled)
            {
                return true;
            }
        }
        return false;
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
    public float GetHealth()
    {
        return _currentHP;
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

        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0,0,0));
        bullet.GetComponent<Transform>().right = player.transform.position - gameObject.transform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
        bullet.GetComponent<Transform>().rotation *= Quaternion.Euler(0, 0, -90);
        Destroy(bullet, 5);
    }

    public void ShootGrenade()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.Normalize(player.transform.position - gameObject.transform.position) * _grenadeStrength, ForceMode2D.Impulse);
        Destroy(bullet, 5);
    }

    public void TakeDamage(float _damage)
    {
        _currentHP -= _damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Debug.Log(collision.gameObject.GetComponent<PlayerBullet>()._damageVal);
            TakeDamage(collision.gameObject.GetComponent<PlayerBullet>()._damageVal);
        }
    }
}
