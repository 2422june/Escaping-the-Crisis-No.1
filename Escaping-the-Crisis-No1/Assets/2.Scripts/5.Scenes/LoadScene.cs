using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : SceneBase
{
    private float _speed;
    [SerializeField]
    private Slider _loadBar;

    public override void Init(SceneManager sceneMng)
    {
        _type = Define.Scene.Load;
        _name = _type.ToString();
        _scene = gameObject;
        InitUI();
        _speed = _loadBar.maxValue / sceneMng.GetLoadTime();

        gameObject.SetActive(false);
    }

    protected override void InitUI()
    {
        Managers.UI.Clear();

        Util.SetRoot(transform);
        Util.SetRoot("Canvas");
        Managers.UI.AddUI<Slider>("LoadBar", "LoadBar");
        _loadBar = Managers.UI.GetUI<Slider>("LoadBar");
    }

    private IEnumerator Loading()
    {
        while(_loadBar.value < _loadBar.maxValue)
        {
            _loadBar.value += _speed * Time.deltaTime;
            yield return null;
        }
        
        _loadBar.value = 100;
        OnLoad();

        yield return null;
    }

    protected override void OnLoad()
    {
        Managers.UI.Clear();
        Managers.Scene.OnLoad();
        Managers.Scene.LoadScene();
    }

    public override void LeftScene()
    {
        gameObject.SetActive(false);
    }

    public override void StartLoad()
    {
        _loadBar.value = _loadBar.minValue;
        gameObject.SetActive(true);
        StartCoroutine(Loading());
    }
}
