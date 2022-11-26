using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyInputField : InputFieldOriginal
{
    [SerializeField] private List<UIButton> uiButtons = new();
    [SerializeField] private Button backSpace, left, right;


    protected override void OnEnable()
    {
        base.OnEnable();
        foreach (var uiButton in uiButtons)
        {
            uiButton.ButtonUI.onClick.AddListener(() => ClickLetter(uiButton.ValueToType));
        }

        backSpace.onClick.AddListener(BackSpaceClicked);
    }

    private void BackSpaceClicked()
    {
        if(string.IsNullOrEmpty(text)) return;
        StringBuilder sb = new StringBuilder(text);
        sb.Remove(text.Length - 1, 1);
        text = sb.ToString();
        SelectInputField();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        foreach (var uiButton in uiButtons)
        {
            uiButton.ButtonUI.onClick.RemoveAllListeners();
        }
    }

    private void ClickLetter(string letterClicked)
    {
        text += letterClicked;
        SelectInputField();
    }

    private void SelectInputField()
    {
        m_AllowInput = true;
        caretPosition = text.Length;
        Select();
        ActivateInputField();
        UpdateLabel();
    }
}