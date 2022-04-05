using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    float bulletSpeed = 5f;

    bool _inWall = false;
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
            //Debug.Log(rotation);
            var bullet = Instantiate(bulletPrefab, this.transform.position, rotation);

            if (_inWall)
            {
                Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GameObject.Find("Wall").GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GameObject.Find("Walls").GetComponent<Collider2D>());
            }

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
            bullet.transform.rotation *= Quaternion.Euler(0, 0, 90);
            
            
        }
        Destroy(this.gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 14)
        {
            //Debug.Log("Grenade Enter Wall");
            _inWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            //Debug.Log("Grenade Exit Wall");
            _inWall = false;
        }
    }
}
