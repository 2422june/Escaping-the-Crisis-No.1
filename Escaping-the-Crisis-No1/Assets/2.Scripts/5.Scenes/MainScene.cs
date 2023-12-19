using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : SceneBase
{
    private void Start()
    {
        _type = Define.Scene.Main;
        _name = _type.ToString();
        _scene = gameObject;

        InitUI();
        InitEvent();
    }

    protected override void InitUI()
    {
    }

    private void InitEvent()
    {
        Managers.Event.AddLeaveButton(LeaveButton);
    }

    public override void StartLoad()
    {
        OnLoad();
    }

    protected override void OnLoad()
    {
        //Managers.Audio.PlayBGM();
    }

    private void LeaveButton()
    {
#if UNITY_EDITOR
        Application.Quit();
#endif
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
