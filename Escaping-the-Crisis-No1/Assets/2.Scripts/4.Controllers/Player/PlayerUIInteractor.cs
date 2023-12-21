using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIInteractor : MonoBehaviour
{
    [SerializeField]
    private Transform _handL, _handR;

    private RaycastHit _handLHit, _handRHit;
    private Ray _handLRay, _handRRay;
    private LineRenderer _lineR, _lineL;
    private GameObject _targetL, _targetR;
    private float _rayDis = 10f;

    private void Start()
    {
        _lineR = _handR.GetComponent<LineRenderer>();
        _lineL = _handL.GetComponent<LineRenderer>();

        _handRRay.origin = _handR.position;
        _handLRay.origin = _handL.position;
    }

    private void Update()
    {
        _handRRay.direction = _handR.forward;
        _handLRay.direction = _handL.forward;
    }
}
