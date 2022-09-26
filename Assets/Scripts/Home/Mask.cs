using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private PliteBuy _pliteBuy;
    
    private float _scaleX = 0;
    private float _scaleY = 0;
    private float _scaleZ = 0;
    private float _maxSize = 70;

    private void OnEnable()
    {
        _pliteBuy.GonePlayer += StartMaskCorontne;
    }

    private void OnDisable()
    {
        _pliteBuy.GonePlayer -= StartMaskCorontne;
    }

    public IEnumerator ScaleDiferent()
    {
        while (_scaleX < _maxSize)
        {
            _transform.localScale = new Vector3(_scaleX++, _scaleY++, _scaleZ++);
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(ScaleDiferent());
    }

    private void StartMaskCorontne()
    {
        StartCoroutine(ScaleDiferent());
    }
}
