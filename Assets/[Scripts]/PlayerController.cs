/********************* Player Controller ***********************************
    Name: Meghan Paris
    Student#: 1010232052
    Date Modified: 2021-10-19
    File: PlayerController.cs
    Description: Controller script for player behaviour.
    Revision History: Changed player to move in a fixed space along the y-axis.
***************************************************************************/
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    //** Changed some variable names to better reflect new player movement. **//
    [Header("Boundary Check")]
    public float verticalBoundary; //**" Previously verticalBoundary. **//

    [Header("Player Speed")]
    public float verticalSpeed; //**" Previously verticalSpeed. **//
    public float maxSpeed;
    public float verticalTValue; //**" Previously horizontalTValue. **//

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

     private void _FireBullet()
    {
        // delay bullet firing 
        if (Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

     //** Altered touch and keyboard input in Move() so player move along the y-axis. **//
    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Vertical") >= 0.1f) 
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.y != 0.0f)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, verticalTValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * verticalSpeed);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    //** Altered bounds to keep player within view on the y-axis. **//
    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.y >= verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f);
        }

        // check left bounds
        if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f);
        }

    }
}
