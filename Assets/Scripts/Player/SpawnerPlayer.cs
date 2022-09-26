using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _josticAnimation;
    [SerializeField] private GameObject _jostic;
    [SerializeField] private Animator _animator;

    private const string _out = "Out";
    private const string _activePlayer = "ActivePlayer";

    public void ActiveTimerSpawner()
    {
        Invoke(_activePlayer, 0.7f);
    }

    private void ActiveJostic()
    {
        _josticAnimation.SetActive(true);
        _animator.SetBool(_out, true);
    }

    private void ActivePlayer()
    {
        _player.ActivePlayer();
        ActiveJostic();
    }

}
