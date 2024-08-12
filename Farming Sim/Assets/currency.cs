using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currency : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] TMPro.TextMeshProUGUI text;

    private void Start()
    {
        amount = 1000;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = amount.ToString();
    }
}
