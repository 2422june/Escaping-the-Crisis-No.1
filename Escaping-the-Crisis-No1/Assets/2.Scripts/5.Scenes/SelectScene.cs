using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScene : SceneBase
{
    public override void Init(SceneManager sceneMng)
    {
        _type = Define.Scene.Select;
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
    }

    protected override void OnLoad()
    {
        gameObject.SetActive(true);
    }

    public override void LeftScene()
    {
        gameObject.SetActive(false);
    }

    public override void StartLoad()
    {
        OnLoad();
    }
}