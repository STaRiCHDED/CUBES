using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] 
    private float _recoloringDuration;
    [SerializeField] 
    private float _recoloringDelay;
    
    private Color _startColor;
    private Color _endColor;
    private Renderer _currentRenderer;

    private float _currentTime;
    
    void Awake()
    {
        _currentRenderer = GetComponent<Renderer>();
        GenerateNewColor();
    }

    private void GenerateNewColor()
    {
        _startColor = _currentRenderer.material.color;
        _endColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }
    void Update()
    {
        _currentTime += Time.deltaTime;
        var result = (_currentTime - _recoloringDelay)/ _recoloringDuration ;
        //Debug.Log(result);
        _currentRenderer.material.color = Color.Lerp(_startColor, _endColor, result);

        if (_currentTime >= _recoloringDelay+_recoloringDuration)
        {
            _currentTime = 0;
            GenerateNewColor();
        }
    }
}
