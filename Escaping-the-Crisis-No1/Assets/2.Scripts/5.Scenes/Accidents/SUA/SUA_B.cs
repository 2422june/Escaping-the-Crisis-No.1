using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUA_B : SceneBase
{
    [SerializeField]
    private GameObject _choiceAccident, _choiceEdu;
    private bool _isChoicedAccident;
    [SerializeField]
    private RoadMovement roadMovement;

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
        _isChoicedAccident = false;
        _choiceAccident.SetActive(!_isChoicedAccident);
        _choiceEdu.SetActive(_isChoicedAccident);
        _inScene = true;
        roadMovement.Return();
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

        if (Input.GetKeyDown(KeyCode.Escape))
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
}