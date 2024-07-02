using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;


public class BirdScript : MonoBehaviour
{
    public Rigidbody2D Bird_RigidBody;
    private LogicManager logic; // This is a c# script
    public float flapStrength;
    public Animator Bird_animator;
    public float deadzone = -14f;
    public bool birdIsAlive = true;

    public GameObject bullets; // This is a c# script

    public Transform Fire; // Transform is position, rotation and scale

    [SerializeField]
    AudioSource Bird_jump;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        
    }

    
    void Update()
    {
        //Bird_RigidBody.velocity = new Vector2(0,0) * 100;
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
        // Runs Frame by Frame
           Bird_RigidBody.velocity = new Vector2(0,1) * flapStrength;
           if(!Bird_jump.isPlaying)
           {
             Bird_jump.Play(); 
           }
           else
           {
             Bird_jump.Stop(); 
           }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && birdIsAlive)
        {
           Instantiate(bullets,Fire.position,transform.rotation);
        }
        else 
        {
          try
          {
          Instantiate(null,new Vector3(0,0,0),transform.rotation);
          }
          catch (Exception ex)
          {
             Debug.Log(ex, this);
          }
        }
    
        if (transform.position.y < deadzone || transform.position.y > 14)
        {
            Destroy(gameObject);
            logic.gameOver();
        }
    }
        
    
    
    // When colliding with the screen
    private void OnCollisionEnter2D(Collision2D collision) 
    {
    
        logic.gameOver();
        birdIsAlive = false;
        Bird_animator.SetBool("Idle",true); // Bird_animator is set to Idle state once the bird is collided.
        
    }
}
