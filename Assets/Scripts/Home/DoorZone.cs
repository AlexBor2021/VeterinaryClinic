using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorZone : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private Player _player;
    private const string Open = "Open";


    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Player>(out _player) || other.TryGetComponent<Client>(out Client client))
        {
            _animator.SetBool(Open, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out _player) || other.TryGetComponent<Client>(out Client client))
        {
            _animator.SetBool(Open, false);
        }
    }
}
