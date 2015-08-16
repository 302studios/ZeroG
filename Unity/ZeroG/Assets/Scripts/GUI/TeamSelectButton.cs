using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

class TeamSelectButton:MonoBehaviour
{
    private List<Button> _buttons = new List<Button>();

    private Button _curSelected;

    public void Start()
    {
        InputControl.Instance.RegisterInputEvent(0, new InputControlData.InputAction(OnClick));
        
    }


    public void OnClick(float XAxis, float YAxis, bool MouseDown, bool MouseUp)
    {

        int index;

        if (_curSelected != null)
        {
            index = _buttons.IndexOf(_curSelected);
        }
        else
        {
            index = 0;
        }

        
        if (XAxis > 0)
        {
            index = (index + 1) % _buttons.Count;
        }
        else
            if (XAxis < 0)
            {
                index = (index - 1) % _buttons.Count;
            }

        if (YAxis > 0)
        {
            index = (index + 2) % _buttons.Count;
        }
        else
            if (YAxis < 0)
            {
                index = (index - 2) % _buttons.Count;
            }
        
    }

    private void NextButton()
    { 
        
    }

    private void PrevButton()
    {

    }
}

