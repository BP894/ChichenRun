using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public MenuUIOpener menuUIOpener;
    // �ʱ� �޴� ���� Ȯ�� 50%
    float prob = 0.5f;
    private void Start()
    {
        menuUIOpener = GetComponent<MenuUIOpener>();
    }

    public void MenuTriggerEntered()
    {
        // Ȯ���� �������� ũ�� ����.
        if(Random.Range(0, 1.0f) < prob)
        {
            menuUIOpener.OpenBlessingPanel();
            // �޴��� ���ȴٸ� ���� ����Ȯ���� 10%�� ����.
            prob -= 0.2f;
        }
        // ���� Ȯ������ �־��� ����� ���� ���ٸ�,
        else
        {
            // ���� ���� Ȯ�� 10% ����
            prob += 0.1f;
        }
    }
}
