using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyInputField : InputFieldOriginal
{
    [SerializeField] private List<UIButton> uiButtons = new();


    protected override void OnEnable()
    {
        base.OnEnable();
        foreach (var uiButton in uiButtons)
        {
            uiButton.ButtonUI.onClick.AddListener(() => ClickLetter(uiButton.ValueToType));
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        foreach (var uiButton in uiButtons)
        {
            uiButton.ButtonUI.onClick.RemoveAllListeners();
        }
        
    }

    public void ClickLetter(string letterClicked)
    {


        text += letterClicked;
        m_AllowInput = true;
        caretPosition = text.Length;
        Select();
        ActivateInputField();


        UpdateLabel();

    }
}