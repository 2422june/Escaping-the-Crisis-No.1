using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUA : ButtonBase
{
    public override void OnClick()
    {
        Managers.Event.ExcuteSUA();
    }
}