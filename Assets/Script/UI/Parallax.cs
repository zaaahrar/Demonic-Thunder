using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _currentOffset;
    private float _imagePositionX;

    private float _maxOffset = 30;
    private float _minOffset = -30;

    private void Start()
    {
        _image = GetComponent<RawImage>();  
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _currentOffset += horizontalInput * _speed * Time.deltaTime;

        if (_currentOffset < _minOffset)
        {
            _currentOffset = 0;
        }
        else if (_currentOffset > _maxOffset)
        {
            _currentOffset = 1;
        }

        _image.uvRect = new Rect(_currentOffset, 0, 1, 1);
    }
}
