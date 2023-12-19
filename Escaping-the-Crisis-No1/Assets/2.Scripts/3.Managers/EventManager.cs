using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//디버그용 이벤트를 모아놓는 곳 (쓸진 모르겠다.)

public class EventManager : ManagerBase
{
    public delegate void Function();
    public delegate void FunctionBool(bool trigger);

    public override void Init()
    {

    }

    private Function LeaveButton;
    public void AddLeaveButton(Function func)
    { LeaveButton += func; }
    public void ExcuteLeaveButton()
    { LeaveButton(); }

    private Function StartButton;
    public void AddStartButton(Function func)
    { StartButton += func; }
    public void ExcuteStartButton()
    { StartButton(); }
}
