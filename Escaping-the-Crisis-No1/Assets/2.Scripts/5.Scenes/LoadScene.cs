using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : SceneBase
{
    private float _speed;
    //[SerializeField]
    private Slider loadBar;

    private void Start()
    {
        _type = Define.Scene.Load;
        _name = "Load";
        _scene = gameObject;
        _speed = 100f / Managers.Scene.GetLoadTime();
        InitUI();
    }

    protected override void InitUI()
    {
        Managers.UI.Clear();

        Util.SetRoot("Canvas");
        Managers.UI.AddUI<Slider>("LoadBar", "LoadBar");
        loadBar = Managers.UI.GetUI<Slider>("LoadBar");

        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        while(loadBar.value < 100)
        {
            loadBar.value += _speed * Time.deltaTime;
            yield return null;
        }
        
        loadBar.value = 100;
        OnLoad();

        yield return null;
    }

    protected override void OnLoad()
    {
        Managers.UI.Clear();
        Managers.Scene.OnLoad();
        Managers.Scene.LoadScene();
    }

    public override void StartLoad()
    {
        OnLoad();
    }
}
