/*********************Bullet Controller***********************************
    Name: Meghan Paris
    Student#: 1010232052
    Date Modified: 2021-10-20
    File: EnemyController.cs
    Description: Controller script for enemy objects.
    Revision History: Changed enemy movement to move along y-axis.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float verticalSpeed; //** Previously horizontalSpeed **//
    public float verticalBoundary; //** Previously verticalBoundary **//
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
