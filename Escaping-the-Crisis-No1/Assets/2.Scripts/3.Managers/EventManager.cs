using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����׿� �̺�Ʈ�� ��Ƴ��� �� (���� �𸣰ڴ�.)

public class EventManager : ManagerBase
{
    public delegate void Function();
    public delegate void FunctionBool(bool trigger);

    public override void Init()
    {

    }

    private Function LeaveButton;
    public void AddExitButton(Function func)
    { LeaveButton += func; }
    public void ExcuteExitButton()
    { LeaveButton(); }

    private Function StartButton;
    public void AddStartButton(Function func)
    { StartButton += func; }
    public void ExcuteStartButton()
    { StartButton(); }
}
