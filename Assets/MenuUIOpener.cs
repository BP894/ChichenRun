using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIOpener : MonoBehaviour
{
    public GameObject entireUI;
    public GameObject panel;

    public TestPlayerControler playerControler;
    public TextMeshProUGUI[] blessingTexts;
    public BlessSlotState[] blessSlotStates;

    private Animator animator;

    private float moveSpeed = 0.0f;

    private void Start()
    {
        entireUI.SetActive(false);
        foreach(TextMeshProUGUI t in blessingTexts)
        {
            t.text = "";
        }
        animator = panel.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        // ���� ���� ���� �ִϸ��̼� >> OpenMenu
        // �ִϸ��̼� ���� ��,
        // slotButton Ȱ��ȭ, �ð� ����, �÷��̾� �ӵ� ����ȭ.
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("OpenMenu") 
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            foreach(BlessSlotState bls in blessSlotStates)
            {
                bls.button.interactable = true;
            }

            Debug.Log("�ð� ����");
            Time.timeScale = 0.0f;
            Time.fixedDeltaTime = 10.0f;
            playerControler.movementSpeed = moveSpeed;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CloseMenu")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            entireUI.SetActive(false);
        }
    }
    public void OpenBlessingPanel()
    {
        // �÷��̾� ��ǲ ����
        playerControler.isUIOpen = true;
        // �÷��̾� �̵��ӵ� �ް�(�ִϸ��̼� ��� �ð� ���� ������Ʈ�� �ε����� ���� ����)
        moveSpeed = playerControler.movementSpeed;
        playerControler.movementSpeed = 0.05f;
        // ��ü UI Ȱ��ȭ
        entireUI.SetActive(true);
        // UI �ִϸ��̼� ����
        if (panel != null)
        {
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
        // �ð� ����(Update �Լ�)

        // ���� ���� �ؽ�Ʈ ���.
        for(int i = 0; i < blessSlotStates.Length; i++)
        {
            blessingTexts[i].text = blessSlotStates[i].blessSlotText;
        }
    }
    public void CloseBlessingPanel()
    {
        // UI �ִϸ��̼� ���� 
        if (panel != null)
        {
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
        // ��ư ��Ȱ��ȭ
        foreach (BlessSlotState bls in blessSlotStates)
        {
            bls.button.interactable = false;
        }
        // �ð� �ǵ�����
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
        // ��ü UI ��Ȱ��ȭ
        entireUI.SetActive(false);
        // �÷��̾� �Է� ���
        playerControler.isUIOpen = false;
    }
}
