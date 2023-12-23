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
    public void AddExitButton(Function func)
    { LeaveButton += func; }
    public void ExcuteExitButton()
    { LeaveButton(); }

    private Function StartButton;
    public void AddStartButton(Function func)
    { StartButton += func; }
    public void ExcuteStartButton()
    { StartButton(); }


    private Function BackButton_AccidentChoice;
    public void AddBackButton_AccidentChoice(Function func)
    { BackButton_AccidentChoice += func; }
    public void ExcuteBackButton_AccidentChoice()
    { BackButton_AccidentChoice(); }

    private Function SUAButton;
    public void AddSUA(Function func)
    { SUAButton += func; }
    public void ExcuteSUA()
    { SUAButton(); }

    private Function SUA_A;
    public void AddSUA_A(Function func)
    { SUA_A += func; }
    public void ExcuteSUA_A()
    { SUA_A(); }

    private Function SUA_B;
    public void AddSUA_B(Function func)
    { SUA_B += func; }
    public void ExcuteSUA_B()
    { SUA_B(); }
}
