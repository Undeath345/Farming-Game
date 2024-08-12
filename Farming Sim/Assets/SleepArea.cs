using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Sleep sleep = other.GetComponent<Sleep>();
        if (sleep != null)
        {
            sleep.DoSleep();
        }
    }
}
