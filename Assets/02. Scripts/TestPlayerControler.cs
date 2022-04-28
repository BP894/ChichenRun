using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerControler : MonoBehaviour
{
    public float movementSpeed = 10f;
    public SpawnManager spawnManager;

    private void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float vMovement = Input.GetAxis("Vertical") * movementSpeed / 2;

        transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }
}
