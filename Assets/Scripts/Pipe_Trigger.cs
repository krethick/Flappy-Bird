using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipe_Trigger : MonoBehaviour
{
    // Use the Logic Manager Reference
    public LogicManager logic; // LogicManager is the c# script
    
    void Start()
    {
        // Communicates with the LogicManager.cs to get the functionality
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.layer == 3) // The bird is on the third layer
        {
        logic.addScore(1);
        }
   }
}
