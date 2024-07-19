using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{
    public virtual bool OnApply(Vector2 WorldPoint)
    {
        Debug.LogWarning("On Apply is  not implemented");
        return true;
    }
}
