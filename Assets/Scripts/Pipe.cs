using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()

    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
