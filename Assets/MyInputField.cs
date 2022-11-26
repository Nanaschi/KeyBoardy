
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyInputField : InputFieldOriginal
{
    public Text myText;        // drag your text object on here
    private bool shiftOn = false;
     
    public void ClickLetter(string letterClicked)
    {
        /*DoStateTransition(SelectionState.Selected, true);
        m_HasDoneFocusTransition = true;*/

        text += letterClicked;
        
        Debug.Log($"{MethodBase.GetCurrentMethod()} {Time.time}", this);

        if(shiftOn) letterClicked = letterClicked.ToUpper();
        
        /*myText.text += letterClicked;*/
        
        /*OnPointerDown(new PointerEventData(EventSystem.current));
        SetCaretActive();
        OnPointerClick(new PointerEventData(EventSystem.current));
        ActivateInputField();
        SetCaretActive();
        m_CaretVisible = true;*/
        m_AllowInput = true;
        caretPosition = text.Length;
        ActivateInputField();
        UpdateLabel();
        /*MoveTextEnd(false);*/

    }
     
    public void ClickBackspace()
    {
        string tempGetString = myText.text;
        if(tempGetString.Length > 0)
        {
            string tempString = tempGetString.Substring(0, tempGetString.Length -1);
            myText.text = tempString;
        }
    }
     
    public void PressShift()
    {
        shiftOn = !shiftOn;
    }
}