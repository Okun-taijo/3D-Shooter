using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private UnityEvent _activated;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerMovement playersoldier))   
        {
            Activate(playersoldier.gameObject);
            _activated.Invoke();
            gameObject.SetActive(false);
        }
    }

    protected virtual void Activate(GameObject player)
    {

    }
}
