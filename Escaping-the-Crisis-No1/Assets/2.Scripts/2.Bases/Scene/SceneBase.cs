using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBase : MonoBehaviour
{
    protected Define.Scene _type;
    protected string _name;
    protected bool _inScene;
    [HideInInspector]
    public GameObject _scene;

    protected virtual void OnLoad() { }

    public virtual void Init(SceneManager sceneMng) { }

    protected virtual void InitUI() { }

    public virtual void StartLoad() { }

    public virtual void LeftScene() { }
}
