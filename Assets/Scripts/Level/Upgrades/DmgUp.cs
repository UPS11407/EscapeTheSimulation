using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DmgUp : MonoBehaviour
{
    [SerializeField] private int _buff;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 0)
        {
            if(collision.gameObject.GetComponent<WeaponSwap>().activeWeapon == 0)
            {
                collision.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Pistol>()._buff += _buff;
            }
            else if (collision.gameObject.GetComponent<WeaponSwap>().activeWeapon == 1)
            {
                collision.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Shotgun>()._buff += _buff;
            }
            Destroy(gameObject);
        }
    }
}
