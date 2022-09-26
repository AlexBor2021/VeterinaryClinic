using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSecondary : MonoBehaviour
{
    [SerializeField] private GameObject _joystic;

    private float _timer = 4f;
    private const string _offObject = "OffObject";

    private void OnEnable()
    {
        _joystic.SetActive(false);
        Invoke(_offObject, _timer);
    }

    private void OffObject()
    {
        _joystic.SetActive(true);
        gameObject.SetActive(false);
    }




}
