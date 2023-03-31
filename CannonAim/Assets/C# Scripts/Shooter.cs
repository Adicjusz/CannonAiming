using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{[Range(100,1000)]
    public float shootForce;
    public GameObject bombPrefab;
    [SerializeField] private LineRenderer lineRenderer;
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
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void DrawProjection()
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt(linepoints / timebetweenPoints) + 1;
        Vector3 startPosition = ReleasePosition.position;
        Vector3 startVelocity = shootForce * transform.forward / bombPrefab.GetComponent<Rigidbody>().mass;
        int i = 0;
        lineRenderer.SetPosition(i, startPosition);
        for (float time = 0; time < linepoints; time += timebetweenPoints)
        {
            i++;
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);
            lineRenderer.SetPosition(i, point);
        }
    }
    public void Shoot()
    {
        GameObject bomb =Instantiate(bombPrefab, transform.position, transform.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce);
    }
}
