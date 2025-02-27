using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable] 
public class Stat
{
    public int maxVal;
    public int currVal;
    public Stat(int curr, int max)
    {
        maxVal = max;
        currVal = curr;
    }
    internal void Subtract(int amount)
    {
        currVal -= amount;
    }
    internal void Add(int amount)
    {
        currVal += amount;
        if (currVal > maxVal) { currVal = maxVal; }

    }
    internal void SetToMax()
    {
        currVal = maxVal;
    }
}
public class Character : MonoBehaviour
{
    public Stat stamina;
    [SerializeField] StatusBar staminaBar;
    public bool isExhausted;

    private void Start()
    {
        UpdateStaminaBar();
    }
    private void UpdateStaminaBar()
    {
        staminaBar.Set(stamina.currVal, stamina.maxVal);
    }
    public void GetTired(int amount)
    {
        stamina.Subtract(amount);
        if (stamina.currVal < 0)
        {
            isExhausted = true;
        }
        UpdateStaminaBar();

    }
    public void Rest(int amount)
    {
        stamina.Add(amount);
        UpdateStaminaBar();

    }
    public void FullRest(int amount)
    {
        stamina.SetToMax();
        UpdateStaminaBar();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            GetTired(10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Rest(10);
        }
    }
}
