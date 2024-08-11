using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float amplitude = 0.5f; 
    public float frequency = 1f; 

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
     
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = new Vector3(startPos.x, startPos.y + yOffset, startPos.z);
    }
}
