using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;

    public float spawnRate = 4;

    private float timer = 0;

    public float heightOffset = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
       {
          timer = timer + Time.deltaTime;
       }
        else
       {
         spawnSkull();
         timer = 0;
       }
    }

    void spawnSkull()
    {  

       float lowestPoint = transform.position.y - heightOffset;
       float highestPoint = transform.position.y + heightOffset;
       // Helps spawning the enemy
       Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation); 
    }
}
