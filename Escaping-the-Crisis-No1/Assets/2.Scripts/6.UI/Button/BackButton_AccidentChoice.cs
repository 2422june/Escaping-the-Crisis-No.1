using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton_AccidentChoice : ButtonBase
{
    public override void OnClick()
    {
        Managers.Event.ExcuteBackButton_AccidentChoice();
    }
}