using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyBoxInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            var puzzle = collision.gameObject.GetComponent<Puzzle>();
        }
    }
}
