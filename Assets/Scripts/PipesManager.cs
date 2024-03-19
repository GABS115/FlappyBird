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
        currentTime += Time.deltaTime;
        if (currentTime > interval)
        {
            CreatePipe();
            currentTime = 0f;
        }
    }

    void CreatePipe()
    {
      var pipeGameObject =  Instantiate(pipeModel,spawnPoint.position, Quaternion.identity);
      var pipeTransform =  pipeGameObject.GetComponent<Transform>();

        float y = Random.Range(-1.1f, 1.1f);

        pipeTransform.position = new Vector3(spawnPoint.position.x, y);
    }
}
