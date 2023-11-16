using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool _isCamera;

    private float _missingHeightCamera = 1.5f;

    private void Update()
    {
        if(_isCamera)
            transform.position = new Vector3(_target.position.x, _target.position.y + _missingHeightCamera, transform.position.z);
        else
            transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
    }
}
