using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Ite,")]
public class Item : ScriptableObject
{
    public string name;
    public bool stackable;
    public Sprite icon;
}
