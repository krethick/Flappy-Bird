using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren_Script : MonoBehaviour
{
    private Pipe pipe;
    void Start()
    {
        pipe = GameObject.FindGameObjectWithTag("Pipe").GetComponent<Pipe>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) 
     {
       if(collision.gameObject.layer == 6)
        {
          
          pipe.MoveDown();
          
        }
    }
}
