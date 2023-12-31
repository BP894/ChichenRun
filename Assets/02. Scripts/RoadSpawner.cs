using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public TestPlayerControler playerControler;
    public List<GameObject> roads;
    private float offset = 8.0f;

    private void Awake()
    {
        if( roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public IEnumerator MoveRoad()
    {
        GameObject movedRoad = roads[0];
        
        yield return new WaitForSeconds(5 / playerControler.movementSpeed);

        roads.Remove(movedRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        movedRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(movedRoad);
    }
}
