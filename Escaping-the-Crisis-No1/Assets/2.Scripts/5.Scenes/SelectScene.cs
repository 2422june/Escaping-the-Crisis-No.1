using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScene : SceneBase
{
    private void Start()
    {
        _type = Define.Scene.Select;
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
    }

    protected override void OnLoad()
    {
    }

    public override void StartLoad()
    {
        OnLoad();
    }
}