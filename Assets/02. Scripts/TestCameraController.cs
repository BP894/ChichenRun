using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour
{
    private Transform player;
    private float yOffset = 0.340f;
    private float zOffset = -0.632f;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void LastUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z + zOffset);
    }
}
