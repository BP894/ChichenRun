using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private RoadSpawner roadSpawner;
    private ObstacleSpawner obstacleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();
    }

    public void SpawnTriggerEntered(Collider col)
    {
        StartCoroutine(roadSpawner.MoveRoad());
        obstacleSpawner.SpawnObstacle(col);
    }
}
