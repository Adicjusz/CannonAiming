using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPrediction : MonoBehaviour
{[SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform ReleasePosition;
    public int linepoints;
    [Range(0.1f, 0.25f)]
    public float timebetweenPoints = 0.1f;

        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawProjection();
    }
    void DrawProjection()
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt(linepoints / timebetweenPoints)+ 1;
    }
}
