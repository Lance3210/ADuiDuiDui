using UnityEngine;

public class CameraView : MonoBehaviour
{

    private bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;
    private float currentDistance;
    private float desiredDistance;
    public float xRange = 10.0f;
    public float yRange = 10.0f;


    void Start()
    {

    }
    void Update()
    {
        Move();

    }

    void Move()
    {

        if (Input.GetMouseButtonDown(1))
        {
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
        }
        if (isMouseDown)
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
                this.transform.position -= offset;
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

    }
}
