using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0f;
    private Vector2 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
