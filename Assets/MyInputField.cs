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

    private int currentCarretPosition;

    public override void OnDeselect(BaseEventData eventData)
    {
        OnSelect(eventData);

    }

    protected override void Start()
    {
        ActivateInputField();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        foreach (var uiButton in uiButtons)
        {
            uiButton.ButtonUI.onClick.AddListener(() => ClickLetter(uiButton.ValueToType));
        }

        backSpace.onClick.AddListener(BackSpaceClicked);
        left.onClick.AddListener(LeftClicked);
        right.onClick.AddListener(RightClicked);
    }

    private void RightClicked()
    {
    }

    private void LeftClicked()
    {
        caretSelectPositionInternal += currentCarretPosition - 1;
        caretPositionInternal += currentCarretPosition - 1;
        currentCarretPosition = caretSelectPositionInternal = caretPositionInternal;
        m_AllowInput = true;
        Select();
        ActivateInputField();

        UpdateLabel();

        /*SelectInputField();*/
    }

    private void BackSpaceClicked()
    {
        if (string.IsNullOrEmpty(text)) return;
        StringBuilder sb = new StringBuilder(text);
        sb.Remove(currentCarretPosition, 1);
        text = sb.ToString();
        m_AllowInput = true;
        Select();
        ActivateInputField();
        UpdateLabel();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        foreach (var uiButton in uiButtons)
        {
            uiButton.ButtonUI.onClick.RemoveAllListeners();
        }

        backSpace.onClick.RemoveAllListeners();
    }

    private void ClickLetter(string letterClicked)
    {
        text += letterClicked;
        m_CaretPosition = m_CaretSelectPosition = text.Length;
        UpdateLabel();
    }

    private void SelectInputField()
    {
        m_AllowInput = true;
        caretPosition = text.Length;
        Select();
        ActivateInputField();
        UpdateLabel();
        currentCarretPosition = caretSelectPositionInternal = caretPositionInternal;
        print(currentCarretPosition);
    }
}