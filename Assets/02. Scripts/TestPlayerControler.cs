using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerControler : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpPower = 5f;
    private bool isJump = false;

    public SpawnManager spawnManager;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isJump)
        {
            Move();
            Rotate();
        }
        else
        {
            transform.Translate(new Vector3(0, 0, movementSpeed) * Time.deltaTime);
        }

        Jump();
    }
    private void Move()
    {
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed;

        transform.Translate(new Vector3(hMovement, 0, movementSpeed) * Time.deltaTime);
    }

    private void Rotate()
    {
        float vRotation = Input.GetAxis("Horizontal");

        if (vRotation > 0)
        {
            transform.GetChild(0).localRotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
        else if (vRotation < 0)
        {
            transform.GetChild(0).localRotation = Quaternion.Euler(new Vector3(0, -45, 0));
        }
        else
        {
            transform.GetChild(0).localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    private void Jump()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJump)
            {
                isJump = true;
                transform.GetChild(0).localRotation = Quaternion.Euler(Vector3.zero);
                rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
            else
            {
                return;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("GROUND"))
        {
            isJump = false;
        }
    }
}
