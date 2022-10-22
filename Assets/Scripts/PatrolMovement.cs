using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    [SerializeField]
    private Transform[] _coordinates;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _timeDelay;
    [SerializeField]
    private GameObject _moveableObject;

    private float _currentTime;
    private int _currentPosition;
    private float _distance;
    private float _travelTime;
    private GameObject _actor;

    private void Awake()
    {
        _actor = Instantiate(_moveableObject);
        _actor.transform.position = _coordinates[0].position;
        _travelTime = GetDistance(0, 1) / _speed;
        //Debug.Log(_actor.name);
    }

    int GetNextIndex()
    {
        return (_currentPosition+1) % _coordinates.Length;
    }

    float GetDistance(int first,int second)
    {
        return Vector3.Distance(_coordinates[first].position, _coordinates[second].position);
    }
    void Update()
    {
        _currentTime += Time.deltaTime;
        var result = (_currentTime - _timeDelay) / _travelTime ;
        //Debug.Log(result);
        _actor.transform.position = Vector3.Lerp(_coordinates[_currentPosition].position, _coordinates[GetNextIndex()].position, result);

        if (_currentTime >= _travelTime+_timeDelay)
        {
            _currentTime = 0;
            _currentPosition = GetNextIndex();
            _travelTime = GetDistance(_currentPosition,GetNextIndex()) / _speed;
        }
    }
}
