using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public MenuUIOpener menuUIOpener;
    // 초기 메뉴 오픈 확률 50%
    float prob = 0.5f;
    private void Start()
    {
        menuUIOpener = GetComponent<MenuUIOpener>();
    }

    public void MenuTriggerEntered()
    {
        // 확률이 랜덤보다 크면 실행.
        if(Random.Range(0, 1.0f) < prob)
        {
            menuUIOpener.OpenBlessingPanel();
            // 메뉴가 열렸다면 다음 오픈확률을 10%씩 줄임.
            prob -= 0.2f;
        }
        // 오픈 확률보다 주어진 경우의 수가 적다면,
        else
        {
            // 다음 오픈 확률 10% 증가
            prob += 0.1f;
        }
    }
}
