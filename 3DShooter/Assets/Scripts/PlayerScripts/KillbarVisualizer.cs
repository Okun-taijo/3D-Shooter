using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillbarVisualizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _killbarText;

    public void VisualBar(string name)
    {
        _killbarText.text = "LAST KILLED ENEMY: "+name;
    }
}
