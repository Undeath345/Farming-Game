using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPersistants
{
    public string Read();
    public void Load(string jsonString);


}
