using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartButton : ButtonBase
{
    public override void OnClick()
    {
        Managers.Event.ExcuteStartButton();
    }
}
