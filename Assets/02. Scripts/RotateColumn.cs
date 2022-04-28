using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateColumn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int randomRatation = Random.Range(0, 4);
        transform.rotation = Quaternion.Euler(0, randomRatation * 90.0f, 0);
    }
}
