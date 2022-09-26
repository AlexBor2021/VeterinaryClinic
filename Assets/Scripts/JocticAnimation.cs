using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JocticAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _jostic;

    public void ActiveJostic()
    {
        _jostic.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
