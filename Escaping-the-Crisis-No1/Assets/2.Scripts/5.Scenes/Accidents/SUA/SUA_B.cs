using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUA_B : SceneBase
{
    [SerializeField]
    private RoadMovement roadMovement;
    [SerializeField]
    private List<GameObject> dial = new List<GameObject>();
    [SerializeField]
    private List<GameObject> obj = new List<GameObject>();

    [SerializeField]
    private GameObject _break, _gear, _side, _power;

    public override void Init(SceneManager sceneMng)
    {
        _type = Define.Scene.Edu_B;
        _name = _type.ToString();
        _scene = gameObject;

        InitUI();
        InitEvent();

        gameObject.SetActive(false);
        _inScene = false;
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
        _inScene = true;
        roadMovement.Return();

        _break.GetComponent<Break>().Init(this);
        _gear.GetComponent<Gear>().Init(this);
        _side.GetComponent<SideBar>().Init(this);
        _power.GetComponent<Power>().Init(this);

        Next();
    }

    public override void LeftScene()
    {
        _inScene = false;
        gameObject.SetActive(false);
    }


    public override void StartLoad()
    {
        OnLoad();
    }

    private int index = -1;

    private void Update()
    {
        if (!_inScene)
            return;
    }

    public void Next()
    {
        if(index >= dial.Count)
        {
            Managers.Scene.LoadScene(Define.Scene.Select);
            return;
        }
        index++;
        dial[index].SetActive(true);
        if(index > 0)
        {
            dial[index-1].SetActive(false);
        }
        obj[index].GetComponent<Outline>().DrawOutline();
    }
}