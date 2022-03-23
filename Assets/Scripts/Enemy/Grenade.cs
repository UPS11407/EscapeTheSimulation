using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    float bulletSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(grenada());
    }

    IEnumerator grenada()
    {
        int delay = Random.Range(1, 4);
        
        yield return new WaitForSeconds(delay);
        int noOfFrags = Random.Range(6, 12);
        for (int i = 0; i < noOfFrags; i++)
        {
            Quaternion rotation = Quaternion.Euler(0,0,Random.Range(0,360));
            Debug.Log(rotation);
            var bullet = Instantiate(bulletPrefab, this.transform.position, rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
            bullet.transform.rotation *= Quaternion.Euler(0, 0, 90);
            
            
        }
        Destroy(this.gameObject);
        
    }
    
}
