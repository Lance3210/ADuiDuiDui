using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{

    public Transform target;
    public float smoothTime = 0.01f;
    private Vector3 cameraVelocity = Vector3.zero;
    private Camera mainCamera;
    private bool shouldMove = false;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shouldMove = true;
        }
        if (target.position.x == transform.position.x && target.position.y == transform.position.y)
        {
            shouldMove = false;
        }
        if (shouldMove)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + new Vector3(0, 0, -5), ref cameraVelocity, smoothTime);
        }

    }

}