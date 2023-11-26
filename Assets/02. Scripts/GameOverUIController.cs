using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUIController : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject portrait;
    public GameObject inGameScore;
    public TextMeshProUGUI scoreText;
   

    public void PrimarySetting(bool b)
    {
        GameOverPanel.SetActive(b);
    }
    public void SetScore()
    {
        // 초상화 비활성화
        portrait.SetActive(false);
        // 점수 비활성화
        inGameScore.SetActive(false);
        // 게임 오버 스코어 표시
        ScoreUIController scoreUIController = GetComponent<ScoreUIController>();
        int score = scoreUIController.score;
        scoreText.text = "Score : " + score;
    }
}
