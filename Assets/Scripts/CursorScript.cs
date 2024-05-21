using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] float minVelocity = 0.001f;

    Vector2 previousPos;
    CircleCollider2D circleCollider;
    Rigidbody2D cursorRigidbody;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cursorRigidbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Cutting();
    }

    private void Cutting()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        cursorRigidbody.position = newPos;
        float velocity = (newPos - previousPos).magnitude * Time.deltaTime;
       // Debug.Log(velocity);
        if (velocity > minVelocity)
        {
            circleCollider.enabled = true;
        } else
        {
            circleCollider.enabled = false;
        }
        previousPos = newPos;
    }
}
