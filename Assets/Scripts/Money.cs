using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string _getMoney = "GetMoney";

    public void GetMoney()
    {
        _animator.SetBool(_getMoney, true);
    }
}
