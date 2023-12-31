using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIOpener : MonoBehaviour
{
    public GameObject entireUI;
    public GameObject panel;
    public GameObject portrait;
    public GameObject scoreObject;

    public TestPlayerControler playerControler;
    public SoundManager soundManager;
    public TextMeshProUGUI[] blessingTexts;
    public BlessSlotState[] blessSlotStates;
    public Transform[] openUIParticleTransforms;

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
        // 현재 진행 중인 애니메이션 >> OpenMenu
        // 애니메이션 종료 시,
        // slotButton 활성화, 시간 정지, 플레이어 속도 정상화.
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("OpenMenu") 
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            foreach(BlessSlotState bls in blessSlotStates)
            {
                bls.button.interactable = true;
            }
            // 파티클 시스템 비활성화
            foreach (var particle in openUIParticleTransforms)
            {
                particle.gameObject.SetActive(false);
            }
            Debug.Log("시간 정지");
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
        // 플레이어 인풋 금지
        playerControler.isUIOpen = true;
        // 플레이어 이동속도 급감(애니메이션 출력 시간 동안 오브젝트에 부딪히는 현상 방지)
        moveSpeed = playerControler.movementSpeed;
        playerControler.movementSpeed = 0.05f;
        // 전체 UI 활성화
        entireUI.SetActive(true);
        // UI 애니메이션 실행
        if (panel != null)
        {
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
        // 메뉴오픈오디오 실행
        soundManager.PlayOnMenuSound();
        // 파티클 시스템 재생
        foreach (var particle in openUIParticleTransforms)
        {
            particle.GetComponentInChildren<ParticleSystem>().Play();
        }
        // 초상화 끄기
        portrait.SetActive(false);
        // 스코어 오브젝트 끄기
        scoreObject.SetActive(false);
        // 시간 정지(Update 함수)
        // 슬롯 설명 텍스트 출력.
        for (int i = 0; i < blessSlotStates.Length; i++)
        {
            blessingTexts[i].text = blessSlotStates[i].blessSlotText;
        }
    }
    public void CloseBlessingPanel()
    {
        // UI 애니메이션 실행 
        if (panel != null)
        {
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
        // 버튼 비활성화
        foreach (BlessSlotState bls in blessSlotStates)
        {
            bls.button.interactable = false;
        }
        // 파티클 시스템 활성화
        foreach (var particle in openUIParticleTransforms)
        {
            particle.gameObject.SetActive(true);
        }
        // 초상화 켜기
        portrait.SetActive(true);
        // 스코어 오브젝트 켜기
        scoreObject.SetActive(true);
        // 시간 되돌리기
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
        // 전체 UI 비활성화
        entireUI.SetActive(false);
        // 플레이어 입력 허용
        playerControler.isUIOpen = false;
    }
}
