using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EduA_Button : ButtonBase
{
    public override void OnClick()
    {
        Managers.Event.ExcuteSUA_A();
    }
}
