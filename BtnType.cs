//==========================================
// writer : Jae Yoon Park.
// file : BtnType.cs.
// content : Start scenes의 버튼 컨트롤.
// descript : .
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public CanvasGroup soundGroup;
    public CanvasGroup languageGroup;
    public CanvasGroup inventoryGroup;
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    //------------------------------------------------------------------------

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Start:
                Debug.Log("시작하기");
                break;
            case BTNType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;
            case BTNType.Quit:
                Application.Quit();
                Debug.Log("종료하기");
                break;
            case BTNType.Sound:
                CanvasGroupOn(soundGroup);
                break;
            case BTNType.Language:
                CanvasGroupOn(languageGroup);
                break;
            case BTNType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                break;
            case BTNType.CloseSound:
                CanvasGroupOff(soundGroup);
                break;
            case BTNType.CloseLanguage:
                CanvasGroupOff(languageGroup);
                break;
            case BTNType.English:
                Debug.Log("영어");
                break;
            case BTNType.Korean:
                Debug.Log("한국어");
                break;
            case BTNType.Inventory:
                CanvasGroupOn(inventoryGroup);
                break;
            case BTNType.CloseInventory:
                CanvasGroupOff(inventoryGroup);
                break;
            case BTNType.SelectItem:
                Debug.Log("아이템 선택");
                break;
        }
    }

    //------------------------------------------------------------------------

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    //------------------------------------------------------------------------

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

    //------------------------------------------------------------------------

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    //------------------------------------------------------------------------

    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    //------------------------------------------------------------------------
}
