using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RubberBand : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform bird;
    private const int Size = 2;
    private const int StatrPoint = 0;
    private const int EndPoint = 1;
    
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = Size;
        lineRenderer.SetPosition(StatrPoint, transform.position);

    }
    void Update()
    {
        lineRenderer.SetPosition(EndPoint, bird.position);
    }
}
