using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EduB_Button : ButtonBase
{
    public override void OnClick()
    {
        Managers.Event.ExcuteSUA_B();
    }
}
