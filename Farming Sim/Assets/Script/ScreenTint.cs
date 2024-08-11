using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Xml.Serialization;

public class ScreenTint : MonoBehaviour
{
    [SerializeField] Color untintedColor;
    [SerializeField] Color tintedColor;
    float f;
    public float speed = 0.5f;

    UnityEngine.UI.Image image;

    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    public void Tint()
    {
        StopAllCoroutines();
        f = 0f;
        StartCoroutine(TintScreen());
    }

    public void UnTint()
    {
        StopAllCoroutines();
        f = 0f;
        StartCoroutine (UnTintScreen());
    }

    private IEnumerator TintScreen()
    {
        while ( f <1f)
        {
            f += Time.deltaTime * speed;
            f = Mathf.Clamp(f, 0, 1f);
            Color c = image.color;
            c = Color.Lerp(untintedColor, tintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator UnTintScreen()
    {
        while (f < 1f)
        {
            f += Time.deltaTime * speed;
            f = Mathf.Clamp(f, 0, 1f);
            Color c = image.color;
            c = Color.Lerp(tintedColor,untintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
    }
}
