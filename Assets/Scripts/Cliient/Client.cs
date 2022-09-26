using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private ObjectPlayer _patPlayer;
    [SerializeField] private GameObject _camera;

    private Vector3 _direction;
    private int _pointNumber;
    private int _step;
    private float _distance => 0.1f;
    private const string Walk = "Walk";
    private const string Pat = "Pat";

    private void OnEnable()
    {
        _pointNumber = 0;
        _step = 1;
        _camera.SetActive(true);
    }

    private void Update()
    {
        Move();
        Rotation();
    }

    public void SetNumber()
    {
        _pointNumber = 2;
        _step = -1;
        _animator.SetBool(Pat, false);
    }

    private void Move()
    {
        if (_pointNumber < _points.Count && _pointNumber >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_pointNumber].transform.position, _speed * Time.deltaTime);
            _animator.SetBool(Walk, true);

            if (Vector3.Distance(transform.position, _points[_pointNumber].transform.position) < _distance && _pointNumber <= _points.Count)
            {
                _pointNumber += _step;

                if (_pointNumber < 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        else
        {
            _animator.SetBool(Walk, false);
        }
    }

    private void Rotation()
    {
        if (_pointNumber < _points.Count && _pointNumber >= 0)
        {
            _direction = _points[_pointNumber].transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
        }
    }
}
