using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayChack : MonoBehaviour
{
    public Transform pointer;

    private void Update()
    {
        /*Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward*1000f, Color.yellow);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            pointer.position = hit.point;
            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
        }*/
    }
}
