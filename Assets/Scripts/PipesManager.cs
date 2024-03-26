using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pipeModel;
    public Transform spawnPoint;
    public float interval;

    private float currentTime = 0f;                                                                             

    void Start()
    {
        
    }

    // Update is called once per frame
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

    public void PlayUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime > interval)
        {
            CreatePipe();
            currentTime = 0f;
        }
    }

    void CreatePipe()
    {
      //var pipeGameObject =  Instantiate(pipeModel, spawnPoint.position, Quaternion.identity);
        var pipeGameObject = Instantiate(pipeModel, transform);
        var pipeTransform =  pipeGameObject.GetComponent<Transform>();

        float y = Random.Range(-1.44f, 0.4f);

        pipeTransform.position = new Vector3(spawnPoint.position.x, y, spawnPoint.position.z);
    }

    public void Restart()
    {
        while(transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
                
        }

    }
}
