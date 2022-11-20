using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToCross : MonoBehaviour
{
    [SerializeField] private Transform _bulletStartPoint;
    private Vector3 directionWithSpread;
   public void RaycastToCrosshair(Vector3 direction)
    {
        Ray _findCenter = new Ray(transform.position, transform.forward);
        RaycastHit _hit;
        Vector3 targetPoint;

        if (Physics.Raycast(_findCenter, out _hit))
        {
            targetPoint = _hit.point;

        }
        else
        {
            targetPoint = _hit.point;
        }


        directionWithSpread = targetPoint - _bulletStartPoint.position;
        Debug.Log(directionWithSpread.normalized);
        direction = directionWithSpread;


    }
}
