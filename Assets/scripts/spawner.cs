using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;

    public float spawnSpeed;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer();
    }

    void SpawnTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Spawn();
            timer = spawnSpeed;
        }
    }

    void Spawn()
    {
        Vector3 offset = new Vector3(Random.Range(-1,1), 0, 0);
        int randEnemy = Random.Range(0, obstacles.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(obstacles[randEnemy], spawnPoints[randSpawnPoint].position + offset, transform.rotation);
    }
}
