using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//�� ��ȯ ����� ����ϰ� �� ������ ���� ����

public class SceneManager : ManagerBase
{
    [SerializeField]
    private List<SceneBase> scenes = new List<SceneBase>();
    private Define.Scene _nextScene;
    private float _loadingTime;
    private bool _onLoading;

    public override void Init()
    {
        _onLoading = false;
        _loadingTime = 3;
        Transform sceneRoot = GameObject.Find("@Scenes").transform;
        for (int i = 0; i < scenes.Count; i++)
        {
            scenes[i] = sceneRoot.Find(((Define.Scene)i).ToString()).GetComponent<SceneBase>();
            scenes[i].Init();
        }
    }

    public void LoadScene(Define.Scene scene = Define.Scene.Load)
    {
        if (_onLoading)
        {
            _onLoading = false;
            scenes[(int)_nextScene].StartLoad();
        }
        else
        {
            _nextScene = scene;
            scenes[(int)Define.Scene.Load].StartLoad();
        }
    }

    public Define.Scene GetNextScene()
    {
        return _nextScene;
    }

    public float GetLoadTime()
    {
        return _loadingTime;
    }

    public void OnLoad()
    {
        _onLoading = true;
    }

    public void OnLoad(SceneBase scene)
    {
        _onLoading = true;
    }
}