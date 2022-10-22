using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMovement : MonoBehaviour
{
    [SerializeField] 
    private float _speed;
    [SerializeField] 
    private GameObject _moveableObject;
    [SerializeField] 
    private Transform _startPosition;
    [SerializeField] 
    private Transform _endPosition;

    private float _currentTime;
    private float _distance;
    private float _travelTime;
    private GameObject _actor;
    private bool _isMovedBack;

    private void Awake()
    {
        _actor = Instantiate(_moveableObject);
        _actor.transform.position = _startPosition.position;
        _travelTime = Vector3.Distance(_actor.transform.position,_endPosition.position) / _speed;
        Debug.Log(_actor.name);
    }
    void Update()
    {
        if (!_isMovedBack)
            _currentTime -= Time.deltaTime;
        else
            _currentTime += Time.deltaTime;

        var result = Mathf.PingPong(_currentTime,_travelTime) / _travelTime;
        
        Debug.Log(result);
        _actor.transform.position = Vector3.Lerp(_startPosition.position, _endPosition.position, result);
        if (Input.GetKeyDown(KeyCode.Space)) _isMovedBack = !_isMovedBack;
    }
}