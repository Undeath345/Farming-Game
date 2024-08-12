using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    internal void DoSleep()
    {
        Debug.Log("I'm sleeping");
        StartCoroutine(SleepRoutine());
    }
    IEnumerator SleepRoutine()
    {
        ScreenTint screenTint = GameManager.Instance.screenTint;
        screenTint.Tint();

        yield return new WaitForSeconds(2f);

        screenTint.UnTint();

        yield return new WaitForSeconds(2f);

        yield return null;

    }

}
