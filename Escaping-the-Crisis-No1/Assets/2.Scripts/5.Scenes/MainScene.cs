using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : SceneBase
{
    public override void Init(SceneManager sceneMng)
    {
        _type = Define.Scene.Main;
        _name = _type.ToString();
        _scene = gameObject;

        InitUI();
        InitEvent();

        gameObject.SetActive(false);
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
        gameObject.SetActive(true);
        //Managers.Audio.PlayBGM();
    }

    public override void LeftScene()
    {
        gameObject.SetActive(false);
    }

    private void LeaveButton()
    {
        Application.Quit();
    }
}
