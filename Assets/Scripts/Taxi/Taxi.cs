using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    [SerializeField] private ParticleSystem _brakeOne;
    [SerializeField] private ParticleSystem _brakeTwo;
    [SerializeField] private GameObject _camera;

    private void OnEnable()
    {
        _brakeOne.Play();
        _brakeTwo.Play();
    }

    public void OffCamera()
    {
        _camera.SetActive(false);
    }
}
