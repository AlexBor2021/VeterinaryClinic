using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bed : MonoBehaviour
{
    [SerializeField] private Transform _positionPat;
    [SerializeField] private CameraBox _cameraBox;
    [SerializeField] private Button  _givingButton;
    [SerializeField] private GameObject _soapImage;
    [SerializeField] private PlayerTutor _playerTutor;
    [SerializeField] private Money _money;
    [SerializeField] private GameObject _joistic;

    private const string _givePlayer = "GivePlayer";
    private const string _onJoistic = "OnJoistic";
    private ObjectPlayer _objectPlayer;
    private bool _nearBed;
    private bool _soapIS;
    private bool _cameraOn = true;
    private Pat _pat;
    private const string _cleenPat = "CleenPat";

    public event UnityAction<bool> UnblockedBox;
    public event UnityAction DestroySoap;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<ObjectPlayer>(out _objectPlayer))
        {
            _nearBed = true;
        }
        if (other.TryGetComponent<Soap>(out Soap soap))
        {
            _soapIS = true;
            Invoke(_cleenPat, 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ObjectPlayer>(out _objectPlayer))
        {
            _nearBed = false;
            _soapIS = false;
        }
    }

    public void GivePlayer()
    {
        if (_nearBed && _soapIS == false)
        {
            _objectPlayer.GiveOdject(gameObject.transform, _positionPat);
            _pat = transform.parent.GetComponentInChildren<Pat>();
            _pat.SetAnimationSit();
            _soapImage.SetActive(true);
        }
        if (_cameraOn && _nearBed)
        {
            UnblockedBox?.Invoke(true);
            _cameraBox.OnCamera();
            _joistic.SetActive(false);
            _cameraOn = false;
            _playerTutor.ActiveMeshTutor();
            Invoke(_onJoistic, 6);
        }
    }

    public void OnJoistic()
    {
        _joistic.SetActive(true);
    }

    private void CleenPat()
    {
        if (_soapIS)
        {
            _pat.Clear();
            _pat.SetAnimationGo();
            _soapIS = false;
        }
        _soapImage.SetActive(false);
        DestroySoap?.Invoke();
        _money.GetMoney();
    }
}
