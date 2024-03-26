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

    void Update()
    {
        switch (GameManager.instance.status)
        {
            case GameStatus.Start:
                break;
            case GameStatus.Play:
                PlayUpdate();
                break;
            case GameStatus.GameOver:
                break;
        }

    }

    // Update is called once per frame
    void PlayUpdate()
    {
        
            transform.position += Vector3.left * Time.deltaTime * speed;
        if (transform.position.x < -2.9f)
        {
            //autodestruir
            Destroy(gameObject);
        }
    }
}
