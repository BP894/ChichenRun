using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        //Destroy(collision.gameObject);
        Debug.Log("게임 종료");
    }
}
