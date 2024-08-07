using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfiner : MonoBehaviour
{
    [SerializeField] CinemachineConfiner confiner;
    
    void Start()
    {
        UpdateBounds();
    }

    public void UpdateBounds()
    {
        Collider2D bounds = GameObject.Find("CameraConfiner").GetComponent<Collider2D>();
        confiner.m_BoundingShape2D = bounds;
    }

}
