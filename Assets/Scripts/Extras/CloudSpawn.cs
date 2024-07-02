using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{

   private float _speed = 2;

   void Start()
   {

   }

   void Update()
   {
      transform.Translate(Vector3.right * (Time.deltaTime * _speed));
   }

}
