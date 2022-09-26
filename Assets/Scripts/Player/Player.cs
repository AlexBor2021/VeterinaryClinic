using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Effect _effectSpawner;
    [SerializeField] private ParticleSystem _effectStep;
    [SerializeField] private ParticleSystem _effectStepTwo;
     

    public void ActivePlayer()
    {
        gameObject.SetActive(true);
    }
    
    public void ActiveEffect()
    {
        _effectSpawner.PlayEffect();
    }

    public void OnStepEffect()
    {
        _effectStep.Play();
    }

    public void OnStepEffectTwo()
    {
        _effectStep.Play();
    }
}
