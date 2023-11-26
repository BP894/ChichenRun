using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [HideInInspector] public int score;

    public void ScoreUIControl()
    {
        score = (int) Time.timeSinceLevelLoad * 10;

        scoreText.text = "Score : " + score;
    }
}
