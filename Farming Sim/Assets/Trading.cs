using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trading : MonoBehaviour
{
    Store store;

    public void BeginTrading(Store store)
    {
        this.store = store;
        Debug.Log("Begin trading");
    }
}
