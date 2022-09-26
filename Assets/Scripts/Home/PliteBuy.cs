using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class PliteBuy : MonoBehaviour
{
    [SerializeField] private  int _money;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private GameObject _furniture;
    [SerializeField] private Effect _confeti;
    [SerializeField] private Effect _moneyEffect;
    [SerializeField] private GameObject _client;
    [SerializeField] private PlayerTutor _playerTutor;

    private const string _activateClient = "ActivateClient";
    private float _delay = 35f;
    private float _timer = 0;

    public event UnityAction GonePlayer;

    private void OnEnable()
    {
        _moneyText.text = _money.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _timer++;
            
            _moneyEffect.PlayEffect();
           
            if (_delay < _timer)
            {
                StartCoroutine(MoneyLess());
                Invoke(_activateClient, 2f);
            }
        }
    }

    public IEnumerator MoneyLess()
    {
        while (_money > 0)
        {
            _money -= 1;
            _moneyText.text = _money.ToString();
            yield return new WaitForSeconds(0.3f);
        }
        GonePlayer?.Invoke();
        _furniture.SetActive(true);
        _moneyEffect.StopEffect();
        _confeti.PlayEffect();
        StopCoroutine(MoneyLess());
        gameObject.SetActive(false);
    }

    private void ActivateClient()
    {
        _client.SetActive(true);
        _playerTutor.ActiveMeshTutor();
    }

}
