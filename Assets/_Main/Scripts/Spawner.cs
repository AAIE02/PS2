using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float TimeSpawn = 1;
    [SerializeField] private float RepeatSpawnTime = 5;
    [SerializeField] private Transform XRangeLeft;
    [SerializeField] private Transform XRangeRight;
    [SerializeField] private Transform YRangeUp;
    [SerializeField] private Transform YRangeDown;
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
