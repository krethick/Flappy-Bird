using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float SkullSpeed = 5;
    public float deadZone = -45;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = transform.position + (Vector3.left * SkullSpeed) * Time.deltaTime;

        if(transform.position.x < deadZone)
        {
            Debug.Log("Skull is Deleted");
            Destroy(gameObject);
        }
    }
    
    
    void OnCollisionEnter2D(Collision2D collision)
    { 
        
         if(collision.gameObject.layer == 3) // The bird is on the third layer
         {
            Destroy(collision.gameObject);
         }
         
         else if(collision.gameObject.layer == 6)
         {
            Destroy(gameObject);
         }

    }
    
}
