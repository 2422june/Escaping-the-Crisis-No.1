using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectScene : SceneBase
{
    [SerializeField]
    private GameObject _choiceAccident, _choiceEdu;
    private bool _isChoicedAccident;

    public override void Init(SceneManager sceneMng)
    {
        _type = Define.Scene.Select;
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
        Managers.Event.AddBackButton_AccidentChoice(BackButoon);
        Managers.Event.AddSUA(SUAButoon);
    }

    protected override void OnLoad()
    {
        gameObject.SetActive(true);
        _isChoicedAccident = false;
        _choiceAccident.SetActive(!_isChoicedAccident);
        _choiceEdu.SetActive(_isChoicedAccident);
        _inScene = true;
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

    private void Update()
    {
        if (!_inScene)
            return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnChoiceAccident();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && _isChoicedAccident)
        {
            GameObject resource = Util.Load<GameObject>("Accident/SUA/Accident");
            GameObject accident = Instantiate(resource, transform.parent);
            Managers.Scene.SetEduScene(accident);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Managers.Scene.LoadScene(Define.Scene.Edu_A);
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            Managers.Scene.LoadScene(Define.Scene.Edu_B);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            Managers.Scene.LoadScene(Define.Scene.Edu_C);
        }
    }

    public void OnChoiceAccident()
    {
        _isChoicedAccident = true;
        _choiceAccident.SetActive(!_isChoicedAccident);
        _choiceEdu.SetActive(_isChoicedAccident);
    }

    public void BackButoon()
    {
        Managers.Scene.LoadScene(Define.Scene.Main);
    }

    public void SUAButoon()
    {
        GameObject resource = Util.Load<GameObject>("Accident/SUA/Accident");
        GameObject accident = Instantiate(resource, transform.parent);
        Managers.Scene.SetEduScene(accident);
        OnChoiceAccident();
    }
}