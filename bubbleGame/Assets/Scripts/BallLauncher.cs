using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] 
    GameObject ballPrefab;

    private Camera mainCamera;  
    private Vector3 startDragPosition;
    private Vector3 endDragPosition;
    private LaunchPreview launchPreview;

    private void Awake()
    {
        launchPreview = GetComponent<LaunchPreview>();
    }
    // Start is called before the first frame update
    void Start()
    {
         mainCamera= Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void EndDrag()
    {
        Vector3 direction = (endDragPosition - startDragPosition).normalized;
        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(-direction);
        
    }
    private void ContinueDrag(Vector3 worldPosition)
    {
        endDragPosition = worldPosition;

        Vector3 direction = endDragPosition - startDragPosition;
        launchPreview.SetEndPoint(transform.position-direction);

    }

    private void StartDrag(Vector3 worldPosition)
    {
        startDragPosition = worldPosition;
        launchPreview.SetStartPoint(transform.position);
    }
}
