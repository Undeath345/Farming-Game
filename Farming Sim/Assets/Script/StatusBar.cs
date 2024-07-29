using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Slider staminabar;
    public void Set(int curr,int max )
    {
        staminabar.maxValue = max;
        staminabar.value = curr;

    }
}
