using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject SpawnObj;
    public float spawnTime = 10f;


    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

   
    // Update is called once per frame
    /*
    void Update()
    {
        // Debug.Log(Time.deltaTime.ToString()+"ss");
        spawnTime += Time.deltaTime;
        if (spawnTime >= 10) {
            Vector2 SpawnPos = new Vector2(Random.Range(-2, 2f), Random.Range(-4f, 4));
            SpawnPosition.position = SpawnPos;
            //SpawnPosition.position.y = 3f;
            Instantiate(SpawnPosition, SpawnPosition.position, SpawnPosition.rotation);
           // Debug.Log(spawnTime+"detla");
          //  spawnTime += 20;
        }

    }
    */
    void Spawn()
    {
        Vector2 SpawnPos = new Vector2(Random.Range(-2,2f),Random.Range(0f,4));
        SpawnPosition.position = SpawnPos;
        //SpawnPosition.position.y = 3f;
        Instantiate(SpawnPosition, SpawnPosition.position,SpawnPosition.rotation);
    }
}
