using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class PlayerTutor : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private MeshRenderer _meshRenderer;
 
    private int _numberTargetTutor = 0;


    private void Update()
    {

        Vector3 diration = _targets[_numberTargetTutor].position - transform.position;
        transform.LookAt(_targets[_numberTargetTutor], Vector3.up);
        Ray ray = new Ray(_player.position, diration);
        Physics.Raycast(ray);
        Vector3 pointTutor = ray.GetPoint(0.7f);
        transform.position = pointTutor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _targets[_numberTargetTutor])
        {
            _meshRenderer.enabled = false;
            _numberTargetTutor++;
            if (_numberTargetTutor >= _targets.Count)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ActiveMeshTutor()
    {
        _meshRenderer.enabled = true;
    }
}
