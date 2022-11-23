using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillsCounVizualizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _killsText;
    public void VisualValue(int value)
    {
        _killsText.text = value.ToString() + " Kills";
    }
}
