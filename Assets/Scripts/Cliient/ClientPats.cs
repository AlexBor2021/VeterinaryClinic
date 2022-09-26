using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class ClientPats : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pats;
    [SerializeField] private Transform _patPosition;
    [SerializeField] private Client _client;
    [SerializeField] private LoadingClient _loading;
    [SerializeField] private PlayerTutor _playerTutor;

    private GameObject _pat;
    private int _numberPat;
    private ObjectPlayer _objectPlayer;

    private void OnEnable()
    {
        _loading.LoadedBarClient += GivePat;
    }

    private void OnDisable()
    {
        _loading.LoadedBarClient -= GivePat;
    }

    private void Start()
    {
        _numberPat = Random.Range(0, _pats.Count);
        _pat = Instantiate(_pats[_numberPat], _patPosition.position, _patPosition.rotation);
        _pat.transform.SetParent(_patPosition.transform);
        _pat.transform.localScale = _patPosition.transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ObjectPlayer>(out _objectPlayer))
        {
            _loading.StartTransfer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player Player))
        {
            _loading.StopTransfer();
        }
    }

    public void GivePat()
    {
        _objectPlayer.TakeObject(_pat);
        _client.SetNumber();
        _playerTutor.ActiveMeshTutor();
    }
}
