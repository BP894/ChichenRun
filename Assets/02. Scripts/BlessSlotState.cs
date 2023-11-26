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
                        blessSlotText = "이동속도 ↑";
                        break;
                    case 1:
                        blessSlotText = "이동속도 ↑↑";
                        break;
                    case 2:
                        blessSlotText = "이동속도 ↑↑↑";
                        break;
                    default:
                        blessSlotText = "증가 X";
                        break;
                }
                break;
            case 2:
                switch (clickCount)
                {
                    case 0:
                        blessSlotText = "점프력 ↑";
                        break;
                    case 1:
                        blessSlotText = "점프력 ↑↑";
                        break;
                    case 2:
                        blessSlotText = "점프력 ↑↑↑";
                        break;
                    default:
                        blessSlotText = "증가 X";
                        break;
                }
                break;
            case 3:
                blessSlotText = "3초간 무적";
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
                // 무적 효과
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
        // 플레이어 본래 메쉬 렌더러 색깔 저장
        Color[] nomalColors = new Color[playerMeshRenderer.materials.Length];
        for(int i = 0; i < playerMeshRenderer.materials.Length; i++)
        {
            nomalColors[i] = playerMeshRenderer.materials[i].color;
        }

        Debug.Log(playerMeshRenderer.name);

        // 플레이어 메쉬 렌더러 색깔 변경
        foreach (var material in playerMeshRenderer.materials)
        {
            material.color = Color.red;
        }
        // 6번 레이어(Obstacle)와 7번 레이어(player)의 충돌 검사 X
        Physics.IgnoreLayerCollision(6, 7, true); 

        // 3초 대기
        yield return new WaitForSeconds(3.0f);

        // 6번 레이어(Obstacle)와 7번 레이어(player)의 충돌 검사 O
        Physics.IgnoreLayerCollision(6, 7, false);
        // 플레이어 메쉬 렌더러 본래 색깔로 변경
        for (int i = 0; i < playerMeshRenderer.materials.Length; i++)
        {
            playerMeshRenderer.materials[i].color = nomalColors[i];
        }
    }
}
