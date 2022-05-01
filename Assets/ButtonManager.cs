using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public TestPlayerControler playerControler;
    public UIManager uiManager;

    public BlessSlotState[] blessSlotState;

    // �ູ ���� Ŭ�� �� �߻��� �̺�Ʈ
    public void SlotButtonClicked()
    {
        // �÷��̾��� ������ ����
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        string[] text = clickObject.name.Split('_');
        int index = int.Parse(text[2]);

        switch(index)
        {
            case 1:
                // Ŭ�� ī��Ʈ ����
                blessSlotState[1].clickCount++;
                // Ŭ�� ī��Ʈ : 3�� ����
                if(blessSlotState[1].clickCount > 3)
                {
                    blessSlotState[1].clickCount = 3;
                }
                // �̵��ӵ� ����
                playerControler.movementSpeed += blessSlotState[1].addedMoveSpeed;
                // �ִ� �ӵ� : 6�� ����
                if(playerControler.movementSpeed > 6)
                {
                    playerControler.movementSpeed = 6.0f;
                }
                // ���� �̹��� ����
                blessSlotState[1].setSpriteImage();
                // ���� ���� ����
                blessSlotState[1].setText();
                Debug.Log("�÷��̾� �ӵ� : " + playerControler.movementSpeed);
                break;
            case 2:
                // Ŭ�� ī��Ʈ ����
                blessSlotState[2].clickCount++;
                // Ŭ�� ī��Ʈ : 2�� ����
                if (blessSlotState[2].clickCount > 3)
                {
                    blessSlotState[2].clickCount = 3;
                }
                // ������ ����
                playerControler.movementSpeed += blessSlotState[2].addedJumpPower;
                // �ִ� ������ : 8�� ����
                if(playerControler.jumpPower > 8)
                {
                    playerControler.jumpPower = 8.0f;
                }
                // ���� �̹��� ����
                blessSlotState[2].setSpriteImage();
                // ���� ���� ����
                blessSlotState[2].setText();
                Debug.Log("�÷��̾� ������ : " + playerControler.jumpPower);
                break;
            case 3:
                // ���� ȿ��
                blessSlotState[3].TGM();
                break;
        }
        // UI �ݱ�
        // UI ��Ȱ��ȭ
        // �ð� ����ȭ
        uiManager.menuUIOpener.CloseBlessingPanel();
    }
}
