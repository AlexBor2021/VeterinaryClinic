using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SkinnedMeshRenderer), typeof(Animator))]

public class Pat : MonoBehaviour
{
    [SerializeField] private Sprite _soap;
    [SerializeField] private Material _dirtyMatirial;
    [SerializeField] private Material _clearMatirial;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private ParticleSystem _dirty;
    [SerializeField] private ParticleSystem _soapEffect;
    [SerializeField] private Animator _animator;

    private bool _clear;
    private const string _go = "Go";
    private const string _sit = "Sit";
    private const string _taking = "Taking";

    private void OnEnable()
    {
        CreatDirt();
        _clear = false;
    }

    public void CreatDirt()
    {
        _dirty.Play();
        _skinnedMeshRenderer.material = _dirtyMatirial;
    }

    public void Clear()
    {
        if (_clear == false)
        {
            _dirty.Stop();
            _skinnedMeshRenderer.material = _clearMatirial;
            _soapEffect.gameObject.SetActive(true);
            _soapEffect.Play();
        }
    }

    public void SetAnimationSit()
    {
        _animator.SetTrigger(_sit);
    }

    public void SetAnimationGo()
    {
        _animator.SetTrigger(_go);
    }

    public void SetAnimationTake()
    {
        _animator.SetTrigger(_taking);
    }
}
