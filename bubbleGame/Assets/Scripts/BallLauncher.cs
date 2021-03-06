using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameManager gameManager;
    [SerializeField] PauseMenu pauseMenu;

    private Camera mainCamera;  
    private Vector3 startDragPosition;
    private Vector3 endDragPosition;
    private LaunchPreview launchPreview;


    private GameObject ball;
    private SpriteRenderer spriteRenderer;
    private Color randomColor;

    private void Awake()
    {
        launchPreview = GetComponent<LaunchPreview>();    
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        ResetColor();
    }
    void ResetColor()
    {
        randomColor = gameManager.getRandomColor();
        spriteRenderer.color = randomColor;
    }
    void Update()
    {
        if (!pauseMenu.IsGamePaused())
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
    }

    private void spawnBall()
    {
        ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Ball>().SetColor(randomColor);
        ResetColor();
        ball.GetComponent<Ball>().fromKnob = true;
    }
    private void EndDrag()
    {
        Vector3 direction = (endDragPosition - startDragPosition).normalized;
        if (direction != Vector3.zero)
        {
            spawnBall();
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);
        }
            launchPreview.HideLine();
        
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
