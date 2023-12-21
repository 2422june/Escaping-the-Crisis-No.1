using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//�� ��ȯ ����� ����ϰ� �� ������ ���� ����

public class SceneManager : ManagerBase
{
    [SerializeField]
    private List<SceneBase> _scenes = new List<SceneBase>();
    private Define.Scene _nextScene, _nowScene;
    private GameObject _rootEduScene;
    private float _loadingTime;
    private bool _onLoading;

    public override void Init()
    {
        _onLoading = false;
        _loadingTime = 3;
        Transform sceneRoot = GameObject.Find("@Scenes").transform;
        Transform scene;

        //not contain edu scenes
        int sceneCount = System.Enum.GetValues(typeof(Define.Scene)).Length - 3;

        for (int i = 0; i < sceneCount; i++)
        {
            _scenes.Add(null);
            scene = sceneRoot.Find(((Define.Scene)i).ToString());
            _scenes[i] = scene.GetComponent<SceneBase>();
            _scenes[i].Init(this);
        }

        _nowScene = Define.Scene.Awake;
    }

    public void LoadScene(Define.Scene scene = Define.Scene.Load)
    {
        if (_onLoading)
        {
            _onLoading = false;
            _scenes[(int)_nextScene].StartLoad();
            _scenes[(int)_nowScene].LeftScene();
            _nowScene = _nextScene;
        }
        else
        {
            _nextScene = scene;

            _scenes[(int)_nowScene].LeftScene();
            _nowScene = Define.Scene.Load;
            _scenes[(int)_nowScene].StartLoad();
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

    public void SetEduScene(GameObject Edu)
    {
        _rootEduScene.SetActive(false);
        
        _rootEduScene = Edu;
        _rootEduScene.SetActive(true);

        _scenes[(int)Define.Scene.Edu_A] = _rootEduScene.transform.Find("A").GetComponent<SceneBase>();
        _scenes[(int)Define.Scene.Edu_B] = _rootEduScene.transform.Find("B").GetComponent<SceneBase>();
        _scenes[(int)Define.Scene.Edu_C] = _rootEduScene.transform.Find("C").GetComponent<SceneBase>();
    }
}