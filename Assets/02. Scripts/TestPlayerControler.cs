using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerControler : MonoBehaviour
{
    public float movementSpeed = 5f;
    public SpawnManager spawnManager;

    private void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float vMovement = Input.GetAxis("Vertical") * movementSpeed / 2;

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.GetChild(0).localRotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.GetChild(0).localRotation = Quaternion.Euler(new Vector3(0, -45, 0));
        }
        else
        {
            transform.GetChild(0).localRotation = Quaternion.Euler(Vector3.zero);
        }

        transform.Translate(new Vector3(hMovement, 0, movementSpeed) * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }
}
