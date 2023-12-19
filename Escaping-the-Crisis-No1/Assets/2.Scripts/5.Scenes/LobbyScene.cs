using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : SceneBase
{
    private void Start()
    {
        _type = Define.Scene.Lobby;
        _name = "Lobby";
        _scene = gameObject;

        InitUI();
        InitEvent();
    }

    protected override void InitUI()
    {
    }

    private void InitEvent()
    {
    }

    protected override void OnLoad()
    {
    }

    public override void StartLoad()
    {
        OnLoad();
    }
}