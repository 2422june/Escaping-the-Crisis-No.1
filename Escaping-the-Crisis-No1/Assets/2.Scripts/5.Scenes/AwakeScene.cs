using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScene : SceneBase
{
    public override void Init(SceneManager sceneMng)
    {
        _type = Define.Scene.Awake;
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

    public override void StartLoad()
    {
        OnLoad();
    }

    protected override void OnLoad()
    {
        gameObject.SetActive(true);
    }

    public override void LeftScene()
    {
        gameObject.SetActive(false);
    }
}
