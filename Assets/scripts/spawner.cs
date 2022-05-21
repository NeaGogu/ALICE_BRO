using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;
    public GameObject[] powerUps;
    
    public float spawnSpeed;
    public float timer = 2;

    // Start is called before the first frame update
    void Start()
    {
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
            
            if (Random.Range(1, 10) == 1)
            {
                SpawnPowerUp();
            }
            
            Spawn();
            timer = spawnSpeed;
        }
    }

    void Spawn()
    {
        int rand = Random.Range(1, 3);
        List<int> points = new List<int>();
        for (int i = 0; i <= rand; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-.5f, .5f), 0, 0);
            int randObstacle = Random.Range(0, obstacles.Length);
            int spawnpoint = Random.Range(0, spawnPoints.Length);
            while (points.Contains(spawnpoint)) {
                spawnpoint = Random.Range(0, spawnPoints.Length);
            }
            Quaternion angle = transform.rotation;
            angle.eulerAngles += new Vector3(0, 0, Random.Range(0, 360));
            Instantiate(obstacles[randObstacle], spawnPoints[spawnpoint].position + offset, angle);
            points.Add(spawnpoint);
        }
    }
    
    void SpawnPowerUp()
    {
        Vector3 offset = new Vector3(Random.Range(-1,1), 0, 0);
        int randPowerUp = Random.Range(0, powerUps.Length);
        int powerUpSpawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject powerUp = Instantiate(powerUps[randPowerUp], spawnPoints[powerUpSpawnPoint].position + offset,
            transform.rotation);
        
    }
}
