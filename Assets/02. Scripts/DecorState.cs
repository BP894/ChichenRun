using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorState : MonoBehaviour
{
    private Color[] flagColors = new Color[3];
    private MeshRenderer meshRenderer;

    private void Start()
    {
        flagColors[0] = Color.red;
        flagColors[1] = Color.cyan;
        flagColors[2] = Color.black;

        meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.material.color = flagColors[Random.Range(0, flagColors.Length)];
    }
}
