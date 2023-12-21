using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerUIInteractor : MonoBehaviour
{
    [SerializeField]
    private Transform _handL, _handR;

    private RaycastHit _handLHit, _handRHit;
    private Ray _handLRay, _handRRay;
    private LineRenderer _lineR, _lineL;
    private GameObject _targetL, _targetR;
    private Vector3 _lineEndL, _lineEndR;
    private float _rayDis = 10f;
    private Button _buttonL, _buttonR;

    private void Start()
    {
        _lineR = _handR.GetComponent<LineRenderer>();
        _lineL = _handL.GetComponent<LineRenderer>();

        _handRRay.origin = _handR.position;
        _handLRay.origin = _handL.position;
    }

    private void Update()
    {
        _lineL.SetPosition(0, _handL.position);
        _lineR.SetPosition(0, _handR.position);

        _handRRay.direction = _handR.forward;
        _handLRay.direction = _handL.forward;

        _lineEndL = _handL.position + (_handL.forward * _rayDis);
        _lineEndR = _handR.position + (_handR.forward * _rayDis);

        _targetL = null;
        _targetR = null;

        if (Physics.Raycast(_handLRay.origin, _handLRay.direction, out _handLHit, _rayDis))
        {
            _targetL = _handLHit.collider.gameObject;
            _lineEndL = _targetL.transform.position;
        }

        if (Physics.Raycast(_handRRay.origin, _handRRay.direction, out _handRHit, _rayDis))
        {
            _targetR = _handRHit.collider.gameObject;
            _lineEndR = _targetR.transform.position;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            if (_targetL != null)
            {
                _buttonL = Util.GetOrAddComponent<Button>(_targetL);
                if(_buttonL != null )
                {
                    Inter(_targetL);
                    _buttonL = null;
                }
            }
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            if (_targetR != null)
            {
                _buttonR = Util.GetOrAddComponent<Button>(_targetR);
                if (_buttonR != null)
                {
                    Inter(_targetR);
                    _buttonR = null;
                }
            }
        }

        _lineL.SetPosition(1, _lineEndL);
        _lineR.SetPosition(1, _lineEndR);
    }

    private void Inter(GameObject btn)
    {
        btn.GetComponent<ButtonBase>().OnClick();
    }
}
