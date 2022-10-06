using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemigos;


    public float TimeSpawn = 1;
    public float RepeatSpawnTime = 5;



    public Transform XRangeLeft;
    public Transform XRangeRight;
    public Transform YRangeUp;
    public Transform YRangeDown;

    
    void Start()
    {
        InvokeRepeating("SpawnEnemies", TimeSpawn,RepeatSpawnTime);
    }


    public void SpawnEnemies()
    {
        Vector3 SpawnPosition = new Vector3(0, 0, 0);

        SpawnPosition = new Vector3(Random.Range(XRangeLeft.position.x,XRangeRight.position.x),Random.Range(YRangeDown.position.y, YRangeUp.position.y),0);

        GameObject enemy = Instantiate(enemigos[0], SpawnPosition, gameObject.transform.rotation);
    }
}
