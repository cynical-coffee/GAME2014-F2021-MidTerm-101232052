/********************* Background Controller **********************************
    Name: Meghan Paris
    Student#: 1010232052
    Date Modified: 2021-10-20
    File: BackgroundController.cs
    Description: Controller script for scrolling background.
    Revision History: Changed background to scroll along x-axis for landscape orientation.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    //** Resets along the x-axis. **//
    private void _Reset()
    {
        transform.position = new Vector3(verticalBoundary, 0.0f);
    }

    //** Altered Move() to have background scroll along the x axis. **//
    private void _Move()
    {
        transform.position -= new Vector3(verticalSpeed, 0.0f) * Time.deltaTime;
    }

    //** Altered CheckBounds() to check if moved beyond bounds on x-axis **//
    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -verticalBoundary)
        {
            _Reset();
        }
    }
}
