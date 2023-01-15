using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public Camera cam;

    public Ball ball;
    public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;
    int numberOfClicks = 0;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        ball.DeactivateRb();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && numberOfClicks < 1)
        {
            isDragging = true;
            OnDragStart();
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0) && numberOfClicks < 1)
        {
            isDragging = false;
            numberOfClicks += 1;
            OnDragStop();
        }

        if(isDragging)
        {
            OnDrag();
        }
    }

    void OnDragStart()
    {
        ball.DeactivateRb();
        var x = Input.mousePosition.x - 960f;
        var y = Input.mousePosition.y - 540f;
        startPoint.x = x;
        startPoint.y = y;
        trajectory.Show();
    }

    void OnDrag()
    {
        var x = Input.mousePosition.x - 960f;
        var y = Input.mousePosition.y - 540f;
        endPoint.x = x;
        endPoint.y = y;
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;
        
        Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(ball.pos, force);
    }

    void OnDragStop()
    {
        ball.ActivateRb();
        ball.Push(force);
        trajectory.Hide();
    }
}
