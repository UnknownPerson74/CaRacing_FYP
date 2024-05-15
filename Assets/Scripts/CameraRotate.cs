using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform pivotTransform; // The pivot transform
    public float rotationSpeed = 100f; // The rotation speed of the camera
    public float minRotation = -45f; // The minimum rotation angle
    public float maxRotation = 45f; // The maximum rotation angle

    private Vector2 touchStartPos; // The position of the touch start
    private Vector2 touchCurrentPos; // The position of the current touch

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check the phase of the touch
            if (touch.phase == TouchPhase.Began)
            {
                // Save the position of the touch start
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Save the position of the current touch
                touchCurrentPos = touch.position;

                // Calculate the rotation angle
                float rotationAngle = (touchCurrentPos.x - touchStartPos.x) * rotationSpeed * 0.01f;

                // Clamp the rotation angle to the minimum and maximum angles
                rotationAngle = Mathf.Clamp(rotationAngle, minRotation, maxRotation);

                // Rotate the camera around the pivot point
                transform.RotateAround(pivotTransform.position, Vector3.up, rotationAngle);

                // Reset the touch start position
                touchStartPos = touchCurrentPos;
            }
        }
    }
}