using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _castle;
    [SerializeField] private LoadingBox _loadingBox;
    [SerializeField] private GameObject _objectCreat;
    [SerializeField] private ObjectPlayer _objectPlayer;
    [SerializeField] private Bed _bed;
    [SerializeField] private PlayerTutor _playerTutor;

    private bool _unbloking;
    private int _parentPlacesNum = 0;
    private bool _close;
    private bool _created;
    private const string Close = "Close";

    private void OnEnable()
    {
        _unbloking = false;
        _created = true;
        _close = true;
        _animator.SetBool(Close, _close);
        _bed.UnblockedBox += Unbloking;
        _loadingBox.LoadedBarBox += CreatObject;
    }

    private void OnDisable()
    {
        _bed.UnblockedBox -= Unbloking;
        _loadingBox.LoadedBarBox -= CreatObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ObjectPlayer>(out ObjectPlayer objectPlayer) && _unbloking)
        {
            OpenBox();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<ObjectPlayer>(out ObjectPlayer objectPlayer) && _unbloking)
        {
            if (_created && _objectPlayer.CountPlacesPlayer > _parentPlacesNum)
            {
                _loadingBox.StartCreat();
                _created = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ObjectPlayer>(out ObjectPlayer objectPlayer) && _unbloking)
        {
            CloseBox();
            _loadingBox.StopCreat();
        }
    }

    private void Unbloking(bool unbloking)
    {
        _unbloking = unbloking;
        _castle.SetActive(false);
    }

    private void OpenBox()
    {
        _close = false;
        _animator.SetBool(Close, _close);
    }

    private void CloseBox()
    {
        _close = true;
        _animator.SetBool(Close, _close);
    }

    private void CreatObject()
    {
        var Object = Instantiate(_objectCreat);
        _objectPlayer.TakeObject(Object, _parentPlacesNum);
        _parentPlacesNum++;
        _loadingBox.StopCreat();
        _created = true;
        _playerTutor.ActiveMeshTutor();
    }
}
