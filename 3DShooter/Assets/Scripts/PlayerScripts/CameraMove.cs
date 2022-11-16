using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private int _rightFingerTouched;
    private float _detectableTouch;
    private Vector2 _lookInput;
    private float _cameraBorder;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _weaponCameraTransform;
    [SerializeField] private float _detectablePersentage;
    [SerializeField] private float _cameraSensitivity;
    [SerializeField] private float _topBorder=90f;
    [SerializeField] private float _botBorder = -90f;

    private void Start()
    {
        _rightFingerTouched = -1;
        _detectableTouch = Screen.width * _detectablePersentage;
    }

    private void Update()
    {
        IsTouched();
        CameraControl();
    }

   

    private void IsTouched()
    {
        for(int i = 0; i<Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if(touch.position.x>_detectableTouch && _rightFingerTouched == -1)
                    {
                        _rightFingerTouched = touch.fingerId;
                    }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (touch.fingerId == _rightFingerTouched)
                    {
                        _rightFingerTouched = -1;
                    }
                    break;
                case TouchPhase.Moved:
                    if (touch.fingerId == _rightFingerTouched)
                    {
                        _lookInput = touch.deltaPosition * _cameraSensitivity * Time.deltaTime;
                    }
                    break;
                case TouchPhase.Stationary:
                    if (touch.fingerId == _rightFingerTouched)
                    {
                        _lookInput = Vector2.zero;
                    }
                    break;
            }
        }
    }

    private void CameraControl()
    {
        _cameraBorder = Mathf.Clamp(_cameraBorder - _lookInput.y, _botBorder, _topBorder);
        _cameraTransform.localRotation = Quaternion.Euler(_cameraBorder, 0, 0);
        _weaponCameraTransform.localRotation = Quaternion.Euler(_cameraBorder, 0, 0);
        transform.Rotate(transform.up, _lookInput.x);
    }
}
