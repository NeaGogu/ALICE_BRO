using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;

    public float spawnSpeed;
    float timer = 2;

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
}
