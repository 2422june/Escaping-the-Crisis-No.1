using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButton : ButtonBase
{
    public override void OnClick()
    {
        Managers.Event.ExcuteExitButton();
    }
}