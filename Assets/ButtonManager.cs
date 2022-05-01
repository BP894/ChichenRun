using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public TestPlayerControler playerControler;
    public UIManager uiManager;

    public BlessSlotState[] blessSlotState;

    // 축복 슬롯 클릭 시 발생할 이벤트
    public void SlotButtonClicked()
    {
        // 플레이어의 스탯이 증가
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        string[] text = clickObject.name.Split('_');
        int index = int.Parse(text[2]);

        switch(index)
        {
            case 1:
                // 클릭 카운트 증가
                blessSlotState[1].clickCount++;
                // 클릭 카운트 : 3로 제한
                if(blessSlotState[1].clickCount > 3)
                {
                    blessSlotState[1].clickCount = 3;
                }
                // 이동속도 증가
                playerControler.movementSpeed += blessSlotState[1].addedMoveSpeed;
                // 최대 속도 : 6로 제한
                if(playerControler.movementSpeed > 6)
                {
                    playerControler.movementSpeed = 6.0f;
                }
                // 슬롯 이미지 변경
                blessSlotState[1].setSpriteImage();
                // 슬롯 설명 변경
                blessSlotState[1].setText();
                Debug.Log("플레이어 속도 : " + playerControler.movementSpeed);
                break;
            case 2:
                // 클릭 카운트 증가
                blessSlotState[2].clickCount++;
                // 클릭 카운트 : 2로 제한
                if (blessSlotState[2].clickCount > 3)
                {
                    blessSlotState[2].clickCount = 3;
                }
                // 점프력 증가
                playerControler.movementSpeed += blessSlotState[2].addedJumpPower;
                // 최대 점프력 : 8로 제한
                if(playerControler.jumpPower > 8)
                {
                    playerControler.jumpPower = 8.0f;
                }
                // 슬롯 이미지 변경
                blessSlotState[2].setSpriteImage();
                // 슬롯 설명 변경
                blessSlotState[2].setText();
                Debug.Log("플레이어 점프력 : " + playerControler.jumpPower);
                break;
            case 3:
                // 무적 효과
                blessSlotState[3].TGM();
                break;
        }
        // UI 닫기
        // UI 비활성화
        // 시간 정상화
        uiManager.menuUIOpener.CloseBlessingPanel();
    }
}
