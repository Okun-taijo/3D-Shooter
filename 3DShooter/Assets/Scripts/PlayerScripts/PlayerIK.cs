using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIK : MonoBehaviour
{
    [SerializeField] private Animator _inverceKinematicAnimator;
    public PlayerMovement playerMovement;
    public WeaponInventory weaponInventory;
    [SerializeField] private Transform _targetLook;
    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _leftHandTarget;
    [SerializeField] private Transform _rightHand;

    [SerializeField] private Quaternion _leftHandRotation;

    [SerializeField] private float _rightHandWeight;

     private Transform _shoulder;
     private Transform _aimPivot;
    void Start()
    {
        _shoulder = _inverceKinematicAnimator.GetBoneTransform(HumanBodyBones.RightShoulder).transform;

        _aimPivot = new GameObject().transform;
        _aimPivot.name = "aim pivot";
        _aimPivot.transform.parent = transform;

        _rightHand = new GameObject().transform;
        _rightHand.name = "right hand";
        _rightHand.transform.parent = _aimPivot;

        _leftHand = new GameObject().transform;
        _leftHand.name = "left hand";
        _leftHand.transform.parent = _aimPivot;

        _rightHand.localPosition = weaponInventory._firstWeapon._rightHandPosition;
        Quaternion _rightHandRotation = Quaternion.Euler(weaponInventory._firstWeapon._rightHandPosition);
        _rightHand.localRotation = _rightHandRotation;
    }

    // Update is called once per frame
    void Update()
    {
        _leftHandRotation = _leftHandTarget.rotation;
        _leftHand.position = _leftHandTarget.position;
        _leftHand.rotation = _leftHandRotation;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        _aimPivot.position = _shoulder.position;
        _inverceKinematicAnimator.SetLookAtWeight(.9f, .9f, .9f, .9f);
        _inverceKinematicAnimator.SetLookAtPosition(_targetLook.position);
    }
}
