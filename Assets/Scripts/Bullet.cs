using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Bullet requies speed
    public float speed = 2f;
    public int damage = 1;
    private Pipe pipe; // Pipe here is the c# script
    
    void Start()
    {
        // Finding the gameObject using the Tag.
        pipe = GameObject.FindGameObjectWithTag("Pipe").GetComponent<Pipe>(); 
    }

    void Update()
    {
        transform.position += transform.right *  speed * Time.deltaTime ;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject); // gameobject refers to the bullet itself
    }
     

     void OnTriggerEnter2D(Collider2D collision) 
     {
       if(collision.CompareTag("Siren"))
        {
           // This will access the parent to get the component of the Parent 
           // From the Bullet class I'll access the Pipe C# Component of the Pipe prefab gameObject 
            Destroy(collision.gameObject);
            pipe = collision.transform.parent.GetComponent<Pipe>();
            if(pipe != null)
            {
            pipe.MoveDown();
            Debug.Log("Door is open");
            }
         }
        
        /*
         else if(collision.gameObject.CompareTag("Skull"))
         {
            Destroy(collision.gameObject);
         }
         */
    }
 }

     

