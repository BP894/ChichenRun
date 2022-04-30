using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> obstacles;
    private RoadSpawner roadSpawner;
  
    private void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        this.SetObstacle();
    }
    private void SetObstacle()
    {
        for (int i = 1; i < roadSpawner.roads.Count; i++)
        {
            this.CreateObstacle(i);
        }
    }
    public void SpawnObstacle(Collider other)
    {
        Transform roadTransform = other.transform.parent;

        for(int i = 0; i < roadTransform.childCount; i++)
        {
            if(roadTransform.GetChild(i).CompareTag("OBSTACLE"))
            {
                Destroy(roadTransform.GetChild(i).gameObject);
            }
        }

        CreateObstacle(0);
    }  
    private void CreateObstacle(int index)
    {
        int randIndex = Random.Range(0, obstacles.Count);

        GameObject obstacle = Instantiate(obstacles[randIndex]) as GameObject;
        obstacle.transform.SetParent(roadSpawner.roads[index].transform, false);
    }
}
