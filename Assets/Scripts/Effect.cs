using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private void OnEnable()
    {
        _effect.Pause(); 
    }

    public void PlayEffect()
    {
        _effect.Play();
    }

    public void StopEffect()
    {
        _effect.Stop();
    }
}
