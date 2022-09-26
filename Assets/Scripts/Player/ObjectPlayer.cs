using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPlayer : MonoBehaviour
{
    [SerializeField] private List<Transform> _objectPlaces;
    [SerializeField] private GameObject _buttonGive;
    [SerializeField] private Transform _parent;
    [SerializeField] private Bed _bed;

    private Pat _pat;
    private GameObject _object;
    private bool _emptyHands;

    public event UnityAction TookObject;
    public event UnityAction GivingObject;
    public int CountPlacesPlayer => _objectPlaces.Count;

    private void OnEnable()
    {
        _emptyHands = true;
        _bed.DestroySoap += DeleteObject;
    }

    private void OnDisable()
    {
        _bed.DestroySoap -= DeleteObject;
    }

    public void TakeObject(GameObject Object, int numberPlace = 0)
    {
        _object = Object;
        if (_object.TryGetComponent<Pat>(out _pat))
        {
            _pat.SetAnimationTake();
        }
        _object.transform.SetParent(_objectPlaces[numberPlace]);
        _object.transform.position = _objectPlaces[numberPlace].position;
        _object.transform.rotation = _objectPlaces[numberPlace].rotation;
        _emptyHands = false;
        _buttonGive.SetActive(true);
        TookObject?.Invoke();
    }

    public void GiveOdject(Transform parent, Transform positonObject)
    {
        if (_object.TryGetComponent<Pat>(out _pat))
        {
            _pat.SetAnimationTake();
        }
        _object.transform.SetParent(parent);
        _object.transform.position = positonObject.position;
        _object.transform.rotation = positonObject.rotation;
        _object.transform.localScale = positonObject.localScale;
        _emptyHands = true;
        GivingObject?.Invoke();
        _buttonGive.SetActive(false);
    }

    public void DeleteObject()
    {
        Destroy(_object);
        GivingObject?.Invoke();
    }
}
