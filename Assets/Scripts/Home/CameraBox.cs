using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBox : MonoBehaviour
{
    [SerializeField] private GameObject  _virtualCamera;
    [SerializeField] private GameObject _arrow;

    private const string _offCamera = "OffCamera";

    public void OnCamera()
    {
        _virtualCamera.SetActive(true);
        _arrow.SetActive(true);
        Invoke(_offCamera, 5f);
    }

    private void OffCamera()
    {
        _virtualCamera.SetActive(false);
    }
}
