using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider), typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private ObjectPlayer _patPlayer;

    private const string Speed = "Speed";
    private const string WhithPat = "WhithPat";

    private void OnEnable()
    {
        _patPlayer.TookObject += RunWhithObject;
        _patPlayer.GivingObject += RunWithoutObject;
    }

    private void OnDisable()
    {
        _patPlayer.TookObject -= RunWhithObject;
        _patPlayer.GivingObject -= RunWithoutObject;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_fixedJoystick.Horizontal * _speed, _rigidbody.velocity.y, _fixedJoystick.Vertical * _speed);

        if (_fixedJoystick.Horizontal != 0 || _fixedJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetFloat(Speed, _speed);
        }
        else
        {
            _animator.SetFloat(Speed, 0);
        }
    }

    public void RunWhithObject()
    {
        _animator.SetBool(WhithPat, true);
    }

    public void RunWithoutObject()
    {
        _animator.SetBool(WhithPat, false);
    }

    public void SetWeintLayer(float weight)
    {
        _animator.SetLayerWeight(1, weight);
    }
}
