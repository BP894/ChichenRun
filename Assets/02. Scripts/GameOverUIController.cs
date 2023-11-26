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
        // �ʻ�ȭ ��Ȱ��ȭ
        portrait.SetActive(false);
        // ���� ��Ȱ��ȭ
        inGameScore.SetActive(false);
        // ���� ���� ���ھ� ǥ��
        ScoreUIController scoreUIController = GetComponent<ScoreUIController>();
        int score = scoreUIController.score;
        scoreText.text = "Score : " + score;
    }
}
