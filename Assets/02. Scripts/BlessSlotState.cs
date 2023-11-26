using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlessSlotState : MonoBehaviour
{
    [HideInInspector] public string blessSlotText;
    [HideInInspector] public float addedMoveSpeed;
    [HideInInspector] public float addedJumpPower;
    [HideInInspector] public Button button;

    public Sprite[] blessImages;

    private string[] text;
    [HideInInspector] public int clickCount = 0;
    private void Awake()
    {
        clickCount = 0;

        button = GetComponent<Button>();
        button.interactable = false;

        text = this.gameObject.name.Split('_');

        this.setText();
        this.setAbility();
        this.setSpriteImage();
    }
    public void setText()
    {
        switch (int.Parse(text[2]))
        {
            case 1:
                switch(clickCount)
                {
                    case 0:
                        blessSlotText = "�̵��ӵ� ��";
                        break;
                    case 1:
                        blessSlotText = "�̵��ӵ� ���";
                        break;
                    case 2:
                        blessSlotText = "�̵��ӵ� ����";
                        break;
                    default:
                        blessSlotText = "���� X";
                        break;
                }
                break;
            case 2:
                switch (clickCount)
                {
                    case 0:
                        blessSlotText = "������ ��";
                        break;
                    case 1:
                        blessSlotText = "������ ���";
                        break;
                    case 2:
                        blessSlotText = "������ ����";
                        break;
                    default:
                        blessSlotText = "���� X";
                        break;
                }
                break;
            case 3:
                blessSlotText = "3�ʰ� ����";
                break;
            default:
                break;
        }
    }
    private void setAbility()
    {
        switch(int.Parse(text[2]))
        {
            case 1:
                addedMoveSpeed = 1.0f;
                break;
            case 2:
                addedJumpPower = 1.0f;
                break;
            case 3:
                // ���� ȿ��
                //TGM();
                break;
        }
    }
    public void setSpriteImage()
    {
        this.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = blessImages[clickCount];
    }
    public IEnumerator TGM()
    {
        GameObject player = GameObject.Find("Player");
        SkinnedMeshRenderer playerMeshRenderer = player.GetComponentInChildren<SkinnedMeshRenderer>();
        // �÷��̾� ���� �޽� ������ ���� ����
        Color[] nomalColors = new Color[playerMeshRenderer.materials.Length];
        for(int i = 0; i < playerMeshRenderer.materials.Length; i++)
        {
            nomalColors[i] = playerMeshRenderer.materials[i].color;
        }

        Debug.Log(playerMeshRenderer.name);

        // �÷��̾� �޽� ������ ���� ����
        foreach (var material in playerMeshRenderer.materials)
        {
            material.color = Color.red;
        }
        // 6�� ���̾�(Obstacle)�� 7�� ���̾�(player)�� �浹 �˻� X
        Physics.IgnoreLayerCollision(6, 7, true); 

        // 3�� ���
        yield return new WaitForSeconds(3.0f);

        // 6�� ���̾�(Obstacle)�� 7�� ���̾�(player)�� �浹 �˻� O
        Physics.IgnoreLayerCollision(6, 7, false);
        // �÷��̾� �޽� ������ ���� ����� ����
        for (int i = 0; i < playerMeshRenderer.materials.Length; i++)
        {
            playerMeshRenderer.materials[i].color = nomalColors[i];
        }
    }
}
