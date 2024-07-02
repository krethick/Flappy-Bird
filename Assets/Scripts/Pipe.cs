using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
public class Pipe : MonoBehaviour
{
    float MovementFactor;
    public float PipeSpeed = 5;
    [SerializeField] Vector3 MovementVector; // 3d Vectors and Points
    [SerializeField] float period = 2f;
    public float deadZone = -45;
    public GameObject Siren;  // Attach the Siren Game Object
    public GameObject lower_pipe; // Attach the Lower Pipe Game Onject
    

    //public GameObject PipeDown;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * PipeSpeed) * Time.deltaTime;

        if(transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }

    
    public void MoveDown()
    {
         
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;

        float rawSineWave = Mathf.Sin(cycles * tau);

        MovementFactor = (rawSineWave + 1f) /2f;

        Vector3 offset =  MovementFactor * MovementVector;

        lower_pipe.transform.position = lower_pipe.transform.position + offset;
       
      }
}


    

  

