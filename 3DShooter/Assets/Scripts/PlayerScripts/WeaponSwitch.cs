using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private int weaponNumber = 0;

    public void Start()
    {
        SelectWeapon();
    }

    public void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapons in transform)
        {
            if (i == weaponNumber)
            {
                weapons.gameObject.SetActive(true);
            }
            else
            {
                weapons.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void UpNumber()
    {
        if (weaponNumber >= transform.childCount - 1)
        {
            weaponNumber = 0;
            SelectWeapon();
        }
        else
        {
            weaponNumber++;
        }
    }
}
