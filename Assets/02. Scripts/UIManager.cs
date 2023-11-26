using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public MenuUIOpener menuUIOpener;
    [HideInInspector] public ScoreUIController scoreUIController;
    [HideInInspector] public GameOverUIController gameOverUIController;
    // �ʱ� �޴� ���� Ȯ�� 30%
    float prob = 0.4f;
    private void Start()
    {
        menuUIOpener = GetComponent<MenuUIOpener>();
        scoreUIController = GetComponent<ScoreUIController>();
        gameOverUIController = GetComponent<GameOverUIController>();
        // ���� ���� UI �ʱ�ȭ ����
        gameOverUIController.PrimarySetting(false);
    }
    private void Update()
    {
        scoreUIController.ScoreUIControl();
    }
    public void MenuTriggerEntered()
    {
        // Ȯ���� �������� ũ�� ����.
        if(Random.Range(0, 1.0f) < prob)
        {
            Debug.Log(prob);
            menuUIOpener.OpenBlessingPanel();
            // �޴��� ���ȴٸ� ���� ����Ȯ���� 10%�� ����.
            prob -= 0.2f;
        }
        // ���� Ȯ������ �־��� ����� ���� ���ٸ�,
        else
        {
            // ���� ���� Ȯ�� 10% ����
            prob += 0.05f;
        }
    }
}
